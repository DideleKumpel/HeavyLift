using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Models;
using HeavyLift.Services;
using HeavyLift.Views.DialogPopups;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.ViewModels.WorkoutViewModels
{
    public partial class ExerciseSelectViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly FileService _fileService;
        private TrainingPlanModel _trainingPlan;
        public TrainingPlanModel TrainingPlan { set {
                _trainingPlan = value;
            } }

        private ObservableCollection<ExerciseModel> _exerciseList;

        [ObservableProperty]
        private ObservableCollection<ExerciseModel> _displayedExercisesList;
        [ObservableProperty]
        private string _searchText;


        public ExerciseSelectViewModel(IServiceProvider serviceProvider, FileService fileService)
        {
            _fileService = fileService;
            LoadExercises();
            _displayedExercisesList = new ObservableCollection<ExerciseModel>(_exerciseList);
        }

        private async Task LoadExercises()
        {
            _exerciseList = new ObservableCollection<ExerciseModel>(await _fileService.LoadAllExercise());
        }

        [RelayCommand]
        private void Test()
        {
            int abc = 2;
        }

        [RelayCommand]
        private async Task AddExerciseToPlan(ExerciseModel exercise)
        {
            if (exercise == null)
                return;
            var result = await Application.Current.MainPage.ShowPopupAsync(new ConformationMessagePopup("Do you wanna add this exercise? \n" + exercise.name));
            if (result is bool boolResoult)
            {
                if (boolResoult == true)
                {
                    exercise.reps = new ObservableCollection<RepModel>();
                    _trainingPlan.plan.Add(exercise);
                    await Shell.Current.GoToAsync("..");
                }
            }
            else
            {
                return;
            }
            

        }
    }
}
