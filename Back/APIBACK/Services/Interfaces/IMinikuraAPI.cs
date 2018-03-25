using APIBACK.Models.Minikura;
using APIBACK.Models.Minikura.Request;
using APIBACK.Models.Minikura.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Services.Interfaces
{
    public interface IMinikuraAPI
    {
        Task<BaseResponse<StoringResponse>> Stotring(StoringRequest param);
        Task<BaseResponse<Thing>> GetItem(GetRequest param);
        Task<BaseResponse<StoringResponse>> PostItem(PostRequest param);
        Task<BaseResponse<StoringResponse>> PatchItem(PatchRequest param);
        Task<BaseResponse<StoringResponse>> Issuing(IssuingRequest param);
        Task<BaseResponse<StoringResponse>> DeleteItem(DeleteRequest param);

    }
}
