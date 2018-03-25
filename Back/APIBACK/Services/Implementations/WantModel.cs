using APIBACK.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Services.Implementations
{
    public class WantModel : IWantModel
    {
        private string targetId;
        public object GetWantedModel()
        {
            if (targetId == null)
                return new { status = 0 };
            var res = new { status = 1, id = targetId };
            targetId = null;
            return res;
        }

        public void SetWantModel(string id)
        {
            targetId = id;
        }
    }
}
