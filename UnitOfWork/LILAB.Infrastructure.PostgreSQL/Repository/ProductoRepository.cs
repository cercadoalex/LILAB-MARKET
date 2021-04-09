using Dapper;
using LILAB.Infraestructura.Interface.Repository;
using LILAB.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LILAB.Infrastructure.PostgreSQL.Repository
{
    public class ProductoRepository : Repository, IProductoRepository
    {
        public ProductoRepository(IDbTransaction transaction) : base(transaction) { }

        public IEnumerable<Producto> GetAll()
        {
            var query = "SELECT * FROM Producto ";
            var result = Connection.Query<Producto>(query, transaction: Transaction).AsList();
            return result;
        }

        public IEnumerable<Producto> GetAllByCategoriaId(int categoriaId)
        {
            var query = "SELECT * FROM Producto where categoriaId=@categoriaId";
            var result = Connection.Query<Producto>(query, new { categoriaId }, transaction: Transaction).AsList();
            return result;
        }

        public Producto GetById(int productoId)
        {

            var query = "SELECT * FROM Producto where productoId=@productoId ";
            var result = Connection.Query<Producto>(query, new { productoId }, transaction: Transaction).FirstOrDefault(); 
            return result;
        }

        public void UpdateStock(int productoId, int cantidad)
        {
            var query = "UPDATE Producto SET stock = stock - @cantidad WHERE productoId=@productoId";
            var result = Connection.Execute(query, new { productoId, cantidad }, transaction: Transaction);
        }
    }
}
