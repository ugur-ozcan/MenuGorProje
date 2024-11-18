using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGor.Application.DTOs
{
    // MenuGor.Application/DTOs/BranchDto.cs
    public class BranchDto : UserDto
    {
        public int CompanyId { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
    }
}
