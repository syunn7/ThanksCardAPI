#nullable disable
namespace ThanksCardAPI.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Employeecd { get; set; }
        public string Employeename { get; set; }
        public string Furigana { get; set; }
        public string Password { get; set; }

        // 多対1: User エンティティは1つの Department エンティティに属する
        public long? OrganizationId { get; set; }
        public virtual MS_ORGANIZATION ORGANIZATION { get; set; }
    }
}
