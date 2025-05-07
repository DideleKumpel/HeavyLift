using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Services;
using HeavyLift.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.ViewModels
{
    public partial class RegisterViewModel: ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserService _userService;

        [ObservableProperty]
        public string _nicknameInput;
        [ObservableProperty]
        public string _emailInput;
        [ObservableProperty]
        public string _passwordInput;
        [ObservableProperty]
        public string _passwordRepeatInput;
        [ObservableProperty]
        public string _errorMessage;

        [RelayCommand]
        public void SwitchToLoginPanel()
        {
            Application.Current.MainPage = _serviceProvider.GetRequiredService<LoginView>();
        }

        [RelayCommand]
        public async Task RegisterAccount()
        {
            ErrorMessage = "";
            if( PasswordInput != PasswordRepeatInput)
            {
                ErrorMessage = "Password are not the same.";
                return;
            }
            //Rest validation is API site
            var response = await _userService.CreateAccountAsync( NicknameInput, EmailInput, PasswordInput);
            if (response.success)
            {
                ErrorMessage = response.message;
                Application.Current.MainPage = _serviceProvider.GetRequiredService<LoginView>();
            }
            ErrorMessage = response.message;
        }

        public RegisterViewModel(IServiceProvider serviceProvider, UserService userService)
        {
            ErrorMessage = "";
            _serviceProvider = serviceProvider;
            _userService = userService;
        }
    }
}
