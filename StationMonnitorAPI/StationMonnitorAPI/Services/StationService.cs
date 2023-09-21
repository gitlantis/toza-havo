using StationMonnitorAPI.DBModels;
using StationMonnitorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Services
{
    public class StationService
    {
        private readonly MyDBContext _myDbContext;
        public StationService(MyDBContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<Station> AddStation(Station model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.EditedDate = DateTime.Now;

                _myDbContext.AddAsync(model);
                await _myDbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Guid?> EditStation(StationModel model)
        {
            try
            {
                var dev = _myDbContext.Stations.Where(c => c.StationGuid == model.StationGuid).FirstOrDefault();

                dev.Name = model.Name;
                dev.Description = model.Description;
                dev.IsActive = model.IsActive;
                dev.CreatedDate = dev.CreatedDate;
                dev.EditedDate = DateTime.Now;

                await _myDbContext.SaveChangesAsync();
                return model.StationGuid;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Guid?> DeleteStation(Guid guid)
        {
            try
            {
                var dev = _myDbContext.Stations.Where(c => c.StationGuid == guid).FirstOrDefault();

                _myDbContext.Stations.Remove(dev);
                await _myDbContext.SaveChangesAsync();

                return dev.StationGuid;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StationModel> GetStationByGuid(Guid guid)
        {
            try
            {
                //_myDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var result = _myDbContext.Stations.Where(c => c.StationGuid == guid).Select(c =>
                new StationModel
                {
                    StationGuid = c.StationGuid,
                    Name = c.Name,
                    Description = c.Description,
                    CreatedDate = c.CreatedDate,
                    IsActive = c.IsActive,
                    EditedDate = c.EditedDate
                }).FirstOrDefault();

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<StationModel>> GetStations()
        {
            try
            {
                var result = _myDbContext.Stations.Select(c =>
                new StationModel
                {
                    StationGuid = c.StationGuid,
                    Name = c.Name,
                    Description = c.Description,
                    CreatedDate = c.CreatedDate,
                    IsActive = c.IsActive,
                    EditedDate = c.EditedDate
                }
                );
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Station>> GetStationsByUser(Guid? userGuid)
        {
            IEnumerable<Station> stations = null;

            if (userGuid == null)
            {
                stations = await _myDbContext.Stations.ToListAsync();
            }
            else
            {
                var user = await _myDbContext.Users.Where(c => c.UserGuid == userGuid).FirstOrDefaultAsync();
                stations = await _myDbContext.Users.Include(c => c.Stations).Where(u => u.UserGuid == user.UserGuid).Select(c => c.Stations).FirstOrDefaultAsync();
            }
            return stations.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<StationUsersModel> GetStationUsers(Guid guid)
        {
            try
            {
                var res = await _myDbContext.Stations.Include(c => c.Users).Where(c => c.StationGuid == guid).FirstOrDefaultAsync();

                var result = new StationUsersModel
                {
                    UserGuid = res.Users.Select(c => c.UserGuid).ToArray(),
                    StationGuid = guid
                };

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<StationUsersModel> ConnectUsers(StationUsersModel model)
        {
            try
            {
                var users = _myDbContext.Users.Where(c => model.UserGuid.Contains(c.UserGuid)).ToList();
                var dev = await _myDbContext.Stations.Include(u => u.Users).Where(c => c.StationGuid == model.StationGuid).FirstOrDefaultAsync();
                var stationUsers = new List<StationUser>();

                var userCheck = dev.Users.DefaultIfEmpty(null);
                if (userCheck.FirstOrDefault() != null)
                {
                    dev.Users.Clear();
                }

                var i = 0;
                foreach (var userGuid in model.UserGuid)
                {
                    var item = new StationUser();
                    item.StationsStationGuid = model.StationGuid;
                    item.UsersUserGuid = userGuid;
                    item.CanEdit = model.CanEdit[i];

                    stationUsers.Add(item);
                    i++;
                }
                var result = dev.StationUsers = stationUsers;
                await _myDbContext.SaveChangesAsync();

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public async Task<StationConfigModel> SetConfig(StationConfigModel model)
        //{
        //    try
        //    {
        //        var fbArr = new dynamic[9];
        //        var dbModel = new StationConfig();

        //        dbModel.StationGuid = model.StationGuid;
        //        fbArr[0] = dbModel.UMax = model.UMax;
        //        fbArr[1] = dbModel.UMin = model.UMin;
        //        fbArr[2] = dbModel.Calm = model.Calm;
        //        fbArr[3] = dbModel.Wup = model.Wup;
        //        fbArr[4] = dbModel.Wdw = model.Wdw;
        //        fbArr[5] = dbModel.Overtime = model.Overtime;
        //        fbArr[6] = dbModel.DownTime = model.DownTime;
        //        fbArr[7] = dbModel.OverVtime = model.OverVtime;
        //        fbArr[8] = dbModel.LowVtime = model.LowVtime;
        //        dbModel.DO0 = model.DO0;
        //        dbModel.DO1 = model.DO1;
        //        dbModel.DO2 = model.DO2;
        //        dbModel.DO3 = model.DO3;

        //        dbModel.ConfGuid = Guid.NewGuid();
        //        dbModel.CreatedDate = DateTime.Now;

        //        _myDbContext.Add(dbModel);
        //        _myDbContext.SaveChanges();

        //        model.CreatedDate = dbModel.CreatedDate;
        //        model.ConfGuid = dbModel.ConfGuid;

        //        //write to firebase
        //        client = new FirebaseClient(fbc);

        //        return model;
        //    }
        //    catch (Exception ex)
        //    {
        //        var err = ex.Message;
        //        throw;
        //    }
        //}

        public async Task<List<StationConfigItemModel>> SetConfigItems(List<StationConfigItemModel> model)
        {
            try
            {
                var dbModel = new List<StationConfigItem>();
                foreach (var item in model)
                {
                    var singleModel = new StationConfigItem();

                    singleModel.StationGuid = item.StationGuid;
                    singleModel.Name = item.Name;
                    singleModel.Comment = item.Comment;
                    singleModel.Value = item.Value;
                    singleModel.Type = item.Type;

                    singleModel.ConfGuid = Guid.NewGuid();
                    singleModel.CreatedDate = DateTime.Now;

                    dbModel.Add(singleModel);
                }

                _myDbContext.AddRange(dbModel);
                _myDbContext.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        public async Task<StationConfigItemModel> SetConfigItem(StationConfigItemModel model)
        {
            try
            {
                var dbModel = new StationConfigItem();

                dbModel.StationGuid = model.StationGuid;
                dbModel.Name = model.Name;
                dbModel.Comment = model.Comment;
                dbModel.Value = model.Value;
                dbModel.Type = model.Type;

                dbModel.ConfGuid = Guid.NewGuid();
                dbModel.CreatedDate = DateTime.Now;

                _myDbContext.Add(dbModel);
                _myDbContext.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        public async Task<List<StationConfigItemModel>> UpdateConfigItems(List<StationConfigItemModel> model)
        {
            try
            {
                var dbModel = new List<StationConfigItem>();
                foreach (var item in model)
                {
                    var res = _myDbContext.StationConfigItem.Where(c => (c.ConfGuid == item.ConfGuid) && (c.StationGuid == item.StationGuid)).FirstOrDefault();

                    if (res!=null)
                    {
                        var singleModel = new StationConfigItem();
                        singleModel = res;
                        singleModel.Name = item.Name;
                        singleModel.Comment = item.Comment;
                        singleModel.Value = item.Value;
                        singleModel.Type = item.Type;

                        singleModel.EditedDate = DateTime.Now;

                        dbModel.Add(singleModel);
                    }
                }

                _myDbContext.UpdateRange(dbModel);
                _myDbContext.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        public async Task<List<StationConfigItemModel>> UpdateConfigValues(List<StationConfigItemModel> model)
        {
            try
            {
                var dbModel = new List<StationConfigItem>();
                foreach (var item in model)
                {
                    var res = _myDbContext.StationConfigItem.Where(c => (c.ConfGuid == item.ConfGuid) && (c.StationGuid == item.StationGuid)).FirstOrDefault();

                    if (res != null)
                    {
                        var singleModel = new StationConfigItem();
                        singleModel = res;                        
                        singleModel.Value = item.Value;
                        singleModel.EditedDate = DateTime.Now;

                        dbModel.Add(singleModel);
                    }
                }

                _myDbContext.UpdateRange(dbModel);
                _myDbContext.SaveChanges();

                return model;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        public async Task<List<StationConfigItemModel>> GetConfigItems(Guid stationGuid)
        {
            try
            {

                var result = _myDbContext.StationConfigItem.Where(c => c.StationGuid == stationGuid).OrderBy(t => t.CreatedDate);
                var model = new List<StationConfigItemModel>();
                
                foreach(var res in result)
                {
                    model.Add(new StationConfigItemModel
                    {
                        ConfGuid = res.ConfGuid,
                        StationGuid = res.StationGuid,
                        Name = res.Name,
                        Comment = res.Comment,
                        Value = res.Value,
                        Type = res.Type,
                        CreatedDate = res.CreatedDate,
                        EditedDate = res.EditedDate                        
                        
                    });
                }

                return model;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        public async Task<Dictionary<string, string>> GetValues(Guid stationGuid)
        {
            try
            {
                var result = _myDbContext.StationConfigItem.Where(c => c.StationGuid == stationGuid).OrderBy(t => t.CreatedDate);
                var model = new Dictionary<string, string>();

                foreach (var res in result)                
                    model.Add(res.Name,res.Value);

                return model;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }

        public async Task<Guid> DeleteStationConfig(Guid stationGuid)
        {
            try
            {

                var result = _myDbContext.StationConfigItem.Where(c => c.StationGuid == stationGuid);
                _myDbContext.RemoveRange(result);
                _myDbContext.SaveChanges();

                return stationGuid;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }
        public async Task<Guid> DeleteConfigItem(Guid itemGuidGuid)
        {
            try
            {

                var result = _myDbContext.StationConfigItem.Where(c => c.ConfGuid == itemGuidGuid).FirstOrDefaultAsync();
                _myDbContext.Remove(result);
                _myDbContext.SaveChanges();

                return itemGuidGuid;
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                throw;
            }
        }
        public async Task<StationConfigModel> GetConfigByStationGuid(Guid guid)
        {
            try
            {
                //_myDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var result = _myDbContext.StationConfig.Where(c => c.StationGuid == guid).OrderByDescending(t => t.CreatedDate).
                    Select(c => new StationConfigModel
                    {
                        ConfGuid = c.ConfGuid,
                        StationGuid = c.StationGuid,
                        UMax = c.UMax,
                        UMin = c.UMin,
                        //Cup = c.Cup,
                        Calm = c.Calm,
                        //Cadw = c.Cadw,
                        Wup = c.Wup,
                        Wdw = c.Wdw,
                        //Ontime = c.Ontime,
                        //Ertime = c.Ertime,
                        Overtime = c.Overtime,
                        DownTime = c.DownTime,
                        OverVtime = c.OverVtime,
                        LowVtime = c.LowVtime,
                        //EMode = c.EMode,
                        CreatedDate = c.CreatedDate,
                        EditedDate = c.EditedDate,
                        DO0 = c.DO0,
                        DO1 = c.DO1,
                        DO2 = c.DO2,
                        DO3 = c.DO3,
                    }).FirstOrDefaultAsync();

                var res = await result;
                return res;
            }
            catch (Exception e)
            {
                return null;

            }
        }

        public async Task<Dictionary<Guid, StationConfigAsMassModel>> GetConfigAsMass(Guid guid)
        {
            try
            {
                //_myDbContext.ChangeTracker.LazyLoadingEnabled = false;
                var result = await _myDbContext.StationConfig.Where(c => c.StationGuid == guid).OrderByDescending(t => t.CreatedDate).FirstOrDefaultAsync();

                var res = new Dictionary<Guid, StationConfigAsMassModel>();
                var config = new StationConfigAsMassModel();

                config.AI = new decimal[9];
                config.DO = new bool[4];

                config.AI[0] = result.UMax;
                config.AI[1] = result.UMin;
                config.AI[2] = result.Calm;
                config.AI[3] = result.Wup;
                config.AI[4] = result.Wdw;
                config.AI[5] = result.Overtime;
                config.AI[6] = result.DownTime;
                config.AI[7] = result.OverVtime;
                config.AI[8] = result.LowVtime;

                config.DO[0] = result.DO0;
                config.DO[1] = result.DO1;
                config.DO[2] = result.DO2;
                config.DO[3] = result.DO3;

                res.Add(guid, config);

                return res;
            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}
