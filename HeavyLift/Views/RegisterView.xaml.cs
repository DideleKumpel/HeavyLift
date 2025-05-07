using HeavyLift.ViewModels;

namespace HeavyLift.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}