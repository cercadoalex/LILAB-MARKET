using Dapper;
using LILAB.Infraestructura.Interface.Repository;
using LILAB.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LILAB.Infrastructure.PostgreSQL.Repository
{
    public class CategoriaRepository : Repository, ICategoriaRepository
    {
        public CategoriaRepository(IDbTransaction transaction) : base(transaction) { }

        public IEnumerable<Categoria> GetAll()
        {
            var query = "SELECT * FROM Categoria ";
            var result = Connection.Query<Categoria>(query, transaction: Transaction).AsList();
            return result;
        }

       


    }
}
