using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentTest1.Models
{
    internal class CustomerInfo
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string CustomerEmail { get; set; }
        public string Customer_Name { get; set; }
        public string CustomerPhone { get; set; }
    }
}
