using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Databases
{
    public class DroneDbContextFactory : IDesignTimeDbContextFactory<DronesDbContext>
    {
        #region fields

        #endregion
        #region Public Methods
        public DronesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DronesDbContext>();
            optionsBuilder.UseSqlServer("Server=BOURASS\\SQLEXPRESS;Database=SuiviDesDrones;TrustServerCertificate=True;Trusted_Connection=True;");

            return new DronesDbContext(optionsBuilder.Options);
        }
        #endregion
    }
}
