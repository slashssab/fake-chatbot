namespace FakeChatbot.Domain
{
    public class ChatHistoryItem
    {
        public Guid Id { get; set; }
        public AuthorEnum Author { get; private set; }
        public string Text { get; private set; }
        public MessageMarkEnum? Mark { get; private set; }
        public DateTime Timestamp { get; private set; }

        public static ChatHistoryItem Create(AuthorEnum author,
            string text)
        {
            return new ChatHistoryItem
            {
                Author = author,
                Text = text,
                Timestamp = DateTime.Now
            };
        }

        public void UpdateMark(MessageMarkEnum newMark)
        {
            Mark = newMark;
    }
    }
}
