using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    public class DeliveryListModel : PageModel
    {
        #region Fields
        private readonly IDeliveryRepository repository;
        public List<Delivery> List { get; set; }=new List<Delivery>();
        #endregion
        #region constructeur
        public DeliveryListModel(IDeliveryRepository repository)
        {
            this.repository = repository;
        }

        #endregion
        public IActionResult OnGet()
        {
           this.List=this.repository.GetAll();

            return this.Page();
        }
    }
}
