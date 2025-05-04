using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.Abstract;
using Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Repositories.EfRepositories;
using Repositories.Contexts;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<BootcampContext>(options =>
    options.UseInMemoryDatabase("BootcampDb"));

// Repositories
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IInstructorRepository, EfInstructorRepository>();
builder.Services.AddScoped<IApplicantRepository, EfApplicantRepository>();
builder.Services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();

// Services
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<IApplicantService, ApplicantManager>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
