namespace LeaveMeAlone
{
    partial class FavouritesLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.friendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.AddToFavouritesButton = new DevExpress.XtraBars.BarButtonItem();
            this.inviteToGroupsButton = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.groupRequestsButton2 = new LeaveMeAlone.BottomBorderButton();
            this.currentProjects2 = new LeaveMeAlone.BottomBorderButton();
            this.coWorkersButton = new LeaveMeAlone.BottomBorderButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.labelFriends = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.friendBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.AddToFavouritesButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.inviteToGroupsButton)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // AddToFavouritesButton
            // 
            this.AddToFavouritesButton.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.AddToFavouritesButton.Caption = "Add to favourites";
            this.AddToFavouritesButton.Id = 1;
            this.AddToFavouritesButton.ImageOptions.Image = global::LeaveMeAlone.Properties.Resources.icons8_christmas_star_20;
            this.AddToFavouritesButton.Name = "AddToFavouritesButton";
            this.AddToFavouritesButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // inviteToGroupsButton
            // 
            this.inviteToGroupsButton.Caption = "Invite to groups";
            this.inviteToGroupsButton.Id = 4;
            this.inviteToGroupsButton.Name = "inviteToGroupsButton";
            this.inviteToGroupsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.inviteToGroupsButton_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.AddToFavouritesButton,
            this.inviteToGroupsButton});
            this.barManager1.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 60);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(834, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 533);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(834, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 60);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 473);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(834, 60);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 473);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtons.Controls.Add(this.groupRequestsButton2);
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
            // groupRequestsButton2
            // 
            this.groupRequestsButton2.AutoSize = true;
            this.groupRequestsButton2.BackColor = System.Drawing.Color.Transparent;
            this.groupRequestsButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupRequestsButton2.FlatAppearance.BorderSize = 0;
            this.groupRequestsButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.groupRequestsButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.groupRequestsButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupRequestsButton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupRequestsButton2.ForeColor = System.Drawing.Color.Gray;
            this.groupRequestsButton2.Location = new System.Drawing.Point(478, 0);
            this.groupRequestsButton2.Margin = new System.Windows.Forms.Padding(0);
            this.groupRequestsButton2.Name = "groupRequestsButton2";
            this.groupRequestsButton2.Size = new System.Drawing.Size(149, 60);
            this.groupRequestsButton2.TabIndex = 8;
            this.groupRequestsButton2.Text = "Storitve 3";
            this.groupRequestsButton2.UseVisualStyleBackColor = false;
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
            this.currentProjects2.Location = new System.Drawing.Point(338, 0);
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
            this.coWorkersButton.Location = new System.Drawing.Point(193, 0);
            this.coWorkersButton.Margin = new System.Windows.Forms.Padding(0);
            this.coWorkersButton.Name = "coWorkersButton";
            this.coWorkersButton.Size = new System.Drawing.Size(145, 60);
            this.coWorkersButton.TabIndex = 6;
            this.coWorkersButton.Text = "Storitve 1";
            this.coWorkersButton.UseVisualStyleBackColor = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(192, 0);
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
            this.labelFriends.Size = new System.Drawing.Size(192, 59);
            this.labelFriends.TabIndex = 8;
            this.labelFriends.Text = "STORITVE";
            // 
            // FavouritesLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.panelButtons);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FavouritesLayout";
            this.Size = new System.Drawing.Size(834, 533);
            ((System.ComponentModel.ISupportInitialize)(this.friendBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource friendBindingSource;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem AddToFavouritesButton;
        private DevExpress.XtraBars.BarButtonItem inviteToGroupsButton;
        private System.Windows.Forms.Panel panelButtons;
        private BottomBorderButton groupRequestsButton2;
        private BottomBorderButton currentProjects2;
        private BottomBorderButton coWorkersButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label labelFriends;
    }
}
