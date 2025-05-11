using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("UserDto"), GenerateMapper]
[Index("Platform", "PlatformUserId", Name = "UQ_Users_PlatformUser", IsUnique = true)]
public partial class User
{
    [DataMember]
    [Key]
    public long Id { get; set; }

    [DataMember]
    [StringLength(50)]
    [Unicode(false)]
    public string Platform { get; set; } = null!;

    [DataMember]
    public long PlatformUserId { get; set; }

    [DataMember]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [DataMember]
    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [DataMember]
    [Precision(3)]
    public DateTime RegistrationDate { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
