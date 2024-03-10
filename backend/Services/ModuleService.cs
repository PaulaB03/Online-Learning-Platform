using backend.Data;
using backend.Models;
using backend.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ModuleService : IModuleService
    {
        private readonly DataContext _context;

        public ModuleService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddModule(Module module)
        {
            await _context.Modules.AddAsync(module);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateModule(int moduleId, Module module)
        {
            var existingModule = await _context.Modules.FindAsync(moduleId);
            if (existingModule == null)
            {
                return false;
            }

            existingModule.Name = module.Name;
            existingModule.Description = module.Description;

            _context.Modules.Update(existingModule);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteModule(int moduleId)
        {
            var module = await _context.Modules.FindAsync(moduleId);
            if (module == null)
            {
                return false;
            }

            _context.Modules.Remove(module);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Module> GetModuleById(int moduleId)
        {
            return await _context.Modules.FirstOrDefaultAsync(m => m.ModuleId == moduleId);
        }

        public async Task<string> GetModuleName(int moduleId)
        {
            var module = await _context.Modules.FindAsync(moduleId);
            if (module == null)
            {
                throw new Exception("Couldn't find module");
            }

            return module.Name;
        }
    }
}
