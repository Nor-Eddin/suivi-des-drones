using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
    /// <summary>
    /// Drones de l'application
    /// </summary>
    public class Drone
    {
        #region Properties
        //[Key]
        //[Required]
        public string Matricule { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        //public HealthStatus HealthStatus { get; set; } = HealthStatus.OK;
        public HealthStatus HealthStatus { get; set; } =null;
        public decimal healthStatusId { get; set; } = HealthStatus.OK.Id;
        #endregion
    }
}
