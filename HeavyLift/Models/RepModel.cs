using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HeavyLift.Models
{
    public class RepModel
    {
        public int Reps { get; set; }
        public float Weight { get; set; }
        public float Distance { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

    }
}
