using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeavyLift.Models;
using System.Collections.ObjectModel;
using HeavyLift.Services;
using CommunityToolkit.Mvvm.Input;

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
    }
}
