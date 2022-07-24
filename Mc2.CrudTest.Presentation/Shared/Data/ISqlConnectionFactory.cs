using System.Data;

namespace Mc2.CrudTest.Shared.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}