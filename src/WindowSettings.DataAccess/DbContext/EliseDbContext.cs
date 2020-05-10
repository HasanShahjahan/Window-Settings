using Microsoft.EntityFrameworkCore;

namespace WindowSettings.DataAccess.DbContext
{
    public class EliseDbContext :  Microsoft.EntityFrameworkCore.DbContext
    {
        public EliseDbContext(DbContextOptions<EliseDbContext> options) : base(options)
        {
        }
    }
}
