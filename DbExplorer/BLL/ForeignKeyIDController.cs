using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DbExplorer.Model;
using DbExplorer.DAL;

namespace DbExplorer.BLL
{
    /// <summary>
    /// Provides Read access to many tables that serve as Foreign Keys in other tables.
    /// </summary>
    /// <remarks>
    /// This class is useful for obtaining <see cref="ForeignKeyConstraint"/> objects that can be used
    /// in web form DropDownLists or the ComboBoxes of Windows applications.
    /// The methods in this class can be bound through the ObjectDataSource controls on Web Forms;
    /// this is possible because the class and methods are marked with the <see cref="ComponentModel"/>
    /// attributes <see cref="DataObjectAttribute"/> and <see cref="DataObjectMethodAttribute"/>.
    /// </remarks>
    [DataObject(true)]
    public class ForeignKeyIDController
    {
        /// <summary>
        /// List all Sales Territories using "Name" as the display and "TerritoryID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListSalesTerritoryIDs()
        {
            return ForeignKeyIDProvider.ListSalesTerritoryIDs();
        }

        /// <summary>
        /// List all Customers using "AccountNumber" as the display and "CustomerID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListCustomerIDs()
        {
            return ForeignKeyIDProvider.ListCustomerIDs();
        }

        /// <summary>
        /// List all Addresses using "AddressLine1" as the display and "AddressID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListAddressIDs()
        {
            return ForeignKeyIDProvider.ListAddressIDs();
        }

        /// <summary>
        /// List all Ship Methods using "Name" as the display and "ShipMethodID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListShipMethodIDs()
        {
            return ForeignKeyIDProvider.ListShipMethodIDs();
        }

        /// <summary>
        /// List all Vendors using "Name" as the display and "VendorID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListVendorIDs()
        {
            return ForeignKeyIDProvider.ListVendorIDs();
        }

        /// <summary>
        /// List all Address Types using "Name" as the display and "AddressTypeID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListAddressTypeIDs()
        {
            return ForeignKeyIDProvider.ListAddressTypeIDs();
        }

        /// <summary>
        /// List all Contact Types using "Name" as the display and "ContactTypeID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListContactTypeIDs()
        {
            return ForeignKeyIDProvider.ListContactTypeIDs();
        }

        /// <summary>
        /// List all Special Offers using "Description" as the display and "SpecialOfferID" as the Primary Key.
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListSpecialOfferIDs()
        {
            return ForeignKeyIDProvider.ListSpecialOfferIDs();
        }

        /// <summary>
        /// List all Contacts using a full, formal name as the display and "ContactID" as the Primary Key (sorted by last name).
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ForeignKeyID> ListContacts()
        {
            List<ForeignKeyID> contacts = ForeignKeyIDProvider.ListContacts();
            contacts = contacts.OrderBy(person => person.DisplayText).ToList();
            return contacts;
        }

    }
}
