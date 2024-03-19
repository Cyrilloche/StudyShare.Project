using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudyShare.Application.Interfaces;
using StudyShare.Application.Services;
using StudyShare.Domain.Interfaces;
using StudyShare.Domain.Repositories;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;
using StudyShare.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IClassLevelRepository, ClassLevelRepository>();
builder.Services.AddScoped<IClassLevelService, ClassLevelService>();

builder.Services.AddScoped<IUserClassLevelRepository, UserClassLevelRepository>();
builder.Services.AddScoped<IUserClassLevelService, UserClassLevelService>();

builder.Services.AddScoped<IPaperRepository, PaperRepository>();
builder.Services.AddScoped<IPaperService, PaperService>();

builder.Services.AddScoped<IKeywordRepository, KeywordRepository>();
builder.Services.AddScoped<IKeywordService, KeywordService>();

builder.Services.AddScoped<IPaperKeywordRepository, PaperKeywordRepository>();
builder.Services.AddScoped<IPaperKeywordService, PaperKeywordService>();

builder.Services.AddScoped<IPaperClassLevelRepository, PaperClassLevelRepository>();
builder.Services.AddScoped<IPaperClassLevelService, PaperClassLevelService>();

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authoriaztion header using the Bearer scheme (\"bearer {token}\")",
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false

        };
    });

// builder.Services.AddDbContextPool<StudyShareDbContext>(options =>
//         {
//             options.UseSqlServer(@"Server=.; Database=StudyShareDB; Trusted_Connection=True; Encrypt=False;");
//         });

builder.Services.AddDbContextPool<StudyShareDbContext>(options =>
        {
            var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyShareProject");
    });
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://127.0.0.1:5500");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
