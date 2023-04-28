using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    public class OneDroneModel : PageModel
    {
        #region Fields
        private readonly IDroneRepository repository;
        #endregion
        #region Constructor
        public OneDroneModel(IDroneRepository repository)
        {
            this.repository = repository;
        }
        #endregion
        #region public methods

        public IActionResult OnGet()
        {
            IActionResult result = this.Page();
            try
            {
            this.Drone = this.repository.GetOne(this.Matricule);

            }
            catch (Exception)
            {
                result= this.NotFound();               
            }
            return result;
        }
        #endregion
        #region properties
        [BindProperty(SupportsGet =true)]
        public string Matricule { get; set; }
        public Drone? Drone { get; set; }
        #endregion
    }
}
