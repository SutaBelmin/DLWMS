namespace DLWMS_StudentskiOnlineServis.Services.Requests
{
    public class AddOdgovorServiceRequest
    {
        public int Id { get; set; }

        public string Odgovor { get; set; }

        public int AnswererId { get; set; }
    }
}
