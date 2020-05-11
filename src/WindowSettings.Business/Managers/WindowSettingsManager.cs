using System.Threading.Tasks;
using WindowSettings.Business.Interfaces;
using WindowSettings.Common.Exception;
using WindowSettings.DataAccess.Repositories;
using WindowSettings.DataObjects.Mappers;
using WindowSettings.DataObjects.Model;

namespace WindowSettings.Business.Managers
{
    public class WindowSettingsManager : IWindowSettingsManager
    {
        private readonly WindowSettingsRepository _windowSettingsRepository;
        public WindowSettingsManager(WindowSettingsRepository windowSettingsRepository) 
        {
            _windowSettingsRepository = windowSettingsRepository;
        }
        public async Task<WindowSettingsDto> CreateWindowSettingsAsync(WindowSettingsDto model)
        {
            var windowSettingsEntity = await _windowSettingsRepository.AddAsync(model.ToCommand());
            return windowSettingsEntity.ToQueries();
        }

        public async Task<WindowSettingsDto> UpdateWindowSettingsAsync(WindowSettingsDto model)
        {
            var windowSettings = await _windowSettingsRepository.GetItemByIdAsync(model.Id);
            if(windowSettings == null) throw new EliseException(400, "Doesn't exist in system.");
            var windowSettingsEntity = await _windowSettingsRepository.UpdateAsync(model.ToCommand());
            return windowSettingsEntity.ToQueries();
        }
    }
}
