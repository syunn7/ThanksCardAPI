#nullable disable
namespace ThanksCardAPI.Models
{
    public class Classification
    {
        public long Id { get ; set ;}
        public string ClassificationName { get ; set ; }

        public virtual ICollection<ThanksCardClassification> ThanksCardClassification { get; set; }
    }
}
