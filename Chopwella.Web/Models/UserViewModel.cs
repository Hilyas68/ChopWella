using Chopwella.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chopwella.Web.Models
{
    public class UserViewModel
    {
        [Required, StringLength(100)]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Do not match")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual IEnumerable<Role> Roles { get; set; }

    }
}
