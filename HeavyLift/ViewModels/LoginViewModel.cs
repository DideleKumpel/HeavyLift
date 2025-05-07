using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeavyLift.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AuthentitacionService _authentitacionService;

        [ObservableProperty]
        public string _emailInput;
        [ObservableProperty]
        public string _passwordInput;
        [ObservableProperty]
        public string _errorMessage;


        [RelayCommand]
        public async Task Login()
        {
            ErrorMessage = "";
            if (!IsValidEmail(EmailInput))
            {
                ErrorMessage += "Invalid email format.\n";
            }
            if(string.IsNullOrWhiteSpace(PasswordInput))
            {
                ErrorMessage = "Please fill in all fields.\n";
                return;
            }

            try
            {
                var result = await _authentitacionService.GetAuthorizationAsync(EmailInput, PasswordInput);
                if (!result.success)
                {
                    ErrorMessage = result.message;
                    PasswordInput = "";
                    return;
                }
                Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();
            }
            catch {
                ErrorMessage = "Error occured while loggin try again later.";
                return;
            }

        }
        [RelayCommand]
        public void SwitchToRegisterPage()
        {
            
        }

        public LoginViewModel(AuthentitacionService authservice, IServiceProvider serviceProvider)
        {
            ErrorMessage = "";
            _authentitacionService = authservice;
            _serviceProvider = serviceProvider;
            TryToLogIn();
        }

        private async void TryToLogIn()
        {
            try
            {
                string token = await SecureStorage.GetAsync("AuthTokenKey");
                if (string.IsNullOrEmpty(token))
                {
                    return;
                }
                bool succes = await _authentitacionService.RefreshToken(token);
                if(succes)
                {
                    Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();
                }
            }
            catch { }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            return System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }
}
