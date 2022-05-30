namespace ThanksCardAPI.Models
{
    public class MS_EMPLOYEE
    {
        public long EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_CD { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string FURIGANA { get; set; }
        public string PASSWORD { get; set; }

        // 多対1: User エンティティは1つの Department エンティティに属する
        public long? ORGANIZATION_ID { get; set; }
        public virtual MS_ORGANIZATION ORGANIZATION { get; set; }
    }
}
