using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StefanBrunotteWebPage.Models
{
    public class UserViewModel
    {
        [Display(Name="User ID")]
        public int Id { get; set; }
        [Required, Display(Name = "UserName"), StringLength(20, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required, Display(Name = "Password")]
        public string Password { get; set; }
    }
}
