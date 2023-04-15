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
        #region Properties

        public DbSet<Drone> Drones { get; set; }
        #endregion
    }
}
