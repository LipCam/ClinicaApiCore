using ClinicaApiCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApiCore.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region ----- Medicos -----
        public DbSet<Medicos> Medicos { get; set; }
        #endregion

        #region ----- Procedimentos -----
        public DbSet<Procedimentos> Procedimentos { get; set; }
        #endregion
    }
}
