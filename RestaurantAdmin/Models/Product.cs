using Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product : CoreEntity
    {
        public string Name { get; set; }

        public string CategoryId { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Status { get; set; }
    }
}
