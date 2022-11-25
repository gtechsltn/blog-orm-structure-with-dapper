using blog_structure_orm.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog_structure_orm.Repositories
{
    /* criando classe genérica, de tipo genérico "T" */
    public class Repository<T> where T : class // onde só aceita tipo genérico de classes
    {
        private readonly SqlConnection _connection; 
        public Repository(SqlConnection connection) => _connection = connection;

        public IEnumerable<T> GetAll() => _connection.GetAll<T>();
    } 
}