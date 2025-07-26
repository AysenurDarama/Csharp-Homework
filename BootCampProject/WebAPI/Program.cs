using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Core.Security.JWT;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositories.Abstract;
using Repositories.Concrete;
using Repositories.Contexts;
using Repositories.EfRepositories;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//JWT CONFIGURATION
builder.Services.AddSingleton<ITokenHelper, JwtHelper>();

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
builder.Services.AddScoped<IBlacklistRepository, EfBlacklistRepository>();

// Services
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<IApplicantService, ApplicantManager>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IApplicationService, ApplicationManager>();
builder.Services.AddScoped<IBootcampService, BootcampManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();


// Business Rules
builder.Services.AddScoped<ApplicantBusinessRules>();
builder.Services.AddScoped<BootcampBusinessRules>();
builder.Services.AddScoped<ApplicationBusinessRules>();
builder.Services.AddScoped<BlacklistBusinessRules>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bootcamp API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer eyJhbGciOi...\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controllers
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
