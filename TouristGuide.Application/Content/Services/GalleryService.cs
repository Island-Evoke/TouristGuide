using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Application.Content.IServices;
using TouristGuide.Domain.Common.Models;
using TouristGuide.Domain.Content.IRepositories;
using TouristGuide.Domain.Content.Models;

namespace TouristGuide.Application.Content.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages\\");
        private readonly IGalleryRepository _galleryRepository;
        public GalleryService(IGalleryRepository galleryRepository) {
           
            _galleryRepository = galleryRepository;
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
                await _galleryRepository.UploadGallery(Title, files, Description);
                return new CommonResponseModel() { responseCode = 1, responseMsg = "Uploaded", returnData = uploadedFilePaths };
            }
            catch (Exception ex) {
                return new CommonResponseModel() { responseCode = 0, responseMsg = ex.Message, returnData = null };
            }
          
            
        }

        public async Task<CommonResponseModel> GetGalleryFilesByFolderName(string Title)
        {
            try
            {
                var directoryPath = Path.Combine(_storagePath, Title);
                if (!Directory.Exists(directoryPath))
                {
                    return new CommonResponseModel() { responseCode = 0, responseMsg = "Directory does not exist", returnData = null };
                }

                var files = Directory.GetFiles(directoryPath).Select(Path.GetFileName).ToList();

                 var dbfiles=  await _galleryRepository.GetGalleryFilesByFolderName(Title);

                return new CommonResponseModel() { responseCode = 1, responseMsg = "Success", returnData = files };
            }
            catch (Exception ex)
            {
                return new CommonResponseModel() { responseCode = 0, responseMsg = ex.Message, returnData = null };
            }
        }
        public async Task<CommonResponseModel> GetAllGalleryFiles()
        {
            List<GalleryModel> galleryList= new List<GalleryModel>();
            try
            {
                var directoryPath = _storagePath;
                if (!Directory.Exists(directoryPath))
                {
                    return new CommonResponseModel() { responseCode = 0, responseMsg = "Directory does not exist", returnData = null };
                }

                var allFiles = new List<string>();

                // Get all subdirectories under the root storage path
                var directories = Directory.GetDirectories(directoryPath);

                // Loop through each subdirectory and gather files
                foreach (var directory in directories)
                {
                    var files = Directory.GetFiles(directory).Select(Path.GetFileName);
                    string relativePath = "";
                    if (directory.StartsWith(_storagePath, StringComparison.OrdinalIgnoreCase))
                    {
                        relativePath= directory.Substring(_storagePath.Length);
                    }
                    var data= await _galleryRepository.GetGalleryFilesByFolderName(relativePath);
                    allFiles.AddRange(files);
                    string Title = directory;
                    string Description = "";
                    galleryList.Add(new GalleryModel() { Description=data.Description,Title=data.Title,Files=allFiles});
                   

                }

                return new CommonResponseModel() { responseCode = 1, responseMsg = "Success", returnData = galleryList };
            }
            catch (Exception ex)
            {
                return new CommonResponseModel() { responseCode = 0, responseMsg = ex.Message, returnData = null };
            }
        }
    }
}
