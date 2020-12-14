using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CapstoneJesseGajda.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public double UserCurrentWeight { get; set; }
        [PersonalData]
        public double UserHeight { get; set; }
        [PersonalData]
        public DateTime UserDOB { get; set; }
        [PersonalData]
        public string UserCountry { get; set; }
        [PersonalData]
        public string UserPostalCode { get; set; }
        [PersonalData]
        public string NewCustomUsername { get; set; }
        public int Rating { get; set; }
        public string ProfileImageUrl { get; set; }


    }
}
