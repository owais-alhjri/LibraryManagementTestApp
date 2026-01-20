using DotNetEnv;
using LMS.API.Middleware;
using LMS.Application.Interfaces;
using LMS.Application.Services;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Persistence;
using LMS.Infrastructure.Repositories;
using LMS.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, IdentityPasswordHasher>();
builder.Services.AddScoped<IBorrowRecordRepository, BorrowRecordRepository>();
builder.Services.AddScoped<IBorrowRecordService, BorrowRecordService>();

builder.Services.AddDbContext<LmsDbContext>(options =>
{
    var host = Environment.GetEnvironmentVariable("DB_HOST");
    var port = Environment.GetEnvironmentVariable("DB_PORT");
    var db = Environment.GetEnvironmentVariable("DB_NAME");
    var user = Environment.GetEnvironmentVariable("DB_USER");
    var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

    var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";
    options.UseNpgsql(connectionString);
}
);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Env.Load();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();
/*v
using(var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LmsDbContext>();

    var book = new LMS.Domain.Entities.Book(
        "Diary of a wimpy ked 3",
        "Jeff Kinney"
        );

    db.Books.Add(book);

    ar user = new LMS.Domain.Entities.User(
        "OWAIS",
        "OWAIS@GMAIL.COM",
        "OWAIS12345"
        );
    db.Users.Add(user);
    
    db.SaveChanges();
    Console.WriteLine("✅ Book inserted into database");
}*/

app.Run();
