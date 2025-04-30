using AutoMapper;
using LMS.DTOs;
using LMS.Repositories.Interfaces;
using LMS.Services.Interfaces;

namespace LMS.Services.Implement
{
    public class ModulesService:IModulesService
    {
        private readonly IModulesRepository _repository;
        private readonly IMapper _mapper;

        public ModulesService(IModulesRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<IEnumerable<ModulesDto>> GetAllModulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ModulesDto> GetModulesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModulesDto> AddModulesAsync(EditModulesDto modulesDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateModulesAsync(EditModulesDto moduleDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteModulesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
