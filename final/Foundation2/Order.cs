using System;
using System.Collections.Generic;

public class Order
{
    public List<Product> Products { get; set; }
    public Customer OrderCustomer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        OrderCustomer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalProductCost = 0;
        foreach (var product in Products)
        {
            totalProductCost += product.GetTotalCost();
        }

        decimal shippingCost = OrderCustomer.IsInUSA() ? 5.00m : 35.00m;
        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{OrderCustomer.Name}\n{OrderCustomer.CustomerAddress.GetFullAddress()}\n";
    }
}
