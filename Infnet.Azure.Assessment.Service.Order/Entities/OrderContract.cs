using Infnet.Azure.Assessment.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Infnet.Azure.Assessment.Service.Order.Entities
{
    [DataContract]
    public class OrderContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public bool IsSent { get; set; }

        [DataMember]
        public bool IsSaved { get; set; }

        [DataMember]
        public virtual List<Product> Products { get; set; }
    }
}