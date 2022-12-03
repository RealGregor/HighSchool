namespace LeaveMeAlone {
    partial class EmployeeProfileViewFormAdmin {
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
            this.label1 = new System.Windows.Forms.Label();
            this.changeEmployeeInformationButton = new System.Windows.Forms.Button();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.deleteEmployeeInformationButton = new System.Windows.Forms.Button();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.emailAdressLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.deleteEmployeeButton = new LeaveMeAlone.BottomBorderButton();
            this.changeInformationButton = new LeaveMeAlone.BottomBorderButton();
            this.changeEmployeePicture = new LeaveMeAlone.OvalPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeEmployeePicture)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.changeEmployeeInformationButton);
            this.panel1.Controls.Add(this.txtAdminPassword);
            this.panel1.Controls.Add(this.deleteEmployeeInformationButton);
            this.panel1.Controls.Add(this.txtPhoneNumber);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtSurname);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.changeEmployeePicture);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(377, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 201;
            this.label1.Text = "Geslo:";
            // 
            // changeEmployeeInformationButton
            // 
            this.changeEmployeeInformationButton.AutoSize = true;
            this.changeEmployeeInformationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.changeEmployeeInformationButton.Location = new System.Drawing.Point(432, 302);
            this.changeEmployeeInformationButton.Name = "changeEmployeeInformationButton";
            this.changeEmployeeInformationButton.Size = new System.Drawing.Size(139, 29);
            this.changeEmployeeInformationButton.TabIndex = 198;
            this.changeEmployeeInformationButton.Text = "Spremeni podatke";
            this.changeEmployeeInformationButton.UseVisualStyleBackColor = true;
            this.changeEmployeeInformationButton.Click += new System.EventHandler(this.changeEmployeeInformationButton_Click);
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAdminPassword.Location = new System.Drawing.Point(432, 275);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.PasswordChar = '*';
            this.txtAdminPassword.Size = new System.Drawing.Size(139, 23);
            this.txtAdminPassword.TabIndex = 200;
            // 
            // deleteEmployeeInformationButton
            // 
            this.deleteEmployeeInformationButton.AutoSize = true;
            this.deleteEmployeeInformationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.deleteEmployeeInformationButton.Location = new System.Drawing.Point(432, 304);
            this.deleteEmployeeInformationButton.Name = "deleteEmployeeInformationButton";
            this.deleteEmployeeInformationButton.Size = new System.Drawing.Size(139, 27);
            this.deleteEmployeeInformationButton.TabIndex = 199;
            this.deleteEmployeeInformationButton.Text = "Izbriši zaposlenega";
            this.deleteEmployeeInformationButton.UseVisualStyleBackColor = true;
            this.deleteEmployeeInformationButton.Visible = false;
            this.deleteEmployeeInformationButton.Click += new System.EventHandler(this.deleteEmployeeInformationButton_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BackColor = System.Drawing.Color.White;
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(165, 292);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(154, 19);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEmail.Location = new System.Drawing.Point(153, 242);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(210, 19);
            this.txtEmail.TabIndex = 2;
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.White;
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSurname.Location = new System.Drawing.Point(82, 192);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(154, 19);
            this.txtSurname.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(62, 142);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 19);
            this.txtName.TabIndex = 0;
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
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameLabel.ForeColor = System.Drawing.Color.Black;
            this.nameLabel.Location = new System.Drawing.Point(12, 142);
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
            this.phoneNumberLabel.Location = new System.Drawing.Point(12, 292);
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
            this.emailAdressLabel.Location = new System.Drawing.Point(12, 242);
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
            this.surnameLabel.Location = new System.Drawing.Point(12, 192);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(64, 20);
            this.surnameLabel.TabIndex = 18;
            this.surnameLabel.Text = "Priimek:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // deleteEmployeeButton
            // 
            this.deleteEmployeeButton.AutoSize = true;
            this.deleteEmployeeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteEmployeeButton.FlatAppearance.BorderSize = 0;
            this.deleteEmployeeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.deleteEmployeeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.deleteEmployeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteEmployeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.deleteEmployeeButton.ForeColor = System.Drawing.Color.Black;
            this.deleteEmployeeButton.Location = new System.Drawing.Point(140, 0);
            this.deleteEmployeeButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteEmployeeButton.Name = "deleteEmployeeButton";
            this.deleteEmployeeButton.Size = new System.Drawing.Size(140, 31);
            this.deleteEmployeeButton.TabIndex = 197;
            this.deleteEmployeeButton.Text = "IZRIŠI ZAPOSLENEGA";
            this.deleteEmployeeButton.UseVisualStyleBackColor = true;
            this.deleteEmployeeButton.Click += new System.EventHandler(this.deleteEmployeeButton_Click);
            this.deleteEmployeeButton.MouseEnter += new System.EventHandler(this.deleteEmployeeButton_MouseEnter);
            this.deleteEmployeeButton.MouseLeave += new System.EventHandler(this.deleteEmployeeButton_MouseLeave);
            // 
            // changeInformationButton
            // 
            this.changeInformationButton.AutoSize = true;
            this.changeInformationButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeInformationButton.FlatAppearance.BorderSize = 0;
            this.changeInformationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.changeInformationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.changeInformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeInformationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeInformationButton.ForeColor = System.Drawing.Color.Black;
            this.changeInformationButton.Location = new System.Drawing.Point(0, 0);
            this.changeInformationButton.Margin = new System.Windows.Forms.Padding(0);
            this.changeInformationButton.Name = "changeInformationButton";
            this.changeInformationButton.Size = new System.Drawing.Size(140, 31);
            this.changeInformationButton.TabIndex = 196;
            this.changeInformationButton.Text = "SPREMENI PODATKE";
            this.changeInformationButton.UseVisualStyleBackColor = true;
            this.changeInformationButton.Click += new System.EventHandler(this.changeInformationButton_Click);
            this.changeInformationButton.Paint += new System.Windows.Forms.PaintEventHandler(this.changeInformationButton_Paint);
            this.changeInformationButton.MouseEnter += new System.EventHandler(this.changeInformationButton_MouseEnter);
            this.changeInformationButton.MouseLeave += new System.EventHandler(this.changeInformationButton_MouseLeave);
            // 
            // changeEmployeePicture
            // 
            this.changeEmployeePicture.BackColor = System.Drawing.Color.Transparent;
            this.changeEmployeePicture.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_account_80;
            this.changeEmployeePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeEmployeePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeEmployeePicture.Location = new System.Drawing.Point(3, 47);
            this.changeEmployeePicture.Name = "changeEmployeePicture";
            this.changeEmployeePicture.Size = new System.Drawing.Size(80, 80);
            this.changeEmployeePicture.TabIndex = 195;
            this.changeEmployeePicture.TabStop = false;
            this.changeEmployeePicture.Click += new System.EventHandler(this.changeProfilePicture_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.deleteEmployeeButton);
            this.panel2.Controls.Add(this.changeInformationButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 31);
            this.panel2.TabIndex = 202;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseUp);
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
            ((System.ComponentModel.ISupportInitialize)(this.changeEmployeePicture)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private OvalPictureBox changeEmployeePicture;
        private BottomBorderButton deleteEmployeeButton;
        private BottomBorderButton changeInformationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button changeEmployeeInformationButton;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Button deleteEmployeeInformationButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
    }
}