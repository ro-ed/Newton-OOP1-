using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.DAL
{
    public class MechanicDataAccess
    {
        private const string mechpath = @"DAL\Mechanic.json";

        public List<Mechanic> GetMechanics()
        {
            string jsonString = File.ReadAllText(mechpath);
            List<Mechanic> mechanics = JsonSerializer.Deserialize<List<Mechanic>>(jsonString);

            return mechanics;
        }

        //public List<Mechanic> AddMechanics()
        //{

        //}
    }
}
