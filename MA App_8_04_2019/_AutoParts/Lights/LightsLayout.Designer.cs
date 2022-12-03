namespace LeaveMeAlone {
    partial class LightsLayout {
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
            this.lightsData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textPriceTo = new System.Windows.Forms.TextBox();
            this.textPriceFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.dataLightLightType = new System.Windows.Forms.CheckedListBox();
            this.labelFuelEfficiency = new System.Windows.Forms.Label();
            this.dataLightType = new System.Windows.Forms.CheckedListBox();
            this.labelLightType = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lightsData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lightsData
            // 
            this.lightsData.BackgroundColor = System.Drawing.Color.White;
            this.lightsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lightsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightsData.GridColor = System.Drawing.Color.Gray;
            this.lightsData.Location = new System.Drawing.Point(0, 139);
            this.lightsData.Margin = new System.Windows.Forms.Padding(0);
            this.lightsData.Name = "lightsData";
            this.lightsData.Size = new System.Drawing.Size(831, 291);
            this.lightsData.TabIndex = 0;
            this.lightsData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.lightsData_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textPriceTo);
            this.panel1.Controls.Add(this.textPriceFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPower);
            this.panel1.Controls.Add(this.labelHeight);
            this.panel1.Controls.Add(this.btnApplyFilters);
            this.panel1.Controls.Add(this.txtVoltage);
            this.panel1.Controls.Add(this.dataLightLightType);
            this.panel1.Controls.Add(this.labelFuelEfficiency);
            this.panel1.Controls.Add(this.dataLightType);
            this.panel1.Controls.Add(this.labelLightType);
            this.panel1.Controls.Add(this.labelWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 139);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(331, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Podrobnosti:";
            // 
            // textPriceTo
            // 
            this.textPriceTo.ForeColor = System.Drawing.Color.Black;
            this.textPriceTo.Location = new System.Drawing.Point(610, 74);
            this.textPriceTo.Name = "textPriceTo";
            this.textPriceTo.Size = new System.Drawing.Size(86, 20);
            this.textPriceTo.TabIndex = 20;
            // 
            // textPriceFrom
            // 
            this.textPriceFrom.ForeColor = System.Drawing.Color.Black;
            this.textPriceFrom.Location = new System.Drawing.Point(610, 38);
            this.textPriceFrom.Name = "textPriceFrom";
            this.textPriceFrom.Size = new System.Drawing.Size(86, 20);
            this.textPriceFrom.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(577, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Do:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(577, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Od:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(577, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cena:";
            // 
            // txtPower
            // 
            this.txtPower.AccessibleName = "Moc";
            this.txtPower.ForeColor = System.Drawing.Color.Black;
            this.txtPower.Location = new System.Drawing.Point(432, 74);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(100, 20);
            this.txtPower.TabIndex = 10;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHeight.ForeColor = System.Drawing.Color.Black;
            this.labelHeight.Location = new System.Drawing.Point(362, 74);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(72, 20);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Moč (W):";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.White;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilters.Location = new System.Drawing.Point(717, 99);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(110, 33);
            this.btnApplyFilters.TabIndex = 8;
            this.btnApplyFilters.Text = "Uporabi filtre";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // txtVoltage
            // 
            this.txtVoltage.AccessibleName = "Napetost";
            this.txtVoltage.ForeColor = System.Drawing.Color.Black;
            this.txtVoltage.Location = new System.Drawing.Point(432, 38);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(100, 20);
            this.txtVoltage.TabIndex = 7;
            // 
            // dataLightLightType
            // 
            this.dataLightLightType.BackColor = System.Drawing.Color.White;
            this.dataLightLightType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataLightLightType.CheckOnClick = true;
            this.dataLightLightType.ForeColor = System.Drawing.Color.Black;
            this.dataLightLightType.FormattingEnabled = true;
            this.dataLightLightType.Items.AddRange(new object[] {
            "Halogen",
            "LED",
            "Xenon"});
            this.dataLightLightType.Location = new System.Drawing.Point(173, 34);
            this.dataLightLightType.Name = "dataLightLightType";
            this.dataLightLightType.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataLightLightType.Size = new System.Drawing.Size(125, 45);
            this.dataLightLightType.TabIndex = 6;
            this.dataLightLightType.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelFuelEfficiency
            // 
            this.labelFuelEfficiency.AutoSize = true;
            this.labelFuelEfficiency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFuelEfficiency.ForeColor = System.Drawing.Color.Black;
            this.labelFuelEfficiency.Location = new System.Drawing.Point(169, 9);
            this.labelFuelEfficiency.Name = "labelFuelEfficiency";
            this.labelFuelEfficiency.Size = new System.Drawing.Size(99, 20);
            this.labelFuelEfficiency.TabIndex = 5;
            this.labelFuelEfficiency.Text = "Vrsta svetila:";
            // 
            // dataLightType
            // 
            this.dataLightType.BackColor = System.Drawing.Color.White;
            this.dataLightType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataLightType.CheckOnClick = true;
            this.dataLightType.ForeColor = System.Drawing.Color.Black;
            this.dataLightType.FormattingEnabled = true;
            this.dataLightType.Items.AddRange(new object[] {
            "Žaromet",
            "Zadnja luč",
            "Smernik",
            "Meglenka"});
            this.dataLightType.Location = new System.Drawing.Point(3, 34);
            this.dataLightType.Name = "dataLightType";
            this.dataLightType.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataLightType.Size = new System.Drawing.Size(125, 60);
            this.dataLightType.TabIndex = 2;
            this.dataLightType.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelLightType
            // 
            this.labelLightType.AutoSize = true;
            this.labelLightType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelLightType.ForeColor = System.Drawing.Color.Black;
            this.labelLightType.Location = new System.Drawing.Point(-1, 9);
            this.labelLightType.Name = "labelLightType";
            this.labelLightType.Size = new System.Drawing.Size(82, 20);
            this.labelLightType.TabIndex = 1;
            this.labelLightType.Text = "Tip svetila:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWidth.ForeColor = System.Drawing.Color.Black;
            this.labelWidth.Location = new System.Drawing.Point(331, 38);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(103, 20);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Napetost (V):";
            // 
            // LightsLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.lightsData);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LightsLayout";
            this.Size = new System.Drawing.Size(831, 430);
            ((System.ComponentModel.ISupportInitialize)(this.lightsData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lightsData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.CheckedListBox dataLightLightType;
        private System.Windows.Forms.Label labelFuelEfficiency;
        private System.Windows.Forms.CheckedListBox dataLightType;
        private System.Windows.Forms.Label labelLightType;
        private System.Windows.Forms.TextBox textPriceTo;
        private System.Windows.Forms.TextBox textPriceFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}
