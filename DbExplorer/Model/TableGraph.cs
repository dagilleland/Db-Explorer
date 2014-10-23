using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExplorer.Model
{
    public class TableGraph : TableInfo
    {
        public IList<ColumnInfo> Columns { get; set; }
    }
}
