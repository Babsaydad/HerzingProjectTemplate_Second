namespace HerzingProjectTemplate.Models
{
    public class Rank
    {
        public int RankId { get; set; }
        public string Category { get; set; } = string.Empty;
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string RankName { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
