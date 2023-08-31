using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CoExcel.components;
using Newtonsoft.Json;

namespace CoExcel
{
    public partial class MainForm : Form
    {
        DataTable dt = new DataTable();

        public MainForm()
        {
            InitializeComponent();

            dt.Columns.Add("序号");
            dt.Columns.Add("名称");
            dt.Columns.Add("计算基数");
            dt.Columns.Add("费率(%)");
            dt.Columns.Add("金额(元)");
            dt.Columns.Add("人工费");
            dt.Columns.Add("材料费");
            dt.Columns.Add("机械费");
            dt.Rows.Add("1", "分部分项工程量清单计价合计", "/", "/", "3", "1", "1", "1");
            dt.Rows.Add("2", "措施项目清单计价合计", "/", "/", "3", "1", "1", "1");
            dt.Rows.Add("3", "单价措施项目工程量清单计价合计", "/", "/", "3", "1", "1", "1");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ExcelUtils excelUtils = new ExcelUtils(); 
            checkInfo.Text = @"开始导入源文件......" + "\r\n";
            ExcelModel excelModel = excelUtils.ReadSourceFile("D:\\电气.xlsx");
            checkInfo.Text += "导入完成\r\n";
            checkInfo.Text += JsonConvert.SerializeObject(excelModel);
            checkInfo.Text += "\r\n";
            Console.WriteLine(JsonConvert.SerializeObject(excelModel));

            //checkInfo.Text += "开始导入目标文件......\r\n";
            //excelUtils.ReadTargetFile("D:\\电气1.xlsx");
            //checkInfo.Text += "导入完成\r\n";
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "D:\\";//注意这里写路径时要用c:\\而不是c:\
            //openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            //openFileDialog.RestoreDirectory = true;
            //openFileDialog.FilterIndex = 1;
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string fileName = openFileDialog.FileName;
            //    //File fileOpen = new File(fName);
            //    //isFileHaveName = true;
            //    //richTextBox1.Text = fileOpen.ReadFile();
            //    //richTextBox1.AppendText("");
            //    MessageBox.Show("test it！" + fileName);
            //}

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = dialog.SelectedPath;
                TreeViewUtils.showTreeView(mainTreeView, savePath);
                mainTreeView.ExpandAll();
            }
        }

        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show("test it！" + e.Node.Text.ToString());
        }

        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(mainTab.SelectedTab.Name.Equals("tabPage1"))
            {
                TableView tableView = new TableView();
                tableView.Dock = DockStyle.Fill;
                tableView.AllowUserToAddRows = false;
                tableView.AllowUserToDeleteRows = false;
                tableView.ReadOnly = true;
                //表头样式
                tableView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                tableView.ColumnHeadersHeight = tableView.ColumnHeadersHeight * 2;
                //tableView.ColumnHeadersHeight = 40;
                //添加多行表头
                tableView.AddSpanHeader(5, 3, "其中：(元)");
                //表头背景色
                tableView.EnableHeadersVisualStyles = false;
                tableView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                //tableView.RowHeadersDefaultCellStyle.BackColor = Color.White;
                //添加行号
                tableView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(tableView_RowPostPaint);
                
                //指定数据源
                tableView.DataSource = dt;
               
                //加载到tabPage
                this.tabPage1.Controls.Add(tableView);

                //禁用表头排序
                for (int i = 0; i < tableView.Columns.Count; i++)
                {
                    tableView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

            if (mainTab.SelectedTab.Name.Equals("tabPage2"))
            {
                Console.WriteLine("tab 2 clicked!");
                MyGridView myGridView = new MyGridView();
                myGridView.Dock = DockStyle.Fill;

                //DataGridViewRow row = new DataGridViewRow();
                //DataGridViewTextBoxCell textboxcell = new DataGridViewTextBoxCell();
                //textboxcell.Value = "aaa";
                //row.Cells.Add(textboxcell);
                //DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                //row.Cells.Add(comboxcell);
                //dataGridView.Rows.Add(row);
                //dataGridView.AutoGenerateColumns = false;

                //设置表格外边框
                //myGridView.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.OutsetDouble;
                //myGridView.GridColor = Color.Red; //边框线 颜色

                //dataGridView.ColumnHeadersVisible = false;

                //设置表头样式
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("宋体", 10, FontStyle.Bold);
                columnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                myGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                //设置表头项
                myGridView.ColumnCount = 4;
                myGridView.Columns[0].Name = "序号";
                myGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                myGridView.Columns[1].Name = "名称";
                myGridView.Columns[2].Name = "计算基数";
                myGridView.Columns[3].Name = "费率(%)";

                //dataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView_CellPainting);
                //dataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);

                string[] row1 = new string[] { "1", "分部分项工程量清单计价合计", "/", "/" };
                string[] row2 = new string[] { "2", "措施项目清单计价合计", "/", "/" };
                myGridView.Rows.Add(row1);
                myGridView.Rows.Add(row2);

                //int index = dataGridView.Rows.Add();
                //dataGridView.Rows[index].Cells[0].Value = "1";
                //dataGridView.Rows[index].Cells[1].Value = "2";

                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.DataSource = dt;
                //dataGridView1.GridColor = Color.Red;

                this.tabPage2.Controls.Add(dataGridView1);
            }
        }

        private void tableView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            // Current row record
            string rowNumber = (e.RowIndex + 1).ToString();
            // Format row based on number of records displayed by using leading zeros
            while (rowNumber.Length < dg.RowCount.ToString().Length) rowNumber = "0" + rowNumber;
            // Position text
            SizeF size = e.Graphics.MeasureString(rowNumber, this.Font);
            if (dg.RowHeadersWidth < (int)(size.Width + 20)) dg.RowHeadersWidth = (int)(size.Width + 20);
            // Use default system text brush
            Brush b = SystemBrushes.ControlText;
            // Draw row number
            e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            //string[] columns = new string[] { "aa", "bb", "cc" };

            //Font font = this.headPanel.Font;//字体
            //Brush color = Brushes.Black;//颜色
            //Brush border = new SolidBrush(this.headPanel.ForeColor);//用前景色画边框
            //Pen borderStyle = new Pen(border, 1);

            ////从什么位置开始画
            //float top = 60F;//Y坐标
            //float left = 560F;//X坐标
            ////画笔X坐标偏移量，left1:最后一次位置，left2当前最远位置
            //float left1 = left, left2 = 0F;
            //float textLeft = 0F;//文本X坐标
            //float textTop = 0F;//文本Y坐标
            //float textWidth = 0F;//文本宽度
            //float textHeight = 0F;//文本高度
            //const float columnHeight = 30F;//行高，包括边框在内
            //const float columnPadding = 10F;//每一列左右多出10像素

            //Graphics g = Graphics.FromHwnd(this.headPanel.Handle);
            //textHeight = font.GetHeight(g);//高
            //textTop = (columnHeight - textHeight) / 2;//上边
            //for (int i = 0; i < columns.Length; i++)
            //{
            //    //先计算文本
            //    textWidth = g.MeasureString(columns[i], font).Width;//宽
            //    textLeft = left1 + columnPadding;//左边
            //    left2 = textLeft + textWidth + columnPadding;

            //    //先画左边框
            //    g.DrawLine(borderStyle, left1, top, left1, columnHeight);

            //    //画文字
            //    g.DrawString(columns[i], font, color, textLeft, textTop);
            //    //注意左边的位置要开始偏移了
            //    left1 = left2;
            //}
            //g.DrawLine(borderStyle, left, top, left2, top);//上边框
            //g.DrawLine(borderStyle, left, columnHeight, left2, columnHeight);//下边框
            //g.DrawLine(borderStyle, left2, top, left2, columnHeight);//右边框
            int rowCount = 5;
            int colCount = 3;
            int cellHeight = 10;
            int cellWidth = 10;
            int height = rowCount * (cellHeight + 1);
            int width = colCount * (cellWidth + 1);

            Image image = new Bitmap(colCount * (cellWidth + 1) + 1, rowCount * (cellHeight + 1) + 1);

            Graphics g = Graphics.FromImage(image);
            //g.Clear(Color.FromArgb(255, 99, 98, 100));
            g.Clear(Color.White);

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Pen pen = new Pen(Color.FromArgb(255, 110, 110, 110));
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i <= colCount; i++)
            {
                g.DrawLine(pen, i * (cellWidth + 1), 0, i * (cellWidth + 1), height);
            }

            for (int i = 0; i <= rowCount; i++)
            {
                g.DrawLine(pen, 0, i * (cellHeight + 1), width, i * (cellHeight + 1));
            }

            image.Save("grid.jpg", ImageFormat.Jpeg);

            image.Dispose();
            g.Dispose();
            pen.Dispose();

            //lblH.Text = height.ToString();
            //lblW.Text = width.ToString();

            //MessageBox.Show("Generated.");

            string signTime = HttpUtils.Timestamp();

            //string content = "石家庄市冀粤生物质能发电有限公司飞灰固化区域封闭项目竞争性竞争性谈判公告5 <div style=\"font-size:30pt\">啊啊啊</div> ";
            //content = Convert.ToBase64String(content);
            string content = this.textBox1.Text;
            content = HttpUtility.UrlEncode(content, System.Text.Encoding.UTF8);
            Console.WriteLine(content);

            // 拼装请求参数
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("title", "石家庄市冀粤生物质能发电有限公司飞灰固化区域封闭项目竞争性竞争性谈判公告5");
            param.Add("content", content);
            param.Add("publishDate", "2020-09-21 15:30:00");
            param.Add("signTime", signTime);
            param.Add("signature", HttpUtils.Md5(signTime + "8h6wWSEv0NT4BvBC"));
            // 发送post请求
            Console.WriteLine(HttpUtils.Post("http://www.hbzbjt.cn/hbzbjt/zbgg", param));
        }
    }
}
