using System;
using System.Collections.Generic;

namespace E_FastOrder.Models;

public partial class FavoriteMenuItem
{
    public int FavoriteMenuItemId { get; set; }

    public int UserId { get; set; }

    public int MenuItemId { get; set; }

    public virtual MenuItem MenuItem { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
