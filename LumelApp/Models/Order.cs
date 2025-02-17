using System;
using System.Collections.Generic;

namespace LumelApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int NoOfItems { get; set; }

    public double Value { get; set; }

    public int PaymentMethodId { get; set; }

    public DateTime DateOfSale { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
