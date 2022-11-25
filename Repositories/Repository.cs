using blog_structure_orm.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace blog_structure_orm.Repositories
{
    /* criando classe genérica, de tipo genérico "T" */
    public class Repository<T> where T : class // onde só aceita tipo genérico de classes
    {   
        /* atribuições com readonly só podem ser feitas no construtor ou na declaração */
        private readonly SqlConnection _connection; 
        public Repository(SqlConnection connection) => _connection = connection;

        public IEnumerable<T> GetAll() => _connection.GetAll<T>();

        /* listando um usuário */
        public T Get(int id) => _connection.Get<T>(id);

        /* criando um usuário */
        public void Create(T model) => _connection.Insert<T>(model);

        /* atualizando usuário, necessita receber um id junto ao update */
        public void Update(T model) => _connection.Update<T>(model);

        /* deletar usuário */
        public void Delete(int id) => _connection.Delete<T>(_connection.Get<T>(id));
    } 
}