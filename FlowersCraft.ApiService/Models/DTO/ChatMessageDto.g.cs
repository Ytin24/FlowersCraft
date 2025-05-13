using System;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� ��������� ����")]
    public partial class ChatMessageDto
    {
        [GraphQLDescription("���������� ������������� ���������")]
        public int Id { get; set; }

        [GraphQLDescription("������������� ������������, ����������� ���������")]
        public long UserId { get; set; }

        [GraphQLDescription("����� ���������")]
        public string? Content { get; set; }

        [GraphQLDescription("��� ����������� (���, ������������ � �.�.)")]
        public string Sender { get; set; }

        [GraphQLDescription("���� � ����� �������� ���������")]
        public DateTime Timestamp { get; set; }
    }

}