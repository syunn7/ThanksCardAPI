namespace ThanksCardAPI.Models
{
    public class ThanksCard2
    {
    public long Id { get; set; }
    public int ThankscardCd { get; set; }
    public string Title { get; set; }
    public int ToId { get; set; }
    public int FromId { get; set; }
    public string Contents { get; set; }
    public DateTime Date { get; set; }
    public string Kidoku { get; set; }
    public string Check { get; set; }
    public string Comment { get; set; }
    public int ClassificationId { get; set; }
    }
}
