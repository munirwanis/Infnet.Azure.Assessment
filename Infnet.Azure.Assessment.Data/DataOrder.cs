using Infnet.Azure.Assessment.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infnet.Azure.Assessment.Data
{
    public class DataOrder : IData<Order>
    {
        public bool Delete(int id)
        {
            using (var db = new Database())
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                return db.SaveChanges() > 0;
            }
        }

        public Order Get(int id)
        {
            using (var db = new Database())
            {
                return db.Orders.Find(id);
            }
        }

        public List<Order> GetAll()
        {
            using (var db = new Database())
            {
                return db.Orders.ToList();
            }
        }

        public bool Insert(Order entry)
        {
            using (var db = new Database())
            {
                db.Orders.Add(entry);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(int id, Order entry)
        {
            using (var db = new Database())
            {
                db.Orders.Attach(entry);
                db.Entry(entry).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
