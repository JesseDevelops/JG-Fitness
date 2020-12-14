using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Models
{
    public class Exercises
    {
        [Key]
        public int ExerciseID { get; set; }
        public string Exercise_Name { get; set; }
    }
}
