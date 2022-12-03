namespace LeaveMeAlone {
    partial class FiltersLayout {
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
            this.tiresData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiameter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.labelLength = new System.Windows.Forms.Label();
            this.textPriceTo = new System.Windows.Forms.TextBox();
            this.textPriceFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.dataFilterShape = new System.Windows.Forms.CheckedListBox();
            this.labelFuelEfficiency = new System.Windows.Forms.Label();
            this.dataFilterType = new System.Windows.Forms.CheckedListBox();
            this.labelSpeedClass = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tiresData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tiresData
            // 
            this.tiresData.BackgroundColor = System.Drawing.Color.White;
            this.tiresData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tiresData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tiresData.GridColor = System.Drawing.Color.Gray;
            this.tiresData.Location = new System.Drawing.Point(0, 139);
            this.tiresData.Margin = new System.Windows.Forms.Padding(0);
            this.tiresData.Name = "tiresData";
            this.tiresData.Size = new System.Drawing.Size(831, 291);
            this.tiresData.TabIndex = 0;
            this.tiresData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tiresData_CellMouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDiameter);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtLength);
            this.panel1.Controls.Add(this.labelLength);
            this.panel1.Controls.Add(this.textPriceTo);
            this.panel1.Controls.Add(this.textPriceFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.labelHeight);
            this.panel1.Controls.Add(this.btnApplyFilters);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.dataFilterShape);
            this.panel1.Controls.Add(this.labelFuelEfficiency);
            this.panel1.Controls.Add(this.dataFilterType);
            this.panel1.Controls.Add(this.labelSpeedClass);
            this.panel1.Controls.Add(this.labelWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 139);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(220, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Podrobnosti:";
            // 
            // txtDiameter
            // 
            this.txtDiameter.AccessibleName = "Premer";
            this.txtDiameter.Enabled = false;
            this.txtDiameter.ForeColor = System.Drawing.Color.Black;
            this.txtDiameter.Location = new System.Drawing.Point(330, 30);
            this.txtDiameter.Name = "txtDiameter";
            this.txtDiameter.Size = new System.Drawing.Size(100, 20);
            this.txtDiameter.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(220, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Premer (mm):";
            // 
            // txtLength
            // 
            this.txtLength.AccessibleName = "Dolzina";
            this.txtLength.Enabled = false;
            this.txtLength.ForeColor = System.Drawing.Color.Black;
            this.txtLength.Location = new System.Drawing.Point(571, 30);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 22;
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelLength.ForeColor = System.Drawing.Color.Black;
            this.labelLength.Location = new System.Drawing.Point(464, 30);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(101, 20);
            this.labelLength.TabIndex = 21;
            this.labelLength.Text = "Dolžina (cm):";
            // 
            // textPriceTo
            // 
            this.textPriceTo.ForeColor = System.Drawing.Color.Black;
            this.textPriceTo.Location = new System.Drawing.Point(737, 68);
            this.textPriceTo.Name = "textPriceTo";
            this.textPriceTo.Size = new System.Drawing.Size(86, 20);
            this.textPriceTo.TabIndex = 20;
            // 
            // textPriceFrom
            // 
            this.textPriceFrom.ForeColor = System.Drawing.Color.Black;
            this.textPriceFrom.Location = new System.Drawing.Point(737, 36);
            this.textPriceFrom.Name = "textPriceFrom";
            this.textPriceFrom.Size = new System.Drawing.Size(86, 20);
            this.textPriceFrom.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(704, 66);
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
            this.label2.Location = new System.Drawing.Point(704, 36);
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
            this.label1.Location = new System.Drawing.Point(704, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cena:";
            // 
            // txtHeight
            // 
            this.txtHeight.AccessibleName = "Visina";
            this.txtHeight.Enabled = false;
            this.txtHeight.ForeColor = System.Drawing.Color.Black;
            this.txtHeight.Location = new System.Drawing.Point(571, 84);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 10;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHeight.ForeColor = System.Drawing.Color.Black;
            this.labelHeight.Location = new System.Drawing.Point(474, 84);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(91, 20);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Višina (cm):";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.White;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilters.Location = new System.Drawing.Point(713, 99);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(110, 33);
            this.btnApplyFilters.TabIndex = 8;
            this.btnApplyFilters.Text = "Uporabi filtre";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.AccessibleName = "Sirina";
            this.txtWidth.Enabled = false;
            this.txtWidth.ForeColor = System.Drawing.Color.Black;
            this.txtWidth.Location = new System.Drawing.Point(571, 57);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 7;
            // 
            // dataFilterShape
            // 
            this.dataFilterShape.BackColor = System.Drawing.Color.White;
            this.dataFilterShape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataFilterShape.CheckOnClick = true;
            this.dataFilterShape.ForeColor = System.Drawing.Color.Black;
            this.dataFilterShape.FormattingEnabled = true;
            this.dataFilterShape.Items.AddRange(new object[] {
            "Okrogel",
            "Kvadraten"});
            this.dataFilterShape.Location = new System.Drawing.Point(111, 30);
            this.dataFilterShape.Name = "dataFilterShape";
            this.dataFilterShape.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataFilterShape.Size = new System.Drawing.Size(87, 30);
            this.dataFilterShape.TabIndex = 6;
            this.dataFilterShape.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelFuelEfficiency
            // 
            this.labelFuelEfficiency.AutoSize = true;
            this.labelFuelEfficiency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFuelEfficiency.ForeColor = System.Drawing.Color.Black;
            this.labelFuelEfficiency.Location = new System.Drawing.Point(107, 7);
            this.labelFuelEfficiency.Name = "labelFuelEfficiency";
            this.labelFuelEfficiency.Size = new System.Drawing.Size(91, 20);
            this.labelFuelEfficiency.TabIndex = 5;
            this.labelFuelEfficiency.Text = "Oblika filtra:";
            // 
            // dataFilterType
            // 
            this.dataFilterType.BackColor = System.Drawing.Color.White;
            this.dataFilterType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataFilterType.CheckOnClick = true;
            this.dataFilterType.ForeColor = System.Drawing.Color.Black;
            this.dataFilterType.FormattingEnabled = true;
            this.dataFilterType.Items.AddRange(new object[] {
            "Oljni filter",
            "Zračni filter"});
            this.dataFilterType.Location = new System.Drawing.Point(3, 30);
            this.dataFilterType.Name = "dataFilterType";
            this.dataFilterType.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataFilterType.Size = new System.Drawing.Size(81, 30);
            this.dataFilterType.TabIndex = 2;
            this.dataFilterType.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelSpeedClass
            // 
            this.labelSpeedClass.AutoSize = true;
            this.labelSpeedClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSpeedClass.ForeColor = System.Drawing.Color.Black;
            this.labelSpeedClass.Location = new System.Drawing.Point(-1, 7);
            this.labelSpeedClass.Name = "labelSpeedClass";
            this.labelSpeedClass.Size = new System.Drawing.Size(85, 20);
            this.labelSpeedClass.TabIndex = 1;
            this.labelSpeedClass.Text = "Vrsta filtra:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWidth.ForeColor = System.Drawing.Color.Black;
            this.labelWidth.Location = new System.Drawing.Point(477, 57);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(88, 20);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Širina (cm):";
            // 
            // FiltersLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.tiresData);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FiltersLayout";
            this.Size = new System.Drawing.Size(831, 430);
            ((System.ComponentModel.ISupportInitialize)(this.tiresData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tiresData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.CheckedListBox dataFilterShape;
        private System.Windows.Forms.Label labelFuelEfficiency;
        private System.Windows.Forms.CheckedListBox dataFilterType;
        private System.Windows.Forms.Label labelSpeedClass;
        private System.Windows.Forms.TextBox textPriceTo;
        private System.Windows.Forms.TextBox textPriceFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiameter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label labelLength;
    }
}
