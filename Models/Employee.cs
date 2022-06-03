#nullable disable
namespace ThanksCardAPI.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string EmployeeCd { get; set; }
        public string EmployeeName { get; set; }
        public string Furigana { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        // 多対1: User エンティティは1つの Department エンティティに属する
        public long? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
