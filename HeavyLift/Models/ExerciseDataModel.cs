using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Models
{
    public class ExerciseDataModel
    {
        public List<ExerciseModel> BaseExercises { get; set; } = new();
        public List<ExerciseModel> CustomExercises { get; set; } = new();
    }
}
