using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HebcaBidder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void ImportTenderFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "请选择招标文件";
            openFileDialog.Filter = "TDF文件(*.tdf)|*.tdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XDocument document = XDocument.Load(openFileDialog.FileName);
                    XElement root = document.Root;

                    XElement tenderInfo = root.Element("tenderInfo");
                    this.label1.Text = "标段编号：" + tenderInfo.Element("tenderSectionNo").Value;
                    this.label2.Text = "标段名称：" + tenderInfo.Element("tenderSectionName").Value;

                    XElement tenderFile = root.Element("tenderFile");
                    string fileName = tenderFile.Attribute("fileName").Value + ".pdf";
                    byte[] fileBytes = Convert.FromBase64String(tenderFile.Value);
                    string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + fileName;
                    File.WriteAllBytes(targetPath, fileBytes);
                    this.tenderFileControl.OpenTenderFile(targetPath);

                    GlobalStore.TenderInfo = root.Element("tenderInfo");
                    GlobalStore.TenderForm = root.Element("tenderForm");
                    this.mainTabControl.Enabled = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("导入招标文件失败：" + ex.Message);
                }
            }
        }
    }
}
