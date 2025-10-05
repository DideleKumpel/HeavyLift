using HeavyLift.Models;
using HeavyLift.ViewModels.WorkoutViewModels;

namespace HeavyLift.Views.WorkoutViews;

public partial class ExerciseSelectView : ContentPage
{
    private readonly ExerciseSelectViewModel _viewModel;

    public TrainingPlanModel TrainingPlanModel
    {
        set
        {
            _viewModel.TrainingPlan = value;
        }
    }
    public ExerciseSelectView(ExerciseSelectViewModel vm)
	{
		InitializeComponent();
        _viewModel = vm;
		BindingContext = vm;
    }
}