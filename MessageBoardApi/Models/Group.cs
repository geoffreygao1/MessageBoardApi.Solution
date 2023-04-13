using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace MessageBoardApi.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [JsonIgnore]
    public List<Message> Messages { get; set; }
  }
}