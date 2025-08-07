using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Models;
using HeavyLift.Views.DialogPopups;
using HeavyLift.Views.WorkoutViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.ViewModels.WorkoutViewModels
{
    public partial class TrainingPlanCreatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private TrainingPlanModel _trainingPlan;

        public TrainingPlanCreatorViewModel()
        {
            
        }

        [RelayCommand]
        public async Task GoBackBtn()
        {
            var result = await Application.Current.MainPage.ShowPopupAsync(new ConformationMessagePopup("Do you wanna go back? \n Progress wont be saved."));
            if (result is bool boolResoult)
            {
                if (boolResoult == true)
                {
                        await Shell.Current.GoToAsync("..");
                }
            }
            else
            {
                return;
            }
        }

        [RelayCommand]
        private void AddSet( ExerciseModel exercise)
        {
            exercise.reps.Add(new RepModel());
        }
        [RelayCommand]
        private void RemoveSet(ExerciseModel exercise)
        {
            if(exercise.reps.Count > 0)
            exercise.reps.RemoveAt(exercise.reps.Count - 1);
        }

        [RelayCommand]
        private async Task AddExercise()
        {
            await Shell.Current.GoToAsync(nameof(ExerciseSelectView));
        }
    }
}