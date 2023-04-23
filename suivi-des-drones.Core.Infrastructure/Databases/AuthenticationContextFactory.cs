using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Databases
{
    public class AuthenticationContextFactory : IDesignTimeDbContextFactory<AuthenticationContext>
    {
        #region fields

        #endregion
        #region Public Methods
        public AuthenticationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthenticationContext>();
            optionsBuilder.UseSqlServer("Server=BOURASS\\SQLEXPRESS;Database=SuiviDesDrones;TrustServerCertificate=True;Trusted_Connection=True;");

            return new AuthenticationContext(optionsBuilder.Options);
        }
        #endregion
    }
}
