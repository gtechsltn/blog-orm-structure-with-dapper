using blog_structure_orm.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog_structure_orm.Repositories
{
    public class UserRepository
    {
        /* connection string */
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) 
            => _connection = connection;


        /* listando usuários com Dapper Contrib */
        public IEnumerable<User> GetAll() => _connection.GetAll<User>();

        /* listando um usuário */
        public User Get(int id) => _connection.Get<User>(id);

        /* criando um usuário */
        public void Create(User user) => _connection.Insert<User>(user);

        /* atualizando usuário */
        public void Update(User user) => _connection.Update<User>(user);

        /* deletar usuário */
        public void Delete(int id) => _connection.Delete<User>( _connection.Get<User>(id) );
    }
}