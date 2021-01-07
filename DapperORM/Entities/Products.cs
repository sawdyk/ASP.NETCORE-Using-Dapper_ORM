using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Cost { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
