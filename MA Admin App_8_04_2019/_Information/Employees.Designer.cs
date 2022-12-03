namespace LeaveMeAlone {
    partial class Employees {
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.employeesData = new System.Windows.Forms.DataGridView();
            this.employeeBinding = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.employeesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zaposleni v avtomehanični delavnici Pelko";
            // 
            // employeesData
            // 
            this.employeesData.AllowUserToAddRows = false;
            this.employeesData.AllowUserToDeleteRows = false;
            this.employeesData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.employeesData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesData.GridColor = System.Drawing.SystemColors.Control;
            this.employeesData.Location = new System.Drawing.Point(0, 35);
            this.employeesData.Name = "employeesData";
            this.employeesData.ReadOnly = true;
            this.employeesData.Size = new System.Drawing.Size(831, 403);
            this.employeesData.TabIndex = 2;
            // 
            // employeeBinding
            // 
            this.employeeBinding.DataSource = typeof(LeaveMeAlone._Information.Employee);
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.employeesData);
            this.Controls.Add(this.label1);
            this.Name = "Employees";
            this.Size = new System.Drawing.Size(831, 438);
            ((System.ComponentModel.ISupportInitialize)(this.employeesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView employeesData;
        private System.Windows.Forms.BindingSource employeeBinding;
    }
}
