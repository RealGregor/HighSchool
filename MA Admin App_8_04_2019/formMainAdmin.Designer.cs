using LeaveMeAlone._Groups;

namespace LeaveMeAlone
{
    partial class formMainAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMainAdmin));
            this.panel2 = new System.Windows.Forms.Panel();
            this.settingsButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.historyButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.autoPartsButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.ordersButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.employeesButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profilePicture = new LeaveMeAlone.OvalPictureBox();
            this.emailText = new System.Windows.Forms.Label();
            this.nameAndSurnameText = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.settingsLayout = new LeaveMeAlone.SettingsLayout();
            this.historyLayout = new LeaveMeAlone.GroupsLayout();
            this.autoPartsLayout = new LeaveMeAlone.AutoParts();
            this.listUsers = new LeaveMeAlone.listUsers();
            this.ordersLayout = new LeaveMeAlone.OrdersLayout();
            this.companyLayout = new LeaveMeAlone.CompanyLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.settingsButton);
            this.panel2.Controls.Add(this.historyButton);
            this.panel2.Controls.Add(this.ordersButton);
            this.panel2.Controls.Add(this.autoPartsButton);
            this.panel2.Controls.Add(this.employeesButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.panel2.Size = new System.Drawing.Size(165, 576);
            this.panel2.TabIndex = 4;
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.settingsButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.settingsButton.Image = global::LeaveMeAlone.Properties.Resources.Settings3;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(0, 328);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(165, 67);
            this.settingsButton.TabIndex = 11;
            this.settingsButton.Text = "Nastavitve";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            this.settingsButton.MouseEnter += new System.EventHandler(this.settingsButton_MouseEnter);
            this.settingsButton.MouseLeave += new System.EventHandler(this.settingsButton_MouseLeave);
            // 
            // historyButton
            // 
            this.historyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.historyButton.FlatAppearance.BorderSize = 0;
            this.historyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.historyButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.historyButton.Image = global::LeaveMeAlone.Properties.Resources.Groups;
            this.historyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.historyButton.Location = new System.Drawing.Point(0, 261);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(165, 67);
            this.historyButton.TabIndex = 10;
            this.historyButton.Text = "Zgodovina";
            this.historyButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.historyButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Visible = false;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            this.historyButton.MouseEnter += new System.EventHandler(this.historyButton_MouseEnter);
            this.historyButton.MouseLeave += new System.EventHandler(this.historyButton_MouseLeave);
            // 
            // autoPartsButton
            // 
            this.autoPartsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoPartsButton.FlatAppearance.BorderSize = 0;
            this.autoPartsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoPartsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.autoPartsButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.autoPartsButton.Image = global::LeaveMeAlone.Properties.Resources.Friends;
            this.autoPartsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.autoPartsButton.Location = new System.Drawing.Point(0, 127);
            this.autoPartsButton.Name = "autoPartsButton";
            this.autoPartsButton.Size = new System.Drawing.Size(165, 67);
            this.autoPartsButton.TabIndex = 9;
            this.autoPartsButton.Text = "Avto Deli";
            this.autoPartsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.autoPartsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.autoPartsButton.UseVisualStyleBackColor = true;
            this.autoPartsButton.Click += new System.EventHandler(this.autoPartsButton_Click);
            this.autoPartsButton.MouseEnter += new System.EventHandler(this.autoPartsButton_MouseEnter);
            this.autoPartsButton.MouseLeave += new System.EventHandler(this.autoPartsButton_MouseLeave);
            // 
            // ordersButton
            // 
            this.ordersButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordersButton.FlatAppearance.BorderSize = 0;
            this.ordersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ordersButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.ordersButton.Image = global::LeaveMeAlone.Properties.Resources.Chat;
            this.ordersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersButton.Location = new System.Drawing.Point(0, 194);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Size = new System.Drawing.Size(165, 67);
            this.ordersButton.TabIndex = 8;
            this.ordersButton.Text = "Naročila";
            this.ordersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ordersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ordersButton.UseVisualStyleBackColor = true;
            this.ordersButton.Click += new System.EventHandler(this.ordersButton_Click);
            this.ordersButton.MouseEnter += new System.EventHandler(this.ordersButton_MouseEnter);
            this.ordersButton.MouseLeave += new System.EventHandler(this.ordersButton_MouseLeave);
            // 
            // employeesButton
            // 
            this.employeesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.employeesButton.FlatAppearance.BorderSize = 0;
            this.employeesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employeesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.employeesButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.employeesButton.Image = global::LeaveMeAlone.Properties.Resources.Admin;
            this.employeesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesButton.Location = new System.Drawing.Point(0, 60);
            this.employeesButton.Name = "employeesButton";
            this.employeesButton.Size = new System.Drawing.Size(165, 67);
            this.employeesButton.TabIndex = 7;
            this.employeesButton.Text = "Zaposleni";
            this.employeesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.employeesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.employeesButton.UseVisualStyleBackColor = true;
            this.employeesButton.Click += new System.EventHandler(this.employeesButton_Click);
            this.employeesButton.MouseEnter += new System.EventHandler(this.employeesButton_MouseEnter);
            this.employeesButton.MouseLeave += new System.EventHandler(this.employeesButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(129)))), ((int)(((byte)(206)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.profilePicture);
            this.panel1.Controls.Add(this.emailText);
            this.panel1.Controls.Add(this.nameAndSurnameText);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 84);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // profilePicture
            // 
            this.profilePicture.BackColor = System.Drawing.Color.Transparent;
            this.profilePicture.BackgroundImage = global::LeaveMeAlone.Properties.Resources.icons8_account_80;
            this.profilePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profilePicture.Location = new System.Drawing.Point(4, 10);
            this.profilePicture.Margin = new System.Windows.Forms.Padding(0);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(60, 60);
            this.profilePicture.TabIndex = 193;
            this.profilePicture.TabStop = false;
            this.profilePicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseDown);
            this.profilePicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseMove);
            this.profilePicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // emailText
            // 
            this.emailText.AutoSize = true;
            this.emailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.emailText.ForeColor = System.Drawing.Color.White;
            this.emailText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.emailText.Location = new System.Drawing.Point(65, 43);
            this.emailText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(100, 20);
            this.emailText.TabIndex = 29;
            this.emailText.Text = "Email adress";
            this.emailText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseDown);
            this.emailText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseMove);
            this.emailText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // nameAndSurnameText
            // 
            this.nameAndSurnameText.AutoSize = true;
            this.nameAndSurnameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameAndSurnameText.ForeColor = System.Drawing.Color.White;
            this.nameAndSurnameText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameAndSurnameText.Location = new System.Drawing.Point(65, 15);
            this.nameAndSurnameText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameAndSurnameText.Name = "nameAndSurnameText";
            this.nameAndSurnameText.Size = new System.Drawing.Size(155, 24);
            this.nameAndSurnameText.TabIndex = 28;
            this.nameAndSurnameText.Text = "Name Surname";
            this.nameAndSurnameText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseDown);
            this.nameAndSurnameText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseMove);
            this.nameAndSurnameText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formMain_MouseUp);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.AutoSize = true;
            this.logoutButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.logoutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoutButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.logoutButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.logoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logoutButton.Image = global::LeaveMeAlone.Properties.Resources.icons8_exit_26;
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.logoutButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoutButton.Location = new System.Drawing.Point(1084, 13);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(123, 56);
            this.logoutButton.TabIndex = 26;
            this.logoutButton.Text = "Logout";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.UseVisualStyleBackColor = false;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // settingsLayout
            // 
            this.settingsLayout.BackColor = System.Drawing.Color.White;
            this.settingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsLayout.Location = new System.Drawing.Point(165, 84);
            this.settingsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.settingsLayout.Name = "settingsLayout";
            this.settingsLayout.Size = new System.Drawing.Size(1048, 576);
            this.settingsLayout.TabIndex = 8;
            this.settingsLayout.Visible = false;
            // 
            // historyLayout
            // 
            this.historyLayout.AutoSize = true;
            this.historyLayout.BackColor = System.Drawing.Color.White;
            this.historyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyLayout.Location = new System.Drawing.Point(165, 84);
            this.historyLayout.Name = "historyLayout";
            this.historyLayout.Size = new System.Drawing.Size(1048, 576);
            this.historyLayout.TabIndex = 7;
            this.historyLayout.Visible = false;
            // 
            // autoPartsLayout
            // 
            this.autoPartsLayout.AutoSize = true;
            this.autoPartsLayout.BackColor = System.Drawing.Color.White;
            this.autoPartsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoPartsLayout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(150)))), ((int)(((byte)(23)))));
            this.autoPartsLayout.Location = new System.Drawing.Point(165, 84);
            this.autoPartsLayout.Name = "autoPartsLayout";
            this.autoPartsLayout.Size = new System.Drawing.Size(1048, 576);
            this.autoPartsLayout.TabIndex = 6;
            this.autoPartsLayout.Visible = false;
            // 
            // listUsers
            // 
            this.listUsers.AutoSize = true;
            this.listUsers.BackColor = System.Drawing.Color.White;
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.Location = new System.Drawing.Point(165, 84);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(1048, 576);
            this.listUsers.TabIndex = 11;
            this.listUsers.Visible = false;
            // 
            // ordersLayout
            // 
            this.ordersLayout.AutoSize = true;
            this.ordersLayout.BackColor = System.Drawing.Color.White;
            this.ordersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersLayout.Location = new System.Drawing.Point(165, 84);
            this.ordersLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ordersLayout.Name = "ordersLayout";
            this.ordersLayout.Size = new System.Drawing.Size(1048, 576);
            this.ordersLayout.TabIndex = 10;
            this.ordersLayout.Visible = false;
            // 
            // companyLayout
            // 
            this.companyLayout.BackColor = System.Drawing.Color.White;
            this.companyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyLayout.Location = new System.Drawing.Point(165, 84);
            this.companyLayout.Name = "companyLayout";
            this.companyLayout.Size = new System.Drawing.Size(1048, 576);
            this.companyLayout.TabIndex = 9;
            this.companyLayout.Visible = false;
            // 
            // formMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 660);
            this.Controls.Add(this.settingsLayout);
            this.Controls.Add(this.historyLayout);
            this.Controls.Add(this.autoPartsLayout);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.ordersLayout);
            this.Controls.Add(this.companyLayout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(996, 635);
            this.Name = "formMainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private TopAndBottomBorderButton settingsButton;
        private TopAndBottomBorderButton historyButton;
        private TopAndBottomBorderButton autoPartsButton;
        private TopAndBottomBorderButton ordersButton;
        private TopAndBottomBorderButton employeesButton;
        private System.Windows.Forms.Panel panel1;
        private OvalPictureBox profilePicture;
        private System.Windows.Forms.Label emailText;
        private System.Windows.Forms.Label nameAndSurnameText;
        private System.Windows.Forms.Button logoutButton;
        private AutoParts autoPartsLayout;
        private GroupsLayout historyLayout;
        private SettingsLayout settingsLayout;
        private CompanyLayout companyLayout;
        private OrdersLayout ordersLayout;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private listUsers listUsers;
    }
}