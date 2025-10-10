using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Models
{
    public class TrainingPlanModel
    {
        public int id { get; set; }
        public ObservableCollection<ExerciseModel> plan { get; set; } = null!;

        public string name { get; set; } = null!;
    }
}
