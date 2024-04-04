using App.Users.Business.Interface;
using App.Users.Business.Services;
using App.Users.Data;
using App.Users.Data.Interface;
using App.Users.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

//context
builder.Services.AddDbContext<UsersContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
var connection = builder.Services.AddDbContext<UsersContext>();

//repositorio
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

//servicio
builder.Services.AddScoped<IUsuariosService, UsuarioServices>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowMyOrigin");

app.MapControllers();

app.Run();
