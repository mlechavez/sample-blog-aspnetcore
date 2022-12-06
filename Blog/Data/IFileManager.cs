using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Data {
    public interface IFileManager {
        FileStream ImageStream(string file);
        Task<string> SaveImage(IFormFile file);
    }
}
