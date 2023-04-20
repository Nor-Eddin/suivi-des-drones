using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Application.Repositories
{
    /// <summary>
    /// Repository qui gére le CRUD
    /// </summary>
    /// <returns></returns>
    public class DroneRepository:IDroneRepository
    {
        #region Fields
        private readonly IDroneDatalayer datalayer;
        #endregion
        #region Constructors
        public DroneRepository(IDroneDatalayer datalayer)
        {
            this.datalayer = datalayer;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Return la liste compléte des drones
        /// </summary>
        /// <returns></returns>

        public List<Drone> GetAll()
        {
            return this.datalayer.GetList();
           
        }
        public void Save(Drone drone)
        {

            drone.healthStatusId = HealthStatus.OK.Id;

            this.datalayer.AddOne(drone);
        }
        #endregion
    }
}
