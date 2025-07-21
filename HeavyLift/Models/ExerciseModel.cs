using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Models
{
    public class ExerciseModel
    {
        public string name { get; set; } = null!;

        public string description { get; set; } = null!;

        public string musclegroups { get; set; } = null!;

        public string type { get; set; } = null!;

        public byte[] image { get; set; } = null!;

        public ObservableCollection<RepModel> reps { get; set; } = null!;
    }
}
