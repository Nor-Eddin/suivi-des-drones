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
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly IUserDataLayer layer;
        #endregion
        #region constructeur
        public UserRepository(IUserDataLayer layer)
        {
            this.layer = layer;
        }
        #endregion
        #region public methods

        public CompleteUser LogIn(AuthenticationUser user)
        {
            var userData=this.layer.GetOne(user.Login,user.Password);
            if(userData == null) throw new ArgumentException(nameof(user));
            return userData;
        }
        #endregion
        #region Properties

        #endregion
    }
}
