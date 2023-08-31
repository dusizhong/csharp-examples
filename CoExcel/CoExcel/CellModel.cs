using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoExcel
{
    class CellModel
    {
        string position;
        string item;
        string value;
        string needCheck;

        public CellModel()
        {
        }

        public string Position
        {
            set { position = value; }
            get { return position; }
        }
    }
}