
using LILAB.Infraestructura.Interface.Repository;

namespace LILAB.Infraestructura.Interface.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        IProductoRepository ProductoRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        ICarritoItemRepository CarritoItemRepository { get; }
    }

}
