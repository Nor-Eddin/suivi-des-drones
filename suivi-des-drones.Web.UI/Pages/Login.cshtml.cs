using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    public class LoginModel : PageModel
    {
        #region Fields
        private readonly IUserRepository repository;
        #endregion
        #region Constructor
        public LoginModel(IUserRepository repository)
        {
            this.repository = repository;
        }
        #endregion
        #region Public Methods
        public IActionResult OnPost()
        {
            IActionResult result=this.Page();
            try
            {
                this.HttpContext.Session.SetInt32("UserId", 1234);
                result = this.RedirectToPage("/Index");
            }catch (Exception ex)
            {

            }
            return result;
        }
        #endregion
        #region Proprieties
        [BindProperty]
        public AuthenticationUser User { get; set; }
        #endregion
    }
}
