using System.Data;

namespace LILAB.Infrastructure.PostgreSQL.Repository
{
    public abstract class Repository
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }

        public Repository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }
}
