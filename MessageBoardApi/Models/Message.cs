using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MessageBoardApi.Models
{
  public class Message
  {
    [JsonIgnore]
    public int MessageId { get; set; }
    [Required]
    [StringLength(20)]
    public string Author { get; set; }
    [Required]
    public string Text { get; set; }
    public DateTime Date { get; set; }
    [Required]
    public int GroupId { get; set; }
    [JsonIgnore]
    public Group Group { get; set; }

  }
}