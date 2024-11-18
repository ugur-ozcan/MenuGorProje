using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuGor.Application.DTOs
{
    // MenuGor.Application/DTOs/AdminDto.cs
    public class AdminDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Sadece oluşturma ve güncelleme için kullanılacak
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
    }
}
