using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeavyLift.Models;
using System.Collections.ObjectModel;

namespace HeavyLift.ViewModels.WorkoutViewModels
{
    partial class ExerciseSelectViewModel : ObservableObject
    {
        private TrainingPlanModel _trainingPlan;

        private ObservableCollection<ExerciseDataModel> exerciseList;

        [ObservableProperty]
        private ObservableCollection<ExerciseDataModel> _displayedExercisesList;


        public ExerciseSelectViewModel()
        {

        }
    }
}
