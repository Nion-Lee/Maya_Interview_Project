namespace Infrastructure.Dtos
{
    public class Vs_IdDto
    {
        public string VS_ID { get; set; }
        public IList<HealthItemDto> HealthItemRepos { get; set; }
    }
}
