using HeavyLift.Models;
using HeavyLift.ViewModels.WorkoutViewModels;

namespace HeavyLift.Views.WorkoutViews;

[QueryProperty(nameof(TrainingPlanModel), "TrainingPlanModel")]
public partial class TrainingPlanCreatorView : ContentPage
{
    private readonly TrainingPlanCreatorViewModel _viewModel;

    public TrainingPlanModel TrainingPlanModel
    {
        set {
            _viewModel.TrainingPlan = value;
        }
    }
    public TrainingPlanCreatorView(TrainingPlanCreatorViewModel vm)
	{
		InitializeComponent();
        _viewModel = vm;
		BindingContext = vm;
    }
}