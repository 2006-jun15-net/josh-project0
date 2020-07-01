namespace Project0.Library
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; }
        public double ProductPrice { get; set; }

        public Product(int prodId, string description, double price)
        {
            ProductID = prodId;
            ProductDescription = description;
            ProductPrice = price;
        }
    }
}