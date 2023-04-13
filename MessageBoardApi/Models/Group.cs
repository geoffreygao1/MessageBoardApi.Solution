using System.Text.Json;
using System.Text.Json.Serialization;

namespace MessageBoardApi.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<Message> Messages { get; set; }
  }
}