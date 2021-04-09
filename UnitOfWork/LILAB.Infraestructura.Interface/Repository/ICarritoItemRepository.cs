using LILAB.Model;
using System.Collections.Generic;

namespace LILAB.Infraestructura.Interface.Repository
{
    public interface ICarritoItemRepository
    {
        void Delete(int carritoItemId);
        IEnumerable<CarritoProductoView> GetAll();
        void Create(CarritoItem carritoItem);
        void UpdateEstado(IEnumerable<CarritoProductoView> ListacarritoItem);

        
    }
}
