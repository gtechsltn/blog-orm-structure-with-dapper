using blog_structure_orm.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog_structure_orm
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        { 
            Console.Clear();

            ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser(); 
        }

        /* listando usuários com Dapper Contrib */
        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {   
                var users = connection.GetAll<User>(); 
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            } 
        }

        /* listando apenas um usuário */
        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {   
                /* apenas com isso o Dapper Contrib ja consegue listar os 
                usuários com base nas propriedades da classe "User" */
                var user = connection.Get<User>(1); 

                Console.Write(user.Name);
            }
        }

        /* criando usuário novo */
        public static void CreateUser()
        {
            var user = new User() {
                Bio = "Usuário para ajudar com perguntas relacionadas ao Blog",
                Email = "help@blogtal.com",
                Image = "https://...",
                Name = "Equipe do Blog",
                PasswordHash = "HASH",
                Slug = "equipe-blog"
            };
            /* inserindo usuário no banco com dapper contrib */
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {   
                connection.Insert<User>(user);
                Console.Write("Cadastro realizado com sucesso!");
            }
        }

                /* criando usuário novo */
        public static void UpdateUser()
        {
            var user = new User() {
                Id = 2,
                Bio = "Usuário para ajudar com perguntas relacionadas ao Blog",
                Email = "contatoblog@blog.com",
                Image = "https://...",
                Name = "Equipe de suporte do Blog",
                PasswordHash = "HASH",
                Slug = "contato-blog"
            };
            /* inserindo usuário no banco com dapper contrib */
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {   
                connection.Update<User>(user);
                Console.Write("Usuário atualizado com sucesso!");
            }
        } 
    }  
}   