using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGor.Application.DTOs
{
    public class DealerDto : UserDto
    {
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
    }
}