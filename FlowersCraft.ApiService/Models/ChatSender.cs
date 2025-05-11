using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FlowersCraft.ApiService.Models;

[AdaptTo("ChatSenderDto"), GenerateMapper]
public partial class ChatSender
{
    [DataMember]
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [DataMember]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("SenderNavigation")]
    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
}
