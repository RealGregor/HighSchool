namespace LeaveMeAlone
{
    partial class DeleteUserAccountConfirmation_
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.deleteAccountButton = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.deleteConfirmationLabel = new DevExpress.XtraEditors.LabelControl();
            this.cancelButton2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cancelButton);
            this.panelControl1.Controls.Add(this.deleteAccountButton);
            this.panelControl1.Controls.Add(this.txtConfirmPassword);
            this.panelControl1.Controls.Add(this.deleteConfirmationLabel);
            this.panelControl1.Controls.Add(this.cancelButton2);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(391, 83);
            this.panelControl1.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(311, 55);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton2_Click);
            // 
            // deleteAccountButton
            // 
            this.deleteAccountButton.Location = new System.Drawing.Point(131, 40);
            this.deleteAccountButton.Name = "deleteAccountButton";
            this.deleteAccountButton.Size = new System.Drawing.Size(85, 23);
            this.deleteAccountButton.TabIndex = 19;
            this.deleteAccountButton.Text = "Delete Account";
            this.deleteAccountButton.Click += new System.EventHandler(this.deleteAccountButton_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(16, 42);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.NullValuePrompt = "Confirm Password";
            this.txtConfirmPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmPassword.TabIndex = 18;
            // 
            // deleteConfirmationLabel
            // 
            this.deleteConfirmationLabel.Appearance.Font = new System.Drawing.Font("SansSerif", 12F);
            this.deleteConfirmationLabel.Appearance.Options.UseFont = true;
            this.deleteConfirmationLabel.Location = new System.Drawing.Point(16, 8);
            this.deleteConfirmationLabel.Name = "deleteConfirmationLabel";
            this.deleteConfirmationLabel.Size = new System.Drawing.Size(327, 19);
            this.deleteConfirmationLabel.TabIndex = 17;
            this.deleteConfirmationLabel.Text = "Are you sure you want to delete your account?";
            // 
            // cancelButton2
            // 
            this.cancelButton2.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton2.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_close_window_24;
            this.cancelButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cancelButton2.FlatAppearance.BorderSize = 0;
            this.cancelButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cancelButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cancelButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton2.Location = new System.Drawing.Point(366, 1);
            this.cancelButton2.Name = "cancelButton2";
            this.cancelButton2.Size = new System.Drawing.Size(22, 22);
            this.cancelButton2.TabIndex = 16;
            this.cancelButton2.UseVisualStyleBackColor = false;
            this.cancelButton2.Click += new System.EventHandler(this.cancelButton2_Click);
            this.cancelButton2.MouseEnter += new System.EventHandler(this.cancelButton2_MouseEnter);
            this.cancelButton2.MouseLeave += new System.EventHandler(this.cancelButton2_MouseLeave);
            // 
            // DeleteUserAccountConfirmation_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(398, 89);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteUserAccountConfirmation_";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeleteUserAccountConfirmation_";
            this.Deactivate += new System.EventHandler(this.DeleteUserAccountConfirmation__Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton deleteAccountButton;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.LabelControl deleteConfirmationLabel;
        private System.Windows.Forms.Button cancelButton2;
    }
}