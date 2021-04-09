using LILAB.Infraestructura.Interface.UnitOfWork;
using Npgsql;
using System.Data;

namespace LILAB.Infrastructure.PostgreSQL.UnitOfWork
{
    public class UnitOfWorkPostgreSQLAdapter : IUnitOfWorkAdapter
    {
        private readonly IDbConnection _context;
        private readonly IDbTransaction _transaction;

        public IUnitOfWorkRepository Repository { get; set; }


        public UnitOfWorkPostgreSQLAdapter(string connectionPostgres)
        {
            _context = new NpgsqlConnection(connectionPostgres);
            _context.Open();
            _transaction = _context.BeginTransaction();


            Repository = new UnitOfWorkRepository(_transaction);

        }


        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
            Repository = null;

        }

        public void SaveChange()
        {
            _transaction.Commit();
        }
    }
}
