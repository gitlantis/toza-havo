using DeviceMonnitorAPI.DBModels;
using DeviceMonnitorAPI.Models;
using DeviceMonnitorAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly DeviceService _deviceService;
        public DeviceController(DeviceService deviceService)
        {
            _deviceService = deviceService;

        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> GetDevices()
        {
            var result = await _deviceService.GetDevices();
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] Device model)
        {
            var result = await _deviceService.AddDevice(model);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> EditDevice([FromBody] DeviceModel model)
        {
            var result = await _deviceService.EditDevice(model);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteDevice([FromBody]Guid guid)
        {
            var result = await _deviceService.DeleteDevice(guid);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> GetDeviceUsers([FromBody]Guid guid)
        {
            var result = await _deviceService.GetDeviceUsers(guid);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> ConnectUsers([FromBody] DeviceUsersModel model)
        {
            var result = await _deviceService.ConnectUsers(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddConfig([FromBody] DeviceConfigModel model)
        {
            var result = await _deviceService.SetConfig(model);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddConfigItems([FromBody] List<DeviceConfigItemModel> model)
        {
            var result = await _deviceService.SetConfigItems(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddConfigItem([FromBody] DeviceConfigItemModel model)
        {
            var result = await _deviceService.SetConfigItem(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetConfigItems([FromBody] Guid guid)
        {
            var result = await _deviceService.GetConfigItems(guid);
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetValues([FromBody] Guid guid)
        {
            var result = await _deviceService.GetValues(guid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConfigItems([FromBody] List<DeviceConfigItemModel> model)
        {
            var result = await _deviceService.UpdateConfigItems(model);
            return Ok(result);
        }
   
        [HttpPost]
        public async Task<IActionResult> UpdateConfigValues([FromBody] List<DeviceConfigItemModel> model)
        {
            var result = await _deviceService.UpdateConfigValues(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDeviceConfig([FromBody] Guid guid)
        {
            var result = await _deviceService.DeleteDeviceConfig(guid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfigItem([FromBody] Guid guid)
        {
            var result = await _deviceService.DeleteConfigItem(guid);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetConfig([FromBody] Guid guid)
        {
            var result = await _deviceService.GetConfigByDeviceGuid(guid);
            return Ok(result);
        } 
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetConfigAsMass([FromBody] Guid guid)
        {
            var result = await _deviceService.GetConfigAsMass(guid);
            return Ok(result);
        }

        //[Authorize(Roles = "ApiAdmin, Device")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Post()
        {
            string _secret, _dev_guid;
            double _co,_co2,_pm1,_pm2_5,_pm10,_aqi,_hum,_sand_hum,_temp,_sand_temp,_sand_elec,_sand_salt,_sand_selec,_rain,_wind_s,_wind_d;
            DateTime _date;

            _secret = HttpContext.Request.Query["secret"].ToString();
            _dev_guid = HttpContext.Request.Query["dev_guid"].ToString();
            double.TryParse(HttpContext.Request.Query["co"].ToString(), out _co);
            double.TryParse(HttpContext.Request.Query["co2"].ToString(), out _co2);
            double.TryParse(HttpContext.Request.Query["pm1"].ToString(), out _pm1);
            double.TryParse(HttpContext.Request.Query["pm2_5"].ToString(), out _pm2_5);
            double.TryParse(HttpContext.Request.Query["pm10"].ToString(), out _pm10);
            double.TryParse(HttpContext.Request.Query["aqi"].ToString(), out _aqi);
            double.TryParse(HttpContext.Request.Query["hum"].ToString(), out _hum);
            double.TryParse(HttpContext.Request.Query["sand_hum"].ToString(), out _sand_hum);
            double.TryParse(HttpContext.Request.Query["temp"].ToString(), out _temp);
            double.TryParse(HttpContext.Request.Query["sand_temp"].ToString(), out _sand_temp);
            double.TryParse(HttpContext.Request.Query["sand_elec"].ToString(), out _sand_elec);
            double.TryParse(HttpContext.Request.Query["sand_salt"].ToString(), out _sand_salt);
            double.TryParse(HttpContext.Request.Query["sand_selec"].ToString(), out _sand_selec);
            double.TryParse(HttpContext.Request.Query["rain"].ToString(), out _rain);
            double.TryParse(HttpContext.Request.Query["wind_s"].ToString(), out _wind_s);
            double.TryParse(HttpContext.Request.Query["wind_d"].ToString(), out _wind_d);
            DateTime.TryParse(HttpContext.Request.Query["date"].ToString(), out _date);

            var postData = new PostDataModel
            {
                secret = _secret,
                dev_guid = _dev_guid,
                co = _co,
                co2 = _co2,
                pm1 = _pm1,
                pm2_5 = _pm2_5,
                pm10 = _pm10,
                aqi = _aqi,
                hum = _hum,
                sand_hum = _sand_hum,
                temp = _temp,
                sand_temp = _sand_temp,
                sand_elec = _sand_elec,
                sand_salt = _sand_salt,
                sand_selec = _sand_selec,
                rain = _rain,
                wind_s = _wind_s,
                wind_d = _wind_d,
                date = _date
            };

            var res = await _deviceService.PostData(postData);

            return Ok(res);
        }

    }
}
