using HeavyLift.ViewModels;

namespace HeavyLift.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}