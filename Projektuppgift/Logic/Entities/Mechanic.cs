using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Entities
{
    
    public class Mechanic     
    {
        


        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfEmployment { get; set; }
        public string EndDate { get; set; }
        //public string Id { get; set; } = Guid.NewGuid().ToString();
        public Guid MechID { get; set; }
        public string CanFixMotor { get; set; }
        public string CanFixTires { get; set; }
        public string CanFixBrakes { get; set; }
        public string CanFixWindshield { get; set; }
        public string CanFixVehicleBody { get; set; }





    }
}
