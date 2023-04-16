using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Databases.EntityConfigurations
{
    internal class DroneEntityTypeConfiguration : IEntityTypeConfiguration<Drone>
    {
        #region Public methods

        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            //troisiéme facons de faire
            builder.HasKey(item => item.Matricule);
            builder.ToTable("Drone");
        }
        #endregion
    }
}
