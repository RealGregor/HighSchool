namespace LeaveMeAlone {
    partial class UserProfileViewFormAdmin {
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
            this.colGroupName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colAdminEmail = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colPrivacy = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colSelected = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colGroupID = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.closeInviteToGroup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.userPicture = new LeaveMeAlone.OvalPictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.emailAdressLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // colGroupName
            // 
            this.colGroupName.FieldName = "GroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 1;
            // 
            // colAdminEmail
            // 
            this.colAdminEmail.FieldName = "AdminEmail";
            this.colAdminEmail.Name = "colAdminEmail";
            this.colAdminEmail.Visible = true;
            this.colAdminEmail.VisibleIndex = 0;
            // 
            // colPrivacy
            // 
            this.colPrivacy.FieldName = "Privacy";
            this.colPrivacy.Name = "colPrivacy";
            this.colPrivacy.Visible = true;
            this.colPrivacy.VisibleIndex = 2;
            // 
            // colSelected
            // 
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            this.colSelected.Visible = true;
            this.colSelected.VisibleIndex = 3;
            // 
            // colGroupID
            // 
            this.colGroupID.FieldName = "GroupID";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.Visible = true;
            this.colGroupID.VisibleIndex = 4;
            // 
            // closeInviteToGroup
            // 
            this.closeInviteToGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeInviteToGroup.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_delete_48;
            this.closeInviteToGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeInviteToGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeInviteToGroup.FlatAppearance.BorderSize = 0;
            this.closeInviteToGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.closeInviteToGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeInviteToGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeInviteToGroup.Location = new System.Drawing.Point(931, 0);
            this.closeInviteToGroup.Margin = new System.Windows.Forms.Padding(0);
            this.closeInviteToGroup.Name = "closeInviteToGroup";
            this.closeInviteToGroup.Size = new System.Drawing.Size(31, 31);
            this.closeInviteToGroup.TabIndex = 17;
            this.closeInviteToGroup.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.txtPhoneNumber);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtSurname);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.userPicture);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.phoneNumberLabel);
            this.panel1.Controls.Add(this.emailAdressLabel);
            this.panel1.Controls.Add(this.surnameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 348);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseUp);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_close_window_24;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(560, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(22, 22);
            this.buttonClose.TabIndex = 25;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.White;
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(165, 197);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(154, 19);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEmail.Location = new System.Drawing.Point(153, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(210, 19);
            this.txtEmail.TabIndex = 2;
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.White;
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSurname.Location = new System.Drawing.Point(82, 130);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.ReadOnly = true;
            this.txtSurname.Size = new System.Drawing.Size(154, 19);
            this.txtSurname.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(62, 98);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(154, 19);
            this.txtName.TabIndex = 0;
            // 
            // userPicture
            // 
            this.userPicture.BackColor = System.Drawing.Color.Transparent;
            this.userPicture.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_account_80;
            this.userPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.userPicture.Location = new System.Drawing.Point(3, 3);
            this.userPicture.Name = "userPicture";
            this.userPicture.Size = new System.Drawing.Size(80, 80);
            this.userPicture.TabIndex = 195;
            this.userPicture.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameLabel.ForeColor = System.Drawing.Color.Black;
            this.nameLabel.Location = new System.Drawing.Point(12, 98);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(40, 20);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Ime:";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.phoneNumberLabel.ForeColor = System.Drawing.Color.Black;
            this.phoneNumberLabel.Location = new System.Drawing.Point(12, 197);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(147, 20);
            this.phoneNumberLabel.TabIndex = 20;
            this.phoneNumberLabel.Text = "Telefonska številka:";
            // 
            // emailAdressLabel
            // 
            this.emailAdressLabel.AutoSize = true;
            this.emailAdressLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailAdressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.emailAdressLabel.ForeColor = System.Drawing.Color.Black;
            this.emailAdressLabel.Location = new System.Drawing.Point(12, 162);
            this.emailAdressLabel.Name = "emailAdressLabel";
            this.emailAdressLabel.Size = new System.Drawing.Size(135, 20);
            this.emailAdressLabel.TabIndex = 17;
            this.emailAdressLabel.Text = "Elektonski naslov:";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.BackColor = System.Drawing.Color.Transparent;
            this.surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.surnameLabel.ForeColor = System.Drawing.Color.Black;
            this.surnameLabel.Location = new System.Drawing.Point(12, 130);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(64, 20);
            this.surnameLabel.TabIndex = 18;
            this.surnameLabel.Text = "Priimek:";
            // 
            // UserProfileViewFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(591, 354);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserProfileViewFormAdmin";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserProfileViewForm";
            this.Deactivate += new System.EventHandler(this.UserProfileViewForm_Deactivate);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.TileViewColumn colGroupName;
        private DevExpress.XtraGrid.Columns.TileViewColumn colAdminEmail;
        private DevExpress.XtraGrid.Columns.TileViewColumn colPrivacy;
        private DevExpress.XtraGrid.Columns.TileViewColumn colSelected;
        private DevExpress.XtraGrid.Columns.TileViewColumn colGroupID;
        private System.Windows.Forms.Button closeInviteToGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label emailAdressLabel;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private OvalPictureBox userPicture;
    }
}