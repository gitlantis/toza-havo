using StationMonnitorAPI.DBModels;
using StationMonnitorAPI.Models;
using StationMonnitorAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Controllers
{
    public class StationController : BaseController
    {
        private readonly StationService _stationService;
        public StationController(StationService stationService)
        {
            _stationService = stationService;

        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> GetStations()
        {
            var result = await _stationService.GetStations();
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> AddStation([FromBody] Station model)
        {
            var result = await _stationService.AddStation(model);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> EditStation([FromBody] StationModel model)
        {
            var result = await _stationService.EditStation(model);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteStation([FromBody]Guid guid)
        {
            var result = await _stationService.DeleteStation(guid);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> GetStationUsers([FromBody]Guid guid)
        {
            var result = await _stationService.GetStationUsers(guid);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> ConnectUsers([FromBody] StationUsersModel model)
        {
            var result = await _stationService.ConnectUsers(model);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddConfig([FromBody] StationConfigModel model)
        //{
        //    var result = await _stationService.SetConfig(model);
        //    return Ok(result);
        //}
        
        [HttpPost]
        public async Task<IActionResult> AddConfigItems([FromBody] List<StationConfigItemModel> model)
        {
            var result = await _stationService.SetConfigItems(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddConfigItem([FromBody] StationConfigItemModel model)
        {
            var result = await _stationService.SetConfigItem(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetConfigItems([FromBody] Guid guid)
        {
            var result = await _stationService.GetConfigItems(guid);
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetValues([FromBody] Guid guid)
        {
            var result = await _stationService.GetValues(guid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConfigItems([FromBody] List<StationConfigItemModel> model)
        {
            var result = await _stationService.UpdateConfigItems(model);
            return Ok(result);
        }
   
        [HttpPost]
        public async Task<IActionResult> UpdateConfigValues([FromBody] List<StationConfigItemModel> model)
        {
            var result = await _stationService.UpdateConfigValues(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStationConfig([FromBody] Guid guid)
        {
            var result = await _stationService.DeleteStationConfig(guid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfigItem([FromBody] Guid guid)
        {
            var result = await _stationService.DeleteConfigItem(guid);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetConfig([FromBody] Guid guid)
        {
            var result = await _stationService.GetConfigByStationGuid(guid);
            return Ok(result);
        } 
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetConfigAsMass([FromBody] Guid guid)
        {
            var result = await _stationService.GetConfigAsMass(guid);
            return Ok(result);
        }

        private double? getProp(PostDataModel postData, string name)
        {
            var val = double.TryParse(HttpContext.Request.Query[name].ToString(), out var dValue);
            if (val) return dValue;
            else return null;            
        }
    }
}
