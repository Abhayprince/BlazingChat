using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingChat.Server.Data.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public long Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }
        public DateTime SentOn { get; set; }

        [ForeignKey(nameof(Message.FromId))]
        public virtual User FromUser { get; set; }

        [ForeignKey(nameof(Message.ToId))]
        public virtual User ToUser { get; set; }
    }
}
