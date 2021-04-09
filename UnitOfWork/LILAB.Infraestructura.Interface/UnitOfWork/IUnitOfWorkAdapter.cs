using System;

namespace LILAB.Infraestructura.Interface.UnitOfWork
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repository { get; }
        void SaveChange();
    }
}
