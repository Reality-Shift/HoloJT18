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
    [Route("api/Models")]
    public class ModelsController : Controller
    {
        private readonly IModelsStorage modelsStorage;

        public ModelsController(IModelsStorage modelsStorage)
        {
            this.modelsStorage = modelsStorage;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var target = await modelsStorage.UnrealModel(id);
            if (target == null)
                return BadRequest();
            return Json(target);
        }

        [HttpGet("texture/{id}")]
        public async Task<IActionResult> GetTexture(string id)
        {
            var target = await modelsStorage.GetTexture(id);
            if (target == null)
                return BadRequest();
            return File(target, "image/jpg");
        }
        [HttpGet("obj/{id}")]
        public async Task<IActionResult> GetObj(string id)
        {
            var target = modelsStorage.GetObj(id);
            if (target == null)
                return BadRequest();
            return File(target, "text/plain");
        }
    }
}