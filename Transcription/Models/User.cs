namespace Transcription.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public List<TranscriptionRequest> TranscriptionRequests { get; set; } = new();
        public List<GlossaryRequest> GlossaryRequests { get; set; } = new();
    }
}