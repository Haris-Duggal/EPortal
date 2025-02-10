using Entities.DTOs;
using Entities.Models;

public class SkillsService
{
    private readonly HttpClient? _httpClient;

    public SkillsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task<List<SkillDTO>> GetTeachingSkillsByIdAsync(string uid)
    {
        try
        {
            var response = await _httpClient!.GetFromJsonAsync<List<SkillDTO>>($"api/TeachingSkill/{uid}");
            return response ?? new List<SkillDTO>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return new List<SkillDTO>();
        }
    }

    public async Task<List<SkillDTO>> GetDevelopmentSkillsByIdAsync(string uid)
    {
        try
        {
            var response = await _httpClient!.GetFromJsonAsync<List<SkillDTO>>($"api/DevelopmentSkill/{uid}");
            return response ?? new List<SkillDTO>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return new List<SkillDTO>();
        }
    }

    public async Task CreateTeachingSkill(CreateSkillDTO skill)
    {
        try
        {
            var response = await _httpClient!.PostAsJsonAsync("api/TeachingSkill", skill);
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task CreateDevelopmentSkill(CreateSkillDTO skill)
    {
        try
        {
            var response = await _httpClient!.PostAsJsonAsync("api/DevelopmentSkill", skill);
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
    public async Task UpdateTeachingSkill(SkillModel skill)
    {
        try
        {
            await _httpClient!.PutAsJsonAsync($"api/TeachingSkill/{skill.SkillID}", skill);
        }
        catch(Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }

    }
}
