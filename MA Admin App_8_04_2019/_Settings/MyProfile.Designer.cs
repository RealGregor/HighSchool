namespace LeaveMeAlone
{
    partial class MyProfile
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
            this.labelEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelPhoneNumber = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.labelName = new DevExpress.XtraEditors.LabelControl();
            this.labelSurname = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelChangeName = new DevExpress.XtraEditors.LabelControl();
            this.labelChangeProfilePicture = new DevExpress.XtraEditors.LabelControl();
            this.labelChangeSurname = new DevExpress.XtraEditors.LabelControl();
            this.labelChangePassword = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.deleteMyAccountButton = new DevExpress.XtraEditors.SimpleButton();
            this.changePasswordButton = new DevExpress.XtraEditors.SimpleButton();
            this.changeInformationButton = new DevExpress.XtraEditors.SimpleButton();
            this.changePhoneNumberLabel = new DevExpress.XtraEditors.LabelControl();
            this.txtPhoneNumber = new DevExpress.XtraEditors.TextEdit();
            this.invalidPasswordLabel = new DevExpress.XtraEditors.LabelControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.changeProfilePicture = new LeaveMeAlone.OvalPictureBox();
            this.profilePicture = new LeaveMeAlone.OvalPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelEmail.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEmail.Appearance.Options.UseFont = true;
            this.labelEmail.Location = new System.Drawing.Point(29, 277);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(146, 27);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "E-mail adress:";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtName.Location = new System.Drawing.Point(839, 196);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtName.Properties.Appearance.Options.UseForeColor = true;
            this.txtName.Properties.NullValuePrompt = "Name";
            this.txtName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtName.Size = new System.Drawing.Size(245, 22);
            this.txtName.TabIndex = 2;
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPhoneNumber.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPhoneNumber.Appearance.Options.UseFont = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(29, 347);
            this.labelPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(155, 27);
            this.labelPhoneNumber.TabIndex = 4;
            this.labelPhoneNumber.Text = "Phone number:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPassword.Location = new System.Drawing.Point(839, 388);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Properties.Appearance.Options.UseForeColor = true;
            this.txtPassword.Properties.NullValuePrompt = "Enter New Password";
            this.txtPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPassword.Size = new System.Drawing.Size(245, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtConfirmPassword.Location = new System.Drawing.Point(839, 431);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtConfirmPassword.Properties.Appearance.Options.UseForeColor = true;
            this.txtConfirmPassword.Properties.NullValuePrompt = "Confirm Current Password";
            this.txtConfirmPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(245, 22);
            this.txtConfirmPassword.TabIndex = 6;
            // 
            // txtSurname
            // 
            this.txtSurname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSurname.Location = new System.Drawing.Point(839, 240);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtSurname.Properties.Appearance.Options.UseForeColor = true;
            this.txtSurname.Properties.NullValuePrompt = "Surname";
            this.txtSurname.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSurname.Size = new System.Drawing.Size(245, 22);
            this.txtSurname.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Appearance.Options.UseFont = true;
            this.labelName.Location = new System.Drawing.Point(29, 214);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(63, 27);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Name";
            // 
            // labelSurname
            // 
            this.labelSurname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSurname.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSurname.Appearance.Options.UseFont = true;
            this.labelSurname.AutoEllipsis = true;
            this.labelSurname.Location = new System.Drawing.Point(120, 214);
            this.labelSurname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(89, 27);
            this.labelSurname.TabIndex = 11;
            this.labelSurname.Text = "Surname";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Garamond", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(625, 22);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(439, 43);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "MODIFY YOUR INFORMATION";
            // 
            // labelChangeName
            // 
            this.labelChangeName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelChangeName.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelChangeName.Appearance.Options.UseFont = true;
            this.labelChangeName.Location = new System.Drawing.Point(625, 193);
            this.labelChangeName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelChangeName.Name = "labelChangeName";
            this.labelChangeName.Size = new System.Drawing.Size(140, 27);
            this.labelChangeName.TabIndex = 13;
            this.labelChangeName.Text = "Change name";
            // 
            // labelChangeProfilePicture
            // 
            this.labelChangeProfilePicture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelChangeProfilePicture.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelChangeProfilePicture.Appearance.Options.UseFont = true;
            this.labelChangeProfilePicture.Location = new System.Drawing.Point(625, 121);
            this.labelChangeProfilePicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelChangeProfilePicture.Name = "labelChangeProfilePicture";
            this.labelChangeProfilePicture.Size = new System.Drawing.Size(226, 27);
            this.labelChangeProfilePicture.TabIndex = 14;
            this.labelChangeProfilePicture.Text = "Change profile picture";
            // 
            // labelChangeSurname
            // 
            this.labelChangeSurname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelChangeSurname.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelChangeSurname.Appearance.Options.UseFont = true;
            this.labelChangeSurname.Location = new System.Drawing.Point(625, 239);
            this.labelChangeSurname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelChangeSurname.Name = "labelChangeSurname";
            this.labelChangeSurname.Size = new System.Drawing.Size(171, 27);
            this.labelChangeSurname.TabIndex = 16;
            this.labelChangeSurname.Text = "Change surname";
            // 
            // labelChangePassword
            // 
            this.labelChangePassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelChangePassword.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelChangePassword.Appearance.Options.UseFont = true;
            this.labelChangePassword.Location = new System.Drawing.Point(617, 386);
            this.labelChangePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelChangePassword.Name = "labelChangePassword";
            this.labelChangePassword.Size = new System.Drawing.Size(180, 27);
            this.labelChangePassword.TabIndex = 17;
            this.labelChangePassword.Text = "Change password";
            // 
            // deleteMyAccountButton
            // 
            this.deleteMyAccountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteMyAccountButton.Location = new System.Drawing.Point(29, 470);
            this.deleteMyAccountButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteMyAccountButton.Name = "deleteMyAccountButton";
            this.deleteMyAccountButton.Size = new System.Drawing.Size(161, 44);
            this.deleteMyAccountButton.TabIndex = 8;
            this.deleteMyAccountButton.Text = "Delete My Account";
            this.deleteMyAccountButton.Click += new System.EventHandler(this.deleteMyAccountButton_Click);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changePasswordButton.Location = new System.Drawing.Point(923, 470);
            this.changePasswordButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(161, 44);
            this.changePasswordButton.TabIndex = 7;
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // changeInformationButton
            // 
            this.changeInformationButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.changeInformationButton.Location = new System.Drawing.Point(916, 325);
            this.changeInformationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changeInformationButton.Name = "changeInformationButton";
            this.changeInformationButton.Size = new System.Drawing.Size(161, 44);
            this.changeInformationButton.TabIndex = 4;
            this.changeInformationButton.Text = "Change Information";
            this.changeInformationButton.Click += new System.EventHandler(this.changeInformationButton_Click);
            // 
            // changePhoneNumberLabel
            // 
            this.changePhoneNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.changePhoneNumberLabel.Appearance.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changePhoneNumberLabel.Appearance.Options.UseFont = true;
            this.changePhoneNumberLabel.Location = new System.Drawing.Point(625, 284);
            this.changePhoneNumberLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changePhoneNumberLabel.Name = "changePhoneNumberLabel";
            this.changePhoneNumberLabel.Size = new System.Drawing.Size(157, 27);
            this.changePhoneNumberLabel.TabIndex = 21;
            this.changePhoneNumberLabel.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPhoneNumber.Location = new System.Drawing.Point(839, 284);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtPhoneNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtPhoneNumber.Properties.NullValuePrompt = "Surname";
            this.txtPhoneNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(245, 22);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // invalidPasswordLabel
            // 
            this.invalidPasswordLabel.Appearance.ForeColor = System.Drawing.Color.Red;
            this.invalidPasswordLabel.Appearance.Options.UseForeColor = true;
            this.invalidPasswordLabel.Location = new System.Drawing.Point(843, 412);
            this.invalidPasswordLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.invalidPasswordLabel.Name = "invalidPasswordLabel";
            this.invalidPasswordLabel.Size = new System.Drawing.Size(0, 16);
            this.invalidPasswordLabel.TabIndex = 22;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Garamond", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(29, 22);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(315, 43);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "YOUR INFORMATION";
            // 
            // changeProfilePicture
            // 
            this.changeProfilePicture.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.changeProfilePicture.BackColor = System.Drawing.Color.Transparent;
            this.changeProfilePicture.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_account_80;
            this.changeProfilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeProfilePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeProfilePicture.Location = new System.Drawing.Point(912, 69);
            this.changeProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.changeProfilePicture.Name = "changeProfilePicture";
            this.changeProfilePicture.Size = new System.Drawing.Size(107, 98);
            this.changeProfilePicture.TabIndex = 195;
            this.changeProfilePicture.TabStop = false;
            this.changeProfilePicture.Click += new System.EventHandler(this.changeProfilePicture_Click);
            // 
            // profilePicture
            // 
            this.profilePicture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.profilePicture.BackColor = System.Drawing.Color.Transparent;
            this.profilePicture.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_account_80;
            this.profilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profilePicture.Location = new System.Drawing.Point(33, 84);
            this.profilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(107, 98);
            this.profilePicture.TabIndex = 194;
            this.profilePicture.TabStop = false;
            // 
            // MyProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.changeProfilePicture);
            this.Controls.Add(this.profilePicture);
            this.Controls.Add(this.invalidPasswordLabel);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.changePhoneNumberLabel);
            this.Controls.Add(this.changeInformationButton);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.deleteMyAccountButton);
            this.Controls.Add(this.labelChangePassword);
            this.Controls.Add(this.labelChangeSurname);
            this.Controls.Add(this.labelChangeProfilePicture);
            this.Controls.Add(this.labelChangeName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelPhoneNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MyProfile";
            this.Size = new System.Drawing.Size(1108, 539);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelEmail;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelPhoneNumber;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private DevExpress.XtraEditors.LabelControl labelName;
        private DevExpress.XtraEditors.LabelControl labelSurname;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelChangeName;
        private DevExpress.XtraEditors.LabelControl labelChangeProfilePicture;
        private DevExpress.XtraEditors.LabelControl labelChangeSurname;
        private DevExpress.XtraEditors.LabelControl labelChangePassword;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton deleteMyAccountButton;
        private DevExpress.XtraEditors.SimpleButton changePasswordButton;
        private DevExpress.XtraEditors.SimpleButton changeInformationButton;
        private DevExpress.XtraEditors.LabelControl changePhoneNumberLabel;
        private DevExpress.XtraEditors.TextEdit txtPhoneNumber;
        private DevExpress.XtraEditors.LabelControl invalidPasswordLabel;
        private OvalPictureBox profilePicture;
        private OvalPictureBox changeProfilePicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
