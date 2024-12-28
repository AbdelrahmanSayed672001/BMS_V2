using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BMS_V2.Models
{
    public class ApplicationUser:IdentityUser
    {
        [StringLength(maximumLength: 50, ErrorMessage = "maximum lenght is 50 please enter a name less than that")]
        [Display(Name = "First name")]
        public string FirstName { get; set; } =string.Empty;


        [StringLength(maximumLength: 50, ErrorMessage = "maximum lenght is 50 please enter a name less than that")]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

    }


}
