namespace LeaveMeAlone._Groups {
    partial class MyCartLayout {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cartData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cartData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartData
            // 
            this.cartData.BackgroundColor = System.Drawing.Color.White;
            this.cartData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartData.GridColor = System.Drawing.Color.White;
            this.cartData.Location = new System.Drawing.Point(0, 0);
            this.cartData.Margin = new System.Windows.Forms.Padding(0);
            this.cartData.Name = "cartData";
            this.cartData.Size = new System.Drawing.Size(831, 360);
            this.cartData.TabIndex = 29;
            this.cartData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cartData_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnAddOrder);
            this.panel1.Controls.Add(this.txtUserPass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 360);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 70);
            this.panel1.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(628, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 218;
            this.label10.Text = "Geslo:";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOrder.AutoSize = true;
            this.btnAddOrder.BackColor = System.Drawing.Color.White;
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddOrder.ForeColor = System.Drawing.Color.Black;
            this.btnAddOrder.Location = new System.Drawing.Point(769, 35);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(59, 29);
            this.btnAddOrder.TabIndex = 215;
            this.btnAddOrder.Text = "Naroči";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // txtUserPass
            // 
            this.txtUserPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtUserPass.Location = new System.Drawing.Point(689, 6);
            this.txtUserPass.Name = "txtUserPass";
            this.txtUserPass.PasswordChar = '*';
            this.txtUserPass.Size = new System.Drawing.Size(139, 23);
            this.txtUserPass.TabIndex = 217;
            // 
            // MyCartLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cartData);
            this.Controls.Add(this.panel1);
            this.Name = "MyCartLayout";
            this.Size = new System.Drawing.Size(831, 430);
            ((System.ComponentModel.ISupportInitialize)(this.cartData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView cartData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.TextBox txtUserPass;
    }
}
