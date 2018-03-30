using APIBACK.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Services.Implementations
{
    public class InProjectStorage : IModelsStorage
    {
        private readonly string folderName;

        public InProjectStorage(IHostingEnvironment env)
        {
            folderName = Path.Combine(env.WebRootPath, "Models3D");
        }
        public async Task<Guid> AddModel(string itemId, Stream objStream, Stream textureStream)
        {
            var folderPath = Path.Combine(folderName, itemId);
            Directory.CreateDirectory(folderPath);
            var objPath = Path.Combine(folderPath, "model.obj");
            using (var fileStream = File.Create(objPath))
            {
                await objStream.CopyToAsync(fileStream);
            }
            var texturePath = Path.Combine(folderPath, "texture.jpg");
            using (var fileStream = File.Create(texturePath))
            {
                await textureStream.CopyToAsync(fileStream);
            }
            return Guid.Empty;
        }

        public Stream GetObj(string id)
        {
            var file = Path.Combine(folderName, id, "model.obj");
            if (!File.Exists(file)) return null;
            return File.OpenRead(file);
        }

        public Stream GetTexture(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetTexture(string id)
        {
            var file = Path.Combine(folderName, id, "texture.jpg");
            if (!File.Exists(file)) return null;
            return Task.FromResult(File.OpenRead(file) as Stream);
        }

        public async Task<object> UnrealModel(string id)
        {
            var file = Path.Combine(folderName, id, "model.obj");
            if (!File.Exists(file)) return null;
            ObjectWork.Class1.loadMesh(file,
                out var positions,
                out var texCors,
                out var normals,
                out var indices);
            for (int i = 0; i < indices.Count; i += 3)
            {
                var a = indices[i];
                indices[i] = indices[i + 2];
                indices[i + 2] = a;
            }
            return new
            {
                pos = positions.Select(S => S.ToString()),
                texCors = texCors.Select(S => S.ToString()),
                indices
            };
        }

        //public async Task<byte[]> UnrealTexture(string id)
        //{
        //    var file = Path.Combine(folderName, id, "texture.jpg");
        //    if (!File.Exists(file)) return null;
        //    var bytes =  await File.ReadAllBytesAsync(file);
        //    return bytes;
        //}
    }
}
