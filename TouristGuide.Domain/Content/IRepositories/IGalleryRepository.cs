using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Domain.Common.Models;
using TouristGuide.Domain.Content.Models;

namespace TouristGuide.Domain.Content.IRepositories
{
    public interface IGalleryRepository
    {
        Task<CommonResponseModel> UploadGallery(string Title, List<IFormFile> files, string Description);
       // Task<CommonResponseModel> GetAllGalleryFiles(string Title);
        Task<GalleryModel> GetGalleryFilesByFolderName(string Title);
    }
}
