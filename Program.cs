using blog_orm_structure_with_dapper.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using blog_orm_structure_with_dapper.Repositories;

namespace blog_orm_structure_with_dapper
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

        static void Main(string[] args)
        { 
            Console.Clear();
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            // ReadUsersT(connection);
            // ReadRolesT(connection);
            // ReadTagT(connection);

            // CreateUserT(connection);
            // CreateRuleT(connection);
            // CreateTagT(connection);

            // UpdateUserT(connection);
            // UpdateRoleT(connection);
            // UpdateTagT(connection);

            // DeleteUserT(connection);
            // DeleteRoleT(connection);
            // DeleteTagT(connection);

            // ReadUsersWithRoles(connection);
            
            connection.Close();
        }
        
        /* listando com Dapper Contrib */
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                Console.Write(user.Name);
                foreach (var role in user.Roles)
                {
                    Console.Write(" - " + role.Name);
                }
            }
        }

        public static void ReadUsersT(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll(); // executando

            foreach (var user in users)
            {
                Console.WriteLine(user.Id + " - " + user.Name);
            }
        }

        public static void ReadRolesT(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();

            foreach (var role in roles)
            {
                Console.WriteLine(role.Id + " - " + role.Name);
            }
        }

        public static void ReadTagT(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();

            foreach (var tag in tags)
            {
                Console.WriteLine(tag.Id + " - " + tag.Name);
            }
        }

        public static void CreateUserT(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            repository.Create(new User {
                Name = "Equipe do Blog",
                Email = "contato@doblog.com",
                PasswordHash = "HASH",
                Bio = "Entre em contato conosco para mais ajuda e informações",
                Image = "https://...",
                Slug = "contato-blog",
            });

            Console.WriteLine("Usuário criado com sucesso!");
        }

        public static void CreateRuleT(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            repository.Create(new Role() {
               Name = "User Premium",
               Slug = "user-premium"
            });
        }

        public static void CreateTagT(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            repository.Create(new Tag() {
                Name = "C# Básico",
                Slug = "csharp"
            });

            Console.WriteLine("Usuário criado com sucesso!");
        }
        
        public static void UpdateUserT(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            repository.Update(new User() {
                Id = 3,
                Name = "Contato do Blog",
                Email = "contato@doblog.com",
                PasswordHash = "HASH",
                Bio = "Entre em contato conosco para mais ajuda e informações",
                Image = "https://...",
                Slug = "contato-blog",
            });
            Console.WriteLine("Conta Atualizada com sucesso");
        }

        public static void UpdateRoleT(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            repository.Update(new Role() {
                Id = 2,
                Name = "Usuário Premium",
                Slug = "usuario-premium"
            });
            Console.WriteLine("Conta Atualizada com sucesso!");
        }

        public static void UpdateTagT(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            repository.Update(new Tag(){
                Id = 3,
                Name = "Csharp Básico",
                Slug = "csharp-basico"
            });
            Console.WriteLine("Atualizado com sucesso!");
        }

        public static void DeleteUserT(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            repository.Delete(1007);

            Console.WriteLine("Usuário deletado com sucesso!");
        }
    
        public static void DeleteRoleT(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            repository.Delete(2);

            Console.WriteLine("Role deletado com sucesso!");
        }

        public static void DeleteTagT(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            repository.Delete(2);

            Console.WriteLine("Tag deletada com sucesso!");
        }
    }
}   