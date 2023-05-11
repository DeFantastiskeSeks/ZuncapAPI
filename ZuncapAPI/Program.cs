using Microsoft.AspNetCore.Authentication.Cookies;
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


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(opt =>

{

    opt.Cookie.Name = "zuncookies";
    opt.LoginPath = "/api/Users/login";
    opt.LogoutPath = "/api/Users/home";


});


var optionsBuilder = 
    new DbContextOptionsBuilder<UserDbContext>();
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(Secrets.ConnectionString));
UserDbContext userDbContext = 
    new UserDbContext(optionsBuilder.Options);
builder.Services.AddScoped<IUserRepository>(sp =>
    new UserRepositoryDB(sp.GetService<UserDbContext>()));

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
