using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Models;
using HeavyLift.Services;
using Newtonsoft.Json;
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
        private readonly IServiceProvider _serviceProvider;
        private readonly TrainingPlanService _trainingPlanService;

        [ObservableProperty]
        private ObservableCollection<TrainingPlanModel> trainingPlans;
        [ObservableProperty]
        private bool _loadingIsVisible;
        [ObservableProperty]
        private bool _errorLoadMessage;
        private TrainingPlanModel _selectedTrainingPlan;

        public WorkoutViewModel(IServiceProvider serviceProvider, TrainingPlanService trainingPlanService)
        {
            LoadingIsVisible = true;
            ErrorLoadMessage = false;
            _serviceProvider = serviceProvider;
            _trainingPlanService = trainingPlanService;
            GetTrainingPlans();
        }

        [RelayCommand]
        private void StartTraining(TrainingPlanModel trainingPlan)
        {
            //first need to do workout session page and logics
            // implement the logic to start the training
        }

        [RelayCommand]
        private void StartEmptyWorkout() 
        {
            //first need to do workout session page and logics
            // Implement the logic to stop an empty workout
        }

        [RelayCommand]
        private void ShowTrainingMenu(TrainingPlanModel trainingPlan)
        {
            // Implement the logic to show the training menu for the selected training plan
        }

        [RelayCommand]
        private void EditTrainingPlan()
        {
            //first need to do workout creator page and logics
            // Implement the logic to edit the selected training plan
        }

        [RelayCommand]
        private void DeleteTrainingPlan()
        {
            // Implement the logic to delete the selected training plan
        }
        [RelayCommand]
        private void ShowTrainingPlanDetails(TrainingPlanModel trainingPlan)
        {
            //first need to do workout deatal page and logics
            // Implement the logic to show the details of the selected training plan
        }

        private async Task GetTrainingPlans()
        {
            var result = await _trainingPlanService.GetTrainingPlans();
            if (result.success)
            {
                try
                {
                    ObservableCollection<TrainingPlanModel> trainingPlans = JsonConvert.DeserializeObject<ObservableCollection<TrainingPlanModel>>(result.message);
                    TrainingPlans = trainingPlans;
                }
                catch (Exception e)
                {
                    TrainingPlans = new ObservableCollection<TrainingPlanModel>();
                    ErrorLoadMessage = true;
                }
            }
            else
            {
                TrainingPlans = new ObservableCollection<TrainingPlanModel>();
                ErrorLoadMessage = true ;
            }
            LoadingIsVisible = false;
        }
    }
}
