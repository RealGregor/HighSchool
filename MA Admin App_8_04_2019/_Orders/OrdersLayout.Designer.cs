using LeaveMeAlone._Groups;

namespace LeaveMeAlone {
    partial class OrdersLayout {
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.labelFriends = new System.Windows.Forms.Label();
            this.ordersData = new System.Windows.Forms.DataGridView();
            this.cartItems = new LeaveMeAlone._Groups.CartItems();
            this.currentProjects2 = new LeaveMeAlone.BottomBorderButton();
            this.coWorkersButton = new LeaveMeAlone.BottomBorderButton();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtons.Controls.Add(this.btnApplyFilters);
            this.panelButtons.Controls.Add(this.dateTimePicker1);
            this.panelButtons.Controls.Add(this.currentProjects2);
            this.panelButtons.Controls.Add(this.coWorkersButton);
            this.panelButtons.Controls.Add(this.splitter1);
            this.panelButtons.Controls.Add(this.labelFriends);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(834, 60);
            this.panelButtons.TabIndex = 29;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApplyFilters.BackColor = System.Drawing.Color.White;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilters.Location = new System.Drawing.Point(726, 18);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(108, 25);
            this.btnApplyFilters.TabIndex = 9;
            this.btnApplyFilters.Text = "Poišči naročila";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
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
            this.btnClose.Location = new System.Drawing.Point(809, 82);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 33;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker1.CustomFormat = "DD.MM.YYYY";
            this.dateTimePicker1.Location = new System.Drawing.Point(526, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(191, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(206, 0);
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
            this.labelFriends.Size = new System.Drawing.Size(206, 59);
            this.labelFriends.TabIndex = 8;
            this.labelFriends.Text = "NAROČILA";
            // 
            // ordersData
            // 
            this.ordersData.BackgroundColor = System.Drawing.Color.White;
            this.ordersData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersData.GridColor = System.Drawing.Color.Gray;
            this.ordersData.Location = new System.Drawing.Point(0, 60);
            this.ordersData.Margin = new System.Windows.Forms.Padding(0);
            this.ordersData.Name = "ordersData";
            this.ordersData.Size = new System.Drawing.Size(834, 473);
            this.ordersData.TabIndex = 35;
            this.ordersData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ordersData_CellMouseClick);
            // 
            // cartItems
            // 
            this.cartItems.BackColor = System.Drawing.Color.White;
            this.cartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartItems.Location = new System.Drawing.Point(0, 60);
            this.cartItems.Name = "cartItems";
            this.cartItems.Size = new System.Drawing.Size(834, 473);
            this.cartItems.TabIndex = 34;
            this.cartItems.Visible = false;
            // 
            // currentProjects2
            // 
            this.currentProjects2.AutoSize = true;
            this.currentProjects2.BackColor = System.Drawing.Color.Transparent;
            this.currentProjects2.Dock = System.Windows.Forms.DockStyle.Left;
            this.currentProjects2.FlatAppearance.BorderSize = 0;
            this.currentProjects2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.currentProjects2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.currentProjects2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentProjects2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentProjects2.ForeColor = System.Drawing.Color.Gray;
            this.currentProjects2.Location = new System.Drawing.Point(383, 0);
            this.currentProjects2.Margin = new System.Windows.Forms.Padding(0);
            this.currentProjects2.Name = "currentProjects2";
            this.currentProjects2.Size = new System.Drawing.Size(140, 60);
            this.currentProjects2.TabIndex = 7;
            this.currentProjects2.Text = "Storitve 2";
            this.currentProjects2.UseVisualStyleBackColor = false;
            // 
            // coWorkersButton
            // 
            this.coWorkersButton.AutoSize = true;
            this.coWorkersButton.BackColor = System.Drawing.Color.Transparent;
            this.coWorkersButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.coWorkersButton.FlatAppearance.BorderSize = 0;
            this.coWorkersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.coWorkersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.coWorkersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coWorkersButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.coWorkersButton.ForeColor = System.Drawing.Color.Gray;
            this.coWorkersButton.Location = new System.Drawing.Point(207, 0);
            this.coWorkersButton.Margin = new System.Windows.Forms.Padding(0);
            this.coWorkersButton.Name = "coWorkersButton";
            this.coWorkersButton.Size = new System.Drawing.Size(176, 60);
            this.coWorkersButton.TabIndex = 6;
            this.coWorkersButton.Text = "Išči po datumu";
            this.coWorkersButton.UseVisualStyleBackColor = false;
            // 
            // OrdersLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ordersData);
            this.Controls.Add(this.cartItems);
            this.Controls.Add(this.panelButtons);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OrdersLayout";
            this.Size = new System.Drawing.Size(834, 533);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelButtons;
        private BottomBorderButton currentProjects2;
        private BottomBorderButton coWorkersButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label labelFriends;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClose;
        private CartItems cartItems;
        private System.Windows.Forms.DataGridView ordersData;
    }
}
