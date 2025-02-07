using EPortalApplication.Models;
using Newtonsoft.Json.Linq;

namespace EPortalApplication.Services
{
    public class JsonService
    {
        public List<Degree> UseJArrayParseInNewtonsoftJson()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "degrees.json");

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("degrees.json not found", filePath);
                }

                using StreamReader reader = new(filePath);
                var json = reader.ReadToEnd();

                var jarray = JArray.Parse(json);

                List<Degree> degrees = jarray.ToObject<List<Degree>>() ?? new List<Degree>();

                return degrees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading degrees.json: {ex.Message}");
                return new List<Degree>();
            }
        }

        public List<string> ReadTeachingSkillsFromJson()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "TeachingSkills.json");

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("TeachingSkills.json not found", filePath);
                }

                using StreamReader reader = new(filePath);
                var json = reader.ReadToEnd();

                var jarray = JArray.Parse(json);

                List<string> TeachingSkills = jarray.Select(jtoken => jtoken.ToString()).ToList();

                return TeachingSkills;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading TeachingSkills.json: {ex.Message}");
                return new List<string>();
            }
        }

        public List<string> ReadDevelopmentSkillsFromJson()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "DevelopmentSkills.json");
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("DevelopmentSkills.json not found", filePath);
                }
                using StreamReader reader = new(filePath);
                var json = reader.ReadToEnd();

                var jarray = JArray.Parse(json);

                List<string> DevelopmentSkills = jarray.Select(jtoken => jtoken.ToString()).ToList();
                return DevelopmentSkills;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading degrees.json: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
