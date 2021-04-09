using LILAB.Model;
using System.Collections.Generic;

namespace LILAB.Infraestructura.Interface.Repository
{
    public interface IProductoRepository
    {
        Producto GetById(int productoId);
        void UpdateStock(int productoId,int cantidad);
        IEnumerable<Producto> GetAll();
        IEnumerable<Producto> GetAllByCategoriaId(int categoriaId);
    }
}
