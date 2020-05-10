using Microsoft.EntityFrameworkCore;
using WindowSettings.DataAccess.Base;
using WindowSettings.DataAccess.DbContext;

namespace WindowSettings.DataAccess.Repositories
{
    public class WindowSettingsRepository : GenericRepository<Entities.Settings.WindowSettings>
    {
        public WindowSettingsRepository(EliseDbContext context) : base(context)
        {
        }
    }
}
