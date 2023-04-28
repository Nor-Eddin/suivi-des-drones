using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Interfaces.Infrastructures
{
    /// <summary>
    /// isole l'accés a la Base de donnée
    /// </summary>
    public interface IDroneDatalayer
    {
        /// <summary>
        /// retourne la liste complete
        /// </summary>
        /// <returns></returns>
        List<Drone> GetList();
        /// <summary>
        /// appel la base pour retourner un drone
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>
        Drone GetOne(string matricule);
        /// <summary>
        /// Permet l'ajout d'un nouveau drone dans la BDD
        /// </summary>
        void AddOne(Drone drone);
    }
}
