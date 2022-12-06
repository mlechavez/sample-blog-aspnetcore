using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blog.Data {
    public class FileManager : IFileManager {
        private string imagepath;

        public FileManager(IConfiguration config) {
            imagepath = config["Path:Images"];
        }

        public FileStream ImageStream(string file) {
            return new FileStream(Path.Combine(imagepath, file), FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile file) {
            try {
                var path = Path.Combine(imagepath);

                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }

                var mimeType = file?.FileName.Substring(file.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mimeType}";

                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create)) {
                    await file.CopyToAsync(fileStream);
                };

                return fileName;
            } catch (Exception e) {

                Console.WriteLine(e.Message);
            }
            return string.Empty;
        }
    }
}
