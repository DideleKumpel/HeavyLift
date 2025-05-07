using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<(bool success, string message)> CreateAccountAsync( string Nickname, string Email, string Password)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/User/CreateAccount", new { Email = Email, Nickname = Nickname, Password = Password });
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, content);
                }
                else
                {
                    return (false, content);
                }
            }
            catch(Exception e)
            {
                return (false, "Register failed: An error occurred while connecting to the server");
            }
        }
    }
}
