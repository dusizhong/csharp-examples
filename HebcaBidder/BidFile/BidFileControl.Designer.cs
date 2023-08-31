
namespace HebcaBidder.BidFile
{
    partial class BidFileControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BidFileControl));
            this.topPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadBidFileButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.axWebPDFCtrl = new AxWebPDFLib.AxWebPDFCtrl();
            this.topPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWebPDFCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.uploadBidFileButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1108, 70);
            this.topPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "待上传...";
            // 
            // uploadBidFileButton
            // 
            this.uploadBidFileButton.Location = new System.Drawing.Point(19, 25);
            this.uploadBidFileButton.Name = "uploadBidFileButton";
            this.uploadBidFileButton.Size = new System.Drawing.Size(120, 28);
            this.uploadBidFileButton.TabIndex = 0;
            this.uploadBidFileButton.Text = "上传投标文件";
            this.uploadBidFileButton.UseVisualStyleBackColor = true;
            this.uploadBidFileButton.Click += new System.EventHandler(this.UploadBidFileButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.axWebPDFCtrl);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 70);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1108, 514);
            this.contentPanel.TabIndex = 1;
            // 
            // axWebPDFCtrl
            // 
            this.axWebPDFCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWebPDFCtrl.Enabled = true;
            this.axWebPDFCtrl.Location = new System.Drawing.Point(0, 0);
            this.axWebPDFCtrl.Name = "axWebPDFCtrl";
            this.axWebPDFCtrl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebPDFCtrl.OcxState")));
            this.axWebPDFCtrl.Size = new System.Drawing.Size(1108, 514);
            this.axWebPDFCtrl.TabIndex = 0;
            this.axWebPDFCtrl.OnFileOpened += new AxWebPDFLib._IWebPDFCtrlEvents_OnFileOpenedEventHandler(this.axWebPDFCtrl_OnFileOpened);
            this.axWebPDFCtrl.OnInsertResult += new AxWebPDFLib._IWebPDFCtrlEvents_OnInsertResultEventHandler(this.axWebPDFCtrl_OnInsertResult);
            // 
            // BidFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "BidFileControl";
            this.Size = new System.Drawing.Size(1108, 584);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWebPDFCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWebPDFLib.AxWebPDFCtrl axWebPDFCtrl;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button uploadBidFileButton;
        private System.Windows.Forms.Label label1;
    }
}
