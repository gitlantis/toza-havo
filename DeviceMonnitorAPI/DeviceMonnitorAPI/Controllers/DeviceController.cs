using DeviceMonnitorAPI.DBModels;
using DeviceMonnitorAPI.Models;
using DeviceMonnitorAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var postData = new PostDataModel();
            postData.secret = HttpContext.Request.Query[nameof(postData.secret)].ToString();
            postData.dev_guid = HttpContext.Request.Query[nameof(postData.dev_guid)].ToString();
            postData.A00 = getProp(postData, nameof(postData.A00));
            postData.A01 = getProp(postData, nameof(postData.A01));
            postData.A02 = getProp(postData, nameof(postData.A02));
            postData.A03 = getProp(postData, nameof(postData.A03));
            postData.A04 = getProp(postData, nameof(postData.A04));
            postData.A05 = getProp(postData, nameof(postData.A05));
            postData.A06 = getProp(postData, nameof(postData.A06));
            postData.A07 = getProp(postData, nameof(postData.A07));
            postData.A08 = getProp(postData, nameof(postData.A08));
            postData.A09 = getProp(postData, nameof(postData.A09));
            postData.A10 = getProp(postData, nameof(postData.A10));
            postData.A11 = getProp(postData, nameof(postData.A11));
            postData.A12 = getProp(postData, nameof(postData.A12));
            postData.A13 = getProp(postData, nameof(postData.A13));
            postData.A14 = getProp(postData, nameof(postData.A14));
            postData.A15 = getProp(postData, nameof(postData.A15));
            postData.A16 = getProp(postData, nameof(postData.A16));
            postData.A17 = getProp(postData, nameof(postData.A17));
            postData.A18 = getProp(postData, nameof(postData.A18));
            postData.A19 = getProp(postData, nameof(postData.A19));
            postData.A20 = getProp(postData, nameof(postData.A20));
            postData.A21 = getProp(postData, nameof(postData.A21));
            postData.A22 = getProp(postData, nameof(postData.A22));
            postData.A23 = getProp(postData, nameof(postData.A23));
            postData.A24 = getProp(postData, nameof(postData.A24));
            postData.A25 = getProp(postData, nameof(postData.A25));
            postData.A26 = getProp(postData, nameof(postData.A26));
            postData.A27 = getProp(postData, nameof(postData.A27));
            postData.A28 = getProp(postData, nameof(postData.A28));
            postData.A29 = getProp(postData, nameof(postData.A29));
            postData.A30 = getProp(postData, nameof(postData.A30));
            postData.A31 = getProp(postData, nameof(postData.A31));
            DateTime.TryParse(HttpContext.Request.Query[nameof(postData.date)].ToString(), out var date);
            postData.date = date;

            var res = await _deviceService.PostData(postData);

            return Ok(res);
        }

        private double? getProp(PostDataModel postData, string name)
        {
            var val = double.TryParse(HttpContext.Request.Query[name].ToString(), out var dValue);
            if (val) return dValue;
            else return null;            
        }
    }
}
