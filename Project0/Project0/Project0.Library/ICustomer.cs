namespace Project0.Library
{
    internal interface ICustomer
    {
        string customerId { get; }
        string firstName { get; set; }
        string lastName { get; set; }
        // string defaultStore {get; set; }
    }
}