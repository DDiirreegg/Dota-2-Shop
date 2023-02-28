using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full name")]
        public string Name { get; set; }
    }
}
