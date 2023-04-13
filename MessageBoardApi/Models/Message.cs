using System.Text.Json;
using System.Text.Json.Serialization;

namespace MessageBoardApi.Models
{
  public class Message
  {
    [JsonIgnore]
    public int MessageId { get; set; }
    public string Author { get; set; }
    public string Text { get; set; }
    public int GroupId { get; set; }
    [JsonIgnore]
    public Group Group { get; set; }

  }
}