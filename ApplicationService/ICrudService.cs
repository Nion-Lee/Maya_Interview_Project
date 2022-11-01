using Infrastructure.Repositories;

namespace ApplicationService
{
    public interface ICrudService
    {
        public Task<FeeNoRepo> Get(string feeNo, CancellationToken stoppingToken);
        public Task<IList<FeeNoRepo>> GetAll(CancellationToken stoppingToken);
        public Task<FeeNoRepo> Update(FeeNoRepo entity, CancellationToken stoppingToken);
        public Task<FeeNoRepo> Create(FeeNoRepo entity, CancellationToken stoppingToken);
        public Task<FeeNoRepo> Delete(string feeNo, CancellationToken stoppingToken);
    }
}
