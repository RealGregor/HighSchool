namespace LeaveMeAlone {
    partial class SearchOilsLayout {
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
            this.oilsData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPriceTo = new System.Windows.Forms.TextBox();
            this.textPriceFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.dataOilType = new System.Windows.Forms.CheckedListBox();
            this.labelSpeedClass = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.oilsData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // oilsData
            // 
            this.oilsData.BackgroundColor = System.Drawing.Color.White;
            this.oilsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oilsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oilsData.Location = new System.Drawing.Point(0, 109);
            this.oilsData.Name = "oilsData";
            this.oilsData.Size = new System.Drawing.Size(831, 321);
            this.oilsData.TabIndex = 0;
            this.oilsData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tiresData_CellMouseClick);
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
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.labelHeight);
            this.panel1.Controls.Add(this.btnApplyFilters);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.dataOilType);
            this.panel1.Controls.Add(this.labelSpeedClass);
            this.panel1.Controls.Add(this.labelWidth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 109);
            this.panel1.TabIndex = 1;
            // 
            // textPriceTo
            // 
            this.textPriceTo.ForeColor = System.Drawing.Color.Black;
            this.textPriceTo.Location = new System.Drawing.Point(589, 70);
            this.textPriceTo.Name = "textPriceTo";
            this.textPriceTo.Size = new System.Drawing.Size(86, 20);
            this.textPriceTo.TabIndex = 20;
            // 
            // textPriceFrom
            // 
            this.textPriceFrom.ForeColor = System.Drawing.Color.Black;
            this.textPriceFrom.Location = new System.Drawing.Point(589, 36);
            this.textPriceFrom.Name = "textPriceFrom";
            this.textPriceFrom.Size = new System.Drawing.Size(86, 20);
            this.textPriceFrom.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(556, 68);
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
            this.label2.Location = new System.Drawing.Point(556, 36);
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
            this.label1.Location = new System.Drawing.Point(556, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cena:";
            // 
            // txtHeight
            // 
            this.txtHeight.AccessibleName = "Višina";
            this.txtHeight.ForeColor = System.Drawing.Color.Black;
            this.txtHeight.Location = new System.Drawing.Point(419, 44);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 10;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelHeight.ForeColor = System.Drawing.Color.Black;
            this.labelHeight.Location = new System.Drawing.Point(348, 44);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(65, 20);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Razred:";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.BackColor = System.Drawing.Color.White;
            this.btnApplyFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApplyFilters.ForeColor = System.Drawing.Color.Black;
            this.btnApplyFilters.Location = new System.Drawing.Point(713, 63);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(110, 33);
            this.btnApplyFilters.TabIndex = 8;
            this.btnApplyFilters.Text = "Uporabi filtre";
            this.btnApplyFilters.UseVisualStyleBackColor = false;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // txtWidth
            // 
            this.txtWidth.AccessibleName = "Širina";
            this.txtWidth.ForeColor = System.Drawing.Color.Black;
            this.txtWidth.Location = new System.Drawing.Point(210, 44);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 7;
            // 
            // dataOilType
            // 
            this.dataOilType.BackColor = System.Drawing.Color.White;
            this.dataOilType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataOilType.CheckOnClick = true;
            this.dataOilType.ForeColor = System.Drawing.Color.Black;
            this.dataOilType.FormattingEnabled = true;
            this.dataOilType.Items.AddRange(new object[] {
            "Motorno olje",
            "Olje menjalnika",
            "Olje za volan"});
            this.dataOilType.Location = new System.Drawing.Point(7, 32);
            this.dataOilType.Name = "dataOilType";
            this.dataOilType.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.dataOilType.Size = new System.Drawing.Size(97, 45);
            this.dataOilType.TabIndex = 2;
            this.dataOilType.Click += new System.EventHandler(this.dataList_Click);
            // 
            // labelSpeedClass
            // 
            this.labelSpeedClass.AutoSize = true;
            this.labelSpeedClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSpeedClass.ForeColor = System.Drawing.Color.Black;
            this.labelSpeedClass.Location = new System.Drawing.Point(3, 9);
            this.labelSpeedClass.Name = "labelSpeedClass";
            this.labelSpeedClass.Size = new System.Drawing.Size(79, 20);
            this.labelSpeedClass.TabIndex = 1;
            this.labelSpeedClass.Text = "Vrsta olja:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelWidth.ForeColor = System.Drawing.Color.Black;
            this.labelWidth.Location = new System.Drawing.Point(120, 44);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(84, 20);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Količina (l):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(120, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Podrobnosti:";
            // 
            // SearchOilsLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.oilsData);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SearchOilsLayout";
            this.Size = new System.Drawing.Size(831, 430);
            ((System.ComponentModel.ISupportInitialize)(this.oilsData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView oilsData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.CheckedListBox dataOilType;
        private System.Windows.Forms.Label labelSpeedClass;
        private System.Windows.Forms.TextBox textPriceTo;
        private System.Windows.Forms.TextBox textPriceFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}
