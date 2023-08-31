
namespace HebcaSeal
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.headPanel = new System.Windows.Forms.Panel();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.axWebPDFCtrl = new AxWebPDFLib.AxWebPDFCtrl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.headPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWebPDFCtrl)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.Controls.Add(this.saveFileButton);
            this.headPanel.Controls.Add(this.openFileButton);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headPanel.Name = "headPanel";
            this.headPanel.Size = new System.Drawing.Size(800, 50);
            this.headPanel.TabIndex = 0;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(108, 11);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(85, 28);
            this.saveFileButton.TabIndex = 2;
            this.saveFileButton.Text = "保存文件";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(12, 11);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(85, 28);
            this.openFileButton.TabIndex = 1;
            this.openFileButton.Text = "打开文件";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // axWebPDFCtrl
            // 
            this.axWebPDFCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWebPDFCtrl.Enabled = true;
            this.axWebPDFCtrl.Location = new System.Drawing.Point(0, 0);
            this.axWebPDFCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.axWebPDFCtrl.Name = "axWebPDFCtrl";
            this.axWebPDFCtrl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebPDFCtrl.OcxState")));
            this.axWebPDFCtrl.Size = new System.Drawing.Size(800, 450);
            this.axWebPDFCtrl.TabIndex = 100;
            this.axWebPDFCtrl.OnFileOpened += new AxWebPDFLib._IWebPDFCtrlEvents_OnFileOpenedEventHandler(this.axWebPDFCtrl_OnFileOpened);
            this.axWebPDFCtrl.OnInsertResult += new AxWebPDFLib._IWebPDFCtrlEvents_OnInsertResultEventHandler(this.axWebPDFCtrl_OnInsertResult);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 424);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 26);
            this.statusStrip.TabIndex = 101;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel.Text = "就绪";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.headPanel);
            this.Controls.Add(this.axWebPDFCtrl);
            this.Name = "mainForm";
            this.Text = "河北CA签章工具v1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_Closing);
            this.headPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWebPDFCtrl)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWebPDFLib.AxWebPDFCtrl axWebPDFCtrl;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

