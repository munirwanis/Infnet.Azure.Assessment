using Infnet.Azure.Assessment.Entities;
using Infnet.Azure.Assessment.Service.Order.Entities;
using System.ServiceModel;

namespace Infnet.Azure.Assessment.Service.Order
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderV1
    {
        [OperationContract]
        bool SaveOrder(Product product);

        [OperationContract]
        OrderContract RetrieveOrder();

        [OperationContract]
        bool SentOrder(int id);

        [OperationContract]
        bool ReceivedOrder(int id);
    }
}
