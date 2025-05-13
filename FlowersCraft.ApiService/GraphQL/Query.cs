using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.GraphQL;

[GraphQLDescription("Запросы для чтения данных")]
public class Query
{
    // -------------------- Product --------------------
    [GraphQLDescription("Получить список всех товаров")]
    public Task<List<ProductDto>> GetProducts([Service] IProductService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить товар по его идентификатору")]
    public Task<ProductDto?> GetProductById(
        [GraphQLDescription("Идентификатор товара")] int id,
        [Service] IProductService service) =>
        service.GetByIdAsync(id);

    // -------------------- Order --------------------
    [GraphQLDescription("Получить список заказов")]
    public Task<List<OrderDto>> GetOrders([Service] IOrderService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить заказ по его идентификатору")]
    public Task<OrderDto?> GetOrderById(
        [GraphQLDescription("Идентификатор заказа")] int id,
        [Service] IOrderService service) =>
        service.GetByIdAsync(id);

    // -------------------- OrderItem --------------------
    [GraphQLDescription("Получить список всех позиций заказов")]
    public Task<List<OrderItemDto>> GetOrderItems([Service] IOrderItemService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить позицию заказа по идентификатору")]
    public Task<OrderItemDto?> GetOrderItemById(
        [GraphQLDescription("Идентификатор позиции заказа")] int id,
        [Service] IOrderItemService service) =>
        service.GetByIdAsync(id);

    // -------------------- User --------------------
    [GraphQLDescription("Получить список пользователей")]
    public Task<List<UserDto>> GetUsers([Service] IUserService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить пользователя по идентификатору")]
    public Task<UserDto?> GetUserById(
        [GraphQLDescription("Идентификатор пользователя")] long id,
        [Service] IUserService service) =>
        service.GetByIdAsync(id);

    // -------------------- ChatMessage --------------------
    [GraphQLDescription("Получить список всех сообщений чата")]
    public Task<List<ChatMessageDto>> GetChatMessages([Service] IChatMessageService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить сообщение чата по идентификатору")]
    public Task<ChatMessageDto?> GetChatMessageById(
        [GraphQLDescription("Идентификатор сообщения")] int id,
        [Service] IChatMessageService service) =>
        service.GetByIdAsync(id);

    // -------------------- ChatSender --------------------
    [GraphQLDescription("Получить список типов отправителей сообщений")]
    public Task<List<ChatSenderDto>> GetChatSenders([Service] IChatSenderService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить отправителя по коду")]
    public Task<ChatSenderDto?> GetChatSenderByCode(
        [GraphQLDescription("Код отправителя (например, user, bot)")] string code,
        [Service] IChatSenderService service) =>
        service.GetByCodeAsync(code);

    // -------------------- OrderStatus --------------------
    [GraphQLDescription("Получить список возможных статусов заказов")]
    public Task<List<OrderStatusDto>> GetOrderStatuses([Service] IOrderStatusService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить статус заказа по коду")]
    public Task<OrderStatusDto?> GetOrderStatusByCode(
        [GraphQLDescription("Код статуса")] string code,
        [Service] IOrderStatusService service) =>
        service.GetByCodeAsync(code);

    // -------------------- ProductCategory --------------------
    [GraphQLDescription("Получить список всех категорий товаров")]
    public Task<List<ProductCategoryDto>> GetProductCategories([Service] IProductCategoryService service) =>
        service.GetAllAsync();

    [GraphQLDescription("Получить категорию товаров по идентификатору")]
    public Task<ProductCategoryDto?> GetProductCategoryById(
        [GraphQLDescription("Идентификатор категории")] int id,
        [Service] IProductCategoryService service) =>
        service.GetByIdAsync(id);
}


