using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoExcel.components
{
    public partial class TableView : DataGridView
    {
        public TableView()
        {
            InitializeComponent();
        }

        public TableView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        //表头结构
        private struct SpanInfo 
        {
            public string Text; //列主标题
            public int Position; //位置（1左，2中，3右）
            public int Left; //对应左行
            public int Right; //对应右行
            public SpanInfo(string Text, int Position, int Left, int Right)
            {
                this.Text = Text;
                this.Position = Position;
                this.Left = Left;
                this.Right = Right;
            }
        }
        //需要2维表头的列
        private Dictionary<int, SpanInfo> SpanRows = new Dictionary<int, SpanInfo>();

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                if (SpanRows.ContainsKey(e.ColumnIndex)) //被合并的列
                {
                    //画边框
                    Graphics g = e.Graphics;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                    int left = e.CellBounds.Left, top = e.CellBounds.Top + 2;
                    int right = e.CellBounds.Right, bottom = e.CellBounds.Bottom;
                    switch (SpanRows[e.ColumnIndex].Position)
                    {
                        case 1:
                            left += 2;
                            break;
                        case 2:
                            break;
                        case 3:
                            right -= 2;
                            break;
                    }
                    //画上半部分底色
                    g.FillRectangle(new SolidBrush(Color.White), left, top, right - left, (bottom - top) / 2);
                    //画横中线
                    g.DrawLine(new Pen(Color.Gray), left, (top + bottom) / 2, right, (top + bottom) / 2);

                    //写标题
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    g.DrawString(e.Value + "", e.CellStyle.Font, Brushes.Black,
                        new Rectangle(left, (top + bottom) / 2, right - left, (bottom - top) / 2), sf);
                    left = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Left, true).Left - 2;

                    if (left < 0) left = this.GetCellDisplayRectangle(-1, -1, true).Width;
                    right = this.GetColumnDisplayRectangle(SpanRows[e.ColumnIndex].Right, true).Right - 2;
                    if (right < 0) right = this.Width;
                    g.DrawString(SpanRows[e.ColumnIndex].Text, e.CellStyle.Font, Brushes.Black,
                        new Rectangle(left, top, right - left, (bottom - top) / 2), sf);

                    e.Handled = true;
                }
            }
            base.OnCellPainting(e);
        }

        //合并表头列
        public void AddSpanHeader(int ColIndex, int ColCount, string Text)
        {
            if (ColCount < 2)
            {
                throw new Exception("合并列至少2以上");
            }
            //将这些列加入列表
            int Right = ColIndex + ColCount - 1; //同一大标题下的最后一列的索引
            SpanRows[ColIndex] = new SpanInfo(Text, 1, ColIndex, Right); //添加标题下的最左列
            SpanRows[Right] = new SpanInfo(Text, 3, ColIndex, Right); //添加该标题下的最右列
            for (int i = ColIndex + 1; i < Right; i++) //中间的列
            {
                SpanRows[i] = new SpanInfo(Text, 2, ColIndex, Right);
            }
        }

        //清除合并的列
        public void ClearSpanInfo()
        {
            SpanRows.Clear();
            //ReDrawHead();
        }

        //刷新显示表头
        public void ReDrawHead()
        {
            foreach (int si in SpanRows.Keys)
            {
                this.Invalidate(this.GetCellDisplayRectangle(si, -1, true));
            }
        }
    }
}
