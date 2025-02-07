using Entities.Models;

namespace EPortalApplication.Services
{
    public class SkillsService
    {
        private readonly HttpClient _httpClient;

        public SkillsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<List<SkillModel>> GetTeachingSkillsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SkillModel>>("api/TeachingSkill");
            return response ?? new List<SkillModel>();
        }

        public async Task<List<SkillModel>> GetTeachingSkillsByIdAsync(string uid)
        {
            var response = await _httpClient.GetFromJsonAsync<List<SkillModel>>($"api/TeachingSkill/{uid}");
            return response ?? new List<SkillModel>();
        }

        public async Task DeleteTeachingSkill(string uid)
        {
            await _httpClient.DeleteAsync($"api/TeachingSkill/{uid}");
        }

        public async Task CreateTeachingSkill(SkillModel skill)
        {
            await _httpClient.PostAsJsonAsync("api/TeachingSkill", skill);
        }

        public async Task UpdateTeachingSkill(SkillModel skill, string uid)
        {
            await _httpClient.PutAsJsonAsync($"api/TeachingSkill/{uid}", skill);
        }

        public async Task<List<SkillModel>> GetDevelopmentSkillsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<SkillModel>>("api/DevelopmentSkill");
            return response ?? new List<SkillModel>();
        }

        public async Task<List<SkillModel>> GetDevelopmentSkillsByIdAsync(string uid)
        {
            var response = await _httpClient.GetFromJsonAsync<List<SkillModel>>($"api/DevelopmentSkill/{uid}");
            return response ?? new List<SkillModel>();
        }

        public async Task DeleteDevelopmentSkill(string uid)
        {
            await _httpClient.DeleteAsync($"api/DevelopmentSkill/{uid}");
        }

        public async Task CreateDevelopmentSkill(SkillModel skill)
        {
            await _httpClient.PostAsJsonAsync("api/DevelopmentSkill", skill);
        }

        public async Task UpdateDevelopmentSkill(SkillModel skill, string uid)
        {
            await _httpClient.PutAsJsonAsync($"api/DevelopmentSkill/{uid}", skill);
        }

    }
}
