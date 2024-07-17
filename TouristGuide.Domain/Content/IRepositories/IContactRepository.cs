using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Domain.Common.Models;

namespace TouristGuide.Domain.Content.IRepositories
{
    public interface IContentRepository
    {
        Task<CommonResponseModel> GetContactPageDetails();
    }
}
