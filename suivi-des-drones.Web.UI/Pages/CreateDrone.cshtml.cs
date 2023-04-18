using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Diagnostics;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    
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
        //deuxi�me facons de faire
        //public void OnPost(string matricule,string dateCreation)//attention au nom des param�tres, mettre ceux du nom dans input
        //troisi�me facons (facons object) le binding par une class
        //public void OnPost(Drone drone)//par le binding=>(TestClass drone)
        public void OnPost()
        {
            //premi�re facon de faire
            //string matricule = this.Request.Form["matricule"];

            this.repository.Save(this.MonDrone);
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
