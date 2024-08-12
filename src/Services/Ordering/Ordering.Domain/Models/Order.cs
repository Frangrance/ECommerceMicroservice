using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;
using Ordering.Domain.Enums;

namespace Ordering.Domain.Models;
public class Order : Aggregate<Guid>
{
    private readonly List<OrderItem> orderItems = new();
    public IReadOnlyList<OrderItem> OrderItems => orderItems.AsReadOnly();
    public Guid CustomerId { get; private set; } = default!;
    public string OrderName { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x=>x.Price * x.Quantity);
        private set { }
    }

}
