using Entities.Models;

namespace EPortalApplication.Services
{
    public class ExperienceService
    {
        HttpClient? _httpClient;
        public ExperienceService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }
        public async Task<List<ExperienceModel>> GetExperienceAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ExperienceModel>>("api/Experience");
            return response ?? new List<ExperienceModel>();
        }
        public async Task<List<ExperienceModel>> GetExperienceByIdAsync(string uid)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ExperienceModel>>($"api/Experience/{uid}");
            return response ?? new List<ExperienceModel>();
        }
        public async Task DeleteExperience(string uid)
        {
            var IsTrue = await _httpClient.DeleteAsync($"api/Experience/{uid}");
            Console.WriteLine(IsTrue);
        }
        public async Task CreateExperience(ExperienceModel experience)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Experience", experience);
            Console.WriteLine(response);
        }
    }
}
