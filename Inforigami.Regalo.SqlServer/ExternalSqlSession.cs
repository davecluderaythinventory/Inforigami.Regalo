using Microsoft.Data.SqlClient;

namespace Inforigami.Regalo.SqlServer
{
    /// <summary>
    /// Represents a <see cref="SqlConnection" /> and <see cref="SqlTransaction" /> that are externally controlled.
    /// </summary>
    /// <remarks>
    /// It is the responsibility of the external owner to manage and dispose of the connection and transaction.
    /// The <see cref="Complete" /> and <see cref="Dispose" /> methods do nothing.
    /// </remarks>
    public sealed class ExternalSqlSession : ISqlSession
    {
        public ExternalSqlSession(SqlConnection connection, SqlTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }

        /// <inheritdoc />
        public SqlConnection Connection { get; }

        /// <inheritdoc />
        public SqlTransaction Transaction { get; }

        /// <inheritdoc />
        public void Complete()
        {
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}
