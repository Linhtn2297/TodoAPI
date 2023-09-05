using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Reload when appsetings change
builder.Configuration.AddJsonFile("appsettings.json", false, true);

// Mysql service
builder.Services.AddEntityFrameworkMySQL().AddDbContext<TodoDbContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Cors policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(builder.Configuration.GetSection("CorsPolicy")["AllowedHosts"])
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ITodoAccess, TodoAccess>();
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

app.MapGet("/", () => "ToDo API \nVersion 1.0 \nCopyright 2023 by Sorimachi Viet Nam");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/api/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
