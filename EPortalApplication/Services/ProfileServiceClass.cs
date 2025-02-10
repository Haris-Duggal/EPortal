using Entities.DTOs;
using Entities.DTOMappers;
using Entities.Models;

namespace EPortalApplication.Services
{
    public class ProfileServiceClass
    {
        private readonly HttpClient? _httpClient;

        public ProfileServiceClass(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<List<ProfileDTO>> GetProfileAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProfileDTO>>("api/PersonalProfile");
                return response ?? new List<ProfileDTO>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<ProfileDTO>();
            }
        }

        public async Task<ProfileDTO> GetProfileByIdAsync(string uid)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ProfileDTO>($"api/PersonalProfile/{uid}");
                return response ?? new ProfileDTO();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new ProfileDTO();
            }
        }

        public async Task DeleteProfile(string uid)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/PersonalProfile/{uid}");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task CreateProfile(CreateProfileDTO profile)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/PersonalProfile", profile);
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

