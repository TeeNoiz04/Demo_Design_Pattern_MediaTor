using Demo_Design_Pattern_MediaTor.Application.Handlers;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IRepository;
using Demo_Design_Pattern_MediaTor.Domain.Interfaces.IService;
using Demo_Design_Pattern_MediaTor.Infrastructure.Repositories;
using Demo_Design_Pattern_MediaTor.Infrastructure;
using Demo_Design_Pattern_MediaTor.Services;

using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Demo_Design_Pattern_MediaTor.Application.Validators;
using Microsoft.AspNetCore.Mvc;
using Demo_Design_Pattern_MediaTor.Middlewares;
using Demo_Design_Pattern_MediaTor.Behaviors;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("OrdersDb"));
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateOrderCommandValidator>());


builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddMediatR(typeof(CreateOrderCommandHandler).Assembly);
// Đăng ký pipeline validation
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.MapControllers();




app.Run();
