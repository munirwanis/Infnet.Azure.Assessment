namespace Infnet.Azure.Assessment.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public long Price { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
    }
}
