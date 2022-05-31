#nullable disable
namespace ThanksCardAPI.Models
{
    public class ThanksCardClassification
    {
        public long Id { get; set; }
        public long ThanksCardId { get; set; }
        public ThanksCard ThanksCard { get; set; }
        public long ClassificationId { get; set; }
        public Classification classification { get; set; }
    }
}
