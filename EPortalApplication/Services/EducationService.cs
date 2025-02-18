using System.Net.Http.Json;
using Entities.DTOs;
using Entities.DTOMappers;
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

        public async Task<List<EducationDTO>> GetEducationAsync()
        {
            try
            {
                var response = await _httpClient!.GetFromJsonAsync<List<EducationDTO>>("api/Education");
                return response ?? new List<EducationDTO>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<EducationDTO>();
            }
        }

        public async Task<List<EducationModel>> GetEducationByIdAsync(string uid)
        {
            try
            {
                var response = await _httpClient!.GetFromJsonAsync<List<EducationModel>>($"api/Education/{uid}");
                return response ?? new List<EducationModel>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<EducationModel>();
            }
        }

        public async Task DeleteEducation(string uid)
        {
            try
            {
                await _httpClient!.DeleteAsync($"api/Education/{uid}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task CreateEducation(EducationModel education)
        {
            try
            {
                await _httpClient!.PostAsJsonAsync("api/Education", education);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task UpdateEducation(int eduID, EducationModel education)
        {
            try
            {
                await _httpClient!.PutAsJsonAsync($"api/Education/{eduID}", education);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task DeleteEducation(int id)
        {
            try
            {
                await _httpClient!.DeleteAsync($"api/Education/{id}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error is : {ex.Message}");
            }
        }
    }
}
