using System.ComponentModel.DataAnnotations;

namespace Transcription.Models
{
    public class TranscriptionRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        [Required(ErrorMessage = "Тип заявки не выбран")]
        public Enums.RequestTypes? RequestType { get; set; }
        public Enums.ProtocolVariants? ProtocolVariant { get; set; }
        public string? FilePath { get; set; }
        [Range(1,50,ErrorMessage = "Количество спикеров должно быть от 1 до 50")]
        public int? SpeakersCount { get; set; }
        public string? SpeakersList { get; set; }
        public Enums.TranscriptionRequestStatuses Status { get; set; } = Enums.TranscriptionRequestStatuses.Sent;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}