using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvScan
{
    public class Item
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Parent { get; set; }
        public bool Available { get; set; }


    }


}
