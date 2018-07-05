using Chopwella.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Chopwella.Infrastructure.Identity.IdentityModel;

namespace Chopwella.Web.ViewModels
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

        public string RoleName { get; set; }

        public virtual IEnumerable<AppRole> Roles { get; set; }
    }
}