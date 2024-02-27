using Apes.SugarKingdom.Application;
using Apes.SugarKingdom.Application.Profiles;
using Apes.SugarKingdom.Data;
using Microsoft.EntityFrameworkCore;

var corsOrigins = "corsOrigins";

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAutoMapper(
            typeof(SugarProfile)
        );

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    options.AddPolicy(name: corsOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://localhost:3000", "https://game.sugarkingdom.io", "https://sugar-kingdom-odyssey.vercel.app");
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
}));

// Add services to the container.
builder.Services.AddScoped<IVersusService, VersusService>();

builder.Services.AddDbContext<ISugarContext, SugarContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(corsOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/healthz");

app.Run();
