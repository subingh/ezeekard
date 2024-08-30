using Microsoft.EntityFrameworkCore;
using EzeeKards.Data.Database;
using EzeeKard.Service.Converters;
using EzeeKard.Service.Implementations;
using EzeeKard.Service.Interfaces;
using EzeeKards.Service.Converter;
using EzeeKards.Service.Implementation;
using EzeeKards.Service.Implementations;
using EzeeKards.Service.Interfaces;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EzeeKard.Common.Helpers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Register converters
builder.Services.AddScoped<ClientConvertion>();
builder.Services.AddScoped<CompanyConverter>();
builder.Services.AddScoped<ErrorConverter>();
builder.Services.AddScoped<ExtraInfoConverter>();
builder.Services.AddScoped<ClientInformationConverter>();


// Register the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IErrorService, ErrorService>();
builder.Services.AddScoped<IClientExtraInfoService, ClientExtraInfoService>();
builder.Services.AddScoped<ICompanyExtraInfoService, CompanyExtraInfoService>();
builder.Services.AddScoped<IClientExtraInfoService, ClientExtraInfoService>();
builder.Services.AddScoped<IClientInformationService, ClientInformationService>();
builder.Services.AddScoped<IAdminService, AdminService>();

// Add services to the container
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ClaimsMiddleWare>();
app.MapControllers();


app.Run();
