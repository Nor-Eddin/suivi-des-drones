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
    }
}
