using LMS.DTOs;
using LMS.Models.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace LMS.Repositories.Interfaces
{
    public interface IModulesRepository:IGenericRepository<Modules>
    {
        Task<Modules> GetModulesById(int id);
        Task<IEnumerable<Modules>> GetAllModules();

    }
}
