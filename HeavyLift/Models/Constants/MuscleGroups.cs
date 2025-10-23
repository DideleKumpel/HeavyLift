using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Models.Constants
{
    public static class MuscleGroups
    {
        public static readonly string[] AllGroups = new[]
        {
            "Chest",
            "Back",
            "Legs",
            "Shoulders",
            "Biceps",
            "Triceps",
            "Abs",
            "Glutes",
            "Calves",
            "Forearms",
            "Cardio",
            "Core",
            "Full Body"
        };

        public static readonly Dictionary<string, string[]> Categories = new()
        {
            {
                "Upper Body", new[]
                {
                    "Chest", "Back", "Shoulders", "Biceps", "Triceps"
                }
            },
            {
                "Lower Body", new[]
                {
                    "Legs", "Glutes", "Calves"
                }
            },
            {
                "Core", new[]
                {
                    "Abs", "Core"
                }
            },
            {
                "Other", new[]
                {
                    "Cardio", "Full Body", "Forearms"
                }
            }
        };
    }
}
