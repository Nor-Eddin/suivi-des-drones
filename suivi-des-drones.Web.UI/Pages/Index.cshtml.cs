using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Infrastructure.Databases;
using suivi_des_drones.Core.Infrastructure.DataLayers;
using suivi_des_drones.Core.Interfaces.Infrastructures;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        #region Fields
        private readonly ILogger<IndexModel> _logger;
        private readonly IDroneRepository repository;
            
        #endregion
        #region constructor
        public IndexModel(ILogger<IndexModel> logger,
            IConfiguration configuration,
            IDroneRepository repository)
        {
           
            _logger = logger;
            this.repository = repository;
        }

        //public void OnGet()
        //{
        //    var drone = new Drone();
        //}

        public IActionResult OnGet()
        {
            IActionResult result=this.Page();
                 this.SetListOfDrones();
                 this.SetListOfStatus();
            return result;
        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    this.SetListOfDrones();
        //    this.SetListOfStatus();
        //    return this.Page();
        //}
        #endregion
        #region Public methods

        #endregion
        #region Internal Methods
        private void SetListOfDrones()
        {

            //this.Drones.Add(new () { Matricule = "54XXD0", CreationDate = DateTime.Now,HealthStatus=HealthStatus.Broken});
            //this.Drones.Add(new () { Matricule = "15FDR14", CreationDate = DateTime.Now.AddDays(-180) });
            //var datalayer = new SqlServerDroneDataLayer();
            this.Drones=this.repository.GetAll();
        }
        private void SetListOfStatus()
        {
            this.StatusList.Add(HealthStatus.OK);
            this.StatusList.Add(HealthStatus.Broken);
            this.StatusList.Add(HealthStatus.Repair);
        }
        #endregion
        #region Properties
        public List<Drone> Drones { get; set; } = new();
        public List<HealthStatus>StatusList { get; set; } = new();
        #endregion
    }
}