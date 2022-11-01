namespace Infrastructure.Dtos
{
    public class HealthItemDto
    {
        public string Name { get; set; }
        public string? VS_PART { set; get; }
        public string? VS_RECORD { set; get; }
        public string? VS_REASON { set; get; }
        public string? VS_MEMO { set; get; }
        public string? CREATE_ID { set; get; }
        public string? CREATE_NAME { set; get; }
        public string? MODIFY_ID { set; get; }
        public string? MODIFY_NAME { set; get; }
        public DateTimeOffset MODIFY_DATE { set; get; } = DateTimeOffset.Now;
        public string? VS_OTHER_MEMO { set; get; }
        public string? VS_TYPE { set; get; }
        public string? VS_CARE { set; get; }
    }
}