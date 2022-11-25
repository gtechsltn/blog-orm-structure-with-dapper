using blog_structure_orm.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using blog_structure_orm.Repositories;

namespace blog_structure_orm
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

        static void Main(string[] args)
        { 
            Console.Clear();
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            /* usuários */
            // ReadUsers(connection);
            // ReadUser(connection);
            // CreateUser(connection);
            // UpdateUser(connection); 
            // DeleteUser(connection);

            /* roles */
            // ReadRoles(connection);

            /* genéricos */
            // ReadUsersT(connection);
            // ReadRolesT(connection);
            ReadTagT(connection);

            // CreateUserT(connection);
            // CreateRuleT(connection);
            // CreateTagT(connection);

            // UpdateUserT(connection);
            // UpdateRoleT(connection);
            // UpdateTagT(connection);

            connection.Close();
        }
        
        /* listando com Dapper Contrib */
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
            repository.Create(new User() {
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

        // /* =============================================================================== */

        // /* listando roles com Dapper Contrib */
        // public static void ReadRoles(SqlConnection connection)
        // {
        //     var repository = new RoleRepository(connection);
        //     var roles = repository.GetAll();

        //     foreach (var role in roles)
        //     {
        //         Console.WriteLine(role.Id + " - " + role.Name);
        //     }
        // }

        // /* =============================================================================== */

        // /* listando usuários com Dapper Contrib */
        // public static void ReadUsers(SqlConnection connection)
        // {
        //     var repository = new UserRepository(connection);
        //     var users = repository.GetAll();

        //     foreach (var user in users)
        //         Console.WriteLine(user.Id +" - "+ user.Name);
        // }

        // /* listando apenas um usuário */
        // public static void ReadUser(SqlConnection connection)
        // {
        //     var repository = new UserRepository(connection);
        //     User user = repository.Get(1);

        //     Console.Write(user.Id +" - "+ user.Name);
        // }

        // /* criando usuário novo */
        // public static void CreateUser(SqlConnection connection)
        // {
        //     var user = new User() {
        //         Bio = "Usuário para ajudar com perguntas relacionadas ao Blog",
        //         Email = "help@blogtal.com",
        //         Image = "https://...",
        //         Name = "Equipe do Blog",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-blog"
        //     };

        //     /* inserindo usuário no banco com dapper contrib */
        //     var repository = new UserRepository(connection);
        //     repository.Create(user);
        // }

        // /* atualizando usuário novo */
        // public static void UpdateUser(SqlConnection connection)
        // {
        //     var user = new User() {
        //         Id = 2,
        //         Bio = "Usuário para ajudar com perguntas relacionadas ao Blog",
        //         Email = "contatoblog@blog.com",
        //         Image = "https://...",
        //         Name = "Equipe de suporte do Blog",
        //         PasswordHash = "HASH",
        //         Slug = "contato-blog"
        //     };
        //     /* inserindo usuário no banco com dapper contrib */
        //     var repository = new UserRepository(connection);
        // } 

        // /* deletando usuário */            
        // public static void DeleteUser(SqlConnection connection)
        // {
        //     /* inserindo usuário no banco com dapper contrib */
        //     var repository = new UserRepository(connection);
        //     repository.Delete(2);
        // }   
    }
}   