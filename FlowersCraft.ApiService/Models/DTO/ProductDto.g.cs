using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� �������� ������")]
    public partial class ProductDto
    {
        [GraphQLDescription("���������� ������������� ������")]
        public int Id { get; set; }

        [GraphQLDescription("�������� ������")]
        public string Name { get; set; }

        [GraphQLDescription("������������� ��������� ������")]
        public int CategoryId { get; set; }

        [GraphQLDescription("���� ������")]
        public decimal Price { get; set; }

        [GraphQLDescription("���� ����������� ������")]
        public bool IsAvailable { get; set; }

        [GraphQLDescription("���� �������� ������ � ������")]
        public DateTime CreatedDate { get; set; }
    }


}