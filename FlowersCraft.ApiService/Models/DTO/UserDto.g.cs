using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO ��� ������������")]
    public partial class UserDto
    {
        [GraphQLDescription("���������� ������������� ������������")]
        public long Id { get; set; }

        [GraphQLDescription("�������� ��������� (��������, telegram, vk)")]
        public string Platform { get; set; }

        [GraphQLDescription("������������� ������������ ������ ���������")]
        public long PlatformUserId { get; set; }

        [GraphQLDescription("��� ������������")]
        public string? FirstName { get; set; }

        [GraphQLDescription("������� ������������")]
        public string? LastName { get; set; }

        [GraphQLDescription("����� �������� ������������")]
        public string? PhoneNumber { get; set; }

        [GraphQLDescription("���� ����������� ������������")]
        public DateTime RegistrationDate { get; set; }
    }

}