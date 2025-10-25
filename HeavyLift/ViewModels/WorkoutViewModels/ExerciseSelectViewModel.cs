using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Models;
using HeavyLift.Models.Constants;
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
        [ObservableProperty]
        private ObservableCollection<string> _muscleGroupsDisplay = new ObservableCollection<string>( MuscleGroups.AllGroups);
        [ObservableProperty]
        private string _selectedMuscleGroups = "All";
        [ObservableProperty]
        private bool _selectMuscleGroupsVisible = false;


        public ExerciseSelectViewModel(IServiceProvider serviceProvider, FileService fileService)
        {
            _fileService = fileService;
            LoadExercises();
            _displayedExercisesList = new ObservableCollection<ExerciseModel>(_exerciseList);
            _muscleGroupsDisplay.Insert(0, "All");
        }

        private async Task LoadExercises()
        {
            _exerciseList = new ObservableCollection<ExerciseModel>(await _fileService.LoadAllExercise());
        }

        [RelayCommand]
        private async Task AddExerciseToPlan(ExerciseModel exercise)
        {
            if (exercise == null)
                return;
            for(int i =0; i<_trainingPlan.plan.Count(); i++)
            {
                if(exercise.name == _trainingPlan.plan[i].name)
                {
                    await Application.Current.MainPage.ShowPopupAsync(new MessagePopup(exercise.name +  " is already in this plan"));
                    return;
                }
            }
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

        [RelayCommand]
        private void OpenSelectMuscleGroupMenu()
        {
            SelectMuscleGroupsVisible = true;
        }

        [RelayCommand]
        private void CloseSelectMuscleGroupMenu() 
        {
            SelectMuscleGroupsVisible = false;
        }

        [RelayCommand]
        private void SelectMuscleGroupFilter(object content)
        {
            var radiobutton = content as RadioButton;

            if(radiobutton == null)
            {
                return;
            }

            string muscleGroup = radiobutton.Value.ToString();

            if (muscleGroup != null)
            {
                SelectedMuscleGroups = muscleGroup;
                ApplyFilters();
            }
        }

        [RelayCommand]
        private void ApplyFilters()
        {
            DisplayedExercisesList.Clear();
            foreach (var exercise in _exerciseList)
            {
                bool ContainsMucleGroup = false;
                if( SelectedMuscleGroups != "All")
                {
                    if (exercise.musclegroups.Contains(SelectedMuscleGroups))
                    {
                        ContainsMucleGroup = true;
                    }
                }
                bool FoundInSearch = false;
                if (string.IsNullOrEmpty(_searchText))
                {
                    FoundInSearch = true;
                }
                else
                {
                    if (exercise.name.Contains(_searchText))
                    {
                        FoundInSearch = true;
                    }
                }
                if(ContainsMucleGroup && FoundInSearch)
                {
                    DisplayedExercisesList.Add(exercise);
                }
            }
        }
    }
}
