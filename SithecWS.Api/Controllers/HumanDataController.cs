using Microsoft.AspNetCore.Mvc;
using SithecWS.Api.Data;
using SithecWS.Api.Models;
using SithecWS.Api.Utilities;
using SithecWS.Api.Models.Response;

namespace SithecWS.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HumanDataController : ControllerBase
    {
        private static readonly HumanData humanData = HumanData.GetHumanData();

        [HttpGet(Name = "SetMigrationData")]
        public async Task MigrationData()
        {
            await humanData.SetMigrationData();
        }

        [HttpGet(Name = "GetData")]
        public async Task<ActionResult<IEnumerable<HumanModel>>> GetData()
        {
            _ = new List<HumanModel>();
            List<HumanModel>? response = await humanData.GetData();
            return response;
        }

        [HttpGet(Name = "GetDataSearch")]
        public async Task<ActionResult<IEnumerable<HumanModel>>> GetDataSearch(int? id, string? nombre)
        {
            _ = new List<HumanModel>();
            List<HumanModel>? response = await humanData.GetData(id, nombre);

            return response;
        }

        [HttpPost(Name = "SetHumanCreate")]
        public async Task<HumanDataResponse> SetHumanCreate(HumanModel requets)
        {
            var response = new HumanDataResponse();
            try
            {
                await humanData.SetHumanCreate(requets);

                response.Status = VariableGlobal.StatusOk;
                response.Message = VariableGlobal.Message;
            }
            catch (Exception ex)
            {
                response.Status = VariableGlobal.StatusFail;
                response.Message = GetExceptionMessage(ex);
            }
            return response;
        }

        [HttpPut(Name = "SetHumanEdit")]
        public async Task<HumanDataResponse> SetHumanEdit(HumanModel requets)
        {
            var response = new HumanDataResponse();
            try
            {
                await humanData.SetHumanEdit(requets);

                response.Status = VariableGlobal.StatusOk;
                response.Message = VariableGlobal.Message;
            }
            catch (Exception ex)
            {
                response.Status = VariableGlobal.StatusFail;
                response.Message = GetExceptionMessage(ex);
            }
            return response;
        }

        private string GetExceptionMessage(Exception ex)
        {
            return ex.Message == "One or more errors occurred." ? ex.InnerException.InnerException.Message : ex.Message;
        }
    }
}