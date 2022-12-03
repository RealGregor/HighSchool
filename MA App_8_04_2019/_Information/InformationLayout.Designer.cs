namespace LeaveMeAlone {
    partial class InformationLayout {
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
            this.friendRequestsButton = new LeaveMeAlone.BottomBorderButton();
            this.employeesButton = new LeaveMeAlone.BottomBorderButton();
            this.aboutUsButton = new LeaveMeAlone.BottomBorderButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.labelFriends = new System.Windows.Forms.Label();
            this.aboutUs = new LeaveMeAlone.AboutUs();
            this.employees = new LeaveMeAlone.Employees();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtons.Controls.Add(this.friendRequestsButton);
            this.panelButtons.Controls.Add(this.employeesButton);
            this.panelButtons.Controls.Add(this.aboutUsButton);
            this.panelButtons.Controls.Add(this.splitter1);
            this.panelButtons.Controls.Add(this.labelFriends);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(835, 60);
            this.panelButtons.TabIndex = 28;
            // 
            // friendRequestsButton
            // 
            this.friendRequestsButton.AutoSize = true;
            this.friendRequestsButton.BackColor = System.Drawing.Color.Transparent;
            this.friendRequestsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.friendRequestsButton.FlatAppearance.BorderSize = 0;
            this.friendRequestsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.friendRequestsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.friendRequestsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.friendRequestsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.friendRequestsButton.ForeColor = System.Drawing.Color.Gray;
            this.friendRequestsButton.Location = new System.Drawing.Point(558, 0);
            this.friendRequestsButton.Margin = new System.Windows.Forms.Padding(0);
            this.friendRequestsButton.Name = "friendRequestsButton";
            this.friendRequestsButton.Size = new System.Drawing.Size(199, 60);
            this.friendRequestsButton.TabIndex = 12;
            this.friendRequestsButton.Text = "Friend Requests";
            this.friendRequestsButton.UseVisualStyleBackColor = false;
            this.friendRequestsButton.Click += new System.EventHandler(this.friendRequestButton_Click);
            this.friendRequestsButton.MouseEnter += new System.EventHandler(this.friendRequestButton_MouseEnter);
            this.friendRequestsButton.MouseLeave += new System.EventHandler(this.friendRequestButton_MouseLeave);
            // 
            // employeesButton
            // 
            this.employeesButton.AutoSize = true;
            this.employeesButton.BackColor = System.Drawing.Color.Transparent;
            this.employeesButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.employeesButton.FlatAppearance.BorderSize = 0;
            this.employeesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.employeesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.employeesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeesButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.employeesButton.ForeColor = System.Drawing.Color.Gray;
            this.employeesButton.Location = new System.Drawing.Point(407, 0);
            this.employeesButton.Margin = new System.Windows.Forms.Padding(0);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(151, 60);
            this.employeesButton.TabIndex = 11;
            this.employeesButton.Text = "Zaposleni";
            this.employeesButton.UseVisualStyleBackColor = false;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            this.employeesButton.MouseEnter += new System.EventHandler(this.employeesButton_MouseEnter);
            this.employeesButton.MouseLeave += new System.EventHandler(this.employeesButton_MouseLeave);
            // 
            // aboutUsButton
            // 
            this.aboutUsButton.AutoSize = true;
            this.aboutUsButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutUsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.aboutUsButton.FlatAppearance.BorderSize = 0;
            this.aboutUsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.aboutUsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.aboutUsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutUsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aboutUsButton.ForeColor = System.Drawing.Color.Gray;
            this.aboutUsButton.Location = new System.Drawing.Point(256, 0);
            this.aboutUsButton.Margin = new System.Windows.Forms.Padding(0);
            this.aboutUsButton.Name = "aboutUsButton";
            this.aboutUsButton.Size = new System.Drawing.Size(151, 60);
            this.aboutUsButton.TabIndex = 10;
            this.aboutUsButton.Text = "O podjetju";
            this.aboutUsButton.UseVisualStyleBackColor = false;
            this.aboutUsButton.Click += new System.EventHandler(this.aboutUsButton_Click);
            this.aboutUsButton.MouseEnter += new System.EventHandler(this.aboutUsButton_MouseEnter);
            this.aboutUsButton.MouseLeave += new System.EventHandler(this.aboutUsButton_MouseLeave);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(255, 0);
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
            this.labelFriends.Size = new System.Drawing.Size(255, 59);
            this.labelFriends.TabIndex = 8;
            this.labelFriends.Text = "INFORMACIJE";
            // 
            // aboutUs
            // 
            this.aboutUs.BackColor = System.Drawing.Color.White;
            this.aboutUs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutUs.Location = new System.Drawing.Point(0, 60);
            this.aboutUs.Name = "aboutUs";
            this.aboutUs.Size = new System.Drawing.Size(835, 473);
            this.aboutUs.TabIndex = 29;
            // 
            // employees
            // 
            this.employees.BackColor = System.Drawing.Color.White;
            this.employees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employees.Location = new System.Drawing.Point(0, 60);
            this.employees.Name = "employees";
            this.employees.Size = new System.Drawing.Size(835, 473);
            this.employees.TabIndex = 30;
            this.employees.Visible = false;
            // 
            // InformationLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.aboutUs);
            this.Controls.Add(this.employees);
            this.Controls.Add(this.panelButtons);
            this.Name = "InformationLayout";
            this.Size = new System.Drawing.Size(835, 533);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label labelFriends;
        private BottomBorderButton friendRequestsButton;
        private BottomBorderButton employeesButton;
        private BottomBorderButton aboutUsButton;
        private AboutUs aboutUs;
        private Employees employees;
    }
}
