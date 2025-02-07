using System.Net.Http.Json;
using System.Text.Json;
using Entities.Models;
namespace EPortalApplication.Services
{
    public class EducationService
    {
        private readonly HttpClient? _httpClient;

        public EducationService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }
        public async Task<List<EducationModel>> GetEducationAsync()
        {
            var response = await _httpClient!.GetFromJsonAsync<List<EducationModel>>("api/Education");
            return response ?? new List<EducationModel>();
        }
        public async Task<List<EducationModel>> GetEducationByIdAsync(string uid)
        {
            var response = await _httpClient!.GetFromJsonAsync<List<EducationModel>>($"api/Education/{uid}");
            return response ?? new List<EducationModel>();
        }
        public async Task DeleteEducation(string uid)
        {
            await _httpClient!.DeleteAsync($"api/Education/{uid}");
            
        }
        public async Task CreateEducation(EducationModel education)
        {
            await _httpClient!.PostAsJsonAsync("api/Education", education);
            
        }
    }
}
