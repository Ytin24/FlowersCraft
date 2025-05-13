using System.Collections.Generic;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Models
{
    [GraphQLDescription("DTO для отправителя сообщения")]
    public partial class ChatSenderDto
    {
        [GraphQLDescription("Код отправителя (например, user, bot)")]
        public string Code { get; set; }

        [GraphQLDescription("Отображаемое имя отправителя")]
        public string Name { get; set; }
    }

}