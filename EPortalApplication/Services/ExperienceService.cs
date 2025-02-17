using Entities.DTOs;
using Entities.Models;

public class ExperienceService
{
    private readonly HttpClient? _httpClient;

    public ExperienceService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task<List<ExperienceDTO>> GetExperienceAsync()
    {
        try
        {
            var response = await _httpClient!.GetFromJsonAsync<List<ExperienceDTO>>("api/Experience");
            return response ?? new List<ExperienceDTO>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return new List<ExperienceDTO>();
        }
    }

    public async Task<List<ExperienceModel>> GetExperienceByIdAsync(string uid)
    {
        try
        {
            var response = await _httpClient!.GetFromJsonAsync<List<ExperienceModel>>($"api/Experience/{uid}");
            return response ?? new List<ExperienceModel>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return new List<ExperienceModel>();
        }
    }

    public async Task DeleteExperience(int uid)
    {
        try
        {
            var response = await _httpClient!.DeleteAsync($"api/Experience/{uid}");
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task CreateExperience(ExperienceModel experience)
    {
        try
        {
            var response = await _httpClient!.PostAsJsonAsync("api/Experience", experience);
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateExperience(ExperienceModel experience)
    {
        try
        {
            var response = await _httpClient!.PutAsJsonAsync($"api/Experience/{experience.ExperienceID}", experience);
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
