using System;
using System.Collections.Generic;
using System.Text;
using Logic.Entities;

namespace Logic.Services
{
    public class StaticLists
    {
        public static List<Errands> errands = new List<Errands>();

        public const string pathforErrand = @"DAL\Errand.json";

        public static List<User> usersList = new List<User>();

        public const string userpath = @"DAL\User.json";

        public static List<Mechanic> mechanics = new List<Mechanic>();

        public const string mechpath = @"DAL\Mechanic.json";

        public static object stockobject = new object();

        public const string stockpath = @"DAL\Stock.json";

    }
}
