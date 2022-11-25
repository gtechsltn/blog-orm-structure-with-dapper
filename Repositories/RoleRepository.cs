using Microsoft.Data.SqlClient;
using blog_structure_orm.Models;
using Dapper.Contrib.Extensions;

namespace blog_structure_orm.Repositories
{
    public class RoleRepository
    {
        /* connection string */
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) 
            => _connection = connection;


        /* listando usuários com Dapper Contrib */
        public IEnumerable<Role> GetAll() => _connection.GetAll<Role>();

        /* listando um usuário */
        public Role Get(int id) => _connection.Get<Role>(id);

        /* criando um usuário */
        public void Create(Role role)
        {
            role.Id = 0; // id é gerado automaticamente pelo unique, então precisa ser 0;
            _connection.Insert<Role>(role);
        }

        /* atualizando usuário */
        public void Update(Role role)
        {
            if(role.Id != 0)
                _connection.Update<Role>(role);
        } 

        /* deletar usuário */
        public void Delete(int id) 
        {   if(id != 0)
                _connection.Delete<Role>( _connection.Get<Role>(id) );
        }
    }
}