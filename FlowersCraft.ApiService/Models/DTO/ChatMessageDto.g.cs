using System;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    public partial class ChatMessageDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string? Content { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; }
    }
}