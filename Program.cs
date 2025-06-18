using demo_mediator_design_pattern.database;
using demo_mediator_design_pattern.handlers;
using demo_mediator_design_pattern.handlers.interfaces;
using demo_mediator_design_pattern.mediators;
using demo_mediator_design_pattern.mediators.interfaces;
using demo_mediator_design_pattern.services;
using Microsoft.EntityFrameworkCore;


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IOrderMediator, OrderMediator>();
builder.Services.AddScoped<IOrderHandler, OrderHandler>();
builder.Services.AddScoped<IInventoryMediator, InventoryMediator>();
builder.Services.AddScoped<IInventoryHandler, InventoryHandler>();
builder.Services.AddScoped<IPaymentHandler, PaymentHandler>();
builder.Services.AddScoped<IPaymentMediator, PaymentMediator>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();