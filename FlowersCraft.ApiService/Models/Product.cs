using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("ProductDto"), GenerateMapper]
[Index("CategoryId", Name = "IX_Products_CategoryId")]
public partial class Product
{
    [DataMember]
    [Key]
    public int Id { get; set; }

    [DataMember]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [DataMember]
    public int CategoryId { get; set; }

    [DataMember]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [DataMember]
    public bool IsAvailable { get; set; }

    [DataMember]
    [Precision(3)]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual ProductCategory Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
