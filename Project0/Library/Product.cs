namespace Project0
{
    class Product
    {
        public string ProductID { get; }
        public string ProductDescription { get; }
        public double ProductPrice { get; set; }

        public Product(string description, double price)
        {
            ProductID = IdFactory.generateNewId();

            ProductDescription = description;

            ProductPrice = price;
        }
    }
}