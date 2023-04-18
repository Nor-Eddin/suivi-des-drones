using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{
    /// <summary>
    /// class parente pour tous les datalayer qui auront besoin du context
    /// </summary>
    public abstract class BaseSqlDatalayer
    {
        #region Fields
        private readonly DronesDbContext? context=null;
        #endregion
        #region Constructor
        public BaseSqlDatalayer(DronesDbContext context)
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
            //recupére les donnée des drone et les healthstatus mais avec include et pas avec les jointures, via la clefs etrangere... bcp + rapide
            var query = from item in this.context?.Drones.Include(item => item.HealthStatus)
                            //where item.CreationDate == DateTime.Now
                        select item;
            return query.ToList();

        }
        #endregion
        #region Properties
        protected DronesDbContext Context { get => this.context; }
        #endregion
    }
}
