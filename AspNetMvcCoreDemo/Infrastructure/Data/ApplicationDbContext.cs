#region using

using Microsoft.EntityFrameworkCore;
using ShowInfos.Core.Models;

#endregion

namespace ShowInfos.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string connection;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext(string connection)
        {
            this.connection = connection;
        }

        //public DbSet<Ninja> Ninjas { get; set; }
        //public DbSet<Plant> Plants { get; set; }
        //public DbSet<Pirate> Pirates { get; set; }
        //public DbSet<Zombie> Zombies { get; set; }

        public DbSet<Doctors> Show_Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connection))
            {
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}