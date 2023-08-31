
namespace HebcaBidder
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.headPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.importTenderFileButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tenderFileControl = new HebcaBidder.TenderFile.TenderFileControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tenderFormControl = new HebcaBidder.TenderForm.TenderFormControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bidFileControl = new HebcaBidder.BidFile.BidFileControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.exportFileControl = new HebcaBidder.ExportFile.ExportFileControl();
            this.headPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.Controls.Add(this.label1);
            this.headPanel.Controls.Add(this.label2);
            this.headPanel.Controls.Add(this.importTenderFileButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(1006, 67);
            this.headPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "标段编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "标段名称：";
            // 
            // importTenderFileButton
            // 
            this.importTenderFileButton.Location = new System.Drawing.Point(17, 21);
            this.importTenderFileButton.Name = "importTenderFileButton";
            this.importTenderFileButton.Size = new System.Drawing.Size(120, 28);
            this.importTenderFileButton.TabIndex = 0;
            this.importTenderFileButton.Text = "导入招标文件";
            this.importTenderFileButton.UseVisualStyleBackColor = true;
            this.importTenderFileButton.Click += new System.EventHandler(this.ImportTenderFileButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainTabControl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 67);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1006, 654);
            this.mainPanel.TabIndex = 1;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Enabled = false;

            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage3);
            this.mainTabControl.Controls.Add(this.tabPage4);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.ItemSize = new System.Drawing.Size(172, 31);
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1006, 654);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tenderFileControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(998, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查看招标文件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tenderFileControl
            // 
            this.tenderFileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenderFileControl.Location = new System.Drawing.Point(3, 3);
            this.tenderFileControl.Name = "tenderFileControl";
            this.tenderFileControl.Size = new System.Drawing.Size(992, 609);
            this.tenderFileControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tenderFormControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(998, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "填写投标报价";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tenderFormControl
            // 
            this.tenderFormControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tenderFormControl.Location = new System.Drawing.Point(3, 3);
            this.tenderFormControl.Name = "tenderFormControl";
            this.tenderFormControl.Size = new System.Drawing.Size(992, 609);
            this.tenderFormControl.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bidFileControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 35);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(998, 615);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "上传投标文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bidFileControl
            // 
            this.bidFileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bidFileControl.Location = new System.Drawing.Point(3, 3);
            this.bidFileControl.Name = "bidFileControl";
            this.bidFileControl.Size = new System.Drawing.Size(992, 609);
            this.bidFileControl.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.exportFileControl);
            this.tabPage4.Location = new System.Drawing.Point(4, 35);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(998, 615);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "加密导出投标文件";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // exportFileControl
            // 
            this.exportFileControl.AutoSize = true;
            this.exportFileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportFileControl.Location = new System.Drawing.Point(3, 3);
            this.exportFileControl.Name = "exportFileControl";
            this.exportFileControl.Size = new System.Drawing.Size(992, 609);
            this.exportFileControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HebcaBidder";
            this.headPanel.ResumeLayout(false);
            this.headPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button importTenderFileButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TenderFile.TenderFileControl tenderFileControl;
        private TenderForm.TenderFormControl tenderFormControl;
        private BidFile.BidFileControl bidFileControl;
        private ExportFile.ExportFileControl exportFileControl;
    }
}

