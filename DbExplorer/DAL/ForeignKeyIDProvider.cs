using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DbExplorer.Model;

namespace DbExplorer.DAL
{
    internal class ForeignKeyIDProvider : AbstractDataProvider<ForeignKeyID>
    {
        #region Instance Members
        public string PrimaryKey { get; set; }
        public string DisplayColumnName { get; set; }
        protected override ForeignKeyID Hydrate(IDataReader reader)
        {
            int id = reader.GetValue<int>(PrimaryKey);
            string displayText = reader.GetValue<string>(DisplayColumnName);
            return new ForeignKeyID(id, displayText);
        }

        private ForeignKeyIDProvider()
        {
        }
        #endregion

        #region Static Methods
        public static List<ForeignKeyID> ListSalesTerritoryIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "Name";
            provider.PrimaryKey = "TerritoryID";
            return provider.FillList(provider.DataStore.ExecuteReader("Sales.SalesTerritory_List"));
        }
        public static List<ForeignKeyID> ListCustomerIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "AccountNumber";
            provider.PrimaryKey = "CustomerID";
            return provider.FillList(provider.DataStore.ExecuteReader("Sales.Customer_List"));
        }
        public static List<ForeignKeyID> ListAddressIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "AddressLine1";
            provider.PrimaryKey = "AddressID";
            return provider.FillList(provider.DataStore.ExecuteReader("Person.Address_List"));
        }
        public static List<ForeignKeyID> ListShipMethodIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "Name";
            provider.PrimaryKey = "ShipMethodID";
            return provider.FillList(provider.DataStore.ExecuteReader("Purchasing.ShipMethod_List"));
        }
        public static List<ForeignKeyID> ListVendorIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "Name";
            provider.PrimaryKey = "VendorID";
            return provider.FillList(provider.DataStore.ExecuteReader("Purchasing.Vendor_List"));
        }
        public static List<ForeignKeyID> ListAddressTypeIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "Name";
            provider.PrimaryKey = "AddressTypeID";
            return provider.FillList(provider.DataStore.ExecuteReader("Person.AddressType_List"));
        }
        public static List<ForeignKeyID> ListContactTypeIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "Name";
            provider.PrimaryKey = "ContactTypeID";
            return provider.FillList(provider.DataStore.ExecuteReader("Person.ContactType_List"));
        }
        public static List<ForeignKeyID> ListSpecialOfferIDs()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            provider.DisplayColumnName = "Description";
            provider.PrimaryKey = "SpecialOfferID";
            return provider.FillList(provider.DataStore.ExecuteReader("Sales.SpecialOffer_List"));
        }
        public static List<ForeignKeyID> ListContacts()
        {
            ForeignKeyIDProvider provider = new ForeignKeyIDProvider();
            IDataReader reader = provider.DataStore.ExecuteReader("Person.Contact_List");

            if (reader == null)
                throw new ArgumentNullException("reader", "reader is null");
            // Make an empty list...
            List<ForeignKeyID> contacts = new List<ForeignKeyID>();
            // Now, go through the reader to add items to the list
            if (!reader.IsClosed)
            {
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetValue<int>("ContactID");
                        string first, middle, last, title, suffix;
                        first = reader.GetValue<string>("FirstName");
                        middle = reader.GetValue<string>("MiddleName");
                        last = reader.GetValue<string>("LastName");
                        title = reader.GetValue<string>("Title");
                        suffix = reader.GetValue<string>("Suffix");
                        // NameStyle: 0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.
                        bool easternStyle = reader.GetValue<bool>("NameStyle");
                        string formalName;
                        if (!string.IsNullOrEmpty(suffix))
                            last += " " + suffix;
                        if (!string.IsNullOrEmpty(middle))
                            first += " " + middle;
                        if (!string.IsNullOrEmpty(title))
                            first = title + " " + first;

                        if (easternStyle)
                            formalName = string.Format("{1}, {0}", last, first);
                        else
                            formalName = string.Format("{1}, {0}", first, last);

                        ForeignKeyID something = new ForeignKeyID(id, formalName);
                        contacts.Add(something);
                    }
                }
            }

            return contacts;
        }
        #endregion
    }
}
