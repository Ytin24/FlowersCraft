using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO дл€ статуса заказа")]
    public partial class OrderStatusDto
    {
        [GraphQLDescription("”никальный код статуса заказа")]
        public string Code { get; set; }

        [GraphQLDescription("„еловеко-читаемое название статуса")]
        public string Name { get; set; }
    }

}