using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Domain.Common.Models;

namespace TouristGuide.Application.Content.IServices
{
    public interface IContactService
    {
        Task<CommonResponseModel> GetContactPageDetails();
    }
}
