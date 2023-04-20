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
    public class SqlServerUserDatalayer : BaseSqlDatalayer, IUserDataLayer
    {
        #region Fields

        #endregion
        #region Constructeur
        public SqlServerUserDatalayer(DronesDbContext context) : base(context)
        {
        }
        #endregion
        #region public methods

        public CompleteUser GetOne(string email, string password)
        {
            var result= this.Context?.Users?.Where(item => item.Login == email && item.Password == password).First();
            return result;
        }
        #endregion
        #region Properties

        #endregion
    }
}
