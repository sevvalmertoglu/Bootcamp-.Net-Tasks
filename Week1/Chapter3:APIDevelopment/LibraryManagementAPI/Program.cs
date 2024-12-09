using LibraryManagementAPI.Middleware.ErrorHandlingMiddleware;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
var redisConnectionString = "localhost:6379";
var redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();