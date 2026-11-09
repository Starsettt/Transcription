namespace Transcription.Models
{
    public class Enums
    {
        public enum RequestTypes
        {
            TranscriptionPlusProtocol = 1,
            Transcription = 2,
            Protocol = 3
        }
        public enum ProtocolVariants
        {
            Meeting = 1,
            VisionaryBoard = 2,
            Testing = 3,
            AssesmentProcedure = 4
        }
        public enum TranscriptionRequestStatuses
        {
            Sent = 1,
            Done = 2
        }
        public enum GlossaryRequestStatuses
        {
            Sent = 1,
            Accepted = 2,
            Rejected = 3
        }
    }
}