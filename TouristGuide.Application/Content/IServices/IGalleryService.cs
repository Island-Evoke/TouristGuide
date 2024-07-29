using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Domain.Common.Models;

namespace TouristGuide.Application.Content.IServices
{
    public interface IGalleryService
    {
        Task<CommonResponseModel> UploadGallery(string Title, List<IFormFile> files, string Description);
        Task<CommonResponseModel> GetGalleryFilesByFolderName(string Title);
        Task<CommonResponseModel> GetAllGalleryFiles();
    }
}
