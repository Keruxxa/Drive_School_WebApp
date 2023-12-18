using API.Server.Interfaces;
using API.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DriveSchoolDbContextConnection");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITheoryExamRepository, TheoryExamRepository>();
builder.Services.AddScoped<IPracticalExamRepository, PracticalExamRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

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
