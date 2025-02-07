using Database;
using Entities.Models;
using Microsoft.Data.SqlClient;

namespace EPortal.Services
{
    public class EducationService : IEducationService
    {
        public async Task AddEducation(string procedureName, SqlParameter[] sp )
        {
            try
            {
                await DALCRUD.AddData(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<List<EducationModel>> GetAllEducation(string procedureName)
        {
            try
            {
               List<EducationModel> educations = await DALCRUD.GetEntitiesFromReadDataAsync<EducationModel>(procedureName);
                return educations;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null!;
            }
        }

        public async Task UpdateEducation(string procedureName, SqlParameter[] sp )
        {
            try
            {
                await DALCRUD.UpdateInfo<EducationModel>(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task DeleteEducation(string procedureName, SqlParameter[]sp)
        {
            try
            {
                await DALCRUD.DeleteInfo(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<List<EducationModel>> GetEducationByID(string procedureName, SqlParameter[] sp)
        {
            try
            {
               return await DALCRUD.GetEntitiesFromReadDataAsync<EducationModel>(procedureName, sp);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
            return null!;
        }
    }
}   