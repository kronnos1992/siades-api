using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace siades.Services.Interfaces
{
    public interface IPhotoRepository
    {
        Task<byte[]> GetAsync(string filename);
        Task<string> SaveAsync(byte[] photo);
    }
}