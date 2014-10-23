using System;
using System.Collections.Generic;
using System.Linq;
using DbExplorer.Model;
using DbExplorer.DAL;
using System.ComponentModel;

namespace DbExplorer.BLL
{
    /// <summary>
    /// Provides Read access to the database to discover information about the tables and their columns.
    /// </summary>
    /// <remarks>
    /// This class is useful for obtaining <see cref="TableInfo"/> and <see cref="TableGraph"/> objects
    /// that can help the student to discover information about the database table(s) they need to
    /// work with.
    /// The most useful information is in the <see cref="TableGraph"/>'s <see cref="ColumnInfo"/> items
    /// (such as the <see cref="ColumnInfo.Description"/>).
    /// </remarks>
    [DataObject()]
    public class TableDataController
    {
        /// <summary>
        /// List all the tables in the database.
        /// </summary>
        /// <returns>A list of <see cref="TableInfo"/> objects</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TableInfo> ListDatabaseTables()
        {
            return (new TableDataProvider()).ListTables();
        }

        /// <summary>
        /// List the details of a given table in the database, including all the
        /// columns in the table.
        /// </summary>
        /// <param name="tableName">The plain name of the table (without the SchemaName portion); e.g.: "Products"</param>
        /// <returns>A <see cref="TableGraph"/> object, or null if the table does not exist in the database.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TableGraph GetDatabaseTableDetails(string tableName)
        {
            return new TableDataProvider().GetTableGraph(tableName);
        }
    }
}
