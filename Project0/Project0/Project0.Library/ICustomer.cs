namespace Project0.Library
{
    internal interface ICustomer
    {
        int CustomerId { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        // string defaultStore {get; set; }
    }
}