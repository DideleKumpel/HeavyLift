using CommunityToolkit.Mvvm.ComponentModel;
using HeavyLift.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.ViewModels
{
    public partial class WorkoutViewModel: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<TrainingPlanModel> trainingPlans;

        public WorkoutViewModel()
        {
            trainingPlans = new ObservableCollection<TrainingPlanModel>() { new TrainingPlanModel() { name = "123 456789 01234 5678 901 23 4567890" }, new TrainingPlanModel() { name = "FBW" }, new TrainingPlanModel() { name = "Upper3" } };
        }
    }
}
