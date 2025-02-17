using System;
using System.Collections.Generic;

namespace LumelApp.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public int DiscountTypeId { get; set; }

    public double DiscountValue { get; set; }

    public double ShipmentCost { get; set; }

    public DateTime EstimatedDeliveryDate { get; set; }

    public DateTime ActualDeliveryDate { get; set; }

    public int OrderStausId { get; set; }

    public virtual DiscountType DiscountType { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual OrderStatus OrderStaus { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
