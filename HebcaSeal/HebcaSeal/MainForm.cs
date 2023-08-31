using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HebcaSeal
{
    public partial class mainForm : Form
    {
        
        private string filePath;
        public mainForm()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "请选择文件";
            openFileDialog.Filter = "PDF文件(*.pdf)|*.pdf";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePath = openFileDialog.FileName;
                try
                {
                    axWebPDFCtrl.OpenFlags = 0x00000008; //打开文件时不自动验证签章，解决打开有时候卡死的情况
                    axWebPDFCtrl.OpenLocalFile(this.filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件失败：" + ex.Message);
                }
            }
            
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            if (axWebPDFCtrl.IsReaderOpened() == 1)
            {
                try
                {
                    int count = axWebPDFCtrl.GetSealCount();
                    if (count < 1)
                    {
                        MessageBox.Show("文件未签章，请签章后保存");
                    }
                    else
                    {
                        try
                        {
                            axWebPDFCtrl.SaveLocalFile(this.filePath);
                            MessageBox.Show("保存成功");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("保存文件失败：" + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取签章数量失败：" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请先打开文件");
            }
        }

        private void mainForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (axWebPDFCtrl.IsReaderOpened() == 1)
            {
                try
                {
                    int count = axWebPDFCtrl.GetSealCount();
                    if (count < 1)
                    {
                        if (MessageBox.Show("文件未签章，确定退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取签章数量失败：" + ex.Message);
                }
            }
        }

        private void axWebPDFCtrl_OnFileOpened(object sender, AxWebPDFLib._IWebPDFCtrlEvents_OnFileOpenedEvent e)
        {
            try
            {
                int count = axWebPDFCtrl.GetSealCount();
                this.toolStripStatusLabel.Text = "文件中电子签章数量：" + count;
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
                this.toolStripStatusLabel.Text = "文件中电子签章数量：" + count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取签章数量失败：" + ex.Message);
            }
        }
    }
}
