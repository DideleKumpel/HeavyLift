using HeavyLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Services
{
    public class TrainingPlanService
    {
        private readonly HttpClient _httpClient;
        public TrainingPlanService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }

        public async Task<(bool success, string message)> GetTrainingPlans()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/TrainingPlan/GetTrainingPlans");
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
            catch (Exception e)
            {
                return (false, "GetTrainingPlans failed: An error occurred while connecting to the server");
            }
        }

        public async Task<(bool success, string message)> DeleteTrainingPlan(int trainingPlanId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/TrainingPlan/DeleteTrainingPlan?PlanId={trainingPlanId}");
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
            catch (Exception e)
            {
                return (false, "An error occurred while connecting to the server");
            }
        }
    }
}
