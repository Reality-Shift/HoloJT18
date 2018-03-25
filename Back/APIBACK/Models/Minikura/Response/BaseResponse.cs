using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Models.Minikura.Response
{
    public class BaseResponse<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<T>  results { get; set; }
    }
}
