#nullable disable
namespace ThanksCardAPI.Models
{
    public class ThanksCard
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ToId { get; set; }
        public virtual Employee To { get; set; }
        public long FromId { get; set; }
        public virtual Employee From { get; set; }
        public string Contents { get; set; }
        public DateTime Date { get; set; }
        public bool Kidoku { get; set; }
        public bool Check { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ThanksCardClassification> ThanksCardClassifications { get; set; }
    }
}
