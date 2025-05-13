using System;
using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для пользователя")]
    public partial class UserDto
    {
        [GraphQLDescription("Уникальный идентификатор пользователя")]
        public long Id { get; set; }

        [GraphQLDescription("Название платформы (например, telegram, vk)")]
        public string Platform { get; set; }

        [GraphQLDescription("Идентификатор пользователя внутри платформы")]
        public long PlatformUserId { get; set; }

        [GraphQLDescription("Имя пользователя")]
        public string? FirstName { get; set; }

        [GraphQLDescription("Фамилия пользователя")]
        public string? LastName { get; set; }

        [GraphQLDescription("Номер телефона пользователя")]
        public string? PhoneNumber { get; set; }

        [GraphQLDescription("Дата регистрации пользователя")]
        public DateTime RegistrationDate { get; set; }
    }

}