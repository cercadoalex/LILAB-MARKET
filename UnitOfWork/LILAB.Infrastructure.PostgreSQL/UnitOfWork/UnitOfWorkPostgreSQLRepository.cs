using LILAB.Infraestructura.Interface.Repository;
using LILAB.Infraestructura.Interface.UnitOfWork;
using LILAB.Infrastructure.PostgreSQL.Repository;
using System.Data;

namespace LILAB.Infrastructure.PostgreSQL.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ICategoriaRepository CategoriaRepository { get; }

        public IProductoRepository ProductoRepository { get; }

        public ICarritoItemRepository CarritoItemRepository { get; }

        public UnitOfWorkRepository(IDbTransaction transaction)
        {
            CategoriaRepository = new CategoriaRepository(transaction);
            ProductoRepository = new ProductoRepository(transaction);
            CarritoItemRepository = new CarritoItemRepository(transaction);
        }
    }

   
}
