
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Services
{
    public class AuthentitacionService
    {
        private readonly HttpClient _httpClient;
        public AuthentitacionService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<(bool success, string message)> GetAuthorizationAsync(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Authorization/GetAuthorization", new { Email = email, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                    if (result != null && result.Token != null)
                    {
                        await SecureStorage.SetAsync("AuthTokenKey" , result.Token);
                        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Barer", result.Token);
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
