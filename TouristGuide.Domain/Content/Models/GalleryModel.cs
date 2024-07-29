using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Domain.Content.Models
{
    public class GalleryModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public IEnumerable<object>? Files { get; set; }
    }
}
