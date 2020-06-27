namespace Project0
{
    class Product
    {
        public string productID { get; }
        public string productDescription { get; }
        public double productPrice { get; set; }

        public Product(string description, double price)
        {
            productID = IdFactory.generateNewId();

            productDescription = description;

            productPrice = price;
        }
    }
}