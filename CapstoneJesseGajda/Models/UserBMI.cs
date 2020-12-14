using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Models
{
    public class UserBMI
    {
        [Key]
        public int Bmi_Id { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public double BMI { get; set; }

    }
}
