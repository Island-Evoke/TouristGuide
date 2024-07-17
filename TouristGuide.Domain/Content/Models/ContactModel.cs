using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Domain.Content.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string? Email { get; set; }
        public string? Phone_Numbers { get; set; }
        public string? Bussiness_Numbers { get; set; }
        public string? Global_Numbers { get; set; }
        public string? Whatsapp_Numbers { get; set; }
        public string? Address { get; set; }
        public string? Help_Contact { get; set; }
    }
}
