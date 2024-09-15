using Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Bill : CoreEntity
    {
        public string uuid { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string contactNumber { get; set; }

        public string paymentMethod { get; set; }

        public int totalAmount { get; set; }

        public string productDetails { get; set; }

        public string createdBy { get; set; }
    }
}
