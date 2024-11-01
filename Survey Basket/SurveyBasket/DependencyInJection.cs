using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using MapsterMapper;


using SurveyBasket.Persistence;
using System.Reflection;


namespace SurveyBasket
{
    public static class DependencyInJection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services , 
            IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();

            var connectionstring = configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(connectionstring));

            services
                .AddSwaggerServices()
                .AddMapsterConfig()
                .AddFluentValidation();

            services.AddScoped<IPollServices, PollServices>();

            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;
        }
        public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {
            //Add Mapster
            var mappingconfig = TypeAdapterConfig.GlobalSettings;
            mappingconfig.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton<IMapper>(new Mapper(mappingconfig));
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.
                AddFluentValidationAutoValidation().
                AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
    
}
