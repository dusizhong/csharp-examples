using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Drawing.Text;
using System.Collections;

namespace CoExcel
{
    class ExcelUtils
    {

        /**
         * 读取源文件
         * @param filePath
         * @return ExcelModel
         */
        public ExcelModel ReadSourceFile(string filePath)
        {
            ExcelModel excelModel = new ExcelModel();
            if (!File.Exists(filePath.ToString())) {
                throw new Exception("文件不存在!");
            }
            string extension = Path.GetExtension(filePath);
            excelModel.FileName = Path.GetFileName(filePath);
            try {
                //获取文件
                IWorkbook workbook = null;
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (extension.Equals(".xls")) {
                    workbook = new HSSFWorkbook(fs);
                } else {
                    workbook = new XSSFWorkbook(fs);
                }
                fs.Close();
                //获取sheets
                Console.WriteLine(workbook.NumberOfSheets);
                List<MySheet> mySheets = new List<MySheet>();
                for(int n=0; n<1; n++) {
                    ISheet sheet = workbook.GetSheetAt(n);
                    MySheet mySheet = new MySheet();
                    mySheet.Name = sheet.SheetName;
                    //获取row
                    List<MyRow> myRows = new List<MyRow>();
                    for (int i = 0; i <= sheet.LastRowNum; i++) {
                        IRow row = sheet.GetRow(i);
                        MyRow myRow = new MyRow();
                        myRow.RowNum = row.RowNum;
                        List<MyCell> myCells = new List<MyCell>();
                        if (row != null) {
                            //获取cell
                            for (int j = 0; j < row.LastCellNum; j++) {
                                ICell cell = row.GetCell(j);
                                MyCell myCell = new MyCell();
                                myCell.ColIndex = cell.ColumnIndex;
                                myCell.CellItem = cell.ToString();
                                myCell.CellValue = cell.ToString();
                                myCell.NeedCheck = true;
                                myCells.Add(myCell);
                            }
                        }
                        myRow.Cells = myCells;
                        myRows.Add(myRow);
                    }
                    mySheet.Rows = myRows;
                    mySheets.Add(mySheet);
                }
                excelModel.Sheets = mySheets;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return excelModel;
        }


        /*
         * 读取目标文件
         * @param filePath
         * @return ExcelModel
         */
        public void ReadTargetFile(string filePath)
        {
            
        }


        public void ReadFile(string filePath)
        {
            IWorkbook workbook = null;
            string extension = Path.GetExtension(filePath);
            try
            {
                FileStream fs = File.OpenRead(filePath);
                if (extension.Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(fs); //读取xls文件
                }
                else
                {
                    workbook = new XSSFWorkbook(fs); //读取xlsx文件
                }
                fs.Close();

                //读取当前表数据
                ISheet sheet = workbook.GetSheetAt(0);

                //读取当前行数据
                IRow row = sheet.GetRow(0);

                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i); //读取当前行数据
                    if (row != null)
                    {
                        for (int j = 0; j < row.LastCellNum; j++)
                        {
                            //读取该行的第j列数据
                            string value = row.GetCell(j).ToString();
                            Console.Write(value.ToString() + " ");
                        }
                        Console.WriteLine("\n");
                    }
                }
            }
            catch (Exception e)
            {
                //只在Debug模式下才输出
                Console.WriteLine(e.Message);
            }
        }
    }
}
