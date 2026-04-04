using FacultyLink.Middleware;
using FacultyLinkApplication.Interface;
using FacultyLinkApplication.Service;
using FacultyLinkDomain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using FacultyLinkApplication.Dto;

var builder = WebApplication.CreateBuilder(args);

//Configuration
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string not found");

var _tokenConfig = builder.Configuration.Get<TokenManagementDto>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Creates a new file daily
    .CreateLogger();


// Add services to the container.
builder.Host.UseSerilog();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
{
    ValidateAudience = false,
    ValidateIssuer = true,
    ValidateIssuerSigningKey = true,
    ValidateLifetime = true,

    ValidIssuer = _tokenConfig.Issuer,
    ValidAudience = _tokenConfig.Audience,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfig.SecretKey))    

});
   

builder.Services.AddScoped<ISecurity, SecurityService>();
builder.Services.AddScoped<IUser, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<AppErrorHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
