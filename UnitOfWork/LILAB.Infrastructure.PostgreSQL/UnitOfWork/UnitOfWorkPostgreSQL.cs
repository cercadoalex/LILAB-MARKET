using LILAB.Infraestructura.Interface.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace LILAB.Infrastructure.PostgreSQL.UnitOfWork
{
    public class UnitOfWorkPostgreSQL : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkPostgreSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IUnitOfWorkAdapter Create()
        {
            string connection = "";
            connection = _configuration.GetConnectionString("PostgressConection2");

            return new UnitOfWorkPostgreSQLAdapter(connection);

        }
    }
}
