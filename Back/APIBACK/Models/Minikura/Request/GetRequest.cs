using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Models.Minikura.Request
{
    public class GetRequest : AuthRequest
    {
        public string item_id { get; set; }
        public string customer_id { get; set; }
        public string storage_status { get; set; }
        public string privacy_status { get; set; }
        public string common01 { get; set; }
        public string common02 { get; set; }
        public string common03 { get; set; }
        public string common04 { get; set; }
        public string common05 { get; set; }
        public string common06 { get; set; }
        public string common07 { get; set; }
        public string common08 { get; set; }
        public string common09 { get; set; }
        public string common10 { get; set; }
    }
}
