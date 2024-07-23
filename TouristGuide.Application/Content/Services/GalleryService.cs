using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Application.Content.IServices;
using TouristGuide.Domain.Common.Models;

namespace TouristGuide.Application.Content.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages\\");

        public GalleryService() {
           
        }
        public async  Task<CommonResponseModel> UploadGallery(string Title, List<IFormFile> files, string Description)
        {
            try
            {
                if (!Directory.Exists(_storagePath))
                {
                    Directory.CreateDirectory(_storagePath);
                }
                if(!Directory.Exists(_storagePath + Title)) 
                    {
                    Directory.CreateDirectory(_storagePath + Title);
                }
                if (files == null || files.Count == 0)
                {
                    return new CommonResponseModel() { responseCode = 0, responseMsg = "No Files", returnData = null };
                }

                var uploadedFilePaths = new List<string>();

                foreach (var file in files)
                {
                    var filePath = Path.Combine(_storagePath+Title, file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    uploadedFilePaths.Add(filePath);
                }

                return new CommonResponseModel() { responseCode = 1, responseMsg = "Uploaded", returnData = uploadedFilePaths };
            }
            catch (Exception ex) {
                return new CommonResponseModel() { responseCode = 0, responseMsg = ex.Message, returnData = null };
            }
          
            
        }
    }
}
