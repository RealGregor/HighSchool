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
    public partial class SearchLightsLayout : UserControl
    {

        private LightViewFormAdmin lightViewForm;//change this

        private bool first = true;

        public SearchLightsLayout()
        {
            InitializeComponent();
        }

        public void SetAutoPartsDataControlSource(BindingList<AutoPart> list)
        {
            if (!first) { return; }
            first = false;

            lightsData.RowHeadersVisible = false;
            //employeesData.Enabled = false;
            lightsData.DefaultCellStyle.SelectionBackColor = lightsData.DefaultCellStyle.BackColor;
            lightsData.DefaultCellStyle.SelectionForeColor = lightsData.DefaultCellStyle.ForeColor;
            lightsData.AllowUserToResizeRows = false;
            lightsData.AllowUserToResizeColumns = false;

            lightsData.RowTemplate.MinimumHeight = 90;
            lightsData.RowTemplate.ReadOnly = true;

            lightsData.DataSource = list;

            lightsData.Columns[0].Visible = false;

            lightsData.Columns[1].HeaderText = "Slika Svetila";
            lightsData.Columns[2].HeaderText = "Ime";
            lightsData.Columns[3].HeaderText = "Proizvajalec";
            lightsData.Columns[4].HeaderText = "Rok Dostave";
            lightsData.Columns[5].HeaderText = "Cena";

            foreach (DataGridViewColumn data in lightsData.Columns) {
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

                //išče samo po tistih parametrih, katere je uporabnik/admin vnesel
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
            foreach (var v in dataLightType.CheckedItems) {
                technicalDescription += ",Tip svetila:" + v;
            }

            //getting all selected values from izkoristek goriva
            foreach (var v in dataLightLightType.CheckedItems) {
                technicalDescription += ",Vrsta Svetila:" + v;
            }
            decimal priceMin = 0, priceMax = 0;
            try {
                priceMin = Convert.ToDecimal(textPriceFrom.Text.Trim());
            } catch (Exception ex) { }
            try {
                priceMax = Convert.ToDecimal(textPriceTo.Text.Trim());
            } catch (Exception ex) { }

            //formMain.mainForm.FunctionSummoner(37, category: "Šumnik");
            formMainAdmin.mainForm.FunctionSummoner(41, category:"Light", technicalDescription: technicalDescription, priceMin: priceMin, priceMax: priceMax);
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

        private void lightsData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex < 0) { return; }
            AutoPart autoPart = (AutoPart)(lightsData.Rows[e.RowIndex].DataBoundItem);
            
            if (lightViewForm != null) {
                lightViewForm.Close();
            }
            lightViewForm = new LightViewFormAdmin(autoPart);
            lightViewForm.Show();
        }
    }
}
