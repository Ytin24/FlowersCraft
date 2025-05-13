using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для элемента заказа")]
    public partial class OrderItemDto
    {
        [GraphQLDescription("Уникальный идентификатор позиции заказа")]
        public int Id { get; set; }

        [GraphQLDescription("Идентификатор заказа")]
        public int OrderId { get; set; }

        [GraphQLDescription("Идентификатор товара")]
        public int ProductId { get; set; }

        [GraphQLDescription("Название товара")]
        public string ProductName { get; set; }

        [GraphQLDescription("Цена единицы товара")]
        public decimal Price { get; set; }

        [GraphQLDescription("Количество товара")]
        public int Quantity { get; set; }
    }

}