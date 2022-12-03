namespace LeaveMeAlone {
    partial class CartLayout {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panelButtons = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.labelFriends = new System.Windows.Forms.Label();
            this.myCartLayout = new LeaveMeAlone._Groups.MyCartLayout();
            this.groupRequestsButton = new LeaveMeAlone.BottomBorderButton();
            this.myOrders = new LeaveMeAlone.BottomBorderButton();
            this.myCart = new LeaveMeAlone.BottomBorderButton();
            this.myOrdersLayout = new LeaveMeAlone._Groups.MyOrdersLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtons.Controls.Add(this.groupRequestsButton);
            this.panelButtons.Controls.Add(this.myOrders);
            this.panelButtons.Controls.Add(this.myCart);
            this.panelButtons.Controls.Add(this.splitter1);
            this.panelButtons.Controls.Add(this.labelFriends);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(831, 60);
            this.panelButtons.TabIndex = 27;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(202, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 60);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelFriends.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.labelFriends.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(150)))), ((int)(((byte)(23)))));
            this.labelFriends.Location = new System.Drawing.Point(0, 0);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.labelFriends.Size = new System.Drawing.Size(202, 59);
            this.labelFriends.TabIndex = 8;
            this.labelFriends.Text = "KOŠARICA";
            // 
            // myCartLayout
            // 
            this.myCartLayout.BackColor = System.Drawing.Color.White;
            this.myCartLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myCartLayout.Location = new System.Drawing.Point(0, 60);
            this.myCartLayout.Name = "myCartLayout";
            this.myCartLayout.Size = new System.Drawing.Size(831, 428);
            this.myCartLayout.TabIndex = 28;
            // 
            // groupRequestsButton
            // 
            this.groupRequestsButton.AutoSize = true;
            this.groupRequestsButton.BackColor = System.Drawing.Color.Transparent;
            this.groupRequestsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupRequestsButton.FlatAppearance.BorderSize = 0;
            this.groupRequestsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.groupRequestsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.groupRequestsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupRequestsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupRequestsButton.ForeColor = System.Drawing.Color.Gray;
            this.groupRequestsButton.Location = new System.Drawing.Point(550, 0);
            this.groupRequestsButton.Margin = new System.Windows.Forms.Padding(0);
            this.groupRequestsButton.Name = "groupRequestsButton";
            this.groupRequestsButton.Size = new System.Drawing.Size(193, 60);
            this.groupRequestsButton.TabIndex = 8;
            this.groupRequestsButton.Text = "Friend Requests";
            this.groupRequestsButton.UseVisualStyleBackColor = false;
            this.groupRequestsButton.Visible = false;
            // 
            // myOrders
            // 
            this.myOrders.AutoSize = true;
            this.myOrders.BackColor = System.Drawing.Color.Transparent;
            this.myOrders.Dock = System.Windows.Forms.DockStyle.Left;
            this.myOrders.FlatAppearance.BorderSize = 0;
            this.myOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.myOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.myOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myOrders.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.myOrders.ForeColor = System.Drawing.Color.Gray;
            this.myOrders.Location = new System.Drawing.Point(372, 0);
            this.myOrders.Margin = new System.Windows.Forms.Padding(0);
            this.myOrders.Name = "myOrders";
            this.myOrders.Size = new System.Drawing.Size(178, 60);
            this.myOrders.TabIndex = 7;
            this.myOrders.Text = "Moja naročila";
            this.myOrders.UseVisualStyleBackColor = false;
            this.myOrders.Click += new System.EventHandler(this.myOrdersButton_Click);
            this.myOrders.MouseEnter += new System.EventHandler(this.myOrdersButton_MouseEnter);
            this.myOrders.MouseLeave += new System.EventHandler(this.myOrdersButton_MouseLeave);
            // 
            // myCart
            // 
            this.myCart.AutoSize = true;
            this.myCart.BackColor = System.Drawing.Color.Transparent;
            this.myCart.Dock = System.Windows.Forms.DockStyle.Left;
            this.myCart.FlatAppearance.BorderSize = 0;
            this.myCart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.myCart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.myCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myCart.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.myCart.ForeColor = System.Drawing.Color.Gray;
            this.myCart.Location = new System.Drawing.Point(203, 0);
            this.myCart.Margin = new System.Windows.Forms.Padding(0);
            this.myCart.Name = "myCart";
            this.myCart.Size = new System.Drawing.Size(169, 60);
            this.myCart.TabIndex = 6;
            this.myCart.Text = "Moja košarica";
            this.myCart.UseVisualStyleBackColor = false;
            this.myCart.Click += new System.EventHandler(this.myCartButton_Click);
            this.myCart.MouseEnter += new System.EventHandler(this.myCartButton_MouseEnter);
            this.myCart.MouseLeave += new System.EventHandler(this.myCartButton_MouseLeave);
            // 
            // myOrdersLayout
            // 
            this.myOrdersLayout.BackColor = System.Drawing.Color.White;
            this.myOrdersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myOrdersLayout.Location = new System.Drawing.Point(0, 60);
            this.myOrdersLayout.Name = "myOrdersLayout";
            this.myOrdersLayout.Size = new System.Drawing.Size(831, 428);
            this.myOrdersLayout.TabIndex = 29;
            // 
            // CartLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.myCartLayout);
            this.Controls.Add(this.myOrdersLayout);
            this.Controls.Add(this.panelButtons);
            this.Name = "CartLayout";
            this.Size = new System.Drawing.Size(831, 488);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelButtons;
        private BottomBorderButton groupRequestsButton;
        private BottomBorderButton myOrders;
        private BottomBorderButton myCart;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label labelFriends;
        private _Groups.MyCartLayout myCartLayout;
        private _Groups.MyOrdersLayout myOrdersLayout;
    }
}
