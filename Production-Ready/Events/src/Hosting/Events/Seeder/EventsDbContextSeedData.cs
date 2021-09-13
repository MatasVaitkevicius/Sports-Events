using Events.Repository.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using SportTypePoco = Events.Repository.Pocos.SportType;

namespace Events.Seeder
{
    public static class EventsDbContextSeedData
    {
        public static void SeedData(this IServiceScopeFactory scopeFactory)
        {
            using (var serviceScope = scopeFactory.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EventsDbContext>();
                if (!context.SportTypes.Any())
                {
                    var sportTypes = new List<SportTypePoco>
                    {
                        new SportTypePoco()
                        {
                            Name = "Basketball"
                        },
                        new SportTypePoco()
                        {
                            Name = "Table Tennis"
                        },
                        new SportTypePoco()
                        {
                            Name = "Football"
                        },
                        new SportTypePoco()
                        {
                            Name = "Other"
                        },
                    };
                    context.AddRange(sportTypes);
                    context.SaveChanges();
                }
            }

        }
    }
}