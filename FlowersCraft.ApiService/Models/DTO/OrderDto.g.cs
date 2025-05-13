using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для заказа")]
    public partial class OrderDto
    {
        [GraphQLDescription("Уникальный идентификатор заказа")]
        public int Id { get; set; }

        [GraphQLDescription("Идентификатор пользователя, сделавшего заказ")]
        public long UserId { get; set; }

        [GraphQLDescription("Код статуса заказа")]
        public string Status { get; set; }

        [GraphQLDescription("Комментарий к заказу")]
        public string? Comments { get; set; }

        [GraphQLDescription("Дата создания заказа")]
        public DateTime CreatedDate { get; set; }
    }

}