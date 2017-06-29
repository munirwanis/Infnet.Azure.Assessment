using System.Collections.Generic;
using System.Linq;
using ProductEntity = Infnet.Azure.Assessment.Entities.Product;
using Infnet.Azure.Assessment.Service.Product.Entities;
using Infnet.Azure.Assessment.Data.Azure;
using Infnet.Azure.Assessment.Data;

namespace Infnet.Azure.Assessment.Service.Product
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProduct
    {
        private QueueData QueueData { get; } = new QueueData("productQueue");
        private DataProduct Db { get; } = new DataProduct();

        public bool AddToQueue(ProductEntity product) =>
            QueueData.AddToQueue<ProductEntity>(product);

        public bool Create(ProductEntity product) =>
            Db.Insert(product);

        public bool Delete(int id) =>
            Db.Delete(id);

        public bool Edit(ProductEntity product) =>
            Db.Update(product.Id, product);

        public List<ProductContract> ListProducts() =>
            (from p in Db.GetAll()
             select new ProductContract
             {
                 Id = p.Id,
                 Category = p.Category,
                 Name = p.Name,
                 Price = p.Price,
                 Quantity = p.Quantity
             }).ToList();

        public ProductContract ProcessQueue() =>
            QueueData.DequeueItem<ProductContract>();
    }
}
