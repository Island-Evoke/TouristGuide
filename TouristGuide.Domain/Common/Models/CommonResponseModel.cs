using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristGuide.Domain.Common.Models
{
    public class CommonResponseModel
    {
        public string? responseMsg { get; set; }
        public int responseCode { get; set; }
        public IEnumerable<object>? returnData { get; set; }
    }
}
