using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DbContexts
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AdventistContext(serviceProvider.GetRequiredService<DbContextOptions<AdventistContext>>());

            if (await context.HealthItem.AnyAsync())
            {
                return;
            }

            await context.FeeNos.AddRangeAsync(_data);
            await context.SaveChangesAsync();
        }

        private static IList<FeeNoRepo> _data = 
            new FeeNoRepo[]
            {
                new FeeNoRepo
                {
                    FeeNo = "1",
                    Vs_IdRepos = new Vs_IdRepo[1]
                    {
                        new Vs_IdRepo
                        {
                            VS_ID = "111",
                            HealthItemRepos=new HealthItemRepo[1]
                            {
                                new HealthItemRepo
                                {
                                    Name = HealthItemName.avpu,
                                    VS_RECORD = "Test1"
                                }
                            }
                        }
                    }
                },
                new FeeNoRepo
                {
                    FeeNo = "2",
                    Vs_IdRepos = new Vs_IdRepo[1]
                    {
                        new Vs_IdRepo
                        {
                            VS_ID = "222",
                            HealthItemRepos=new HealthItemRepo[1]
                            {
                                new HealthItemRepo
                                {
                                    Name = HealthItemName.bw,
                                    VS_RECORD = "Test2"
                                }
                            }
                        }
                    }
                },
                new FeeNoRepo
                {
                    FeeNo = "3",
                    Vs_IdRepos = new Vs_IdRepo[1]
                    {
                        new Vs_IdRepo
                        {
                            VS_ID = "333",
                            HealthItemRepos=new HealthItemRepo[1]
                            {
                                new HealthItemRepo
                                {
                                    Name = HealthItemName.limbs_weakness,
                                    VS_RECORD = "Test3"
                                }
                            }
                        }
                    }
                }
            };
    }
}