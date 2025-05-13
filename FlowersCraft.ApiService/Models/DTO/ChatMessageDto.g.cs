using System;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для сообщения чата")]
    public partial class ChatMessageDto
    {
        [GraphQLDescription("Уникальный идентификатор сообщения")]
        public int Id { get; set; }

        [GraphQLDescription("Идентификатор пользователя, написавшего сообщение")]
        public long UserId { get; set; }

        [GraphQLDescription("Текст сообщения")]
        public string? Content { get; set; }

        [GraphQLDescription("Код отправителя (бот, пользователь и т.п.)")]
        public string Sender { get; set; }

        [GraphQLDescription("Дата и время отправки сообщения")]
        public DateTime Timestamp { get; set; }
    }

}