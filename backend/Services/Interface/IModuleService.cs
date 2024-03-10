using backend.Models;

namespace backend.Services.Interface
{
    public interface IModuleService
    {
        Task<bool> AddModule(Module module);
        Task<bool> UpdateModule(int moduleId, Module module);
        Task<bool> DeleteModule(int moduleId);
        Task<Module> GetModuleById(int moduleId);
        Task<string> GetModuleName(int moduleId);
    }
}
