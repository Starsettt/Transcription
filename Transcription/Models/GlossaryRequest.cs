using System.ComponentModel.DataAnnotations;

namespace Transcription.Models
{
    public class GlossaryRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required(ErrorMessage = "Внесите термин")]
        public string Term { get; set; } = string.Empty;

        [Required(ErrorMessage = "Внесите описание")]
        public string Description {  get; set; } = string.Empty;

        public Enums.GlossaryRequestStatuses Status { get; set; } = Enums.GlossaryRequestStatuses.Sent;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}