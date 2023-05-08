using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ZuncapAPI.Context;
using ZuncapAPI.Repository;
using ZuncapAPI.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
optionsBuilder.UseSqlServer(Secrets.ConnectionString);
UserDbContext userDbContext = new UserDbContext(optionsBuilder.Options);
builder.Services.AddSingleton<UserRepository>(new UserRepository(userDbContext));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
