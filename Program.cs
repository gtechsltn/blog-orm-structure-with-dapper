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
            ReadUsers();
            // ReadUser();
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
    }  
}   