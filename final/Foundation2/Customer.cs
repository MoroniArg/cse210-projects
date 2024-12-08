public class Customer
{
    public string Name { get; set; }
    public Address CustomerAddress { get; set; }

    public Customer(string name, Address customerAddress)
    {
        Name = name;
        CustomerAddress = customerAddress;
    }

    public bool IsInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
}
