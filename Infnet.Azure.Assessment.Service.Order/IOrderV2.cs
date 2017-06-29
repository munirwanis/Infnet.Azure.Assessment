using Infnet.Azure.Assessment.Entities;
using Infnet.Azure.Assessment.Service.Order.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace Infnet.Azure.Assessment.Service.Order
{
    [ServiceContract]
    public interface IOrderV2
    {
        [OperationContract]
        bool SaveOrder(List<Product> products);

        [OperationContract]
        OrderContract RetrieveOrder();

        [OperationContract]
        bool SentOrder(int id);

        [OperationContract]
        bool ReceivedOrder(int id);
    }
}
