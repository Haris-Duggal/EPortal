using Entities.Models;

namespace EPortalApplication.Services
{
    public class ContactInfoService
    {
        private readonly HttpClient _httpClient;

        public ContactInfoService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task AddContactInfo(ContactInfoModel model)
        {
            try
            {
                await _httpClient!.PostAsJsonAsync("api/ContactInfo", model);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<List<ContactInfoModel>> GetContactbyID(string uid)
        {
            try
            {
                var response = await _httpClient!.GetFromJsonAsync<List<ContactInfoModel>>($"api/ContactInfo/{uid}");
                return response ?? new List<ContactInfoModel>();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<ContactInfoModel>();
            }
            
        }

        public async Task EditContactInfo(ContactInfoModel model)
        {
            try
            {
                await _httpClient!.PutAsJsonAsync($"api/ContactInfo/{model.fk_UserID}", model);
            }
            catch (Exception ex) {
                Console.Error.WriteLine($"Error is : {ex.Message}");
            
            }
        }
        public async Task DeleteContactInfo(string id)
        {
            try
            {
                await _httpClient!.DeleteAsync($"api/Contactinfo/{id}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"The Error is : {ex.Message}");
            }
        }
    }
}
