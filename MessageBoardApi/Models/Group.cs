namespace MessageBoardApi.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public string Name { get; set; }
    public List<Message> Messages { get; set; }
  }
}