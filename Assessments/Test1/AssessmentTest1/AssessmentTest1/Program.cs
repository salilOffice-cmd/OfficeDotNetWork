using AssessmentTest1.Models;

namespace AssessmentTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. Adding Customers and Orders
            //AddCustomer(("Salil Deogade", "salil.deogade@gmail.com", "8093840383"));
            //AddCustomer(("Anu Deogade", "anu.deogade@gmail.com", "4238424208"));
            //AddCustomer(("Rohit Sharma", "rohit.sharma@gmail.com", "4970298323"));
            //AddCustomer(("Vijay Sir", "Vijay.sir@gmail.com", "99820830193"));
            //AddCustomer(("Vijay Sir1", "Vijay1.sir@gmail.com", "99820830193"));
            //AddCustomer(("Vijay Sir2", "Vijay2.sir@gmail.com", "99825550193"));
            //AddCustomer(("Vijay Sir3", "Vijay3.sir@gmail.com", "99826660193"));

            //AddOrder(("Salil Deogade", 2000, "Medical Chowk"));
            //AddOrder(("Anu Deogade", 1000, "Medical Chowk"));
            //AddOrder(("Rohit sharma", 4000, "Medical Chowk"));
            //AddOrder(("Vijay Sir", 4000, "Sitabuldi"));
            //AddOrder(("Vijay Sir1", 5000, "Sitabuldi"));
            //AddOrder(("Vijay Sir2", 10000, "Sitabuldi"));
            //AddOrder(("Vijay Sir3", 41000, "Sitabuldi"));
            //AddOrder(("Vijay Sir5", 41000, "Sitabuldi"));


            // 2. Updating the status
            // Whenever we call this function it should update the orderStatus everyTime
            //UpdateOrder(1);  // status - out for delivery
            //UpdateOrder(2);  // status - delivered
            //UpdateOrder(2);  // status - delivered


            // 3. Getting orders and customers with joins
            //Get_Order_CustomerDetails();


            // 4. Getting orders based on the delivery dates and particular location
            DateTime fromDate = new DateTime(2023, 10, 1);
            DateTime toDate = new DateTime(2023, 10, 30);
            GetDeliveredOrdersByDateAndLocation("Medical Chowk", fromDate, toDate);
        }

        #region AddingOrderAndCustomer
        public static void AddOrder((string customerName, int amount, string deliveryLocation) order)
        {

            // Date
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("ddMMyyyyHHmmss");

            // FirstName
            string[] splitName = order.customerName.Split(' ');
            string firstName = splitName[0];

            Order newOrder = new Order
            {
                Customer_name = order.customerName,
                Invoice_id = "Ord" + "_" + firstName + formattedDate,
                Order_date = now,
                Amount = order.amount,
                DeliveryLocation = order.deliveryLocation,
                OrderStatus = "Initiated"
            };

            using(DeliveryManagementSystemContext context = new DeliveryManagementSystemContext())
            {
                // Adding Order to order Table
                context.Orders.Add(newOrder);
                context.SaveChanges();


                // Updating Order in CustomerInfo Table
                newOrder.OrderStatus = "Initiated";
                newOrder.EstimatedDeliveryDate = newOrder.Order_date.AddDays(5);

                CustomerInfo foundCustomer = context.CustomerInfos
                        .Where(c => c.Customer_Name == newOrder.Customer_name).FirstOrDefault();

                if (foundCustomer != null)
                {
                    foundCustomer.OrderId = newOrder.Id;
                }
                context.SaveChanges();

            }

        }
        
        public static void AddCustomer((string name, string email, string phone) customer)
        {
            CustomerInfo newCustomer = new CustomerInfo
            {
                CustomerEmail = customer.email,
                Customer_Name = customer.name,
                CustomerPhone = customer.phone
            };

            using (DeliveryManagementSystemContext context = new DeliveryManagementSystemContext())
            {
                context.CustomerInfos.Add(newCustomer);
                context.SaveChanges();
            }
        }

        #endregion


        public static void UpdateOrder(int orderId)
        {
            using(DeliveryManagementSystemContext context = new DeliveryManagementSystemContext())
            {
                var foundOrder = context.Orders.Find(orderId);
                if(foundOrder != null)
                {
                    if(foundOrder.OrderStatus == "Out For Delivery")
                    {
                        foundOrder.OrderStatus = "Delivered";
                        foundOrder.DeliveryDate = DateTime.Now;
                    }
                    else if (foundOrder.OrderStatus == "Initiated")
                    {
                        foundOrder.OrderStatus = "Out For Delivery";
                    }
                    context.SaveChanges();

                }

            }
        }

        public static void Get_Order_CustomerDetails()
        {
            using(DeliveryManagementSystemContext context = new DeliveryManagementSystemContext())
            {
                var query = context.Orders.Join(
                        context.CustomerInfos,
                        order => order.Id,
                        cInfo => cInfo.OrderId,
                        (order, cInfo) => new
                        {
                            order.Id,
                            order.Invoice_id,
                            cInfo.Customer_Name,
                            cInfo.CustomerEmail,
                            cInfo.CustomerPhone
                        }
                    );

                foreach(var order in query)
                {
                    Console.WriteLine(
                        $"{order.Id} | {order.Invoice_id} | {order.Customer_Name}" +
                        $" | {order.CustomerEmail} | {order.CustomerPhone}");
                }
                
            }
        }

        public static void GetDeliveredOrdersByDateAndLocation
            (string deliveryLocation, DateTime fromDate, DateTime toDate)
        {
            using(DeliveryManagementSystemContext context = new DeliveryManagementSystemContext())
            {

                // Getting all the orders from a particular location which are delivered
                // 1. Approach Number1 --> With Joins Only
                var DeliveredOrdersAtParticularLocation =
                    context.Orders.Where(
                        order => order.DeliveryDate != null &&
                        order.DeliveryLocation == deliveryLocation)
                                  .Join(
                                        context.CustomerInfos,
                                        order => order.Id,
                                        cInfo => cInfo.OrderId,
                                        (order, cInfo) => new
                                        {
                                            order.DeliveryLocation,
                                            order.DeliveryDate,
                                            cInfo.CustomerEmail,
                                            cInfo.CustomerPhone
                                        }
                                      );

                var getDeliveredOrdersByDate = DeliveredOrdersAtParticularLocation
                                .Where(
                                    order => order.DeliveryDate >= fromDate &&
                                             order.DeliveryDate <= toDate
                                 );

                // Note- Sir Please uncomment this, incase approach2 doesn't work
                // Console.WriteLine("Using Joins and where");
                foreach (var order in getDeliveredOrdersByDate)
                {
                    Console.WriteLine(
                        $"{order.DeliveryLocation} | {order.CustomerEmail} | {order.CustomerPhone} | {order.DeliveryDate}");
                }


                //  2. Approach Number2 --> With GroupBy
                var groupByDate = context.Orders
                       .Where(
                        order => order.DeliveryDate != null &&
                        order.DeliveryLocation == deliveryLocation)
                        .Join(
                                context.CustomerInfos,
                                order => order.Id,
                                cInfo => cInfo.OrderId,
                                (order, cInfo) => new
                                {
                                    order.DeliveryLocation,
                                    order.DeliveryDate,
                                    cInfo.CustomerEmail,
                                    cInfo.CustomerPhone
                                }
                             )
                        .GroupBy(order => order.DeliveryDate >= fromDate &&
                                             order.DeliveryDate <= toDate)
                        .Select(orderGroup => new
                        {
                            groupKey = orderGroup.Key,
                            DeliveryLocation = orderGroup
                                                .Select(order => order.DeliveryLocation)
                                                .FirstOrDefault(),
                            Count = orderGroup.Count(),
                            Emails = orderGroup.Select(order => order.CustomerEmail),
                            PhoneNumbers = orderGroup.Select(order => order.CustomerPhone)
                        });


                Console.WriteLine("Using Group By");
                foreach (var group in groupByDate)
                {
                    //Console.WriteLine("Group : " + group.groupKey);
                    Console.Write(group.DeliveryLocation + "|");
                    Console.Write(group.Count + "|");
                    foreach (var email in group.Emails)
                    {
                        Console.Write(email + ',');
                    }
                    Console.Write("|");
                    foreach (var number in group.PhoneNumbers)
                    {
                        Console.Write(number + ',');
                    }

                }

                // Approach 3 --> The right approach
                var join = context.Orders.Where(
                    order => order.DeliveryDate >= fromDate
                            && order.DeliveryDate <= toDate)
                        .Join(
                            context.CustomerInfos,
                            table1 => table1.Id,
                            table2 => table2.OrderId,
                            (table1, table2) => new
                            {

                                location = table1.DeliveryLocation,
                                email = table2.CustomerEmail,
                                phone = table2.CustomerPhone,

                            })
                        .GroupBy(e => e.location)
                        .Select(group => new
                            {
                                location = group.Key,
                                ordercount = group.Count(),
                                milinfo = string.Join(",", group.Select(e => e.email)),
                                phoneinfo = string.Join(",", group.Select(e => e.phone))
                            }).ToList();

                foreach (var result in join)
                {
                    Console.WriteLine($"{result.location} | {result.ordercount} | {result.milinfo} | {result.phoneinfo}");
                }


            }
        }

    }
}