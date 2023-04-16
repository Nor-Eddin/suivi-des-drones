using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{
    public class SqlServerDroneDataLayer : IDroneDatalayer
    {
        #region Fields
        private readonly DronesDbContext? context = null;
        #endregion
        #region Constructor
        public SqlServerDroneDataLayer(DronesDbContext context)
        {
            this.context = context;
        }

        #endregion
        #region Public Methods
        public List<Drone> GetList()
        {
            #region a modifier
            //using var context = new DronesDbContext();
            #endregion
            
            var query=from item in this.context?.Drones
                      //where item.CreationDate == DateTime.Now
                      select item;
            return query.ToList();
            
        }
        public void AddOne(Drone drone)
        {
            this.context?.Drones.Add(drone);
            var entry = this.context?.Entry(drone.HealthStatus);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            this.context?.SaveChanges();
        }

        #endregion

    }
}
