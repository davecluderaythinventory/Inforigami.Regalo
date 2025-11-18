using System;

using Microsoft.Data.SqlClient;

namespace Inforigami.Regalo.SqlServer
{
    /// <summary>
    /// Provides access to an already open <see cref="SqlConnection" /> and <see cref="SqlTransaction" />.
    /// </summary>
    public interface ISqlSession : IDisposable
    {
        /// <summary>
        /// An already open <see cref="SqlConnection" /> instance.
        /// </summary>
        SqlConnection Connection { get; }

        /// <summary>
        /// An active <see cref="SqlTransaction" /> instance.
        /// </summary>
        SqlTransaction Transaction { get; }

        /// <summary>
        /// Allows Regalo to signal successful completion, e.g. to allow the transaction to be committed if appropriate.
        /// </summary>
        void Complete();
    }
}
