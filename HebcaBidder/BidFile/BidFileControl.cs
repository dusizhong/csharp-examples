using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HebcaBidder.BidFile
{
    public partial class BidFileControl : UserControl
    {
        public BidFileControl()
        {
            InitializeComponent();
        }

        private void UploadBidFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.axWebPDFCtrl.OpenLocalFile(openFileDialog.FileName);
                GlobalStore.BidFile = new XElement("bidFile");
                GlobalStore.BidFile.Add(new XAttribute("localPath", openFileDialog.FileName));
            }
        }

        private void axWebPDFCtrl_OnFileOpened(object sender, AxWebPDFLib._IWebPDFCtrlEvents_OnFileOpenedEvent e)
        {
            try
            {
                int count = axWebPDFCtrl.GetSealCount();
                this.label1.Text = "文件中电子签章数量：" + count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取签章数量失败：" + ex.Message);
            }
        }

        private void axWebPDFCtrl_OnInsertResult(object sender, AxWebPDFLib._IWebPDFCtrlEvents_OnInsertResultEvent e)
        {
            try
            {
                int count = axWebPDFCtrl.GetSealCount();
                this.label1.Text = "文件中电子签章数量：" + count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取签章数量失败：" + ex.Message);
            }
        }
    }
}
