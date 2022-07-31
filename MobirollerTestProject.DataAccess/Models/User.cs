using System;
using System.Collections.Generic;

#nullable disable

namespace MobirollerTestProject.DataAccess.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
