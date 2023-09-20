using StationMonnitorAPI.DBModels;
using StationMonnitorAPI.Models;
using StationMonnitorAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StationMonnitorAPI.Controllers
{
    [AllowAnonymous]
    public class StationDataController : BaseController
    {
        private readonly StationDataService _stationDataService;

        public StationDataController(StationDataService stationDataService)
        {
            _stationDataService = stationDataService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetDynamicData()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst("UserId");
            var role = claimsIdentity.FindFirst(claimsIdentity.RoleClaimType).Value;
            var userGuid = claim.Value;

            List<StationDynamicData> result = new List<StationDynamicData>();
            if (role.Equals("ApiAdmin") || role.Equals("Admin"))
            {
                result = await _stationDataService.GetCacheDynamicData(null);
            }
            else
            {
                result = await _stationDataService.GetCacheDynamicData(Guid.Parse(userGuid));
            }

            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteData([FromBody] Guid guid)
        {
            var result = await _stationDataService.DeleteData(guid);
            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteDataByStation([FromBody] Guid guid)
        {
            var result = await _stationDataService.DeleteStationData(guid);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> GetArchive([FromBody] ArchiveDataModel model)
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst("UserId");           
            var userGuid = claim.Value;

            var result = await _stationDataService.GetArchive(Guid.Parse(userGuid), model.StationGuid, model.ItemCount, model.PageNum);

            return Ok(result);
        }

        [Authorize(Roles = "ApiAdmin, Admin")]                
        [HttpPost]
        public async Task<IActionResult> SetParams([FromBody] ParamsModel model)
        {
            var result = await _stationDataService.SetParams(model);

            return Ok(result);
        }
        
        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetParams([FromBody] Guid guid)
        {
            var result = await _stationDataService.GetParams(guid);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetInstantData([FromBody] RequestGuid model)
        {
            var result = await _stationDataService.GetInstantData(model.id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GetBoxplot([FromBody] RequestDynamicDataModel model)
        {
            var result = await _stationDataService.GetDynamicData(model.id, model.param);
            return Ok(result);
        }

        //[Authorize(Roles = "ApiAdmin, Station")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Post()
        {
            var postData = new PostDataModel();
            postData.secret = HttpContext.Request.Query[nameof(postData.secret)].ToString();
            postData.station_id = HttpContext.Request.Query[nameof(postData.station_id)].ToString();
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

            var res = await _stationDataService.PostData(postData);

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
