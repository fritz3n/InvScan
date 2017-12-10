using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvScan
{
    public class Item : IEquatable<Item>
    {
        public int Id { get; set; }
        public string Unique { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Parent { get; set; }
        public bool Available { get; private set; }
        public bool IsChild { get; set; } = false;
        public List<Item> Children { get; private set; } = new List<Item>();

        public void AddChild(Item itm)
        {
            if (!IsChild)
            {
                if (Children.Exists(x => x.Unique == itm.Unique))
                {
                    Children.Find(x => x.Unique == itm.Unique).Update(itm);
                }
                else
                {
                    itm.Parent = Unique;
                    itm.IsChild = true;

                    Children.Add(itm);
                }
            }
        }

        public void SetAvailable(bool avb)
        {
            Available = avb;
            foreach (Item itm in Children)
            {
                itm.SetAvailable(avb);
            }
        }

        public string GetAvailableText()
        {
            return (Available ? "Yes" : "No");
        }

        public Item GetParent()
        {
            return DbWrap.GetItem(Parent);
        }

        public void RemoveChild(Item itm)
        {
            Children.Remove(itm);
        }

        public void Update(Item itm)
        {
            //Id = itm.Id;
            Unique = itm.Unique;
            Code = itm.Code;
            Name = itm.Name;
            Description = itm.Description;
            Place = itm.Place;
            Parent = itm.Parent;
            Available = itm.Available;
            IsChild = itm.IsChild;
            Children = itm.Children;
        }

        public Item()
        {
            Unique = RandomString(5);
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public bool Equals(Item other)
        {
            return (Unique == other.Unique);
        }

    }


}
