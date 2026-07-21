using Pix.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte aos Controllers
builder.Services.AddControllers();

builder.Services.AddScoped<PixService>();

builder.Services.AddScoped<PixCodeGenerator>();

builder.Services.AddScoped<QrCodeService>();

// Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();