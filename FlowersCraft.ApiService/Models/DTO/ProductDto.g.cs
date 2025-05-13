using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для описания товара")]
    public partial class ProductDto
    {
        [GraphQLDescription("Уникальный идентификатор товара")]
        public int Id { get; set; }

        [GraphQLDescription("Название товара")]
        public string Name { get; set; }

        [GraphQLDescription("Идентификатор категории товара")]
        public int CategoryId { get; set; }

        [GraphQLDescription("Цена товара")]
        public decimal Price { get; set; }

        [GraphQLDescription("Флаг доступности товара")]
        public bool IsAvailable { get; set; }

        [GraphQLDescription("Дата создания записи о товаре")]
        public DateTime CreatedDate { get; set; }
    }


}