using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace DbExplorer.DAL
{
    public static class DataReaderExtensions
    {
        public static T GetValue<T>(this IDataReader reader, string columnName)
        {
            T value = default(T);
            int index = reader.GetOrdinal(columnName);
            if (!reader.IsDBNull(columnName))
                value = (T)(reader.GetValue(index));
            return value;
        }

        public static bool IsDBNull(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index);
        }
    }
}
