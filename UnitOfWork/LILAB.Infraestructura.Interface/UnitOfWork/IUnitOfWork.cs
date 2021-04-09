

namespace LILAB.Infraestructura.Interface.UnitOfWork
{
   public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
