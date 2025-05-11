using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("ProductCategoryDto"), GenerateMapper]
[Index("Name", Name = "UQ__ProductC__737584F68BE5CDDE", IsUnique = true)]
public partial class ProductCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
