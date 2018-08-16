using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvScan
{
    static class DbWrap
    {
        public static void Insert(Item itm)
        {
            using (var db = new LiteDatabase(@"db.db"))
            {
                LiteCollection<Item> inv = db.GetCollection<Item>("items");
                
                // Insert new customer document (Id will be auto-incremented)
                inv.Insert(itm);

                Log("New Item", LogItem.LogType.Insert, itm);
            }
        }

        public static void Debug()
        {
            using (var db = new LiteDatabase(@"db.db"))
            {

                LiteCollection<Item> inv = db.GetCollection<Item>("items");
                List<Item> list = inv.Find(Query.All()).ToList();

                foreach (Item itm in list)
                {
                    Console.WriteLine(itm.Name);
                }
            }
        }

        public static List<Item> GetList()
        {
            using (var db = new LiteDatabase(@"db.db"))
            {

                LiteCollection<Item> inv = db.GetCollection<Item>("items");
                List<Item> list = inv.Find(Query.All()).ToList();

                return list;
            }
        }

        public static List<Item> GetList(string code)
        {
            using (var db = new LiteDatabase(@"db.db"))
            {

                LiteCollection<Item> inv = db.GetCollection<Item>("items");
                List<Item> list = inv.Find(Query.All()).ToList();

                List<Item> list2 = GetWithCode(list, code);

                return list2;
            }
        }

        public static Item GetItem(string Unique)
        {
            using (var db = new LiteDatabase(@"db.db"))
            {

                LiteCollection<Item> inv = db.GetCollection<Item>("items");
                List<Item> list = inv.Find(Query.EQ("Unique", Unique)).ToList();

                if(list.Count > 0)
                {
                    return list[0];
                }
                else
                {
                    return null;
                }
                
            }
        }

        public static void Update(Item itm)
        {
            if (itm.IsChild)
            {
                Item Parent = GetItem(itm.Parent);
                Parent.AddChild(itm);

                Update(Parent);
            }
        

            using (var db = new LiteDatabase(@"db.db"))
            {

                LiteCollection<Item> inv = db.GetCollection<Item>("items");
                
                inv.Update(itm);
                Log("New Item", LogItem.LogType.Update, itm);

            }
            
        } 

        public static void Delete(Item itm)
        {

            if (itm.IsChild)
            {
                Item Parent = GetItem(itm.Parent);
                Parent.RemoveChild(itm);

                Update(Parent);
            }

            using (var db = new LiteDatabase(@"db.db"))
            {

                LiteCollection<Item> inv = db.GetCollection<Item>("items");

                inv.Delete(itm.Id);
                Log("New Item", LogItem.LogType.Delete, itm);
            }
        }

        public static List<Item> GetWithCode(List<Item> input, string code, List<Item> progress = null)
        {

            if(progress == null)
            {
                progress = new List<Item>();
            }

            foreach (Item itm in input)
            {
                Console.WriteLine("checking:" + itm.Name);
                if(itm.Code == code)
                {
                    progress.Add(itm);
                }

                GetWithCode(itm.Children, code, progress);
            }

            return progress;
        }

        public static void Log(string mes = "x", LogItem.LogType Typ = LogItem.LogType.Null, object obj = null)
        {
            using (var db = new LiteDatabase(@"db.db"))
            {
                LogItem itm = new LogItem(mes, Typ, obj);

                LiteCollection<LogItem> log = db.GetCollection<LogItem>("log");
                
                log.Insert(itm);
            }
        }
    }
}
