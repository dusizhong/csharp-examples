using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HebcaBidder.TenderForm
{
    public partial class TenderFormControl : UserControl
    {
        public TenderFormControl()
        {
            InitializeComponent();
        }

        private XElement tenderForm;

        private void TenderFormControl_Load(object sender, EventArgs e)
        {
            tenderForm = GlobalStore.TenderForm;
            if(tenderForm == null)
            {
                MessageBox.Show("请先导入招标文件");
                return;
            }

            Panel titlePanel = new Panel();
            titlePanel.Height = 60;
            titlePanel.BackColor = Color.AliceBlue;
            titlePanel.Dock = DockStyle.Top;
            Label titleLabel = new Label();
            titleLabel.Text = "投标报价";
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Font = new Font(Font.FontFamily, 20);
            titlePanel.Controls.Add(titleLabel);

            TableLayoutPanel tableLayout = new TableLayoutPanel();
            tableLayout.Dock = DockStyle.Top;
            tableLayout.ColumnCount = 2;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial;

            int i = 0;
            foreach (XElement x in tenderForm.Elements())
            {
                ++tableLayout.RowCount;
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));

                Label label = new Label();
                label.Text = x.Attribute("fieldName").Value;
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleRight;
                label.Font = new Font(Font.FontFamily, 16);
                tableLayout.Controls.Add(label);
                tableLayout.SetCellPosition(label, new TableLayoutPanelCellPosition(0, i));

                TextBox textBox = new TextBox();
                textBox.Width = 300;
                textBox.Anchor = AnchorStyles.Left;
                textBox.Name = x.Attribute("fieldId").Value;
                textBox.Font = new Font(Font.FontFamily, 16);
                textBox.TextChanged += TextBox_TextChanged;
                tableLayout.Controls.Add(textBox);
                tableLayout.SetCellPosition(textBox, new TableLayoutPanelCellPosition(1, i));
                i++;
            }

            tableLayout.Height = tableLayout.RowCount * 60 + 10;
            this.Controls.Add(tableLayout);
            this.Controls.Add(titlePanel);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            foreach (XElement formField in tenderForm.Elements())
            {
                if (formField.Attribute("fieldId").Value.Equals(textBox.Name))
                {
                    formField.Value = textBox.Text;
                }
            }
        }
    }
}
