using Events.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Repository.Startup
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventsDbContext>(options =>
                options.UseSqlite("connection", b => b.MigrationsAssembly("Events.Repository.Contexts")));
        }
    }
}