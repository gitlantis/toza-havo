using DeviceMonnitorAPI.DBModels;
using DeviceMonnitorAPI.Models;
using DeviceMonnitorAPI.Services.Interfaces;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Caching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.Services
{
    public class DeviceDataService
    {
        private readonly MyDBContext _myDbContext;
        private readonly DeviceService _deviceService;
        private readonly IRedisCacheService _redisCacheService;

        private readonly IFirebaseConfig fbc = new FirebaseConfig()
        {
            AuthSecret = Constants.FirebaseSecret,
            BasePath = Constants.FirebaseUrl
        };
        private IFirebaseClient client;

        public DeviceDataService(MyDBContext myDbContext, DeviceService deviceService, IRedisCacheService redisCacheService)
        {
            _myDbContext = myDbContext;
            _deviceService = deviceService;
            _redisCacheService = redisCacheService;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public async Task<Guid?> AddData(DeviceRawData model)
        //{
        //    try
        //    {
        //        var dev = await _deviceService.GetDeviceByGuid(model.DeviceGUID);
        //        if (dev == null)
        //        {
        //            var devModel = new Device();
        //            devModel.DeviceGuid = model.DeviceGUID;
        //            devModel.Name = model.DeviceGUID.ToString();
        //            devModel.Description = model.DeviceGUID.ToString();
        //            devModel.IsActive = true;

        //            var result = await _deviceService.AddDevice(devModel);

        //            dev.DeviceGuid = result.DeviceGuid;
        //            dev.Name = result.Name;
        //            dev.Description = result.Description;
        //            dev.CreatedDate = result.CreatedDate;
        //            dev.EditedDate = result.EditedDate;

        //        }

        //        if (dev != null)
        //        {
        //            var guid = Guid.NewGuid();

        //            var data = new DeviceData();
        //            var dataAi = new List<DataAI>();
        //            var dataAo = new List<DataAO>();
        //            var dataDi = new List<DataDI>();
        //            var dataDo = new List<DataDO>();
        //            var dataMeta = new List<DataMEATADATA>();

        //            data.Id = guid;
        //            data.DeviceGuid = dev.DeviceGuid;
        //            data.CreatedDate = model.DataCreatedTime;
        //            data.EditedDate = DateTime.Now;
        //            await _myDbContext.AddRangeAsync(data);

        //            for (int i = 0; i < model.tData.AI.Count(); i++)
        //            {
        //                dataAi.Add(new DataAI
        //                {
        //                    DataGuid = data.Id,
        //                    Param = model.tData.AI[i],
        //                    CreatedDate = DateTime.Now
        //                });
        //            }
        //            await _myDbContext.AddRangeAsync(dataAi);

        //            for (int i = 0; i < model.tData.AO.Count(); i++)
        //            {
        //                dataAo.Add(new DataAO
        //                {
        //                    DataGuid = data.Id,
        //                    Param = model.tData.AO[i],
        //                    CreatedDate = DateTime.Now
        //                });
        //            }
        //            await _myDbContext.AddRangeAsync(dataAo);

        //            for (int i = 0; i < model.tData.DI.Count(); i++)
        //            {
        //                dataDi.Add(new DataDI
        //                {
        //                    DataGuid = data.Id,
        //                    Param = model.tData.DI[i],
        //                    CreatedDate = DateTime.Now
        //                });
        //            }
        //            await _myDbContext.AddRangeAsync(dataDi);

        //            for (int i = 0; i < model.tData.DI.Count(); i++)
        //            {
        //                dataDo.Add(new DataDO
        //                {
        //                    DataGuid = data.Id,
        //                    Param = model.tData.DO[i],
        //                    CreatedDate = DateTime.Now
        //                });
        //            }
        //            await _myDbContext.AddRangeAsync(dataDo);

        //            for (int i = 0; i < model.tData.METADATA.Count(); i++)
        //            {
        //                dataMeta.Add(new DataMEATADATA
        //                {
        //                    DataGuid = data.Id,
        //                    Param = model.tData.METADATA[i],
        //                    CreatedDate = DateTime.Now
        //                });
        //            }

        //            await _myDbContext.AddRangeAsync(dataMeta);
        //            await _myDbContext.SaveChangesAsync();
        //            var device = new Device();
        //            device.DeviceGuid = dev.DeviceGuid;
        //            await this.SetCacheDynamicData(device);
        //            return data.Id;
        //        }
        //        return null;

        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public async Task<Guid?> DeleteData(Guid guid)
        {
            try
            {
                var data = _myDbContext.WeatherDeviceData.Where(c => c.Id == guid).FirstOrDefault();
                _myDbContext.WeatherDeviceData.Remove(data);
                await _myDbContext.SaveChangesAsync();
                return guid;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Guid?> DeleteDeviceData(Guid guid)
        {
            try
            {
                var dev = _myDbContext.WeatherDeviceData.Where(c => c.DeviceGuid == guid);
                _myDbContext.RemoveRange(dev);
                await _myDbContext.SaveChangesAsync();

                return guid;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<DeviceDynamicData>> GetCacheDynamicData(Guid? userGuid)
        {
            try
            {
                var dynData = new List<DeviceDynamicData>();
                var devices = await _deviceService.GetDevicesByUser(userGuid);

                foreach (var device in devices)
                {
                    var data = _redisCacheService.Get<DeviceDynamicData>(device.DeviceGuid);
                    if (data == null)
                    {
                        data = await this.SetCacheDynamicData(device);
                    }
                    dynData.Add(data);
                }
                return dynData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<List<ArchiveDataModel>> GetArchive(Guid userGuid, Guid guid, int itemCount, int page)
        {
            var archData = new List<ArchiveDataModel>();

            try
            {
                var device = await _myDbContext.Devices.Where(g => g.DeviceGuid == guid).FirstOrDefaultAsync();

                if (device != null)
                {
                    var params_ = await _myDbContext.ParamNames.Where(c => c.DeviceGuid == device.DeviceGuid).OrderBy(c => c.CreatedDate).ToListAsync();

                    var allData = _myDbContext.WeatherDeviceData.Where(c => c.DeviceGuid == guid).Count();
                    var _data = await _myDbContext.WeatherDeviceData.Where(c => c.DeviceGuid == guid).OrderByDescending(c => c.CreatedDate).Skip((page - 1) * itemCount).Take(itemCount).ToListAsync();

                    //page count
                    var pages = (decimal)allData / (decimal)itemCount;
                    var p = (pages * 10) % 10;
                    var pagesCount = p == 0 ? pages : ++pages;
                    var allPages = Convert.ToInt32(Math.Truncate(pagesCount));

                    foreach (var data in _data)
                    {
                        var rawDataAI = new List<ChildDataWithParam>();

                        var count = new int[5];

                        if (data != null)
                        {
                            rawDataAI = WeatherMass(data);
                            count[0] = rawDataAI.Count();
                        }

                        archData.Add(
                               new ArchiveDataModel
                               {
                                   DeviceGuid = device.DeviceGuid,
                                   Name = device.Name,
                                   PageNum = page,
                                   DataCount = allData,
                                   ItemCount = itemCount,
                                   PageCount = allPages,
                                   RowCount = count.Max(),
                                   CreatedDate = data.CreatedDate,
                                   AI = rawDataAI.OrderBy(c => c.ParamOrder).ToList(),
                               });
                    }
                }
                return archData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Guid> SetParams(ParamsModel model)
        {
            try
            {
                var oldParams = await _myDbContext.ParamNames.Where(c => c.DeviceGuid == model.DeviceGUID).ToListAsync();
                _myDbContext.RemoveRange(oldParams);

                var param = new List<ParamName>();

                foreach (var m in model.Params)
                {
                    param.Add(new ParamName
                    {
                        Id = Guid.NewGuid(),
                        DeviceGuid = model.DeviceGUID,
                        Name = m.Name,
                        NameDomain = m.NameDomain,
                        NameIndex = m.NameIndex,
                        OrderIndex = m.OrderIndex,
                        CreatedDate = DateTime.Now
                    });
                }

                await _myDbContext.AddRangeAsync(param);
                await _myDbContext.SaveChangesAsync();

                return param.FirstOrDefault().DeviceGuid;
            }
            catch (Exception)
            {

                return Guid.Empty;
            }
        }

        public async Task<ParamsModel> GetParams(Guid guid)
        {
            try
            {
                var params_ = await _myDbContext.ParamNames.Where(c => c.DeviceGuid == guid).ToListAsync();

                var param = new ParamsModel();

                param.DeviceGUID = params_.FirstOrDefault().DeviceGuid;
                var problemDetails = new List<SingleParamModel>();
                foreach (var p in params_)
                {
                    problemDetails.Add(new SingleParamModel
                    {
                        Name = p.Name,
                        NameDomain = p.NameDomain,
                        NameIndex = p.NameIndex,
                        OrderIndex = p.OrderIndex
                    });
                }

                param.Params = problemDetails.OrderBy(c=>c.OrderIndex).ToList();

                return param;
            }
            catch (Exception e)
            {

                return null;
            }

        }

        public List<ChildDataWithParam> GetChildData<T>(List<ParamName> params_, List<T> model)
        {
            var rawData = new List<ChildDataWithParam>();

            for (int i = 0; i < model.Count; i++)            
            {
                var indx = 0;
                var ord = 0;
                var name = "";
                var name_domain = "";
                try
                {
                    var idx = params_.ElementAt(i).NameIndex;
                    indx = idx>model.Count? model.Count : idx;
                    ord = params_.ElementAt(i).OrderIndex;
                    name = params_.ElementAt(i).Name;
                    name_domain = params_.ElementAt(i).NameDomain;
                }
                catch { }
                if (name != "")
                {
                    try
                    {
                        rawData.Add(new ChildDataWithParam
                        {
                            ParamIndex = indx,
                            ParamOrder = ord,
                            ParamName = name,
                            ParamSubDomain = name_domain.ToUpper(),
                            Params = model[indx]
                        });
                    }
                    catch { }
                }
            }
            return rawData;
        }

        private async Task<DeviceDynamicData> SetCacheDynamicData(Device device)
        {
            try
            {
                var dynData = new DeviceDynamicData();
                var wdata = new WeatherDeviceData();
                var params_ = await _myDbContext.ParamNames.Where(c => c.DeviceGuid == device.DeviceGuid).OrderBy(c => c.CreatedDate).ToListAsync();

                var data = await _myDbContext.WeatherDeviceData
                    .Where(c => c.DeviceGuid == device.DeviceGuid).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();

                var count = new int[5];

                var diffMins = 3;
                var lastDate = new DateTime();
                var rawDataAI = new List<ChildDataWithParam>();
                if (data != null)
                {
                    diffMins = Convert.ToInt32(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMinutes - TimeSpan.FromTicks(data.EditedDate.Ticks).TotalMinutes);

                    rawDataAI = WeatherMass(data);
                    count[0] = rawDataAI.Count();
                }

                dynData = new DeviceDynamicData
                    {
                        DeviceGuid = device.DeviceGuid,
                        Name = device.Name,
                        LastDataTime = lastDate,
                        IsWorking = (diffMins < Constants.diffMins && diffMins >= 0) ? true : false,
                        IsActive = device.IsActive,
                        RowCount = count.Max(),
                        AI = rawDataAI.OrderBy(c => c.ParamOrder).ToList(),
                    };

                _redisCacheService.Delete<DeviceDynamicData>(device.DeviceGuid);
                _redisCacheService.Set<DeviceDynamicData>(device.DeviceGuid, dynData);
                return dynData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static List<ChildDataWithParam>  WeatherMass(WeatherDeviceData data)
        {
            var rawDataAI = new List<ChildDataWithParam>();
            if (data.A00 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A00)).Name,
                    Params = data.A00
                });
            if (data.A01 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A01)).Name,
                    Params = data.A01
                });
            if (data.A02 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A02)).Name,
                    Params = data.A02
                });
            if (data.A03 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A03)).Name,
                    Params = data.A03
                });
            if (data.A04 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A04)).Name,
                    Params = data.A04
                });
            if (data.A05 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A05)).Name,
                    Params = data.A05
                });
            if (data.A06 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A06)).Name,
                    Params = data.A06
                });
            if (data.A07 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A07)).Name,
                    Params = data.A07
                });
            if (data.A08 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A08)).Name,
                    Params = data.A08
                });
            if (data.A09 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A09)).Name,
                    Params = data.A09
                });
            if (data.A10 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A10)).Name,
                    Params = data.A10
                });
            if (data.A11 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A11)).Name,
                    Params = data.A11
                });
            if (data.A12 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A12)).Name,
                    Params = data.A12
                });
            if (data.A13 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A13)).Name,
                    Params = data.A13
                });
            if (data.A14 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A14)).Name,
                    Params = data.A14
                });
            if (data.A15 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A15)).Name,
                    Params = data.A15
                });
            if (data.A16 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A16)).Name,
                    Params = data.A16
                });
            if (data.A17 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A17)).Name,
                    Params = data.A17
                });
            if (data.A18 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A18)).Name,
                    Params = data.A18
                });
            if (data.A19 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A19)).Name,
                    Params = data.A19
                });
            if (data.A20 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A20)).Name,
                    Params = data.A20
                });
            if (data.A21 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A21)).Name,
                    Params = data.A21
                });
            if (data.A22 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A22)).Name,
                    Params = data.A22
                });
            if (data.A23 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A23)).Name,
                    Params = data.A23
                });
            if (data.A24 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A24)).Name,
                    Params = data.A24
                });
            if (data.A25 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A25)).Name,
                    Params = data.A25
                });
            if (data.A26 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A26)).Name,
                    Params = data.A26
                });
            if (data.A27 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A27)).Name,
                    Params = data.A27
                });
            if (data.A28 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A28)).Name,
                    Params = data.A28
                });
            if (data.A29 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A29)).Name,
                    Params = data.A29
                });
            if (data.A30 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A30)).Name,
                    Params = data.A30
                });
            if (data.A31 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = typeof(WeatherDeviceData).GetProperty(nameof(WeatherDeviceData.A31)).Name,
                    Params = data.A31
                });

            rawDataAI.Add(new ChildDataWithParam
            {
                ParamName = nameof(WeatherDeviceData.CreatedDate),
                Params = data.CreatedDate
            });
            return rawDataAI;
        }
    }
}
 