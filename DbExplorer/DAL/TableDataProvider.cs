using System;
using System.Collections.Generic;
using System.Linq;
using DbExplorer.Model;
using System.Data;

namespace DbExplorer.DAL
{
    internal class TableDataProvider : AbstractDataProvider<TableInfo>
    {
        protected override TableInfo Hydrate(IDataReader reader)
        {
            return Hydrate<TableInfo>(reader);
        }

        private T Hydrate<T>(IDataReader reader) where T : TableInfo, new()
        {
            T info = new T();
            info.DatabaseName = reader.GetValue<string>("TABLE_CATALOG");
            info.Description = reader.GetValue<string>("Description");
            info.SchemaName = reader.GetValue<string>("TABLE_SCHEMA");
            info.TableName = reader.GetValue<string>("TABLE_NAME");
            info.TableType = reader.GetValue<string>("TABLE_TYPE");
            return info;
        }

        public List<TableInfo> ListTables()
        {
            return FillList(DataStore.ExecuteReader("TableData_List"));
        }

        public TableGraph GetTableGraph(string tableName)
        {
            TableGraph info = null;

            using (IDataReader reader = DataStore.ExecuteReader("TableData_Get", tableName))
            {
                if (!reader.IsClosed && reader.Read())
                {
                    info = Hydrate<TableGraph>(reader);

                    if (reader.NextResult())
                    {
                        info.Columns = new List<ColumnInfo>();
                        while (reader.Read())
                        {
                            ColumnInfo column = new ColumnInfo();

                            column.ColumnName = reader.GetValue<string>("COLUMN_NAME");
                            column.OrdinalPosition = reader.GetValue<int>("ORDINAL_POSITION");
                            column.DataType = reader.GetValue<string>("DATA_TYPE");
                            column.MaxCharacterLength = reader.GetValue<int?>("CHARACTER_MAXIMUM_LENGTH");
                            column.IsNullable = reader.GetValue<string>("IS_NULLABLE").Equals("NO", StringComparison.InvariantCultureIgnoreCase);
                            column.DefaultValue = reader.GetValue<string>("COLUMN_DEFAULT");
                            column.Description = reader.GetValue<string>("Description");

                            info.Columns.Add(column);
                        }
                    }
                    reader.Close();
                }
            }

            return info;
        }

    }
}
