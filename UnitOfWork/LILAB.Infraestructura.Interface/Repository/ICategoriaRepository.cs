using LILAB.Model;
using System.Collections.Generic;

namespace LILAB.Infraestructura.Interface.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
    }
}
