using Logic.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Logic.Entities;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Logic.Services
{
    public class AddErrandService
    {
        public static List<Errands> errands = new List<Errands>();

        public static List<Car> cars = new List<Car>();

        //public const string pathforErrand = @"C:\Users\julia\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\Errand.json";

        public const string pathforErrand = @"C:\Users\Adm\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\Errand.json";

        public const string pathforCar = @"C:\Users\Adm\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\Car.json";
    }
}