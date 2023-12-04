using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentTest1.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public string Invoice_id { get; set; }
        public string Customer_name { get; set; }
        public DateTime Order_date { get; set; }
        public int Amount { get; set; }
        public string DeliveryLocation { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
