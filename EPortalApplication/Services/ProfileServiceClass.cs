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

        public async Task<List<PersonalProfileModel>> GetProfileAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<PersonalProfileModel>>("api/PersonalProfile");
            return response ?? new List<PersonalProfileModel>();

        }

        public async Task<PersonalProfileModel> GetProfileByIdAsync(string uid)
        {
            var response = await _httpClient.GetFromJsonAsync<PersonalProfileModel>($"api/PersonalProfile/{uid}");
            return response ?? new PersonalProfileModel();
        }

        public async Task DeleteProfile(string uid)
        {
           var IsTrue= await _httpClient.DeleteAsync($"api/PersonalProfile/{uid}");
            Console.WriteLine(IsTrue);

        }

        public async Task CreateProfile(PersonalProfileModel profile)
        {
            var response = await _httpClient.PostAsJsonAsync("api/PersonalProfile", profile);
            Console.WriteLine(response);
        }
    }
}
