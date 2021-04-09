using LILAB.Infraestructura.Interface.UnitOfWork;
using LILAB.Model;
using System.Collections.Generic;

namespace LILAB.Service
{
    public class CategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Categoria> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                var result = context.Repository.CategoriaRepository.GetAll();
                return result;
            }
        }

    }
}
