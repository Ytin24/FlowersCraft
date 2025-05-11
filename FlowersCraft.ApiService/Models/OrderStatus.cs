using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("OrderStatusDto"), GenerateMapper]
public partial class OrderStatus
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("StatusNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
