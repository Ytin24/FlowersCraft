using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("OrderDto"), GenerateMapper]
[Index("UserId", "CreatedDate", Name = "IX_Orders_UserId_CreatedDate", IsDescending = new[] { false, true })]
public partial class Order
{
    [Key]
    public int Id { get; set; }

    [DataMember]
    public long UserId { get; set; }

    [DataMember]
    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [DataMember]
    public string? Comments { get; set; }

    [DataMember]
    [Precision(3)]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("Status")]
    [InverseProperty("Orders")]
    public virtual OrderStatus StatusNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
