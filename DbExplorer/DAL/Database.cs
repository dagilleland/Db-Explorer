using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbExplorer.DAL
{
    class Database
    {
        internal System.Data.IDataReader ExecuteReader(string p)
        {
            throw new NotImplementedException();
        }

        internal System.Data.IDataReader ExecuteReader(string p, string tableName)
        {
            throw new NotImplementedException();
        }
    }
    class DatabaseFactory
    {
        internal static Database CreateDatabase(string CONNECTION_STRING_NAME)
        {
            throw new NotImplementedException();
        }
    }
}
