using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities;

namespace Logic.Services
{
    public class StaticLists
    {
        public static List<Errands> errands = new List<Errands>();

        //public const string pathforErrand = @"C:\Users\sandr\source\repos\NewRepos\Projektuppgift\Logic\DAL\Errand.json";

        public const string pathforErrand = @"C:\Users\Adm\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\Errand.json";

        public static List<User> usersList = new List<User>();

        //public const string userpath = @"C:\Users\sandr\source\repos\NewRepos\Projektuppgift\Logic\DAL\User.json";

        public const string userpath = @"C:\Users\Adm\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\User.json";

        public static List<Mechanic> mechanics = new List<Mechanic>();

        //public const string mechpath = @"C:\Users\sandr\source\repos\NewRepos\Projektuppgift\Logic\DAL\Mechanic.json";

        public const string mechpath = @"C:\Users\Adm\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\Mechanic.json";

        public static object stockobject = new object();

        //public const string stockpath = @"C:\Users\sandr\source\repos\NewRepos\Projektuppgift\Logic\DAL\Stock.json";

        public const string stockpath = @"C:\Users\Adm\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\Stock.json";

    }
}
