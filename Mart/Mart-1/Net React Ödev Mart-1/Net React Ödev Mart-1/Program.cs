using Business;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=technologies.db"))
            .AddScoped<ProgrammingLanguageService>()
            .AddScoped<TechnologyService>()
            .AddScoped<IRepository<ProgrammingLanguage>, ProgrammingLanguageRepository>()
            .AddScoped<IRepository<Technology>, TechnologyRepository>()
            .BuildServiceProvider();

        var dbContext = serviceProvider.GetService<ApplicationDbContext>();

        dbContext.Database.Migrate();

        var programmingLanguageService = serviceProvider.GetService<ProgrammingLanguageService>();
        var technologyService = serviceProvider.GetService<TechnologyService>();

        bool continueApp = true;

        while (continueApp)
        {
            
            Console.Clear();
            Console.WriteLine("Lütfen bir işlem seçin:");
            Console.WriteLine("1. Programlama Dili Ekle");
            Console.WriteLine("2. Teknoloji Ekle");
            Console.WriteLine("3. Programlama Dillerini Listele");
            Console.WriteLine("4. Teknolojileri Listele");
            Console.WriteLine("5. Programlama Dili Sil");
            Console.WriteLine("6. Teknoloji Sil");
            Console.WriteLine("7. Çıkış");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                 
                    Console.Write("Programlama dili adı girin: ");
                    var languageName = Console.ReadLine();

                    var programmingLanguage = new ProgrammingLanguage { Name = languageName };
                    programmingLanguageService.AddProgrammingLanguage(programmingLanguage);

                    Console.WriteLine($"Programlama dili {languageName} başarıyla eklendi.");
                    break;

                case "2":
                   
                    Console.Write("Teknoloji adı girin: ");
                    var technologyName = Console.ReadLine();

                    Console.Write("Teknolojinin bağlı olduğu programlama dilini girin: ");
                    var associatedLanguageName = Console.ReadLine();

                    var associatedLanguage = programmingLanguageService.GetAllProgrammingLanguages()
                        .FirstOrDefault(lang => lang.Name.Equals(associatedLanguageName, StringComparison.OrdinalIgnoreCase));

                    if (associatedLanguage != null)
                    {
                        var technology = new Technology { Name = technologyName, ProgrammingLanguage = associatedLanguage };
                        technologyService.AddTechnology(technology);
                        Console.WriteLine($"Teknoloji {technologyName} başarıyla eklendi.");
                    }
                    else
                    {
                        Console.WriteLine("Geçerli bir programlama dili girin.");
                    }
                    break;

                case "3":
                   
                    Console.WriteLine("\nProgramlama Dilleri:");
                    foreach (var lang in programmingLanguageService.GetAllProgrammingLanguages())
                    {
                        Console.WriteLine($"- {lang.Name}");
                    }
                    break;

                case "4":
                 
                    Console.WriteLine("\nTeknolojiler:");
                    foreach (var tech in technologyService.GetAllTechnologies())
                    {
                        Console.WriteLine($"- {tech.Name} (Bağlı olduğu dil: {tech.ProgrammingLanguage.Name})");
                    }
                    break;

                case "5":
                    
                    Console.Write("Silmek istediğiniz programlama dilinin adını girin: ");
                    var deleteLanguageName = Console.ReadLine();

                    var languageToDelete = programmingLanguageService.GetAllProgrammingLanguages()
                        .FirstOrDefault(lang => lang.Name.Equals(deleteLanguageName, StringComparison.OrdinalIgnoreCase));

                    if (languageToDelete != null)
                    {
                        programmingLanguageService.DeleteProgrammingLanguage(languageToDelete);
                        Console.WriteLine($"Programlama dili {deleteLanguageName} başarıyla silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Silmek istediğiniz dil bulunamadı.");
                    }
                    break;

                case "6":
                   
                    Console.Write("Silmek istediğiniz teknolojinin adını girin: ");
                    var deleteTechnologyName = Console.ReadLine();

                    var technologyToDelete = technologyService.GetAllTechnologies()
                        .FirstOrDefault(tech => tech.Name.Equals(deleteTechnologyName, StringComparison.OrdinalIgnoreCase));

                    if (technologyToDelete != null)
                    {
                        technologyService.DeleteTechnology(technologyToDelete);
                        Console.WriteLine($"Teknoloji {deleteTechnologyName} başarıyla silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Silmek istediğiniz teknoloji bulunamadı.");
                    }
                    break;

                case "7":
                   
                    continueApp = false;
                    Console.WriteLine("Çıkılıyor...");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçenek, tekrar deneyin.");
                    break;
            }

            
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
