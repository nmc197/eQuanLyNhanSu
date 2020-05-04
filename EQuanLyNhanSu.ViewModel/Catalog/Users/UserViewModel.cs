using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.ViewModel.Catalog.Users
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
    }
}
