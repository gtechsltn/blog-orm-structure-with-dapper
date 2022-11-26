using Microsoft.Data.SqlClient;
using blog_orm_structure_with_dapper.Models;
using Dapper;
using System.Linq;

namespace blog_orm_structure_with_dapper.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection; 
        public UserRepository(SqlConnection connection) : base(connection) //=> chamando o construtor da superclasse;
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT [User].*, [Role].*
                FROM [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";

            var users = new List<User>();
            //                    //=> param1, param2, retorno
            var items = _connection.Query<User, Role, User>(query, (user, role)
            => { /* função anônima de mapeamento */

                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                /* verificando se o usuário já existe no banco */
                if(usr == null)
                {
                    usr = user;
                    if(role != null)
                        usr.Roles.Add(role);
                    users.Add(usr);

                } else usr.Roles.Add(role); 

                return user;
            }, splitOn: "Id"/* divide a partir do id */);

            return users;
        }
    }
}