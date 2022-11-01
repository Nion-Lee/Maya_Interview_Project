using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService
{
    public sealed class CrudService : ICrudService
    {
        private readonly IDbContextFactory<AdventistContext> _contextFactory;

        public CrudService(IDbContextFactory<AdventistContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<FeeNoRepo> Get(string feeNo, CancellationToken stoppingToken)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.FeeNos.AsNoTracking()
                .Include(f => f.Vs_IdRepos)
                .ThenInclude(v => v.HealthItemRepos)
                .FirstOrDefaultAsync(h => h.FeeNo == feeNo, stoppingToken);
        }

        public async Task<IList<FeeNoRepo>> GetAll(CancellationToken stoppingToken)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.FeeNos.AsNoTracking()
                .Include(f => f.Vs_IdRepos)
                .ThenInclude(v => v.HealthItemRepos)
                .ToArrayAsync(stoppingToken);
        }

        public async Task<FeeNoRepo> Update(FeeNoRepo entity, CancellationToken stoppingToken)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.FeeNos
                .Include(f => f.Vs_IdRepos)
                .ThenInclude(v => v.HealthItemRepos)
                .FirstOrDefaultAsync(h => h.FeeNo == entity.FeeNo, stoppingToken);

            if (item == null)
                return null;

            SetValues(item, entity);

            await context.SaveChangesAsync(stoppingToken);
            return item;
        }

        public async Task<FeeNoRepo> Create(FeeNoRepo entity, CancellationToken stoppingToken)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.FeeNos.AddAsync(entity, stoppingToken);

            await context.SaveChangesAsync(stoppingToken);
            return item.Entity;
        }

        public async Task<FeeNoRepo> Delete(string feeNo, CancellationToken stoppingToken)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.FeeNos.AsNoTracking()
                .Include(f => f.Vs_IdRepos)
                .ThenInclude(v => v.HealthItemRepos)
                .FirstOrDefaultAsync(h => h.FeeNo == feeNo, stoppingToken);

            if (item == null)
                return null;

            var removed = context.FeeNos.Remove(item);
            await context.SaveChangesAsync(stoppingToken);

            return removed.Entity;
        }

        private void SetValues(FeeNoRepo origin, FeeNoRepo newValue)
        {
            for (int i = 0; i < origin.Vs_IdRepos.Count; i++)
            {
                for (int j = 0; j < origin.Vs_IdRepos[i].HealthItemRepos.Count; j++)
                {
                    origin.Vs_IdRepos[i].HealthItemRepos[j] = newValue.Vs_IdRepos[i].HealthItemRepos[j];
                }
            }
        }
    }
}
