using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbExplorer.Model
{
    public class ForeignKeyID
    {
        private string _DisplayText;
        private int _ID;
        public string DisplayText
        {
            get { return _DisplayText; }
        }
        public int ID
        {
            get { return _ID; }
        }
        public ForeignKeyID(int ID, string DisplayText)
        {
            this._ID = ID;
            this._DisplayText = DisplayText;
        }
    }
}
