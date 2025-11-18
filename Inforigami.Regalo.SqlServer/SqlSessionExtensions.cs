using Microsoft.Data.SqlClient;

namespace Inforigami.Regalo.SqlServer
{
    internal static class SqlSessionExtensions
    {
        public static SqlCommand CreateCommand(this ISqlSession sqlSession)
        {
            var command = sqlSession.Connection.CreateCommand();
            command.Transaction = sqlSession.Transaction;
            return command;
        }
    }
}
