namespace Project0
{
    internal interface ICustomer
    {
        string customerId { get; }
        string firstName { get; set; }
        string lastName { get; set; }
        // string defaultStore {get; set; }
    }
}