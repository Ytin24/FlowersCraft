using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.GraphQL;

[GraphQLDescription("Операции записи, обновления и удаления данных")]
public class Mutation
{
    // -------------------- Product --------------------

    [GraphQLDescription("Создать новый товар")]
    public Task<ProductDto> CreateProduct(
        [GraphQLDescription("Данные товара")] ProductDto input,
        [Service] IProductService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить существующий товар")]
    public Task<bool> UpdateProduct(
        [GraphQLDescription("Идентификатор товара")] int id,
        [GraphQLDescription("Новые данные")] ProductDto input,
        [Service] IProductService service) =>
        service.UpdateAsync(id, input);

    [GraphQLDescription("Удалить товар по идентификатору")]
    public Task<bool> DeleteProduct(
        [GraphQLDescription("Идентификатор товара")] int id,
        [Service] IProductService service) =>
        service.DeleteAsync(id);

    // -------------------- Order --------------------

    [GraphQLDescription("Создать новый заказ")]
    public Task<OrderDto> CreateOrder(
        [GraphQLDescription("Данные заказа")] OrderDto input,
        [Service] IOrderService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить заказ по ID")]
    public Task<bool> UpdateOrder(
        [GraphQLDescription("ID заказа")] int id,
        [GraphQLDescription("Новые данные")] OrderDto input,
        [Service] IOrderService service) =>
        service.UpdateAsync(id, input);

    [GraphQLDescription("Удалить заказ по ID")]
    public Task<bool> DeleteOrder(
        [GraphQLDescription("ID заказа")] int id,
        [Service] IOrderService service) =>
        service.DeleteAsync(id);

    // -------------------- OrderItem --------------------

    [GraphQLDescription("Создать элемент заказа")]
    public Task<OrderItemDto> CreateOrderItem(
        [GraphQLDescription("Данные элемента заказа")] OrderItemDto input,
        [Service] IOrderItemService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить элемент заказа")]
    public Task<bool> UpdateOrderItem(
        [GraphQLDescription("ID элемента заказа")] int id,
        [GraphQLDescription("Новые данные")] OrderItemDto input,
        [Service] IOrderItemService service) =>
        service.UpdateAsync(id, input);

    [GraphQLDescription("Удалить элемент заказа")]
    public Task<bool> DeleteOrderItem(
        [GraphQLDescription("ID элемента заказа")] int id,
        [Service] IOrderItemService service) =>
        service.DeleteAsync(id);

    // -------------------- User --------------------

    [GraphQLDescription("Создать нового пользователя")]
    public Task<UserDto> CreateUser(
        [GraphQLDescription("Данные пользователя")] UserDto input,
        [Service] IUserService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить пользователя")]
    public Task<bool> UpdateUser(
        [GraphQLDescription("ID пользователя")] long id,
        [GraphQLDescription("Новые данные")] UserDto input,
        [Service] IUserService service) =>
        service.UpdateAsync(id, input);

    [GraphQLDescription("Удалить пользователя")]
    public Task<bool> DeleteUser(
        [GraphQLDescription("ID пользователя")] long id,
        [Service] IUserService service) =>
        service.DeleteAsync(id);

    // -------------------- ChatMessage --------------------

    [GraphQLDescription("Создать сообщение чата")]
    public Task<ChatMessageDto> CreateChatMessage(
        [GraphQLDescription("Данные сообщения")] ChatMessageDto input,
        [Service] IChatMessageService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить сообщение чата")]
    public Task<bool> UpdateChatMessage(
        [GraphQLDescription("ID сообщения")] int id,
        [GraphQLDescription("Новые данные")] ChatMessageDto input,
        [Service] IChatMessageService service) =>
        service.UpdateAsync(id, input);

    [GraphQLDescription("Удалить сообщение чата")]
    public Task<bool> DeleteChatMessage(
        [GraphQLDescription("ID сообщения")] int id,
        [Service] IChatMessageService service) =>
        service.DeleteAsync(id);

    // -------------------- ChatSender --------------------

    [GraphQLDescription("Создать тип отправителя")]
    public Task<ChatSenderDto> CreateChatSender(
        [GraphQLDescription("Данные отправителя")] ChatSenderDto input,
        [Service] IChatSenderService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить отправителя")]
    public Task<bool> UpdateChatSender(
        [GraphQLDescription("Код отправителя")] string code,
        [GraphQLDescription("Новые данные")] ChatSenderDto input,
        [Service] IChatSenderService service) =>
        service.UpdateAsync(code, input);

    [GraphQLDescription("Удалить отправителя")]
    public Task<bool> DeleteChatSender(
        [GraphQLDescription("Код отправителя")] string code,
        [Service] IChatSenderService service) =>
        service.DeleteAsync(code);

    // -------------------- OrderStatus --------------------

    [GraphQLDescription("Создать статус заказа")]
    public Task<OrderStatusDto> CreateOrderStatus(
        [GraphQLDescription("Данные статуса")] OrderStatusDto input,
        [Service] IOrderStatusService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить статус заказа")]
    public Task<bool> UpdateOrderStatus(
        [GraphQLDescription("Код статуса")] string code,
        [GraphQLDescription("Новые данные")] OrderStatusDto input,
        [Service] IOrderStatusService service) =>
        service.UpdateAsync(code, input);

    [GraphQLDescription("Удалить статус заказа")]
    public Task<bool> DeleteOrderStatus(
        [GraphQLDescription("Код статуса")] string code,
        [Service] IOrderStatusService service) =>
        service.DeleteAsync(code);

    // -------------------- ProductCategory --------------------

    [GraphQLDescription("Создать категорию товаров")]
    public Task<ProductCategoryDto> CreateProductCategory(
        [GraphQLDescription("Данные категории")] ProductCategoryDto input,
        [Service] IProductCategoryService service) =>
        service.CreateAsync(input);

    [GraphQLDescription("Обновить категорию товаров")]
    public Task<bool> UpdateProductCategory(
        [GraphQLDescription("ID категории")] int id,
        [GraphQLDescription("Новые данные")] ProductCategoryDto input,
        [Service] IProductCategoryService service) =>
        service.UpdateAsync(id, input);

    [GraphQLDescription("Удалить категорию товаров")]
    public Task<bool> DeleteProductCategory(
        [GraphQLDescription("ID категории")] int id,
        [Service] IProductCategoryService service) =>
        service.DeleteAsync(id);
}


