namespace LeaveMeAlone {
    partial class LightViewForm {
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
            this.labelCurrentAmount = new System.Windows.Forms.Label();
            this.btnRemoveAmountFromCart = new System.Windows.Forms.Button();
            this.btnRemoveAllFromCart = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeliveryDeadline = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtGrip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProducer = new System.Windows.Forms.TextBox();
            this.txtFuel = new System.Windows.Forms.TextBox();
            this.txtWeightIndex = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.labelFuelEfficiency = new System.Windows.Forms.Label();
            this.labelWeightIndex = new System.Windows.Forms.Label();
            this.labelSpeedClass = new System.Windows.Forms.Label();
            this.autoPartPicture = new System.Windows.Forms.PictureBox();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoPartPicture)).BeginInit();
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
            this.panel1.Controls.Add(this.labelCurrentAmount);
            this.panel1.Controls.Add(this.btnRemoveAmountFromCart);
            this.panel1.Controls.Add(this.btnRemoveAllFromCart);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.labelAmount);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDeliveryDeadline);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtGrip);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtProducer);
            this.panel1.Controls.Add(this.txtFuel);
            this.panel1.Controls.Add(this.txtWeightIndex);
            this.panel1.Controls.Add(this.txtSpeed);
            this.panel1.Controls.Add(this.labelFuelEfficiency);
            this.panel1.Controls.Add(this.labelWeightIndex);
            this.panel1.Controls.Add(this.labelSpeedClass);
            this.panel1.Controls.Add(this.autoPartPicture);
            this.panel1.Controls.Add(this.btnAddToCart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 413);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.formLogin_MouseUp);
            // 
            // labelCurrentAmount
            // 
            this.labelCurrentAmount.AutoSize = true;
            this.labelCurrentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCurrentAmount.ForeColor = System.Drawing.Color.Black;
            this.labelCurrentAmount.Location = new System.Drawing.Point(119, 27);
            this.labelCurrentAmount.Name = "labelCurrentAmount";
            this.labelCurrentAmount.Size = new System.Drawing.Size(517, 29);
            this.labelCurrentAmount.TabIndex = 255;
            this.labelCurrentAmount.Text = "V košarici imate trenutno NUM takšnih izdelkov.";
            this.labelCurrentAmount.Visible = false;
            // 
            // btnRemoveAmountFromCart
            // 
            this.btnRemoveAmountFromCart.AutoSize = true;
            this.btnRemoveAmountFromCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemoveAmountFromCart.Location = new System.Drawing.Point(429, 349);
            this.btnRemoveAmountFromCart.Name = "btnRemoveAmountFromCart";
            this.btnRemoveAmountFromCart.Size = new System.Drawing.Size(169, 27);
            this.btnRemoveAmountFromCart.TabIndex = 254;
            this.btnRemoveAmountFromCart.Text = "Odstrani iz košarice";
            this.btnRemoveAmountFromCart.UseVisualStyleBackColor = true;
            this.btnRemoveAmountFromCart.Visible = false;
            this.btnRemoveAmountFromCart.Click += new System.EventHandler(this.btnRemoveAmountFromCart_Click);
            // 
            // btnRemoveAllFromCart
            // 
            this.btnRemoveAllFromCart.AutoSize = true;
            this.btnRemoveAllFromCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnRemoveAllFromCart.Location = new System.Drawing.Point(429, 380);
            this.btnRemoveAllFromCart.Name = "btnRemoveAllFromCart";
            this.btnRemoveAllFromCart.Size = new System.Drawing.Size(169, 27);
            this.btnRemoveAllFromCart.TabIndex = 253;
            this.btnRemoveAllFromCart.Text = "Odstrani vse iz košarice";
            this.btnRemoveAllFromCart.UseVisualStyleBackColor = true;
            this.btnRemoveAllFromCart.Visible = false;
            this.btnRemoveAllFromCart.Click += new System.EventHandler(this.btnRemoveAllFromCart_Click);
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
            this.buttonClose.Location = new System.Drawing.Point(710, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(22, 22);
            this.buttonClose.TabIndex = 25;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAmount.ForeColor = System.Drawing.Color.Black;
            this.labelAmount.Location = new System.Drawing.Point(604, 354);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(67, 20);
            this.labelAmount.TabIndex = 236;
            this.labelAmount.Text = "Količina:";
            // 
            // txtAmount
            // 
            this.txtAmount.AccessibleName = "";
            this.txtAmount.Location = new System.Drawing.Point(677, 354);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(54, 20);
            this.txtAmount.TabIndex = 235;
            // 
            // txtName
            // 
            this.txtName.AccessibleName = "";
            this.txtName.Location = new System.Drawing.Point(100, 97);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(195, 20);
            this.txtName.TabIndex = 207;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(3, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 234;
            this.label9.Text = "Ime izdelka:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(321, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 233;
            this.label8.Text = "Opis izdelka:";
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "Opis izdelka";
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(323, 193);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(404, 143);
            this.txtDescription.TabIndex = 220;
            this.txtDescription.Text = "";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(321, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 232;
            this.label7.Text = "Rok dostave:";
            // 
            // txtDeliveryDeadline
            // 
            this.txtDeliveryDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryDeadline.Location = new System.Drawing.Point(423, 93);
            this.txtDeliveryDeadline.Name = "txtDeliveryDeadline";
            this.txtDeliveryDeadline.ReadOnly = true;
            this.txtDeliveryDeadline.Size = new System.Drawing.Size(100, 20);
            this.txtDeliveryDeadline.TabIndex = 217;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(321, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 231;
            this.label6.Text = "Cena (eur):";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(423, 131);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 219;
            // 
            // txtGrip
            // 
            this.txtGrip.AccessibleName = "Vrsta svetila";
            this.txtGrip.Location = new System.Drawing.Point(100, 131);
            this.txtGrip.Name = "txtGrip";
            this.txtGrip.ReadOnly = true;
            this.txtGrip.Size = new System.Drawing.Size(111, 20);
            this.txtGrip.TabIndex = 208;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(2, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 230;
            this.label5.Text = "Vrsta svetila:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(529, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 229;
            this.label4.Text = "Proizvajalec:";
            // 
            // txtProducer
            // 
            this.txtProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducer.Location = new System.Drawing.Point(631, 93);
            this.txtProducer.Name = "txtProducer";
            this.txtProducer.ReadOnly = true;
            this.txtProducer.Size = new System.Drawing.Size(100, 20);
            this.txtProducer.TabIndex = 218;
            // 
            // txtFuel
            // 
            this.txtFuel.AccessibleName = "Moč";
            this.txtFuel.Location = new System.Drawing.Point(100, 236);
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.ReadOnly = true;
            this.txtFuel.Size = new System.Drawing.Size(111, 20);
            this.txtFuel.TabIndex = 211;
            // 
            // txtWeightIndex
            // 
            this.txtWeightIndex.AccessibleName = "Napetost";
            this.txtWeightIndex.Location = new System.Drawing.Point(100, 201);
            this.txtWeightIndex.Name = "txtWeightIndex";
            this.txtWeightIndex.ReadOnly = true;
            this.txtWeightIndex.Size = new System.Drawing.Size(111, 20);
            this.txtWeightIndex.TabIndex = 210;
            // 
            // txtSpeed
            // 
            this.txtSpeed.AccessibleName = "Tip svetila";
            this.txtSpeed.Location = new System.Drawing.Point(100, 165);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.ReadOnly = true;
            this.txtSpeed.Size = new System.Drawing.Size(111, 20);
            this.txtSpeed.TabIndex = 209;
            // 
            // labelFuelEfficiency
            // 
            this.labelFuelEfficiency.AutoSize = true;
            this.labelFuelEfficiency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFuelEfficiency.ForeColor = System.Drawing.Color.Black;
            this.labelFuelEfficiency.Location = new System.Drawing.Point(1, 236);
            this.labelFuelEfficiency.Name = "labelFuelEfficiency";
            this.labelFuelEfficiency.Size = new System.Drawing.Size(72, 20);
            this.labelFuelEfficiency.TabIndex = 224;
            this.labelFuelEfficiency.Text = "Moč (W):";
            // 
            // labelWeightIndex
            // 
            this.labelWeightIndex.AutoSize = true;
            this.labelWeightIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWeightIndex.ForeColor = System.Drawing.Color.Black;
            this.labelWeightIndex.Location = new System.Drawing.Point(1, 201);
            this.labelWeightIndex.Name = "labelWeightIndex";
            this.labelWeightIndex.Size = new System.Drawing.Size(103, 20);
            this.labelWeightIndex.TabIndex = 223;
            this.labelWeightIndex.Text = "Napetost (V):";
            // 
            // labelSpeedClass
            // 
            this.labelSpeedClass.AutoSize = true;
            this.labelSpeedClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSpeedClass.ForeColor = System.Drawing.Color.Black;
            this.labelSpeedClass.Location = new System.Drawing.Point(1, 165);
            this.labelSpeedClass.Name = "labelSpeedClass";
            this.labelSpeedClass.Size = new System.Drawing.Size(82, 20);
            this.labelSpeedClass.TabIndex = 222;
            this.labelSpeedClass.Text = "Tip svetila:";
            // 
            // autoPartPicture
            // 
            this.autoPartPicture.BackgroundImage = global::LeaveMeAlone.Properties.Resources.noImage;
            this.autoPartPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.autoPartPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.autoPartPicture.Location = new System.Drawing.Point(3, 3);
            this.autoPartPicture.Name = "autoPartPicture";
            this.autoPartPicture.Size = new System.Drawing.Size(110, 80);
            this.autoPartPicture.TabIndex = 203;
            this.autoPartPicture.TabStop = false;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.AutoSize = true;
            this.btnAddToCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddToCart.Location = new System.Drawing.Point(608, 380);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(123, 27);
            this.btnAddToCart.TabIndex = 199;
            this.btnAddToCart.Text = "Dodaj v košarico";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // LightViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(741, 419);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LightViewForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserProfileViewForm";
            this.Deactivate += new System.EventHandler(this.UserProfileViewForm_Deactivate);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoPartPicture)).EndInit();
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
        private System.Windows.Forms.PictureBox autoPartPicture;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeliveryDeadline;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtGrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProducer;
        private System.Windows.Forms.TextBox txtFuel;
        private System.Windows.Forms.TextBox txtWeightIndex;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label labelFuelEfficiency;
        private System.Windows.Forms.Label labelWeightIndex;
        private System.Windows.Forms.Label labelSpeedClass;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnRemoveAmountFromCart;
        private System.Windows.Forms.Button btnRemoveAllFromCart;
        private System.Windows.Forms.Label labelCurrentAmount;
    }
}