using System;
using System.Windows.Forms;

namespace HebcaBidder.TenderFile
{
    public partial class TenderFileControl : UserControl
    {
        public TenderFileControl()
        {
            InitializeComponent();
        }

        public void OpenTenderFile(string filePath)
        {
            try
            {
                this.axWebPDFCtrl.OpenFlags = 0x00000008; //打开文件时不自动验证签章，解决打开有时候卡死的情况
                this.axWebPDFCtrl.OpenLocalFile(filePath);
                //this.axWebPDFCtrl.ShowToolbar(false);
                this.axWebPDFCtrl.DisableSealFunc(true);
                /*this.axWebPDFCtrl.SetToolbarButtonVisible(
                    WebPDFLib.ToolbarButtonType.BTN_SEAL 
                    | WebPDFLib.ToolbarButtonType.BTN_PAGESEAL
                    | WebPDFLib.ToolbarButtonType.BTN_HANDSIGN
                    | WebPDFLib.ToolbarButtonType.BTN_GAPSEAL
                    | WebPDFLib.ToolbarButtonType.BTN_KEYWORD
                    | WebPDFLib.ToolbarButtonType.BTN_TEXT
                    | WebPDFLib.ToolbarButtonType.BTN_COMMENT
                    );*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件失败！" + ex.Message);
            }
        }

        private void TenderFileControl_Load(object sender, EventArgs e)
        {
            
        }
    }
}
