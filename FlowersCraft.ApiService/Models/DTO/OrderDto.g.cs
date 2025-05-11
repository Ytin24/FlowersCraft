using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    public partial class OrderDto
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public string? Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}