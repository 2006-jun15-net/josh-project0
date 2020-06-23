namespace Project0
{
    class Product
    {
        private static int _productIDSeed = 012345;
        public string productID { get; }
        public string productDescription { get; }

        public double productPrice { get; set; }

        public Product(string description, double price)
        {
            productID = _productIDSeed.ToString();
            _productIDSeed++;

            productDescription = description;

            productPrice = price;
        }
    }
}