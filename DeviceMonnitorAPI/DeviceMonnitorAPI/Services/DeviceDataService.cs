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
using System.Linq;
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
                    var paramData = new List<dynamic>();

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


                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Co),
                                Params = data.Co
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Co2),
                                Params = data.Co2
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Pm1),
                                Params = data.Pm1
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Pm2_5),
                                Params = data.Pm2_5
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Pm10),
                                Params = data.Pm10
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Aqi),
                                Params = data.Aqi
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Humadity),
                                Params = data.Humadity
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.SandHumadity),
                                Params = data.SandHumadity
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Temperature),
                                Params = data.Temperature
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.SandTemperature),
                                Params = data.SandTemperature
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.SandElectric),
                                Params = data.SandElectric
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.SandSalt),
                                Params = data.SandSalt
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.SandSaltElectric),
                                Params = data.SandSaltElectric
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.Rain),
                                Params = data.Rain
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.WindSpeed),
                                Params = data.WindSpeed
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.WindDirection),
                                Params = data.WindDirection
                            });
                            rawDataAI.Add(new ChildDataWithParam
                            {
                                ParamName = nameof(WeatherDeviceData.DeviceDate),
                                Params = data.DeviceDate
                            });

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

                var params_ = await _myDbContext.ParamNames.Where(c => c.DeviceGuid == device.DeviceGuid).OrderBy(c => c.CreatedDate).ToListAsync();

                var data = await _myDbContext.WeatherDeviceData
                    .Where(c => c.DeviceGuid == device.DeviceGuid).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();

                var rawDataAI = new List<ChildDataWithParam>();
                var count = new int[5];

                var diffMins = 3;
                var lastDate = new DateTime();

                if (data != null)
                {
                    //var ai = new List<string>();

                    diffMins = Convert.ToInt32(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalMinutes - TimeSpan.FromTicks(data.EditedDate.Ticks).TotalMinutes);
                    //lastDate = data.CreatedDate;// $" ({data.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss")})";

                    //var res = await _myDbContext.DataAI.Where(c => c.DataGuid == data.Id).OrderBy(o => o.CreatedDate).Select(s => s.Param.ToString("#0.##")).ToListAsync();
                    //var par = params_.Where(c => c.NameDomain.ToUpper().Equals("AI")).ToList();
                    //rawDataAI.AddRange(GetChildData(par, res));

                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Co),
                        Params = data.Co
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Co2),
                        Params = data.Co2
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Pm1),
                        Params = data.Pm1
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Pm2_5),
                        Params = data.Pm2_5
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Pm10),
                        Params = data.Pm10
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Aqi),
                        Params = data.Aqi
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Humadity ),
                        Params = data.Humadity 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.SandHumadity ),
                        Params = data.SandHumadity 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Temperature ),
                        Params = data.Temperature 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.SandTemperature ),
                        Params = data.SandTemperature 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.SandElectric ),
                        Params = data.SandElectric 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.SandSalt ),
                        Params = data.SandSalt 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.SandSaltElectric),
                        Params = data.SandSaltElectric
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.Rain ),
                        Params = data.Rain 
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.WindSpeed),
                        Params = data.WindSpeed
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.WindDirection),
                        Params = data.WindDirection
                    });
                    rawDataAI.Add(new ChildDataWithParam
                    {
                        ParamName = nameof(WeatherDeviceData.DeviceDate),
                        Params = data.DeviceDate
                    });

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
    }
}
 