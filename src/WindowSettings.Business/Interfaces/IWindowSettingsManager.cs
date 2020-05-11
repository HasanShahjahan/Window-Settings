using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WindowSettings.DataObjects.Model;

namespace WindowSettings.Business.Interfaces
{
    public interface IWindowSettingsManager
    {
        Task<WindowSettingsDto> CreateWindowSettingsAsync(WindowSettingsDto model);
        Task<WindowSettingsDto> UpdateWindowSettingsAsync(WindowSettingsDto model);
    }

}
