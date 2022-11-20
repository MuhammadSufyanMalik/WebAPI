using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MilliKutuphaneBusiness.Abstract;
using MilliKutuphaneBusiness.Concrete;
using MilliKutuphaneDataAccess.Abstract;
using MilliKutuphaneDataAccess.Concrete.EntityFramework;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();

builder.Services.AddSingleton<IGateService, GateService>();
builder.Services.AddSingleton<IGatesDal, EfGatesDal>();

builder.Services.AddSingleton<IStudentDal, EfStudentDal>();

builder.Services.AddSingleton<IAdminService, AdminService>();
builder.Services.AddSingleton<IAdminDal, EfAdminDal>();

builder.Services.AddSingleton<ISchoolService, SchoolService>();
builder.Services.AddSingleton<ISchoolDal, EfSchoolDal>();

builder.Services.AddSingleton<IUserHistoryService, UserHistoryService>();
builder.Services.AddSingleton<IUserHistoryDal, EfUserHistoryDal>();

builder.Services.AddSingleton<IUserQrCodeDal, EfUserQrCodeDal>();







builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"Bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
