using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    public class Mechanic
    {
        public string Name { get; set; }
        public int DateOfBirth { get; set; }
        public int DateOfEmployment { get; set; }
        public int EndDate { get; set; }
        public bool CanFixMotor { get; set; }
        public bool CanFixTires { get; set; }
        public bool CanFixBrakes { get; set; }
        public bool CanFixWindshield { get; set; }
        public bool CanFixVehicleBody { get; set; }




    }
}
