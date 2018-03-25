using APIBACK.Models.Minikura;
using APIBACK.Models.Minikura.Request;
using APIBACK.Models.Minikura.Response;
using APIBACK.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIBACK.Services.Implementations
{
    public class MinikuraAPI : IMinikuraAPI
    {
        private HttpClient http = new HttpClient()
        {
            BaseAddress = new Uri("https://junction-tokyo.minikura.com/v1/minikura/")
        };
        public async Task<BaseResponse<StoringResponse>> DeleteItem(DeleteRequest param)
        {
            var uri = http.GetUri("item", param.AsDictionary());
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            var res = await http.SendAsync(request);
            var a = res.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<BaseResponse<StoringResponse>>(a);
        }

        public async Task<BaseResponse<Thing>> GetItem(GetRequest param)
        {
            var uri = http.GetUri("item", param.AsDictionary());
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var res = await http.SendAsync(request);
            var a = res.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<BaseResponse<Thing>>(a);
        }

        public Task<BaseResponse<StoringResponse>> Issuing(IssuingRequest param)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<StoringResponse>> PatchItem(PatchRequest param)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<StoringResponse>> PostItem(PostRequest param)
        {
            var uri = http.GetUri("item", new { }.AsDictionary());
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new FormUrlEncodedContent(param.AsDictionary())
            };
            var res = await http.SendAsync(request);
            var a = res.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<BaseResponse<StoringResponse>>(a);
        }

        public Task<BaseResponse<StoringResponse>> Stotring(StoringRequest param)
        {
            throw new NotImplementedException();
        }
    }
}
