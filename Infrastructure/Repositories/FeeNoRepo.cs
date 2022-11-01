namespace Infrastructure.Repositories
{
    public class FeeNoRepo
    {
        public long Id { get; set; }
        public string FeeNo { get; set; }
        public IList<Vs_IdRepo> Vs_IdRepos { get; set; }
    }
}
