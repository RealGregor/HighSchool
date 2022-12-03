using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using LMA.Data.UI.ViewModels.ViewModels;
using LeaveMeAlone._AutoParts.Tires;

namespace LeaveMeAlone
{
    public partial class OilsLayout : UserControl
    {

        private OilViewForm oilViewForm;

        private bool first = true;

        public OilsLayout()
        {
            InitializeComponent();

        }

        public void SetAutoPartsDataControlSource(BindingList<AutoPart> list)
        {
            if (!first) { return; }
            first = false;

            oilsData.RowHeadersVisible = false;
            //employeesData.Enabled = false;
            oilsData.DefaultCellStyle.SelectionBackColor = oilsData.DefaultCellStyle.BackColor;
            oilsData.DefaultCellStyle.SelectionForeColor = oilsData.DefaultCellStyle.ForeColor;
            oilsData.AllowUserToResizeRows = false;
            oilsData.AllowUserToResizeColumns = false;

            oilsData.RowTemplate.MinimumHeight = 90;
            oilsData.RowTemplate.ReadOnly = true;

            oilsData.DataSource = list;

            oilsData.Columns[0].Visible = false;

            oilsData.Columns[1].HeaderText = "Slika Olja";
            oilsData.Columns[2].HeaderText = "Ime";
            oilsData.Columns[3].HeaderText = "Proizvajalec";
            oilsData.Columns[4].HeaderText = "Rok Dostave";
            oilsData.Columns[5].HeaderText = "Cena";

            foreach (DataGridViewColumn data in oilsData.Columns) {
                data.DefaultCellStyle.Font = new Font("Microsoft YaHei", 16);
                if (data.Name.Equals("Name")) {
                    data.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    continue;
                }
                if (data.Name.Equals("Picture")) {
                    continue;
                }
                data.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

        }
        
        //creates a string with all the filters
        private void btnApplyFilters_Click(object sender, EventArgs e) {
            
            string technicalDescription = "";

            //getting values from širina, višina etc.. and add them to tecnicalDescription
            foreach (var v in this.Controls.OfType<Panel>().Single().Controls.OfType<TextBox>().ToList()) {
                string text = v.Text.Trim();
                string name = v.AccessibleName;

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(text)) {
                    continue;
                }
                if (string.IsNullOrEmpty(technicalDescription)) {
                    technicalDescription += name + ":" + text;
                    continue;
                }
                technicalDescription += "," + name + ":" + text;
            }
            
            //getting all selected values from indeks hitrosti
            foreach (var v in dataOilType.CheckedItems) {
                technicalDescription += ",Vrsta olja:" + v;
            }
            decimal priceMin = 0, priceMax = 0;
            try {
                priceMin = Convert.ToDecimal(textPriceFrom.Text.Trim());
            } catch (Exception ex) { }
            try {
                priceMax = Convert.ToDecimal(textPriceTo.Text.Trim());
            } catch (Exception ex) { }

            //formMain.mainForm.FunctionSummoner(37, category: "Šumnik");
            formMain.mainForm.FunctionSummoner(38, category:"Oil", technicalDescription: technicalDescription, priceMin: priceMin, priceMax: priceMax);
        }
        //Seems like it would be more efficient to use checkedListBox1.IndexFromPoint(e.x, e.y) 
        //in the MouseDown handler,instead of looping through the GetItemRectangle results.
        private void dataList_Click(object sender, EventArgs e) {
            var list = ((CheckedListBox)sender);
            for (int i = 0; i < list.Items.Count; i++) {


                if (list.GetItemRectangle(i).Contains(list.PointToClient(MousePosition))) {
                    switch (list.GetItemCheckState(i)) {
                        case CheckState.Checked:
                            list.SetItemCheckState(i, CheckState.Unchecked);
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            list.SetItemCheckState(i, CheckState.Checked);
                            break;
                    }

                }

            }
        }

        private void tiresData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) { return; }
            AutoPart autoPart = (AutoPart)(oilsData.Rows[e.RowIndex].DataBoundItem);
            
            if (oilViewForm != null) {
                oilViewForm.Close();
            }
            oilViewForm = new OilViewForm(autoPart);
            oilViewForm.Show();
        }
    }
}
