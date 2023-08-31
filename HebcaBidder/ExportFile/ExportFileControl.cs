using HebcaBidder.Util;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HebcaBidder.ExportFile
{
    public partial class ExportFileControl : UserControl
    {
        public ExportFileControl()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            XDocument bidFileXDoc = new XDocument(new XElement("root"));
            bidFileXDoc.Root.Add(GlobalStore.TenderInfo);

            foreach (XElement element in GlobalStore.TenderForm.Elements())
            {
                if(element.Value.Length == 0)
                {
                    MessageBox.Show("请填写投标报价");
                    return;
                }
            }
            if (GlobalStore.BidFile == null)
            {
                MessageBox.Show("请先上传投标文件");
                return;
            }
            int sealCount = this.axWebPDFCtrl.GetSealCount_Pack(GlobalStore.BidFile.Attribute("localPath").Value, true);
            if (sealCount < 1)
            {
                MessageBox.Show("投标文件未加盖电子签章");
                return;
            }
            HebcaP11XLib.CertMgr certMgr = new HebcaP11XLib.CertMgr();
            certMgr.Licence = "amViY56Xmp2cnpeanZyel5qdnJ6Xmp2cYWhlYoQsftgudcLw21NcfvO8eN13ICbS";
            certMgr.ReloadDevice();
            if (certMgr.GetDeviceCount() < 1)
            {
                MessageBox.Show("请插入CA数字证书");
                return;
            }
            if (certMgr.GetDeviceCount() > 1)
            {
                MessageBox.Show("电脑上插入了多个CA数字证书，你到底用哪个？不用的请拔除！");
                return;
            }
            /*try
            {
                HebcaP11XLib.Cert cert = certMgr.GetSignCert(0);
                cert.UILogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }*/
            if (this.textBox1.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写加密密码");
                return;
            }

            string secretKey = this.textBox1.Text.Trim().PadRight(16, 'x');

            XElement tenderForm = new XElement("tenderForm");
            tenderForm.Value = SM4Utils.EncryptECB(secretKey, Encoding.UTF8.GetBytes(GlobalStore.TenderForm.ToString()));
            bidFileXDoc.Root.Add(tenderForm);
            
            string filePath = GlobalStore.BidFile.Attribute("localPath").Value;
            string targetPath = filePath.Substring(0, filePath.LastIndexOf(".")) + ".bdf";
            byte[] fileBytes = File.ReadAllBytes(filePath);
            //string fileBase64 = Convert.ToBase64String(fileBytes);
            GlobalStore.BidFile.Value = SM4Utils.EncryptECB(secretKey, fileBytes);
            bidFileXDoc.Root.Add(GlobalStore.BidFile);

            HebcaP11XLib.Pkcs7 pkcs7 = certMgr.CreatePkcs7();
            string certBase64 = certMgr.GetEncryptCert(0).GetCertB64();
            pkcs7.AddRecipientCert(certBase64);
            secretKey = pkcs7.EnvelopText(secretKey, HebcaP11XLib.EnvelopAlg.ENA_SM4_CBC); //2: ENA_SM4_CBC，CA采用SM4对称加密？？不应该是SM3非对称吗？
            XElement secretKeyElement = new XElement("SecretKey");
            secretKeyElement.Value = secretKey;
            bidFileXDoc.Root.Add(secretKeyElement);

            string exportFileName = Path.GetFileNameWithoutExtension(filePath) + ".bdf";
            string exportPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + exportFileName;
            bidFileXDoc.Save(exportPath);
            MessageBox.Show("导出成功！");
        }

        private void ExportFileControl_Load(object sender, EventArgs e)
        {
            Console.WriteLine("page load");
        }
    }
}
