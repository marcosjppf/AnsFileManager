using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.EntityFramework;
using System.Data.Entity;

namespace AnsFileManager.Data.Configurations
{
    public class OracleConfiguration : DbConfiguration
    {
        public OracleConfiguration()
        {
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
            SetProviderFactory("Oracle.ManagedDataAccess.Client", OracleClientFactory.Instance);
            SetDefaultConnectionFactory(new OracleConnectionFactory());
        }
    }
}
