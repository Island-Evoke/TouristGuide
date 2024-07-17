using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Application.Content.IServices;
using TouristGuide.Domain.Common.Models;
using TouristGuide.Domain.Content.IRepositories;
using TouristGuide.Infastructure.Content.Repositories;

namespace TouristGuide.Application.Content.Services
{
    public class ContactService :IContactService
    {
        private readonly IContentRepository _contactRepository;
        public ContactService(IContentRepository contactRepository) { 
            _contactRepository = contactRepository;
        }
        //Contact Us Page
       public async Task<CommonResponseModel> GetContactPageDetails()
        {
           var response=await _contactRepository.GetContactPageDetails();
           return response;
        }
    }
}
