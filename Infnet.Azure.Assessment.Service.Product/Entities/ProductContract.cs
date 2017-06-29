using System.Runtime.Serialization;

namespace Infnet.Azure.Assessment.Service.Product.Entities
{
    [DataContract]
    public class ProductContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public long Price { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}