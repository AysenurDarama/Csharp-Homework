using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.Abstract;
using Repositories.Concrete;
using Repositories.Contexts;
using Repositories.EfRepositories;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<BootcampContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BootcampDb")));


// Repositories
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IInstructorRepository, EfInstructorRepository>();
builder.Services.AddScoped<IApplicantRepository, EfApplicantRepository>();
builder.Services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();
builder.Services.AddScoped<IApplicationRepository, EfApplicationRepository>();
builder.Services.AddScoped<IBootcampRepository, EfBootcampRepository>();


// Services
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<IApplicantService, ApplicantManager>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IApplicationService, ApplicationManager>();
builder.Services.AddScoped<IBootcampService, BootcampManager>();


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
    app.UseDeveloperExceptionPage();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
