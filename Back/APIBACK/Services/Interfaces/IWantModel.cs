using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Services.Interfaces
{
    public interface IWantModel
    {
        void SetWantModel(string id);
        object GetWantedModel();
    }
}
