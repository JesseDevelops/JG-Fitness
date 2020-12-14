using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneJesseGajda.Models
{
    public class ExerciseMetrics
    {
        [Key]
        public int ExerciseMetricId { get; set; } 
        public string UserId { get; set; }

        public int ExerciseId { get; set; }

        public DateTime Date { get; set; }

        public double WeightUsed { get; set; }

    }
}
