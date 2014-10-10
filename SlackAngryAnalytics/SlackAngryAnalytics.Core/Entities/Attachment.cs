namespace SlackAngryAnalytics.Core.Entities
{
    public class Attachment : ISlackEntity
    {
        public string ServiceName { get; set; }
        public string Title { get; set; }
        public string TitleLink { get; set; }
        public string Text { get; set; }
        public string FallBack { get; set; }
        public string FromUrl { get; set; }
        public long Id { get; set; }

    }
}