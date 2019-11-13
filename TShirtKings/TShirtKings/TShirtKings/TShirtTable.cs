using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace TShirtKings
{
    public class TShirtTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string ShirtSize { get; set; }

        public string DateOfOrder { get; set; }

        public string ShirtName { get; set; }

        public string ShippingAddress { get; set; }

        public string EmailAddress { get; set; }

        public string ContactDetails { get; set; }
        
        bool Done { get; set; }
    }
}
