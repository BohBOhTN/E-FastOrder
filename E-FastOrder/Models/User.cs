using System;
using System.Collections.Generic;

namespace E_FastOrder.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<FavoriteMenuItem> FavoriteMenuItems { get; set; } = new List<FavoriteMenuItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}
