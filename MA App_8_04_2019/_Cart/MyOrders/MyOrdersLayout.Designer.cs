namespace LeaveMeAlone._Groups {
    partial class MyOrdersLayout {
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
            this.ordersData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.cartItems = new LeaveMeAlone._Groups.CartItems();
            ((System.ComponentModel.ISupportInitialize)(this.ordersData)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersData
            // 
            this.ordersData.BackgroundColor = System.Drawing.Color.White;
            this.ordersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersData.GridColor = System.Drawing.Color.White;
            this.ordersData.Location = new System.Drawing.Point(0, 0);
            this.ordersData.Margin = new System.Windows.Forms.Padding(0);
            this.ordersData.Name = "ordersData";
            this.ordersData.Size = new System.Drawing.Size(831, 430);
            this.ordersData.TabIndex = 29;
            this.ordersData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cartData_CellMouseClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_close_window_24;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(806, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 31;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cartItems
            // 
            this.cartItems.BackColor = System.Drawing.Color.White;
            this.cartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartItems.Location = new System.Drawing.Point(0, 0);
            this.cartItems.Name = "cartItems";
            this.cartItems.Size = new System.Drawing.Size(831, 430);
            this.cartItems.TabIndex = 30;
            this.cartItems.Visible = false;
            // 
            // MyOrdersLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ordersData);
            this.Controls.Add(this.cartItems);
            this.Name = "MyOrdersLayout";
            this.Size = new System.Drawing.Size(831, 430);
            ((System.ComponentModel.ISupportInitialize)(this.ordersData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView ordersData;
        private CartItems cartItems;
        private System.Windows.Forms.Button btnClose;
    }
}
