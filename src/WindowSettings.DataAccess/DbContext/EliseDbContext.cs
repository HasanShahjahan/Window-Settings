using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace WindowSettings.DataAccess.DbContext
{
    public class EliseDbContext :  Microsoft.EntityFrameworkCore.DbContext
    {
        public EliseDbContext(DbContextOptions<EliseDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.Settings.WindowSettings> WindowSettings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
