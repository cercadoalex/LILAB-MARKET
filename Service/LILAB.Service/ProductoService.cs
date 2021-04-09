using LILAB.Infraestructura.Interface.UnitOfWork;
using LILAB.Model;
using System.Collections.Generic;

namespace LILAB.Service
{
    public class ProductoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Producto> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repository.ProductoRepository.GetAll();
                return result;
            }
        }
        public IEnumerable<Producto> GetAllByCategoriaId(int categoriaId)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repository.ProductoRepository.GetAllByCategoriaId(categoriaId);
                return result;
            }
        }
        public Producto GetById(int productoId)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repository.ProductoRepository.GetById(productoId);
                return result;
            }
        }

        public  void UpdateStock()
        {
            using (var context = _unitOfWork.Create())
            {
                var listaCarrito = context.Repository.CarritoItemRepository.GetAll();
                foreach (var item in listaCarrito)
                {
                    context.Repository.ProductoRepository.UpdateStock(item.ProductoId, item.Cantidad);
                }
                context.Repository.CarritoItemRepository.UpdateEstado(listaCarrito);
                context.SaveChange();
            }
        }
    }
}
