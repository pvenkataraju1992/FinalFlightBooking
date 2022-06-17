using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.UserManagement.Api.Models
{
    public class UserRegister
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}
