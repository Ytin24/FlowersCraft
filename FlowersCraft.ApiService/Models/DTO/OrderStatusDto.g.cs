using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� ������� ������")]
    public partial class OrderStatusDto
    {
        [GraphQLDescription("���������� ��� ������� ������")]
        public string Code { get; set; }

        [GraphQLDescription("��������-�������� �������� �������")]
        public string Name { get; set; }
    }

}