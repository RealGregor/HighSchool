namespace LeaveMeAlone._Groups {
    partial class CartItems {
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
            ((System.ComponentModel.ISupportInitialize)(this.cartData)).BeginInit();
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
            this.cartData.Size = new System.Drawing.Size(831, 430);
            this.cartData.TabIndex = 29;
            this.cartData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cartData_CellMouseClick);
            // 
            // CartItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cartData);
            this.Name = "CartItems";
            this.Size = new System.Drawing.Size(831, 430);
            ((System.ComponentModel.ISupportInitialize)(this.cartData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView cartData;
    }
}
