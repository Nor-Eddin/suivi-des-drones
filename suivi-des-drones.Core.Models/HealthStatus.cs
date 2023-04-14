using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Models
{
 
    //Facon avec enum
    //public enum HealthStatus
    //{
    //    ok=0,
    //    broken=-1,
    //    repair=-2
    //}

    //Facon class
      //public class HealthStatus
      //{
      //    public static HealthStatus OK = new HealthStatus() { Id = 0, Label = "OK" };
      //    public static HealthStatus Broken = new HealthStatus() { Id = -1, Label = "Cassé" };
      //    public static HealthStatus Repair = new HealthStatus() { Id = -2, Label = "En réparation" };
      //    public int Id { get; set; } = 0;
      //    public string Label { get; set; } = default!;
      //}

    //Facon record en 2 exemples

    //public record HearthStatus(int Id,string Label);

    public record HealthStatus
    {
        public static HealthStatus OK = new HealthStatus() { Id = 0, Label = "OK" };
        public static HealthStatus Broken = new HealthStatus() { Id = -1, Label = "Cassé" };
        public static HealthStatus Repair = new HealthStatus() { Id = -2, Label = "En réparation" };
        public int Id { get; init; }
        public string Label { get; init; } = default!;

    }

}
