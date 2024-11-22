namespace PersonalWebsite.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime DateWritten { get; set; }
    }
}
