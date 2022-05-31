#nullable disable
namespace ThanksCardAPI.Models
{
    public class MS_ORGANIZATION
    {
        public long Id { get; set; }
        public int Organiztioncd { get; set; }
        public string Organiztionname { get; set; }

        // 部と課のような階層構造を実現するために、自己参照(DepartmentエンティティがDepartmentエンティティとリレーションを持つ)を利用する
        // ParentId には親部署のIdが入る
        // Parent には親部署が入る
        // Children には子部署リストが入る
        public long? ParentId { get; set; }
        public virtual MS_ORGANIZATION Parent { get; set; }
        public virtual ICollection<MS_ORGANIZATION> Children { get; set; }

        // 1対多: Department エンティティには複数の User エンティティが属する
        public virtual ICollection<MS_EMPLOYEE> EMPLOYEEs { get; set; }
    }
}
