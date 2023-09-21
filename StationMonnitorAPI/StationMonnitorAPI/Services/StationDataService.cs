using StationMonnitorAPI.DBModels;
using StationMonnitorAPI.Models;
using StationMonnitorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using ServiceStack.Caching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using StationMonnitorAPI.Helpers;

namespace StationMonnitorAPI.Services
{
    public class StationDataService
    {
        private readonly MyDBContext _myDbContext;
        private readonly StationService _stationService;
        private readonly IRedisCacheService _redisCacheService;

        public StationDataService(MyDBContext myDbContext, StationService stationService, IRedisCacheService redisCacheService)
        {
            _myDbContext = myDbContext;
            _stationService = stationService;
            _redisCacheService = redisCacheService;

        }

        public async Task<Guid?> DeleteData(Guid guid)
        {
            try
            {
                var data = _myDbContext.StationData.Where(c => c.Id == guid).FirstOrDefault();
                _myDbContext.StationData.Remove(data);
                await _myDbContext.SaveChangesAsync();
                return guid;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Guid?> DeleteStationData(Guid guid)
        {
            try
            {
                var dev = _myDbContext.StationData.Where(c => c.StationGuid == guid);
                _myDbContext.RemoveRange(dev);
                await _myDbContext.SaveChangesAsync();

                return guid;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<StationDynamicData>> GetCacheDynamicData(Guid? userGuid)
        {
            try
            {
                var dynData = new List<StationDynamicData>();
                var stations = await _stationService.GetStationsByUser(userGuid);

                foreach (var station in stations)
                {
                    var data = _redisCacheService.Get<StationDynamicData>(station.StationGuid);
                    if (data == null)
                    {
                        data = await this.SetCacheDynamicData(station);
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
                var station = await _myDbContext.Stations.Where(g => g.StationGuid == guid).FirstOrDefaultAsync();

                if (station != null)
                {
                    var params_ = await _myDbContext.ParamNames.Where(c => c.StationGuid == station.StationGuid).OrderBy(c => c.CreatedDate).ToListAsync();

                    var allData = _myDbContext.StationData.Where(c => c.StationGuid == guid).Count();
                    var _data = await _myDbContext.StationData.Where(c => c.StationGuid == guid).OrderByDescending(c => c.CreatedDate).Skip((page - 1) * itemCount).Take(itemCount).ToListAsync();

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
                                   StationGuid = station.StationGuid,
                                   Name = station.Name,
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
                var oldParams = await _myDbContext.ParamNames.Where(c => c.StationGuid == model.StationGUID).ToListAsync();
                _myDbContext.RemoveRange(oldParams);

                var param = new List<ParamName>();

                foreach (var m in model.Params)
                {
                    param.Add(new ParamName
                    {
                        Id = Guid.NewGuid(),
                        StationGuid = model.StationGUID,
                        Name = m.Name,
                        NameDomain = m.NameDomain,
                        NameIndex = m.NameIndex,
                        OrderIndex = m.OrderIndex,
                        CreatedDate = DateTime.Now
                    });
                }

                await _myDbContext.AddRangeAsync(param);
                await _myDbContext.SaveChangesAsync();

                return param.FirstOrDefault().StationGuid;
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
                var params_ = await _myDbContext.ParamNames.Where(c => c.StationGuid == guid).ToListAsync();

                var param = new ParamsModel();

                param.StationGUID = params_.FirstOrDefault().StationGuid;
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

        private async Task<StationDynamicData> SetCacheDynamicData(Station station)
        {
            try
            {
                var dynData = new StationDynamicData();
                var wdata = new StationData();
                var params_ = await _myDbContext.ParamNames.Where(c => c.StationGuid == station.StationGuid).OrderBy(c => c.CreatedDate).ToListAsync();

                var data = await _myDbContext.StationData
                    .Where(c => c.StationGuid == station.StationGuid).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();

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

                dynData = new StationDynamicData
                    {
                        StationGuid = station.StationGuid,
                        Name = station.Name,
                        LastDataTime = lastDate,
                        IsWorking = (diffMins < Constants.diffMins && diffMins >= 0) ? true : false,
                        IsActive = station.IsActive,
                        RowCount = count.Max(),
                        AI = rawDataAI.OrderBy(c => c.ParamOrder).ToList(),
                    };

                _redisCacheService.Delete<StationDynamicData>(station.StationGuid);
                _redisCacheService.Set<StationDynamicData>(station.StationGuid, dynData);
                return dynData;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Guid?> PostData(PostDataModel model)
        {
            try
            {
                var user = await _myDbContext.Users.Where(c => c.Password == model.secret).FirstOrDefaultAsync();

                if (user != null)
                {
                    Guid guid = Guid.NewGuid();
                    DateTime date = DateTime.Now;

                    var stationData = new StationData
                    {
                        Id = guid,
                        StationGuid = Guid.Parse(model.station_id),
                        A00 = model.A00,
                        A01 = model.A01,
                        A02 = model.A02,
                        A03 = model.A03,
                        A04 = model.A04,
                        A05 = model.A05,
                        A06 = model.A06,
                        A07 = model.A07,
                        A08 = model.A08,
                        A09 = model.A09,
                        A10 = model.A10,
                        A11 = model.A11,
                        A12 = model.A12,
                        A13 = model.A13,
                        A14 = model.A14,
                        A15 = model.A15,
                        A16 = model.A16,
                        A17 = model.A17,
                        A18 = model.A18,
                        A19 = model.A19,
                        A20 = model.A20,
                        A21 = model.A21,
                        A22 = model.A22,
                        A23 = model.A23,
                        A24 = model.A24,
                        A25 = model.A25,
                        A26 = model.A26,
                        A27 = model.A27,
                        A28 = model.A28,
                        A29 = model.A29,
                        A30 = model.A30,
                        A31 = model.A31,
                        StationDate = model.date ?? DateTime.Now,
                        CreatedDate = date,
                        EditedDate = date
                    };

                    await _myDbContext.AddAsync(stationData);
                    await _myDbContext.SaveChangesAsync();

                    return guid;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StationInstantDataModel> GetInstantData(Guid? stationGuid)
        {
            try
            {
                var result = new StationInstantDataModel();
                var stationLocations = new StationLocationModel();

                var stations = await _stationService.GetStations();

                var data = _myDbContext.StationData
                    .Where(c => c.StationGuid == (stationGuid ?? stations.FirstOrDefault().StationGuid) && c.CreatedDate > DateTime.Now.AddDays(-7)).OrderByDescending(c => c.CreatedDate);

                var instantValues = await data.FirstOrDefaultAsync();
                result.Aqi = 99;
                result.Pm1_0 = instantValues?.A02;
                result.Pm2_5 = instantValues?.A03;
                result.Pm10 = instantValues?.A04;
                result.Co2 = instantValues?.A14;

                if(instantValues != null)
                result.InstantValues = new List<StationInstantValueModel> {
                    new StationInstantValueModel
                    {
                        Section = Constants.InstantValues["temperature"],
                        CurrentValue = instantValues?.A00,
                        SubCurrentValue = instantValues?.A00,
                        Avg = data.Count()>0?data.Sum(x=>Convert.ToInt32(x.A00 ?? 0))/data.Count():1,
                        Min = data.Min(x=>x.A00 ?? 0),
                        Max = data.Max(x=>x.A00 ?? 0)

                    }, new StationInstantValueModel
                    {
                        Section = Constants.InstantValues["humadity"],
                        CurrentValue = instantValues?.A01,
                        SubCurrentValue = instantValues?.A01,
                        Avg = data.Count()>0?data.Sum(x=>Convert.ToInt32(x.A01 ?? 0))/data.Count():1,
                        Min = data.Min(x=>x.A01 ?? 0),
                        Max = data.Max(x=>x.A01 ?? 0)

                    }, new StationInstantValueModel
                    {
                        Section = Constants.InstantValues["pressure"],
                        CurrentValue = instantValues?.A28,
                        Avg = data.Count()>0?data.Sum(x=>Convert.ToInt32(x.A28 ?? 0))/data.Count():1,
                        Min = data.Min(x=>x.A28 ?? 0),
                        Max = data.Max(x=>x.A28 ?? 0)

                    }, new StationInstantValueModel
                    {
                        Section = Constants.InstantValues["wind"],
                        CurrentValue = instantValues?.A20,
                        SubCurrentValue = instantValues?.A21,
                        Avg = data.Count()>0?data.Sum(x=>Convert.ToInt32(x.A20 ?? 0))/data.Count():1,
                        Min = data.Min(x=>x.A20 ?? 0),
                        Max = data.Max(x=>x.A20 ?? 0)

                    }, new StationInstantValueModel
                    {
                        Section = Constants.InstantValues["radiation"],
                        CurrentValue = instantValues?.A29,
                        SubCurrentValue = instantValues?.A29,
                        Avg = data.Count()>0?data.Sum(x=>Convert.ToInt32(x.A29 ?? 0))/data.Count():0,
                        Min = data.Min(x=>x.A29 ?? 0),
                        Max = data.Max(x=>x.A29 ?? 0)
                    }
                 };

                var locations = await _myDbContext.Stations
                    .Include(c => c.StationsData)
                    .Select(c => new
                    {
                        Station = c,
                        LastWeatherData = c.StationsData.OrderByDescending(data => data.CreatedDate).FirstOrDefault()
                    })
                    .ToListAsync();

                result.StationLocations = new List<StationLocationModel>();
                foreach (var location in locations)
                {
                    var stationLocation = new StationLocationModel
                    {
                        Id = location.Station.StationGuid,
                        LocationName = location.Station.Description,
                        Langitude = location.LastWeatherData?.A24,
                        Latitude = location.LastWeatherData?.A25,
                        Altitude = location.LastWeatherData?.A26
                    };

                    result.StationLocations.Add(stationLocation);
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<DynamicChartsDataModel> GetDynamicData(Guid stationGuid, string param)
        {
            try
            {
                var result = new DynamicChartsDataModel();

                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                var data = await _myDbContext.StationData
                    .Where(c => c.StationGuid == stationGuid && c.StationDate > DateTime.Now.AddDays(-7))
                    .GroupBy(t => new
                    {
                        Day = t.StationDate.Date,
                        Hour = t.StationDate.Hour
                    })
                    .Select(g => new
                    {
                        Day = g.Key.Day,
                        Hour = g.Key.Hour,
                        PM1_0 = g.Average(t => t.A02),
                        PM2_5 = g.Average(t => t.A03),
                        PM10 = g.Average(t => t.A04),
                        CO2 = g.Average(t => t.A14)
                    })
                    .OrderBy(result => result.Day)
                    .ThenBy(result => result.Hour)
                    .ToListAsync();

                var days = data.GroupBy(c => c.Day);
                result.BoxPlot = new List<double[]>();
                result.Heatmap = new List<double[]>();
                result.Days = new List<DateTime>();

                int i = 6;

                foreach (var day in days)
                {
                    IEnumerable<double> daylyValues;
                    switch (param)
                    {
                        case "pm1_0":
                            daylyValues = day.Select(c => c.PM1_0).Cast<double>();
                            break;
                        case "pm2_5":
                            daylyValues = day.Select(c => c.PM2_5).Cast<double>();
                            break;
                        case "pm10":
                            daylyValues = day.Select(c => c.PM10).Cast<double>();
                            break;
                        case "co2":
                            daylyValues = day.Select(c => c.CO2).Cast<double>();
                            break;
                        default:
                            return null;
                    }

                    var hours = day.Select(c => c.Hour).Cast<int>().ToArray();
                    var plot = BoxPlotCalculator.CalculateBoxPlotStatistics(daylyValues.ToArray());

                    var d = day.Select(c => c.Day).Cast<DateTime>().FirstOrDefault();
                    result.Days.Add(d);
                    result.BoxPlot.Add(new double[] { plot.Minimum, plot.LowerQuartile, plot.Median, plot.UpperQuartile, plot.Maximum });

                    var deylyQueue = new Queue<double>(daylyValues.ToArray());
                    for (var j = 0; j < 24; j++)
                    {
                        result.Heatmap.Add(new double[] { j, i, hours.Contains(j) ? deylyQueue.Dequeue() : 0 });
                    }
                    i--;
                }
                result.BoxplotMedian = BoxPlotCalculator.CalculateBoxPlotsMedian(result.BoxPlot.ToArray());

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private List<ChildDataWithParam>  WeatherMass(StationData data)
        {
            var weatherData = new StationData();
            var weatherContextParams = _myDbContext.StationDataParam;
            var rawDataAI = new List<ChildDataWithParam>();
            if (data.A00 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c=>c.Param.Equals(nameof(weatherData.A00))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A00))).FirstOrDefault().Description,
                    Params = data.A00
                });
            if (data.A01 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A01))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A01))).FirstOrDefault().Description,
                    Params = data.A01
                });
            if (data.A02 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A02))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A02))).FirstOrDefault().Description,
                    Params = data.A02
                });
            if (data.A03 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A03))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A03))).FirstOrDefault().Description,
                    Params = data.A03
                });
            if (data.A04 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A04))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A04))).FirstOrDefault().Description,
                    Params = data.A04
                });
            if (data.A05 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A05))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A05))).FirstOrDefault().Description,
                    Params = data.A05
                });
            if (data.A06 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A06))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A06))).FirstOrDefault().Description,
                    Params = data.A06
                });
            if (data.A07 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A07))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A07))).FirstOrDefault().Description,
                    Params = data.A07
                });
            if (data.A08 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A08))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A08))).FirstOrDefault().Description,
                    Params = data.A08
                });
            if (data.A09 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A09))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A09))).FirstOrDefault().Description,
                    Params = data.A09
                });
            if (data.A10 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A10))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A10))).FirstOrDefault().Description,
                    Params = data.A10
                });
            if (data.A11 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A11))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A11))).FirstOrDefault().Description,
                    Params = data.A11
                });
            if (data.A12 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A12))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A12))).FirstOrDefault().Description,
                    Params = data.A12
                });
            if (data.A13 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A13))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A13))).FirstOrDefault().Description,
                    Params = data.A13
                });
            if (data.A14 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A14))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A14))).FirstOrDefault().Description,
                    Params = data.A14
                });
            if (data.A15 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A15))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A15))).FirstOrDefault().Description,
                    Params = data.A15
                });
            if (data.A16 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A16))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A16))).FirstOrDefault().Description,
                    Params = data.A16
                });
            if (data.A17 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A17))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A17))).FirstOrDefault().Description,
                    Params = data.A17
                });
            if (data.A18 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A18))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A18))).FirstOrDefault().Description,
                    Params = data.A18
                });
            if (data.A19 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A19))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A19))).FirstOrDefault().Description,
                    Params = data.A19
                });
            if (data.A20 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A20))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A20))).FirstOrDefault().Description,
                    Params = data.A20
                });
            if (data.A21 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A21))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A21))).FirstOrDefault().Description,
                    Params = data.A21
                });
            if (data.A22 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A22))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A22))).FirstOrDefault().Description,
                    Params = data.A22
                });
            if (data.A23 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A23))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A23))).FirstOrDefault().Description,
                    Params = data.A23
                });
            if (data.A24 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A24))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A24))).FirstOrDefault().Description,
                    Params = data.A24
                });
            if (data.A25 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A25))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A25))).FirstOrDefault().Description,
                    Params = data.A25
                });
            if (data.A26 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A26))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A26))).FirstOrDefault().Description,
                    Params = data.A26
                });
            if (data.A27 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A27))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A27))).FirstOrDefault().Description,
                    Params = data.A27
                });
            if (data.A28 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A28))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A28))).FirstOrDefault().Description,
                    Params = data.A28
                });
            if (data.A29 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A29))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A29))).FirstOrDefault().Description,
                    Params = data.A29
                });
            if (data.A30 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A30))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A30))).FirstOrDefault().Description,
                    Params = data.A30
                });
            if (data.A31 != null)
                rawDataAI.Add(new ChildDataWithParam
                {
                    ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A31))).FirstOrDefault().Name,
                    ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.A31))).FirstOrDefault().Description,
                    Params = data.A31
                });

            rawDataAI.Add(new ChildDataWithParam
            {
                ParamName = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.CreatedDate))).FirstOrDefault().Name,
                ParamDesc = weatherContextParams.Where(c => c.Param.Equals(nameof(weatherData.CreatedDate))).FirstOrDefault().Description,
                Params = data.CreatedDate
            });
            return rawDataAI;
        }
    }
}
 