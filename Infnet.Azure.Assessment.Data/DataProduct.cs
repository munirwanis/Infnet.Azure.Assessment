using Infnet.Azure.Assessment.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infnet.Azure.Assessment.Data
{
    public class DataProduct : IData<Product>
    {
        public bool Delete(int id)
        {
            using (var db = new Database())
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                return db.SaveChanges() > 0;
            }
        }

        public Product Get(int id)
        {
            using (var db = new Database())
            {
                return db.Products.Find(id);
            }
        }

        public List<Product> GetAll()
        {
            using (var db = new Database())
            {
                return db.Products.ToList();
            }
        }

        public bool Insert(Product entry)
        {
            using (var db = new Database())
            {
                db.Products.Add(entry);
                return db.SaveChanges() > 0;
            }
        }

        public bool Update(int id, Product entry)
        {
            using (var db = new Database())
            {
                db.Products.Attach(entry);
                db.Entry(entry).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
    }
}
