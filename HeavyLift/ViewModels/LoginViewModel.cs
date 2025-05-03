using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.ViewModels
{
    internal partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        public string _emailInput;
        [ObservableProperty]
        public string _passwordInput;
        [ObservableProperty]
        public string _errorMessage;

        public string Tekscior { get; set; }

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
        }
        [RelayCommand]
        public void SwitchToRegisterPage()
        {
            
        }

        public LoginViewModel()
        {
            ErrorMessage = "";
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
