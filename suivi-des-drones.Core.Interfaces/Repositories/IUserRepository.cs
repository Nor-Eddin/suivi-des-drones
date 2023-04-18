using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// verify precense of user with login (email) and password (hash)
        /// </summary>
        /// <param name="user"></param>
        CompleteUser LogIn(AuthenticationUser user);
    }
}
