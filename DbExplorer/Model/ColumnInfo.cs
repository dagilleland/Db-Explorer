using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExplorer.Model
{
    public class ColumnInfo
    {
        /// <summary>Hydrdate from the column named 'ORDINAL_POSITION'</summary>
        public int OrdinalPosition { get; set; }
        /// <summary>Hydrdate from the column named 'COLUMN_NAME'</summary>
        public string ColumnName { get; set; }
        /// <summary>Hydrdate from the column named 'DATA_TYPE'</summary>
        public string DataType { get; set; }
        /// <summary>Hydrdate from the column named 'CHARACTER_MAXIMUM_LENGTH'</summary>
        public int? MaxCharacterLength { get; set; }
        /// <summary>Hydrdate from the column named 'IS_NULLABLE'</summary>
        public bool IsNullable { get; set; }
        /// <summary>Hydrdate from the column named 'COLUMN_DEFAULT'</summary>
        public string DefaultValue { get; set; }
        /// <summary>Hydrdate from the column named 'Description'</summary>
        public string Description { get; set; }
    }
}
