using API.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;
using ReactApp.Server.Services.UserService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserDbContextConnection");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy(name: "UsersOrigins",
    policy =>
    {
        policy.WithOrigins("https://localhost:5173").AllowAnyMethod().AllowAnyHeader();
    }));


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("UsersOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
