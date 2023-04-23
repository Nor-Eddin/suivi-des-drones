using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Diagnostics;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    [Authorize]
    public class CreateDroneModel : PageModel
    {
        #region Fields
        private readonly IDroneRepository repository;
        #endregion
        #region Public Methods
        public CreateDroneModel(IDroneRepository repository)
        {
            this.repository = repository;
        }
        public void OnGet()
        {
        }
        //deuxiéme facons de faire
        //public void OnPost(string matricule,string dateCreation)//attention au nom des paramétres, mettre ceux du nom dans input
        //troisiéme facons (facons object) le binding par une class
        //public void OnPost(Drone drone)//par le binding=>(TestClass drone)

        public IActionResult OnPost()
        {
            IActionResult result = this.Page();
            if (this.ModelState.IsValid)
            {


            //premiére facon de faire
            //string matricule = this.Request.Form["matricule"];

            this.repository.Save(this.MonDrone);

            this.MonDrone = new();
            this.ModelState.Clear();
                result = this.RedirectToPagePermanent("./CreateDrone");
            }
            return result;

        }
        #endregion
        #region properties
        [BindProperty]
        public Drone MonDrone { get; set; }

        #endregion
        //public class TestClass
        //{
        //    public string Matricule { get; set; }
        //}
    }
}
