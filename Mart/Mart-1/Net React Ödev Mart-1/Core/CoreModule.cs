using Business;
using DataAccess;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class CoreModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository<ProgrammingLanguage>, ProgrammingLanguageRepository>();
            services.AddScoped<IRepository<Technology>, TechnologyRepository>();
            services.AddScoped<ProgrammingLanguageService>();
            services.AddScoped<TechnologyService>();
        }
    }

}
