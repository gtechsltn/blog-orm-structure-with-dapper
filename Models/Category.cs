using Dapper.Contrib.Extensions;

namespace blog_orm_structure_with_dapper.Models
{   
    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Post> Posts { get; set; }
    }
}