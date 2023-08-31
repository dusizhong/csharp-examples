using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoExcel
{
    class ExcelModel
    {
        private string fileName;
        private List<MySheet> sheets;

        public ExcelModel() { }
        public string FileName
        {
            set { fileName = value; }
            get { return fileName; }
        }
        public List<MySheet> Sheets
        {
            set { sheets = value; }
            get { return sheets; }
        }
    }

    class MySheet
    {
        string name;
        List<MyRow> rows;

        public MySheet() { }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public List<MyRow> Rows
        {
            set { rows = value; }
            get { return rows; }
        }
    }

    class MyRow
    {
        int rowNum;
        List<MyCell> cells;

        public MyRow() { }
        public int RowNum
        {
            set { rowNum = value; }
            get { return rowNum; }
        }
        public List<MyCell> Cells
        {
            set { cells = value; }
            get { return cells; }
        }
    }

    class MyCell
    {
        private int colIndex;
        private string cellItem;
        private string cellValue;
        private bool needCheck;

        public MyCell() { }

        public int ColIndex
        {
            set { colIndex = value; }
            get { return colIndex; }
        }

        public string CellItem
        {
            set { cellItem = value; }
            get { return cellItem; }
        }

        public string CellValue
        {
            set { cellValue = value; }
            get { return cellValue; }
        }

        public bool NeedCheck
        {
            set { needCheck = value; }
            get { return needCheck; }
        }
    }
}
