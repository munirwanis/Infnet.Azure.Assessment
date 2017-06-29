using System.Collections.Generic;

namespace Infnet.Azure.Assessment.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public bool IsSent { get; set; }

        public bool IsSaved { get; set; }

        public List<Product> Products { get; set; }
    }
}
