using CA.Domain.Entities.Base;

namespace CA.Domain.Entities
{
    public partial class MenuSystem : EntityBase<int>
    {
        public int? ParentId { get; set; }
        public int? ValueId { get; set; }
        public string Description { get; set; }
        public string Breadcrumb { get; set; }
        public int? Level { get; set; }
    }
}
