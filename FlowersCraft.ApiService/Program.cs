using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.GraphQL;
using FlowersCraft.ApiService.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddDbContextFactory<FlowersCraftDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("FlowersCraft")
         ?? throw new InvalidOperationException("Connection string 'FlowersCraft' not found.")
    )
);
builder.Services.AddControllers();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IChatMessageService, ChatMessageService>();
builder.Services.AddScoped<IChatSenderService, ChatSenderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();


builder.Services.AddMapster();


var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "FlowersCraft API";
        options.ShowSidebar = true;
    });
}

app.MapDefaultEndpoints();
app.MapControllers();
app.MapGraphQL();
app.UseCors();

await app.RunAsync();