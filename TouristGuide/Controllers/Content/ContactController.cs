using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristGuide.Application.Content.IServices;

namespace TouristGuide.API.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;   
        public ContactController(IContactService contactService) {
            
            _contactService = contactService;
        }

        [HttpGet]
        [Route("GetContactPageDetails")]
        public async Task<IActionResult> GetContactPageDetails()
        {
            var response=await _contactService.GetContactPageDetails();
            return Ok(new { result = response });
        }
    }
}
