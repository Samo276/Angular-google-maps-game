namespace gAPI
{
    public class QuestItem
    {
        public int Id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string Question { get; set; }
        public bool Answer { get; set; }
        public bool IsDone { get; set; }
        public bool Correct { get; set; }
        public double Range {get; set; }
    }
}
