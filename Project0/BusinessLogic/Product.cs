namespace Project0
{
    class Product
    {
        private static int _productIDSeed = 012345;
        private string productID { get; }
        private string productDescription { get; }

        private double productPrice { get; set; }

        public Product(string description, double price)
        {
            productID = _productIDSeed.ToString();
            _productIDSeed++;

            productDescription = description;

            productPrice = price;
        }
    }
}