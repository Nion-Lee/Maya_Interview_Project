namespace Infrastructure.Repositories
{
    /// 
    /// 更細節的正規化我就沒做了，因為裡面有很多欄位存的是json字串.....
    /// 

    public class HealthItemRepo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? VS_PART { set; get; }
        public string? VS_RECORD { set; get; }
        public string? VS_REASON { set; get; }
        public string? VS_MEMO { set; get; }
        public string? CREATE_ID { set; get; }
        public string? CREATE_NAME { set; get; }
        public DateTimeOffset CREATE_DATE { set; get; } = DateTimeOffset.Now;
        public string? MODIFY_ID { set; get; }
        public string? MODIFY_NAME { set; get; }
        public DateTimeOffset MODIFY_DATE { set; get; } = DateTimeOffset.Now;
        public string? VS_OTHER_MEMO { set; get; }
        public string? VS_TYPE { set; get; }
        public string? VS_CARE { set; get; }
    }
}