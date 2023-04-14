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
    public class DroneRepository
    {
        /// <summary>
        /// Return la liste compléte des drones
        /// </summary>
        /// <returns></returns>
        #region Public Methode
        public List<Drone> GetAll()
        {
            return new ();
        }
        #endregion
    }
}
