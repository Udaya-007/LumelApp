using System;
using System.Collections.Generic;

namespace LumelApp.Models;

public partial class PaymentMethod
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
