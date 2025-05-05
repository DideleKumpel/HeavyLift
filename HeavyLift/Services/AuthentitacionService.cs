using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Services
{
    internal class AuthentitacionService
    {
        private readonly HttpClient _httpClient;
        private string _apiBaseUrl = "https://7c13-84-40-218-81.ngrok-free.app";
        public AuthentitacionService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<(bool success, string message)> Login(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Authorization/login", new { Email = email, Password = password });
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                    if (result != null && result.Token != null)
                    {
                        await SecureStorage.SetAsync("AuthTokenKey" , result.Token);
                        return (true, "Login successful");
                    }
                    else
                    {
                        return (false, "Login failed:Invalid login response");
                    }
                }
                else
                {
                    return (false, "Login failed: Wrong e-mail or password");
                }
            }
            catch
            { 

                return (false, "Login failed: An error occurred while connecting to the server");
            }
        }
        private class LoginResult { public string Token { get; set; } }
    }

}
