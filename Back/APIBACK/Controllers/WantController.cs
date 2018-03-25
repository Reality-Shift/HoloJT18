using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBACK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBACK.Controllers
{
    [Produces("application/json")]
    [Route("api/Want")]
    public class WantController : Controller
    {
        private readonly IWantModel wantModel;

        public WantController(IWantModel wantModel)
        {
            this.wantModel = wantModel;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(wantModel.GetWantedModel());
        }
        [HttpPost("{id}")]
        public IActionResult Post(string id)
        {
            wantModel.SetWantModel(id);
            return Json(new {});
        }
    }
}