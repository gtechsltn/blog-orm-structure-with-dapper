using Dapper.Contrib.Extensions;

namespace blog_orm_structure_with_dapper.Models
{
    [Table("[Role]")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
} 