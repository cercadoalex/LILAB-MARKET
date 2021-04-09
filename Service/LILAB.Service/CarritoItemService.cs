using LILAB.Infraestructura.Interface.UnitOfWork;
using LILAB.Model;
using System.Collections.Generic;

namespace LILAB.Service
{
    public class CarritoItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarritoItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CarritoProductoView> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repository.CarritoItemRepository.GetAll();
                return result;
            }
        }
        public void Delete(int carritoItemId)
        {
            using (var context = _unitOfWork.Create())
            {
               context.Repository.CarritoItemRepository.Delete(carritoItemId);
                context.SaveChange();

            }
        }

        public void Create(CarritoItem carritoItem)
        {
            using (var context = _unitOfWork.Create())
            {
                context.Repository.CarritoItemRepository.Create(carritoItem);
                context.SaveChange();
            }
        }

    }
}
