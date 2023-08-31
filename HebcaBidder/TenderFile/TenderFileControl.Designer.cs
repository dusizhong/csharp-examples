
namespace HebcaBidder.TenderFile
{
    partial class TenderFileControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TenderFileControl));
            this.axWebPDFCtrl = new AxWebPDFLib.AxWebPDFCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.axWebPDFCtrl)).BeginInit();
            this.SuspendLayout();
            // 
            // axWebPDFCtrl
            // 
            this.axWebPDFCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWebPDFCtrl.Enabled = true;
            this.axWebPDFCtrl.Location = new System.Drawing.Point(0, 0);
            this.axWebPDFCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.axWebPDFCtrl.Name = "axWebPDFCtrl";
            this.axWebPDFCtrl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebPDFCtrl.OcxState")));
            // 
            // TenderFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axWebPDFCtrl);
            this.Name = "TenderFileControl";
            this.Size = new System.Drawing.Size(1108, 618);
            this.Load += new System.EventHandler(this.TenderFileControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWebPDFCtrl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxWebPDFLib.AxWebPDFCtrl axWebPDFCtrl;
    }
}
