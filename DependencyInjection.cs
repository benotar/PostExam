using Exam.Data;
using Microsoft.EntityFrameworkCore;

namespace Exam;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SQLiteConnection");

        services.AddDbContext<PostsDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IPostsDbContext>(provider =>
            provider.GetService<PostsDbContext>());


        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });
        
        return services;
    }
}