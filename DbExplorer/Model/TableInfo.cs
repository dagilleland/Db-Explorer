using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExplorer.Model
{
    public class TableInfo
    {
        /// <summary>Hydrdate from the column named 'TABLE_CATALOG'</summary>
        public string DatabaseName { get; set; }
        /// <summary>Hydrdate from the column named 'TABLE_SCHEMA'</summary>
        public string SchemaName { get; set; }
        /// <summary>Hydrdate from the column named 'TABLE_NAME'</summary>
        public string TableName { get; set; }
        /// <summary>Hydrdate from the column named 'TABLE_TYPE'</summary>
        public string TableType { get; set; }
        /// <summary>Hydrdate from the column named 'Description'</summary>
        public string Description { get; set; }

        /// <summary>The FullyQualifiedTableName is in the format SchemaName.TableName</summary>
        public string FullyQualifiedTableName
        { get { return SchemaName + "." + TableName; } }
    }
}
