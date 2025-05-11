using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("ChatMessageDto"), GenerateMapper]
[Index("UserId", "Timestamp", Name = "IX_ChatMessages_UserId_Timestamp", IsDescending = new[] { false, true })]
public partial class ChatMessage
{
    [Key]
    public int Id { get; set; }
    [DataMember]
    public long UserId { get; set; }
    [DataMember]
    public string? Content { get; set; }

    [DataMember]
    [StringLength(20)]
    [Unicode(false)]
    public string Sender { get; set; } = null!;

    [DataMember]
    [Precision(3)]
    public DateTime Timestamp { get; set; }

    [ForeignKey("Sender")]
    [InverseProperty("ChatMessages")]
    public virtual ChatSender SenderNavigation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("ChatMessages")]
    public virtual User User { get; set; } = null!;
}
