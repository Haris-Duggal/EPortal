using Entities.DTOs;
using Entities.Models;
using EPortalApplication.Components.Pages.Profile;

public class SkillsService
{
    private readonly HttpClient? _httpClient;

    public SkillsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }

    public async Task<List<SkillModel>> GetTeachingSkillsByIdAsync(string uid)
    {
        try
        {
            var response = await _httpClient!.GetFromJsonAsync<List<SkillModel>>($"api/TeachingSkill/{uid}");
            return response ?? new List<SkillModel>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return new List<SkillModel>();
        }
    }

    public async Task<List<SkillModel>> GetDevelopmentSkillsByIdAsync(string uid)
    {
        try
        {
            var response = await _httpClient!.GetFromJsonAsync<List<SkillModel>>($"api/DevelopmentSkill/{uid}");
            return response ?? new List<SkillModel>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return new List<SkillModel>();
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

    public async Task UpdateDevelopmentSkill(SkillModel skill)
    {
        try
        {
            await _httpClient!.PutAsJsonAsync($"api/DevelopmentSkill/{skill.SkillID}", skill);
        }
        catch( Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteTeachingSkill(int id)
    {
        try
        {
            await _httpClient!.DeleteAsync($"api/DevelopmentSkill/{id}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteDevelopmentSkill(int id)
    {
        try
        {
            await _httpClient!.DeleteAsync($"api/DevelopmentSkill/{id}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
