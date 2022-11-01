namespace Infrastructure.Repositories
{
    public class Vs_IdRepo
    {
        public long Id { get; set; }
        public string VS_ID { get; set; }
        public IList<HealthItemRepo> HealthItemRepos { get; set; }
    }
}
