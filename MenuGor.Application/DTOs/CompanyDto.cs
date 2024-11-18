using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGor.Application.DTOs
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int DealerId { get; set; }
        public int BranchCount { get; set; }
        public List<BranchDto> Branches { get; set; }
    }
}
