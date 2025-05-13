using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для категории товара")]
    public partial class ProductCategoryDto
    {
        [GraphQLDescription("Уникальный идентификатор категории")]
        public int Id { get; set; }

        [GraphQLDescription("Название категории")]
        public string Name { get; set; }
    }

}