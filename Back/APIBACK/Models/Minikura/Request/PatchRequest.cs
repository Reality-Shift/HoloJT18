using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Models.Minikura.Request
{
    public class PatchRequest : PostRequest
    {
        public string item_id { get; set; }
    }
}
