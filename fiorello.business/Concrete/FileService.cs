using fiorello.business.Abstract;
using fiorello.data.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiorello.business.Concrete
{
    public class FileService : IFileService
    {

        readonly private IFilesReadRepository _filesReadRepository;
        readonly private IFilesWriteRepository _filesWriteRepository;


        public FileService(IFilesReadRepository filesReadRepository, IFilesWriteRepository filesWriteRepository)
        {
            _filesReadRepository = filesReadRepository;
            _filesWriteRepository = filesWriteRepository;
        }

        public bool CheckSize(IFormFile file, int maxSize)
        {
            if (file.Length / 1024 < maxSize)
            {
                throw new Exception($"hecmi {maxSize} kicik olmalidir");
            }
            return true;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public bool IsImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                
                throw new Exception("bos deyer");
            }


            if (!file.ContentType.StartsWith("image/"))
            {
                throw new Exception("Verilen tipde deyil");
            }


            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Verilen tipde deyil");
               
            }

            return true;
        }


        public async Task<string> UploadAsync(IFormFile file)
        {
            var filename = $"{Guid.NewGuid()}_{file.FileName}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}
