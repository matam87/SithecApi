using Microsoft.AspNetCore.Mvc;
using SithecWS.Api.Data;
using SithecWS.Api.Models;

namespace SithecWS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanController : ControllerBase
    {
        private static readonly HumanData humanData = HumanData.GetHumanData();

        [HttpGet(Name = "GetHuman")]
        public async Task<List<HumanModel>> GetHuman()
        {
            var response = await humanData.GetHumanModel();
            return response;
        }
    }
}