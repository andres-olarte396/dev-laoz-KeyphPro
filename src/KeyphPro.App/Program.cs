using KeyphPro.Application.Commond;
using KeyphPro.Application.Services;
using KeyphPro.Domain.Repositories;
using KeyphPro.Domain.Repositories.Commands;
using KeyphPro.Domain.Repositories.Queries;
using KeyphPro.Domain.Services;
using KeyphPro.Infrastructure;
using KeyphPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreVO.Core.Entities.Commond;

namespace KeyphPro.App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = host.Services.GetRequiredService<AddAssessmentForm>();
            System.Windows.Forms.Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder()
        {
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                  .Build();

            return Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   // Registrar el logger genérico para todas las clases
                   services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

                   // Registro de AutoMapper
                   services.AddAutoMapper(typeof(MappingProfile).Assembly);

                   // Add the configuration to the services
                   services.AddSingleton(configuration);
                   // Configure the database connection
                   string commandConnection = configuration.GetConnectionString("CommandConnection");
                   string queryConnection = configuration.GetConnectionString("QueryConnection");

                   // Agrega KeyphProDbContext al contenedor de servicios
                   services.AddDbContext<KeyphProCommandDbContext>(
                    options =>
                        options.UseSqlite(commandConnection)
                                .LogTo(Console.WriteLine, LogLevel.Information));

                   services.AddDbContext<KeyphProQueryDbContext>(
                      options =>
                          options.UseSqlite(queryConnection)
                                 .LogTo(Console.WriteLine, LogLevel.Information));

                   // Registrar el patrón UnitOfWork
                   services.AddScoped<IUnitOfWork, UnitOfWork>();

                   // Registrar los repositorios
                   services.AddScoped(typeof(ICommandRepository<,>), typeof(CommandRepository<,>));
                   services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryRepository<,>));

                   // Registrar los servicios
                   services.AddTransient(typeof(IBasicService<,,>), typeof(BasicService<,,>));
                   services.AddTransient(typeof(IAssessmentService), typeof(AssessmentService));

                   // Register the main form and other usercontrols
                   services.AddScoped<AddAssessmentForm>();
               });
        }
    }
}