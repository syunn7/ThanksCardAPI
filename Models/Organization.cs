namespace ThanksCardAPI.Models
{
    public class Organization
    {
        public long Id { get; set; }
        public int OrganizationCd { get; set; }
        public string? OrganizationName { get; set; }

        // 部と課のような階層構造を実現するために、自己参照(DepartmentエンティティがDepartmentエンティティとリレーションを持つ)を利用する
        // ParentId には親部署のIdが入る
        // Parent には親部署が入る
        // Children には子部署リストが入る
        public long? ParentId { get; set; }
        public virtual Organization Parent { get; set; }
        public virtual ICollection<Organization> Children { get; set; }

        // 1対多: Department エンティティには複数の User エンティティが属する
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
