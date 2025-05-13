using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� ������")]
    public partial class OrderDto
    {
        [GraphQLDescription("���������� ������������� ������")]
        public int Id { get; set; }

        [GraphQLDescription("������������� ������������, ���������� �����")]
        public long UserId { get; set; }

        [GraphQLDescription("��� ������� ������")]
        public string Status { get; set; }

        [GraphQLDescription("����������� � ������")]
        public string? Comments { get; set; }

        [GraphQLDescription("���� �������� ������")]
        public DateTime CreatedDate { get; set; }
    }

}