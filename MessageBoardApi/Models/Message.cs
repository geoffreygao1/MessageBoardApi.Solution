namespace MessageBoardApi.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Author { get; set; }
    public string Text { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }

  }
}