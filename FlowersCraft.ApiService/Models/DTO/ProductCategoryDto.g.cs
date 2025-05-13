using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� ��������� ������")]
    public partial class ProductCategoryDto
    {
        [GraphQLDescription("���������� ������������� ���������")]
        public int Id { get; set; }

        [GraphQLDescription("�������� ���������")]
        public string Name { get; set; }
    }

}