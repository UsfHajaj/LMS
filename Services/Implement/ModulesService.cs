using AutoMapper;
using LMS.DTOs;
using LMS.Models.Courses;
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
        public async Task<IEnumerable<ModulesDto>> GetAllModulesAsync()
        {
            var modules =await _repository.GetAllModules();
            var modulesDto = _mapper.Map<IEnumerable<ModulesDto>>(modules);
            return modulesDto;
        }

        public async Task<ModulesDto> GetModulesByIdAsync(int id)
        {
            var module =await _repository.GetModulesById(id);
            return _mapper.Map<ModulesDto>(module);
        }

        public async Task<ModulesDto> AddModulesAsync(EditModulesDto modulesDto)
        {
            var module = _mapper.Map<Modules>(modulesDto);
            await _repository.AddAsync(module);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ModulesDto>(module);
        }

        public async Task UpdateModulesAsync(int id,EditModulesDto moduleDto)
        {
            var module = await _repository.GetByIdAsync(id);
            _mapper.Map(moduleDto, module);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteModulesAsync(int id)
        {
            var module =await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(module);
            await _repository.SaveChangesAsync();
        }
    }
}
