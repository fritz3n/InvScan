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
                List<Item> list = inv.Find(Query.EQ("Code",code)).ToList();

                return list;
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

            }
        }

    }
}
