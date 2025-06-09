using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Models;
using HeavyLift.Views.DialogPopups;
using System;
using System.Collections.Generic;
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
            // Initialize the view model properties or commands if needed
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

    }
}