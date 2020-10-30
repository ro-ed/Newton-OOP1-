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
        public string UserID { get; set; }
        public bool CanFixMotor { get; set; }
        public bool CanFixTires { get; set; }
        public bool CanFixBrakes { get; set; }
        public bool CanFixWindshield { get; set; }
        public bool CanFixVehicleBody { get; set; }




    }
}
