using System;

namespace FacilityMgmt.DAL.Common.Interfaces
{
    // If the DAL lives inside the service project, then there is no need for this.
    // But, because I have multiple DAL implementations in this particular solution, I need this
    public interface IDbConfiguration
    {
        string ConnectionString { get; }
    }

    public sealed class DbConfiguration : IDbConfiguration
    {
        private readonly System.Data.SqlClient.SqlConnectionStringBuilder _builder;

        public DbConfiguration(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
        }

        public string ConnectionString => _builder.ConnectionString;
    }
}
