using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Services.Interfaces
{
    public interface IModelsStorage
    {
        Task<Guid> AddModel(string itemId, Stream objStream, Stream textureStream);
        Stream GetObj(string id);
        Task<Stream> GetTexture(string id);
        Task<object> UnrealModel(string id);
        //Task<byte[]> UnrealTexture(string id);
    }
}
