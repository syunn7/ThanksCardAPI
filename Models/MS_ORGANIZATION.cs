namespace ThanksCardAPI.Models
{
    public class MS_ORGANIZATION
    {
        public long ORGANIZATION_ID { get; set; }
        public int ORGANIZATION_CD { get; set; }
        public string? ORGANIZATION_NAME { get; set; }

        // 部と課のような階層構造を実現するために、自己参照(DepartmentエンティティがDepartmentエンティティとリレーションを持つ)を利用する
        // ParentId には親部署のIdが入る
        // Parent には親部署が入る
        // Children には子部署リストが入る
        public long? PARENT_ID { get; set; }
        public virtual Department Parent { get; set; }
        public virtual ICollection<Department> Children { get; set; }

        // 1対多: Department エンティティには複数の User エンティティが属する
        public virtual ICollection<MS_EMPLOYEE> EMPLOYEEs { get; set; }
    }
}
