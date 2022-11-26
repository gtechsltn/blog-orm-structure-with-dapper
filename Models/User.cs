using System;
using Dapper.Contrib.Extensions;

namespace blog_structure_orm.Models
{
    
    [Table("[User]")] //=> metadados e notações, informações adicionais sobre a classe
    public class User
    {
        /* nomes iguais ao das colunas da table */
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)] //=> não insere isso no insert com dapper.
        public List<Role> Roles { get; set; }

        public User() 
            => Roles = new List<Role>();
    }
}