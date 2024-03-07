using Microsoft.EntityFrameworkCore;
using StudyShare.Application.Interfaces;
using StudyShare.Application.Services;
using StudyShare.Domain.Interfaces;
using StudyShare.Domain.Repositories;
using StudyShare.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapControllers();
app.Run();
