using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Models
{
    public class WorkoutList
    {
        [Key]
        public int WorkoutId { get; set; }

        public string UserId { get; set; }

        public int Exercise_One { get; set; }

        public int Exercise_Two { get; set; }
        public int Exercise_Three { get; set; }
        public int Exercise_Four { get; set; }
        public int Exercise_Five { get; set; }
        public int Exercise_Six { get; set; }
        public int Exercise_Seven { get; set; }
        public int Exercise_Eight { get; set; }
        public int Exercise_Nine { get; set; }
        public int Exercise_Ten { get; set; }
        public string Exercise_Name { get; set; }

    }
}
