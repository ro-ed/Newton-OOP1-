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
    public class AddMechanicService
    {
        public static List<Mechanic> mechanics = new List<Mechanic>();

        public const string mechpath = @"C:\Users\sandr\source\repos\NewRepos\Projektuppgift\Logic\DAL\Mechanic.json";

       

            //    File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanicsToSave));
        }
    }
    
    
    //public static void JsonSerialize(List<Mechanic> mechanicsToSave2, string filePath)
    //{
    //    JsonSerializer jsonSerializer = new JsonSerializer();
    //    StreamWriter sw = new StreamWriter(mechpath);
    //    JsonWriter jsonWriter = new JsonTextWriter(sw);

    //    jsonSerializer.Serialize(jsonWriter, mechanicsToSave2);

    //    jsonWriter.Close();
    //    sw.Close();


    //}

    //public static object JsonDeserialize(Type dataType, string filePath)
    //{
    //    JObject obj = null;
    //    JsonSerializer jsonSerializer = new JsonSerializer();
    //    if (File.Exists(mechpath))
    //    {
    //        StreamReader sr = new StreamReader(mechpath);
    //        JsonReader jsonReader = new JsonTextReader(sr);
    //        obj = jsonSerializer.Deserialize(jsonReader) as JObject;
    //        jsonReader.Close();
    //        sr.Close();
    //    }
    //    return obj.ToObject(dataType);
    //}




