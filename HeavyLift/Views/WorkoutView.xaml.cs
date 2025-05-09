using HeavyLift.ViewModels;

namespace HeavyLift.Views;

public partial class WorkoutView : ContentPage
{
	public WorkoutView(WorkoutViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}