using System;
using System.Collections.Generic;

namespace LumelApp.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public double AvailableQuantity { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;
}
