using LMS.DTOs;

namespace LMS.Services.Interfaces
{
    public interface IModulesService
    {
        Task<ModulesDto> GetModulesByIdAsync(int id);
        Task<IEnumerable<ModulesDto>> GetAllModulesAsync();
        Task<ModulesDto> AddModulesAsync(EditModulesDto modulesDto);
        Task UpdateModulesAsync(EditModulesDto moduleDto);
        Task DeleteModulesAsync(int id);
    }
}
