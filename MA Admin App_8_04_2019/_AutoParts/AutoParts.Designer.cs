namespace LeaveMeAlone {
    partial class AutoParts {
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
            this.labelAutoParts = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.filtersButton = new LeaveMeAlone.BottomBorderButton();
            this.oilsButton = new LeaveMeAlone.BottomBorderButton();
            this.lightsButton = new LeaveMeAlone.BottomBorderButton();
            this.tiresButton = new LeaveMeAlone.BottomBorderButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tiresLayout = new LeaveMeAlone.TiresLayout();
            this.lightsLayout = new LeaveMeAlone.LightsLayout();
            this.oilsLayout = new LeaveMeAlone.OilsLayout();
            this.filtersLayout = new LeaveMeAlone.FiltersLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAutoParts
            // 
            this.labelAutoParts.AutoSize = true;
            this.labelAutoParts.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAutoParts.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.labelAutoParts.Location = new System.Drawing.Point(0, 0);
            this.labelAutoParts.Name = "labelAutoParts";
            this.labelAutoParts.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.labelAutoParts.Size = new System.Drawing.Size(207, 59);
            this.labelAutoParts.TabIndex = 8;
            this.labelAutoParts.Text = "AVTO DELI";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.Controls.Add(this.filtersButton);
            this.panelButtons.Controls.Add(this.oilsButton);
            this.panelButtons.Controls.Add(this.lightsButton);
            this.panelButtons.Controls.Add(this.tiresButton);
            this.panelButtons.Controls.Add(this.splitter1);
            this.panelButtons.Controls.Add(this.labelAutoParts);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(834, 60);
            this.panelButtons.TabIndex = 9;
            // 
            // filtersButton
            // 
            this.filtersButton.AutoSize = true;
            this.filtersButton.BackColor = System.Drawing.Color.Transparent;
            this.filtersButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.filtersButton.FlatAppearance.BorderSize = 0;
            this.filtersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.filtersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.filtersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtersButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filtersButton.ForeColor = System.Drawing.Color.Gray;
            this.filtersButton.Location = new System.Drawing.Point(582, 0);
            this.filtersButton.Margin = new System.Windows.Forms.Padding(0);
            this.filtersButton.Name = "filtersButton";
            this.filtersButton.Size = new System.Drawing.Size(103, 60);
            this.filtersButton.TabIndex = 10;
            this.filtersButton.Text = "Filtri";
            this.filtersButton.UseVisualStyleBackColor = false;
            this.filtersButton.Click += new System.EventHandler(this.filtersButton_Click);
            this.filtersButton.MouseEnter += new System.EventHandler(this.filtersButton_MouseEnter);
            this.filtersButton.MouseLeave += new System.EventHandler(this.filtersButton_MouseLeave);
            // 
            // oilsButton
            // 
            this.oilsButton.AutoSize = true;
            this.oilsButton.BackColor = System.Drawing.Color.Transparent;
            this.oilsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.oilsButton.FlatAppearance.BorderSize = 0;
            this.oilsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.oilsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.oilsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oilsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.oilsButton.ForeColor = System.Drawing.Color.Gray;
            this.oilsButton.Location = new System.Drawing.Point(483, 0);
            this.oilsButton.Margin = new System.Windows.Forms.Padding(0);
            this.oilsButton.Name = "oilsButton";
            this.oilsButton.Size = new System.Drawing.Size(99, 60);
            this.oilsButton.TabIndex = 8;
            this.oilsButton.Text = "Olja";
            this.oilsButton.UseVisualStyleBackColor = false;
            this.oilsButton.Click += new System.EventHandler(this.oilsButton_Click);
            this.oilsButton.MouseEnter += new System.EventHandler(this.oilsButton_MouseEnter);
            this.oilsButton.MouseLeave += new System.EventHandler(this.oilsButton_MouseLeave);
            // 
            // lightsButton
            // 
            this.lightsButton.AutoSize = true;
            this.lightsButton.BackColor = System.Drawing.Color.Transparent;
            this.lightsButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.lightsButton.FlatAppearance.BorderSize = 0;
            this.lightsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.lightsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.lightsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lightsButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lightsButton.ForeColor = System.Drawing.Color.Gray;
            this.lightsButton.Location = new System.Drawing.Point(361, 0);
            this.lightsButton.Margin = new System.Windows.Forms.Padding(0);
            this.lightsButton.Name = "lightsButton";
            this.lightsButton.Size = new System.Drawing.Size(122, 60);
            this.lightsButton.TabIndex = 7;
            this.lightsButton.Text = "Svetila";
            this.lightsButton.UseVisualStyleBackColor = false;
            this.lightsButton.Click += new System.EventHandler(this.lightsButton_Click);
            this.lightsButton.MouseEnter += new System.EventHandler(this.lightsButton_MouseEnter);
            this.lightsButton.MouseLeave += new System.EventHandler(this.lightsButton_MouseLeave);
            // 
            // tiresButton
            // 
            this.tiresButton.AutoSize = true;
            this.tiresButton.BackColor = System.Drawing.Color.Transparent;
            this.tiresButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.tiresButton.FlatAppearance.BorderSize = 0;
            this.tiresButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.tiresButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.tiresButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tiresButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tiresButton.ForeColor = System.Drawing.Color.Gray;
            this.tiresButton.Location = new System.Drawing.Point(208, 0);
            this.tiresButton.Margin = new System.Windows.Forms.Padding(0);
            this.tiresButton.Name = "tiresButton";
            this.tiresButton.Size = new System.Drawing.Size(153, 60);
            this.tiresButton.TabIndex = 6;
            this.tiresButton.Text = "Pnevmatike";
            this.tiresButton.UseVisualStyleBackColor = false;
            this.tiresButton.Click += new System.EventHandler(this.tiresButton_Click);
            this.tiresButton.MouseEnter += new System.EventHandler(this.tiresButton_MouseEnter);
            this.tiresButton.MouseLeave += new System.EventHandler(this.tiresButton_MouseLeave);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(207, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 60);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // tiresLayout
            // 
            this.tiresLayout.BackColor = System.Drawing.Color.White;
            this.tiresLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tiresLayout.Location = new System.Drawing.Point(0, 60);
            this.tiresLayout.Name = "tiresLayout";
            this.tiresLayout.Size = new System.Drawing.Size(834, 473);
            this.tiresLayout.TabIndex = 10;
            // 
            // lightsLayout
            // 
            this.lightsLayout.BackColor = System.Drawing.Color.White;
            this.lightsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightsLayout.Location = new System.Drawing.Point(0, 60);
            this.lightsLayout.Name = "lightsLayout";
            this.lightsLayout.Size = new System.Drawing.Size(834, 473);
            this.lightsLayout.TabIndex = 11;
            // 
            // oilsLayout
            // 
            this.oilsLayout.BackColor = System.Drawing.Color.White;
            this.oilsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oilsLayout.Location = new System.Drawing.Point(0, 60);
            this.oilsLayout.Name = "oilsLayout";
            this.oilsLayout.Size = new System.Drawing.Size(834, 473);
            this.oilsLayout.TabIndex = 12;
            // 
            // filtersLayout
            // 
            this.filtersLayout.BackColor = System.Drawing.Color.White;
            this.filtersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtersLayout.Location = new System.Drawing.Point(0, 60);
            this.filtersLayout.Name = "filtersLayout";
            this.filtersLayout.Size = new System.Drawing.Size(834, 473);
            this.filtersLayout.TabIndex = 13;
            // 
            // AutoParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tiresLayout);
            this.Controls.Add(this.lightsLayout);
            this.Controls.Add(this.oilsLayout);
            this.Controls.Add(this.filtersLayout);
            this.Controls.Add(this.panelButtons);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(150)))), ((int)(((byte)(23)))));
            this.Name = "AutoParts";
            this.Size = new System.Drawing.Size(834, 533);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelAutoParts;
        private System.Windows.Forms.Panel panelButtons;
        private BottomBorderButton oilsButton;
        private BottomBorderButton lightsButton;
        private BottomBorderButton tiresButton;
        private System.Windows.Forms.Splitter splitter1;
        private BottomBorderButton filtersButton;
        private TiresLayout tiresLayout;
        private LightsLayout lightsLayout;
        private OilsLayout oilsLayout;
        private FiltersLayout filtersLayout;
    }
}
