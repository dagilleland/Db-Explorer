using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DbExplorer;

namespace DbExplorer.DAL
{
    // internal means it can't be seen outside this project
    // abstract means it's incomplete (you need to use the subclass)
    internal abstract class AbstractDataProvider<T>
    {
        #region Constructors, properties and constants
        // the key name to hook into the web.config
        private const string CONNECTION_STRING_NAME = "AW";

        // the Enterprise Library's ADO factory-magic-wizard
        protected Database DataStore { get; private set; }

        // the constructor sets up the property above
        public AbstractDataProvider()
        {
            DataStore = DatabaseFactory.CreateDatabase(CONNECTION_STRING_NAME);
        }
        #endregion

        // An abstract method must be implemented in the subclass
        protected abstract T Hydrate(IDataReader reader);

        // A method to create a single CBO from the DataReader
        protected T FillObject(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader", "reader is null");
            // create the CBO object (whatever it is...)
            T result = default(T);

            using (reader)
            {
                if (reader.Read())
                {
                    result = Hydrate(reader);
                }
            }
            return result;
        }

        // A method to fill up a list of CBOs from the DataReader
        protected List<T> FillList(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader", "reader is null");
            // Make an empty list...
            List<T> bunchOfCBOs = new List<T>();
            // Now, go through the reader to add items to the list
            if (!reader.IsClosed)
            {
                using (reader)
                {
                    while (reader.Read())
                    {
                        T something = Hydrate(reader);
                        bunchOfCBOs.Add(something);
                    }
                }
            }
            // return all the stuff
            return bunchOfCBOs;
        }
    }
}
