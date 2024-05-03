using System;
using System.Collections.Generic;

namespace E_FastOrder.Models;

public partial class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? Category { get; set; }

    public virtual ICollection<FavoriteMenuItem> FavoriteMenuItems { get; set; } = new List<FavoriteMenuItem>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
