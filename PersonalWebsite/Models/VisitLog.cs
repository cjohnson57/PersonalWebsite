namespace PersonalWebsite.Models
{
    public class VisitLog
    {
        public int VisitLogId { get; set; }
        public string URL { get; set; }
        public DateTime Time { get; set; }

        public VisitLog() { }

        public VisitLog(string url, DateTime time)
        {
            URL = url;
            Time = time;
        }
    }
}
