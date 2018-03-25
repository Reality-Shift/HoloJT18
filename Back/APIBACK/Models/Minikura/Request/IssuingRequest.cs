using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Models.Minikura.Request
{
    public class IssuingRequest : AuthRequest
    {

        public string item_id { get; set; }
    }
}
