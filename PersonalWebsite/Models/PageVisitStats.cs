namespace PersonalWebsite.Models
{
    public class PageVisitStats
    {
        public string URL { get; set; }
        public int VisitsEver { get; set; }
        public int VisitsYear { get; set; }
        public int VisitsMonth { get; set; }

        public PageVisitStats() { }

        public PageVisitStats(string url, int visitsEver, int visitsYear, int visitsMonth)
        {
            URL = url;
            VisitsEver = visitsEver;
            VisitsYear = visitsYear;
            VisitsMonth = visitsMonth;
        }
    }
}
