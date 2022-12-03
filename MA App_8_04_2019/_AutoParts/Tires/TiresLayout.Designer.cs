namespace LeaveMeAlone {
    partial class TiresLayout {
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
            this.textPriceTo = new System.Windows.Forms.TextBox();
            this.textPriceFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataTireType = new System.Windows.Forms.CheckedListBox();
            this.labelTireType = new System.Windows.Forms.Label();
            this.txtRimDiameter = new System.Windows.Forms.TextBox();
            this.labelRimDiameter = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.dataFuelEfficiency = new System.Windows.Forms.CheckedListBox();
            this.labelFuelEfficiency = new System.Windows.Forms.Label();
            this.labelWeightIndex = new System.Windows.Forms.Label();
            this.dataSpeedClass = new System.Windows.Forms.CheckedListBox();
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
            this.panel1.Controls.Add(this.textPriceTo);
            this.panel1.Controls.Add(this.textPriceFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dataTireType);
            this.panel1.Controls.Add(this.labelTireType);
            this.panel1.Controls.Add(this.txtRimDiameter);
            this.panel1.Controls.Add(this.labelRimDiameter);
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.labelHeight);
            this.panel1.Controls.Add(this.btnApplyFilters);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.dataFuelEfficiency);
            this.panel1.Controls.Add(this.labelFuelEfficiency);
            this.panel1.Controls.Add(this.labelWeightIndex);
            this.panel1.Controls.Add(this.dataSpeedClass);
            this.panel1.Controls.Add(this.labelSpeedClass);
            this.panel1.Controls.Add(this.labelWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 139);
            this.panel1.TabIndex = 1;
            // 
            // textPriceTo
            // 
            this.textPriceTo.ForeColor = System.Drawing.Color.Black;
            this.textPriceTo.Location = new System.Drawing.Point(737, 74);
            this.textPriceTo.Name = "textPriceTo";
            this.textPriceTo.Size = new System.Drawing.Size(86, 20);
            this.textPriceTo.TabIndex = 20;
            // 
            // textPriceFrom
            // 
            this.textPriceFrom.ForeColor = System.Drawing.Color.Black;
            this.textPriceFrom.Location = new System.Drawing.Point(737, 48);
            this.textPriceFrom.Name = "textPriceFrom";
            this.textPriceFrom.Size = new System.Drawing.Size(86, 20);
            this.textPriceFrom.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(704, 72);
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
            this.label2.Location = new System.Drawing.Point(704, 48);
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
            this.label1.Location = new System.Drawing.Point(704, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cena:";
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "Indeks Nosilnosti";
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(303, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 15;
            // 
            // dataTireType
            // 
            this.dataTireType.BackColor = System.Drawing.Color.White;
            this.dataTireType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataTireType.CheckOnClick = true;
            this.dataTireType.ForeColor = System.Drawing.Color.Black;
            this.dataTireType.FormattingEnabled = true;
            this.dataTireType.Items.AddRange(new object[] {
            "Letna",
            "Zimska",
            "Zimsko-Letna"});
            this.dataTireType.Location = new System.Drawing.Point(305, 82);
            this.dataTireType.Name = "dataTireType";
            this.dataTireType.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataTireType.Size = new System.Drawing.Size(115, 45);
            this.dataTireType.TabIndex = 14;
            this.dataTireType.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelTireType
            // 
            this.labelTireType.AutoSize = true;
            this.labelTireType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTireType.ForeColor = System.Drawing.Color.Black;
            this.labelTireType.Location = new System.Drawing.Point(301, 61);
            this.labelTireType.Name = "labelTireType";
            this.labelTireType.Size = new System.Drawing.Size(119, 20);
            this.labelTireType.TabIndex = 13;
            this.labelTireType.Text = "Tip pnevmatike:";
            // 
            // txtRimDiameter
            // 
            this.txtRimDiameter.AccessibleName = "Cole";
            this.txtRimDiameter.ForeColor = System.Drawing.Color.Black;
            this.txtRimDiameter.Location = new System.Drawing.Point(580, 97);
            this.txtRimDiameter.Name = "txtRimDiameter";
            this.txtRimDiameter.Size = new System.Drawing.Size(100, 20);
            this.txtRimDiameter.TabIndex = 12;
            // 
            // labelRimDiameter
            // 
            this.labelRimDiameter.AutoSize = true;
            this.labelRimDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelRimDiameter.ForeColor = System.Drawing.Color.Black;
            this.labelRimDiameter.Location = new System.Drawing.Point(526, 97);
            this.labelRimDiameter.Name = "labelRimDiameter";
            this.labelRimDiameter.Size = new System.Drawing.Size(45, 20);
            this.labelRimDiameter.TabIndex = 11;
            this.labelRimDiameter.Text = "Cole:";
            // 
            // txtHeight
            // 
            this.txtHeight.AccessibleName = "Visina";
            this.txtHeight.ForeColor = System.Drawing.Color.Black;
            this.txtHeight.Location = new System.Drawing.Point(580, 61);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 10;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHeight.ForeColor = System.Drawing.Color.Black;
            this.labelHeight.Location = new System.Drawing.Point(526, 61);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(56, 20);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Višina:";
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
            this.txtWidth.ForeColor = System.Drawing.Color.Black;
            this.txtWidth.Location = new System.Drawing.Point(580, 25);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 7;
            // 
            // dataFuelEfficiency
            // 
            this.dataFuelEfficiency.BackColor = System.Drawing.Color.White;
            this.dataFuelEfficiency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataFuelEfficiency.CheckOnClick = true;
            this.dataFuelEfficiency.ForeColor = System.Drawing.Color.Black;
            this.dataFuelEfficiency.FormattingEnabled = true;
            this.dataFuelEfficiency.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.dataFuelEfficiency.Location = new System.Drawing.Point(155, 30);
            this.dataFuelEfficiency.Name = "dataFuelEfficiency";
            this.dataFuelEfficiency.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataFuelEfficiency.Size = new System.Drawing.Size(125, 90);
            this.dataFuelEfficiency.TabIndex = 6;
            this.dataFuelEfficiency.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelFuelEfficiency
            // 
            this.labelFuelEfficiency.AutoSize = true;
            this.labelFuelEfficiency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFuelEfficiency.ForeColor = System.Drawing.Color.Black;
            this.labelFuelEfficiency.Location = new System.Drawing.Point(151, 9);
            this.labelFuelEfficiency.Name = "labelFuelEfficiency";
            this.labelFuelEfficiency.Size = new System.Drawing.Size(127, 20);
            this.labelFuelEfficiency.TabIndex = 5;
            this.labelFuelEfficiency.Text = "Izkoristek goriva:";
            // 
            // labelWeightIndex
            // 
            this.labelWeightIndex.AutoSize = true;
            this.labelWeightIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWeightIndex.ForeColor = System.Drawing.Color.Black;
            this.labelWeightIndex.Location = new System.Drawing.Point(299, 9);
            this.labelWeightIndex.Name = "labelWeightIndex";
            this.labelWeightIndex.Size = new System.Drawing.Size(199, 20);
            this.labelWeightIndex.TabIndex = 3;
            this.labelWeightIndex.Text = "Indeks nosilnosti (65 -119):";
            // 
            // dataSpeedClass
            // 
            this.dataSpeedClass.BackColor = System.Drawing.Color.White;
            this.dataSpeedClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataSpeedClass.CheckOnClick = true;
            this.dataSpeedClass.ForeColor = System.Drawing.Color.Black;
            this.dataSpeedClass.FormattingEnabled = true;
            this.dataSpeedClass.Items.AddRange(new object[] {
            "N",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "H",
            "V",
            "W",
            "Y",
            "ZR"});
            this.dataSpeedClass.Location = new System.Drawing.Point(3, 30);
            this.dataSpeedClass.Name = "dataSpeedClass";
            this.dataSpeedClass.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataSpeedClass.Size = new System.Drawing.Size(125, 90);
            this.dataSpeedClass.TabIndex = 2;
            this.dataSpeedClass.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelSpeedClass
            // 
            this.labelSpeedClass.AutoSize = true;
            this.labelSpeedClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSpeedClass.ForeColor = System.Drawing.Color.Black;
            this.labelSpeedClass.Location = new System.Drawing.Point(-1, 9);
            this.labelSpeedClass.Name = "labelSpeedClass";
            this.labelSpeedClass.Size = new System.Drawing.Size(112, 20);
            this.labelSpeedClass.TabIndex = 1;
            this.labelSpeedClass.Text = "Indeks hitrosti:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWidth.ForeColor = System.Drawing.Color.Black;
            this.labelWidth.Location = new System.Drawing.Point(526, 25);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(53, 20);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Širina:";
            // 
            // TiresLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.tiresData);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TiresLayout";
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
        private System.Windows.Forms.TextBox txtRimDiameter;
        private System.Windows.Forms.Label labelRimDiameter;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.CheckedListBox dataFuelEfficiency;
        private System.Windows.Forms.Label labelFuelEfficiency;
        private System.Windows.Forms.Label labelWeightIndex;
        private System.Windows.Forms.CheckedListBox dataSpeedClass;
        private System.Windows.Forms.Label labelSpeedClass;
        private System.Windows.Forms.CheckedListBox dataTireType;
        private System.Windows.Forms.Label labelTireType;
        private System.Windows.Forms.TextBox textPriceTo;
        private System.Windows.Forms.TextBox textPriceFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
