using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Databases
{
    public class DronesDbContext:DbContext
    {
        #region Constructors
        public DronesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DronesDbContext()
        {
        }

        #endregion
        #region Public Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //deuxieme posibilité de faire
            //modelBuilder.ApplyConfiguration();
            //modelBuilder.Entity<Drone>().HasKey(item => item.Matricule);
            modelBuilder.ApplyConfiguration(new EntityConfigurations.DroneEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfigurations.HealthStatusEntityTypeConfiguration());
        }
        #endregion
        #region Properties
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Drone>HealthStatuses { get; set; }
        #endregion
    }
}
