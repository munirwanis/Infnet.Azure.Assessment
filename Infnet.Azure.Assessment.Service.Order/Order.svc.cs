using System;
using System.Collections.Generic;
using Infnet.Azure.Assessment.Entities;
using OrderEntity = Infnet.Azure.Assessment.Entities.Order;
using Infnet.Azure.Assessment.Service.Order.Entities;
using Infnet.Azure.Assessment.Data.Azure;
using Infnet.Azure.Assessment.Data;
using System.Diagnostics;

namespace Infnet.Azure.Assessment.Service.Order
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Order : IOrderV1, IOrderV2
    {
        private QueueData QueueData { get; } = new QueueData("orderQueue");
        private DataOrder Db { get; } = new DataOrder();

        public bool ReceivedOrder(int id)
        {
            try
            {
                var order = Db.Get(id);
                order.IsSaved = true;
                return Db.Update(id, order);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public OrderContract RetrieveOrder()
        {
            var order = QueueData.DequeueItem<OrderContract>();
            return order;
        }

        public bool SaveOrder(Product product)
        {
            var products = new List<Product>
            {
                product
            };

            var order = new OrderEntity
            {
                IsSaved = false,
                IsSent = false,
                Products = products
            };

            return Db.Insert(order);
        }

        public bool SaveOrder(List<Product> products)
        {
            var order = new OrderEntity
            {
                IsSaved = false,
                IsSent = false,
                Products = products
            };

            return Db.Insert(order);
        }

        public bool SentOrder(int id)
        {
            try
            {
                var order = Db.Get(id);
                order.IsSaved = true;
                return Db.Update(id, order);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
