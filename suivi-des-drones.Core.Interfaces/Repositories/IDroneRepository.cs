using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Interfaces.Repositories
{
    /// <summary>
    /// Contrat pour tout repository qui gére des drone
    /// </summary>
    public interface IDroneRepository
    {
        List<Drone> GetAll();
        /// <summary>
        /// récupére un drone par son matricule
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>
        Drone GetOne(string matricule);
        /// <summary>
        /// Ajout ou updated'un drone
        /// </summary>
        /// <param name="drone"></param>
        void Save(Drone drone);
        
    }
}
