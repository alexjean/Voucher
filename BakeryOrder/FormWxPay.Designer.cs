namespace BakeryOrder
{
    partial class FormWxPay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSuccess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(196, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = " 微信支付连线作业状态";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(648, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ItemHeight = 16;
            this.listBoxMsg.Location = new System.Drawing.Point(9, 91);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(648, 308);
            this.listBoxMsg.TabIndex = 7;
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Location = new System.Drawing.Point(274, 423);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(113, 77);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(68, 423);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 77);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "撤消支付请求";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSuccess
            // 
            this.btnSuccess.Enabled = false;
            this.btnSuccess.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuccess.Location = new System.Drawing.Point(484, 423);
            this.btnSuccess.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Size = new System.Drawing.Size(113, 77);
            this.btnSuccess.TabIndex = 8;
            this.btnSuccess.Text = "支付成功印单";
            this.btnSuccess.UseVisualStyleBackColor = true;
            // 
            // FormWxPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(669, 554);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSuccess);
            this.Controls.Add(this.listBoxMsg);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormWxPay";
            this.Text = "FormWxPay";
            this.Load += new System.EventHandler(this.FormWxPay_Load);
            this.Shown += new System.EventHandler(this.FormWxPay_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSuccess;
    }
}