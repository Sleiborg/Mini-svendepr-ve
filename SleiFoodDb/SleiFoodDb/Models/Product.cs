using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SleiFoodDb.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string title { get; set; }
        public string descriptions { get; set; }

        public string image { get; set; }
    }
}
