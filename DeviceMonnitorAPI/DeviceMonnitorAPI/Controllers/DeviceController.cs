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
    }
}
