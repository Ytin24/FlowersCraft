using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� �������� ������")]
    public partial class OrderItemDto
    {
        [GraphQLDescription("���������� ������������� ������� ������")]
        public int Id { get; set; }

        [GraphQLDescription("������������� ������")]
        public int OrderId { get; set; }

        [GraphQLDescription("������������� ������")]
        public int ProductId { get; set; }

        [GraphQLDescription("�������� ������")]
        public string ProductName { get; set; }

        [GraphQLDescription("���� ������� ������")]
        public decimal Price { get; set; }

        [GraphQLDescription("���������� ������")]
        public int Quantity { get; set; }
    }

}