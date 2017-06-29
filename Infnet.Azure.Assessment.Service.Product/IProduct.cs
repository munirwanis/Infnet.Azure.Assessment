using Infnet.Azure.Assessment.Service.Product.Entities;
using System.Collections.Generic;
using System.ServiceModel;
using ProductEntity = Infnet.Azure.Assessment.Entities.Product;

namespace Infnet.Azure.Assessment.Service.Product
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProduct
    {
        [OperationContract]
        bool AddToQueue(ProductEntity product);

        [OperationContract]
        ProductContract ProcessQueue();

        [OperationContract]
        List<ProductContract> ListProducts();

        [OperationContract]
        bool Create(ProductEntity product);

        [OperationContract]
        bool Edit(ProductEntity product);

        [OperationContract]
        bool Delete(int id);
    }
}
