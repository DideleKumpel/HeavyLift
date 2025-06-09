using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using HeavyLift.Models;
using HeavyLift.Services;
using HeavyLift.Views.DialogPopups;
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

        [ObservableProperty]
        private TrainingPlanModel _selectedTrainingPlan;
        [ObservableProperty]
        private bool _trainingMenuVisibile;

        public WorkoutViewModel(IServiceProvider serviceProvider, TrainingPlanService trainingPlanService)
        {
            LoadingIsVisible = true;
            ErrorLoadMessage = false;
            TrainingMenuVisibile = false;
            _serviceProvider = serviceProvider;
            _trainingPlanService = trainingPlanService;
            GetTrainingPlans();
        }

        [RelayCommand]
        private async Task CreateNewTrainingPlan() {
            await Shell.Current.GoToAsync("TrainingPlanCreatorView", new Dictionary<string, object> { { "TrainingPlanModel", TrainingPlans[0] } });  //change after the buging to create new training plan

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
            if( trainingPlan == null)
            {
                return;
            }
            SelectedTrainingPlan = trainingPlan;
            TrainingMenuVisibile = true;
        }

        [RelayCommand]
        private void CloseTrainingMenu()
        {
            TrainingMenuVisibile = false;
            SelectedTrainingPlan = null;
        }

        [RelayCommand]
        private void EditTrainingPlan()
        {
            //first need to do workout creator page and logics
            // Implement the logic to edit the selected training plan
        }

        [RelayCommand]
        private async Task DeleteTrainingPlan()
        {
            var resoult = await Application.Current.MainPage.ShowPopupAsync(new ConformationPopup());
            if ( resoult is bool boolResoult)
            {
                if (boolResoult == true)
                {
                    var result = await _trainingPlanService.DeleteTrainingPlan(SelectedTrainingPlan.id);
                    if (result.success)
                    {
                        await Application.Current.MainPage.ShowPopupAsync(new MessagePopup("Training plan deleted successfully"));
                        TrainingPlans.Remove(SelectedTrainingPlan);
                        CloseTrainingMenu();
                    }
                    else
                    {
                         await Application.Current.MainPage.ShowPopupAsync(new MessagePopup(result.message));
                        return;
                    }
                }
            }
            else
            {
                return;
            }
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
