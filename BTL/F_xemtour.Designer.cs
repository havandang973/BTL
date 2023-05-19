namespace BTL
{
    partial class F_xemtour
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
            this.DGV_Xem = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btntim = new System.Windows.Forms.Button();
            this.txtkey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Xem)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Xem
            // 
            this.DGV_Xem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DGV_Xem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Xem.Location = new System.Drawing.Point(46, 211);
            this.DGV_Xem.Name = "DGV_Xem";
            this.DGV_Xem.RowHeadersWidth = 51;
            this.DGV_Xem.RowTemplate.Height = 24;
            this.DGV_Xem.Size = new System.Drawing.Size(1331, 495);
            this.DGV_Xem.TabIndex = 26;
            this.DGV_Xem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Xem_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(112, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1164, 54);
            this.label1.TabIndex = 25;
            this.label1.Text = "THÔNG TIN VỀ TOUR KHÁCH HÀNG ĐÃ ĐĂNG KÝ";
            // 
            // btntim
            // 
            this.btntim.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btntim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntim.ForeColor = System.Drawing.Color.Blue;
            this.btntim.Location = new System.Drawing.Point(1279, 148);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(96, 32);
            this.btntim.TabIndex = 63;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // txtkey
            // 
            this.txtkey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtkey.Location = new System.Drawing.Point(924, 155);
            this.txtkey.Name = "txtkey";
            this.txtkey.Size = new System.Drawing.Size(333, 22);
            this.txtkey.TabIndex = 62;
            // 
            // F_xemtour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 733);
            this.Controls.Add(this.btntim);
            this.Controls.Add(this.txtkey);
            this.Controls.Add(this.DGV_Xem);
            this.Controls.Add(this.label1);
            this.Name = "F_xemtour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_xemtour";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Xem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Xem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.TextBox txtkey;
    }
}