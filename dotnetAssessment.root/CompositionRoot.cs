using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using dotnetAssessment.data;
using dotnetAssessment.business.Services;
using dotnetAssessment.business.Services.Impl;
using dotnetAssessment.data.Repositories;
using dotnetAssessment.data.Repositories.Impl;
namespace dotnetAssessment.root;
public class CompositionRoot
{
    public CompositionRoot()
    {
    }

    public static void injectDependencies(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(opts => opts.UseInMemoryDatabase("Database"));
        services.AddScoped<DatabaseContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IInvitationRepository, InvitationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

}
