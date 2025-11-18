using System;
using System.Data;

using Microsoft.Data.SqlClient;

namespace Inforigami.Regalo.SqlServer
{
    /// <summary>
    /// Represents an internal <see cref="SqlConnection" /> and <see cref="SqlTransaction" /> that
    /// are created and managed by Regalo.
    /// </summary>
    internal sealed class TransientSqlSession : ISqlSession
    {
        /// <inheritdoc />
        public SqlConnection Connection { get; }

        /// <inheritdoc />
        public SqlTransaction Transaction { get; }

        public TransientSqlSession(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException("connectionString");
            (Connection, Transaction) = Connect(connectionString);
        }

        /// <inheritdoc />
        public void Complete()
        {
            Transaction.Commit();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Connection.Dispose();
            Transaction.Dispose();
        }

        private static (SqlConnection, SqlTransaction) Connect(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return (connection, connection.BeginTransaction(IsolationLevel.ReadCommitted));
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }
    }
}