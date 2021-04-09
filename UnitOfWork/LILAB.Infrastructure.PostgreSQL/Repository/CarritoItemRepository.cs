using Dapper;
using LILAB.Infraestructura.Interface.Repository;
using LILAB.Model;
using System.Collections.Generic;
using System.Data;

namespace LILAB.Infrastructure.PostgreSQL.Repository
{
    public class CarritoItemRepository : Repository, ICarritoItemRepository
    {
        public CarritoItemRepository(IDbTransaction transaction) : base(transaction) { }

        public void Create(CarritoItem carritoItem)
        {

            var query = @"INSERT INTO CarritoItem (productoid, preciounitario, cantidad, preciototal,estado)
                        VALUES(@productoid, @preciounitario, @cantidad, @preciototal,@estado);";
           Connection.Execute(query, carritoItem, transaction: Transaction);

        }
    
        public void Delete(int carritoItemId)
        {
            var query = "DELETE FROM CarritoItem WHERE  CarritoItemId=@CarritoItemId";
            Connection.Execute(query, new { carritoItemId }, transaction: Transaction);
        }

        public void UpdateEstado(IEnumerable<CarritoProductoView> items)
        {
            foreach (var item in items)
            {
                var query = "UPDATE CarritoItem SET Estado=false Where CarritoItemId=@CarritoItemId ";
                Connection.Execute(query, new { CarritoItemId = item.CarritoItemId, }, transaction: Transaction);
            }
        }

        public IEnumerable<CarritoProductoView> GetAll()
        {
            var query = @"SELECT c.carritoitemid,p.productoid,p.nombre,p.descripcion,c.cantidad,c.preciounitario,c.preciototal FROM CarritoItem c 
                        inner join Producto p on c.productoid=p.productoid Where c.Estado=true";
            var result = Connection.Query<CarritoProductoView>(query, transaction: Transaction).AsList();
            return result;
        }


    }
}
