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
    private readonly IServiceCollection _services;
    public CompositionRoot(IServiceCollection services)
    {
        this._services = services;
    }

    public void Compose()
    {
        _services.AddDbContext<DatabaseContext>(opts => opts.UseInMemoryDatabase("Database"));
        _services.AddScoped<DatabaseContext>();
        _services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        _services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        _services.AddScoped<IEventRepository, EventRepository>();
        _services.AddScoped<IInvitationRepository, InvitationRepository>();
        _services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
