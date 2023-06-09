﻿using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace suivi_des_drones.Core.Infrastructure.DataLayers
{
    public class SqlServerDroneDataLayer : BaseSqlDatalayer,IDroneDatalayer
    {
        #region Fields
        
        #endregion

        #region Constructor
        public SqlServerDroneDataLayer(DronesDbContext context):base(context)
        {
            
        }

        #endregion
        #region Public Methods
        public List<Drone> GetList()
        {
            #region a modifier
            //using var context = new DronesDbContext();
            #endregion
            //recupére les donnée des drone et les healthstatus mais avec include et pas avec les jointures, via la clefs etrangere... bcp + rapide
            var query=from item in this.Context?.Drones.Include(item=>item.HealthStatus)
                      //where item.CreationDate == DateTime.Now
                      select item;
            return query.ToList();
            
        }
        public Drone? GetOne(string matricule)
        {
            return this.Context.Drones
                .Include(item => item.HealthStatus)
                .First(item => item.Matricule == matricule);
        }

        public void AddOne(Drone drone)
        {

            Context?.Drones.Add(drone);
            //var entry = this.context?.Entry(drone.HealthStatus);           
            //entry.State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            Context?.SaveChanges();

        }

        #endregion

    }
}
