namespace LeaveMeAlone
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.settingsButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.cartButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.autoPartsButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.servicesButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.informationButton = new LeaveMeAlone.TopAndBottomBorderButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profilePicture = new LeaveMeAlone.OvalPictureBox();
            this.nameAndSurnameText = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.settingsLayout = new LeaveMeAlone.SettingsLayout();
            this.cartLayout = new LeaveMeAlone.CartLayout();
            this.autoPartsLayout = new LeaveMeAlone.AutoParts();
            this.listUsers = new LeaveMeAlone.listUsers();
            this.servicesLayout = new LeaveMeAlone.FavouritesLayout();
            this.informationLayout = new LeaveMeAlone.InformationLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.settingsButton);
            this.panel2.Controls.Add(this.cartButton);
            this.panel2.Controls.Add(this.autoPartsButton);
            this.panel2.Controls.Add(this.servicesButton);
            this.panel2.Controls.Add(this.informationButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.panel2.Size = new System.Drawing.Size(165, 533);
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
            // cartButton
            // 
            this.cartButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.cartButton.FlatAppearance.BorderSize = 0;
            this.cartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cartButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.cartButton.Image = global::LeaveMeAlone.Properties.Resources.Groups;
            this.cartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cartButton.Location = new System.Drawing.Point(0, 261);
            this.cartButton.Name = "cartButton";
            this.cartButton.Size = new System.Drawing.Size(165, 67);
            this.cartButton.TabIndex = 10;
            this.cartButton.Text = "Košarica";
            this.cartButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cartButton.UseVisualStyleBackColor = true;
            this.cartButton.Click += new System.EventHandler(this.cartButton_Click);
            this.cartButton.MouseEnter += new System.EventHandler(this.cartButton_MouseEnter);
            this.cartButton.MouseLeave += new System.EventHandler(this.cartButton_MouseLeave);
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
            this.autoPartsButton.Location = new System.Drawing.Point(0, 194);
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
            // servicesButton
            // 
            this.servicesButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.servicesButton.FlatAppearance.BorderSize = 0;
            this.servicesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.servicesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.servicesButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.servicesButton.Image = global::LeaveMeAlone.Properties.Resources.Chat;
            this.servicesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.servicesButton.Location = new System.Drawing.Point(0, 127);
            this.servicesButton.Name = "servicesButton";
            this.servicesButton.Size = new System.Drawing.Size(165, 67);
            this.servicesButton.TabIndex = 8;
            this.servicesButton.Text = "Storitve";
            this.servicesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.servicesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.servicesButton.UseVisualStyleBackColor = true;
            this.servicesButton.Click += new System.EventHandler(this.servicesButton_Click);
            this.servicesButton.MouseEnter += new System.EventHandler(this.servicesButton_MouseEnter);
            this.servicesButton.MouseLeave += new System.EventHandler(this.servicesButton_MouseLeave);
            // 
            // informationButton
            // 
            this.informationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.informationButton.FlatAppearance.BorderSize = 0;
            this.informationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.informationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.informationButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.informationButton.Image = global::LeaveMeAlone.Properties.Resources.Admin;
            this.informationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.informationButton.Location = new System.Drawing.Point(0, 60);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(165, 67);
            this.informationButton.TabIndex = 7;
            this.informationButton.Text = "Informacije";
            this.informationButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.informationButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.informationButton.UseVisualStyleBackColor = true;
            this.informationButton.Click += new System.EventHandler(this.informationButton_Click);
            this.informationButton.MouseEnter += new System.EventHandler(this.informationButton_MouseEnter);
            this.informationButton.MouseLeave += new System.EventHandler(this.informationButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(129)))), ((int)(((byte)(206)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.profilePicture);
            this.panel1.Controls.Add(this.nameAndSurnameText);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 84);
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
            // nameAndSurnameText
            // 
            this.nameAndSurnameText.AutoSize = true;
            this.nameAndSurnameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameAndSurnameText.ForeColor = System.Drawing.Color.White;
            this.nameAndSurnameText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameAndSurnameText.Location = new System.Drawing.Point(65, 29);
            this.nameAndSurnameText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameAndSurnameText.Name = "nameAndSurnameText";
            this.nameAndSurnameText.Size = new System.Drawing.Size(119, 24);
            this.nameAndSurnameText.TabIndex = 28;
            this.nameAndSurnameText.Text = "Ime Priimek";
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
            this.logoutButton.Location = new System.Drawing.Point(871, 13);
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
            // settingsLayout
            // 
            this.settingsLayout.BackColor = System.Drawing.Color.White;
            this.settingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsLayout.Location = new System.Drawing.Point(165, 84);
            this.settingsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.settingsLayout.Name = "settingsLayout";
            this.settingsLayout.Size = new System.Drawing.Size(835, 533);
            this.settingsLayout.TabIndex = 8;
            this.settingsLayout.Visible = false;
            // 
            // cartLayout
            // 
            this.cartLayout.AutoSize = true;
            this.cartLayout.BackColor = System.Drawing.Color.White;
            this.cartLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartLayout.Location = new System.Drawing.Point(165, 84);
            this.cartLayout.Name = "cartLayout";
            this.cartLayout.Size = new System.Drawing.Size(835, 533);
            this.cartLayout.TabIndex = 7;
            this.cartLayout.Visible = false;
            // 
            // autoPartsLayout
            // 
            this.autoPartsLayout.AutoSize = true;
            this.autoPartsLayout.BackColor = System.Drawing.Color.White;
            this.autoPartsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoPartsLayout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(150)))), ((int)(((byte)(23)))));
            this.autoPartsLayout.Location = new System.Drawing.Point(165, 84);
            this.autoPartsLayout.Name = "autoPartsLayout";
            this.autoPartsLayout.Size = new System.Drawing.Size(835, 533);
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
            this.listUsers.Size = new System.Drawing.Size(835, 533);
            this.listUsers.TabIndex = 11;
            this.listUsers.Visible = false;
            // 
            // servicesLayout
            // 
            this.servicesLayout.AutoSize = true;
            this.servicesLayout.BackColor = System.Drawing.Color.White;
            this.servicesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.servicesLayout.Location = new System.Drawing.Point(165, 84);
            this.servicesLayout.Margin = new System.Windows.Forms.Padding(0);
            this.servicesLayout.Name = "servicesLayout";
            this.servicesLayout.Size = new System.Drawing.Size(835, 533);
            this.servicesLayout.TabIndex = 10;
            this.servicesLayout.Visible = false;
            // 
            // informationLayout
            // 
            this.informationLayout.BackColor = System.Drawing.Color.White;
            this.informationLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationLayout.Location = new System.Drawing.Point(165, 84);
            this.informationLayout.Name = "informationLayout";
            this.informationLayout.Size = new System.Drawing.Size(835, 533);
            this.informationLayout.TabIndex = 9;
            this.informationLayout.Visible = false;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 617);
            this.Controls.Add(this.settingsLayout);
            this.Controls.Add(this.cartLayout);
            this.Controls.Add(this.autoPartsLayout);
            this.Controls.Add(this.listUsers);
            this.Controls.Add(this.servicesLayout);
            this.Controls.Add(this.informationLayout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(996, 635);
            this.Name = "formMain";
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
        private TopAndBottomBorderButton cartButton;
        private TopAndBottomBorderButton autoPartsButton;
        private TopAndBottomBorderButton servicesButton;
        private TopAndBottomBorderButton informationButton;
        private System.Windows.Forms.Panel panel1;
        private OvalPictureBox profilePicture;
        private System.Windows.Forms.Label nameAndSurnameText;
        private System.Windows.Forms.Button logoutButton;
        private AutoParts autoPartsLayout;
        private CartLayout cartLayout;
        private SettingsLayout settingsLayout;
        private InformationLayout informationLayout;
        private FavouritesLayout servicesLayout;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private listUsers listUsers;
    }
}