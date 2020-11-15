using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Logic.Services.StaticLists;
using Logic.Entities;
using Logic.Interfaces;
using Logic.Exceptions;

namespace Logic.DAL
{
    public partial class GenericClass : ILogic
    {
        public static void Overrite()
        {

            File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            string jsonFromFile;

            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
        }

        //public static void DateFormat(string date)
        //{
        //    try
        //    {
        //        String.Format("{0:YYYY/MM/DD}", date);
        //    }
        //    catch (DateFormatException ex)
        //    {
        //        throw new DateFormatException(ex.Message);
        //    }
        //}








    }
}


