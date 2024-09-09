using EvinceDev.Service.Interfaces;
using EvinceDev.Service.Services;
using EvinceDevPracticalTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using EvinceDev.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:3000", "*").AllowAnyHeader().AllowAnyMethod())
);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});


builder.Services.AddApiVersioning(option => { 
    option.AssumeDefaultVersionWhenUnspecified=true;
    option.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddNewtonsoftJson(options => options.SerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var connectionString = "Server=(localDB)\\local;Database=EvinceDevTestDB;Trusted_Connection=True;TrustServerCertificate=True;"; //builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<DbContext, ApplicationContext>(s => s.GetService<ApplicationContext>());

builder.Services.AddScoped<EvinceDev.Entity.ApplicationContext>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
