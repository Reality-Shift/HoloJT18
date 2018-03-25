using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBACK.Models.Minikura.Request;
using APIBACK.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace APIBACK.Controllers
{
    [Produces("application/json")]
    [Route("api/Work")]
    public class WorkController : Controller
    {
        private readonly IMinikuraAPI minikuraAPI;
        private readonly IModelsStorage modelsStorage;

        public WorkController(
            IMinikuraAPI minikuraAPI,
            IModelsStorage modelsStorage)
        {
            this.minikuraAPI = minikuraAPI;
            this.modelsStorage = modelsStorage;
        }

        public async Task<IActionResult> Get()
        {
            var requestData = HttpContext.Request.Query.To<GetRequest>();
            var finded = await minikuraAPI.GetItem(requestData);
            return Json(finded);
        }
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile obj, IFormFile texture)
        {
            if (obj == null || texture == null)
                return BadRequest();
            var requestData = HttpContext.Request.Form.To<PostRequest>();
            var finded = await minikuraAPI.PostItem(requestData);
            var id = await modelsStorage.AddModel(
                finded.results[0].item_id,
                obj.OpenReadStream(),
                texture.OpenReadStream());
            return Json(finded);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var requestData = HttpContext.Request.Query.To<GetRequest>();
            var finded = await minikuraAPI.GetItem(requestData);
            foreach (var item in finded.results)
            {
                await minikuraAPI.DeleteItem(new DeleteRequest
                {
                    item_id = item.item_id
                });
            }
            return Json(finded.results.Select(s => s.item_id));
        }
    }
}