using kaf.dal;
using kaf.dbFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaf.gui {
    public partial class FItemsEditor : Form {
        public FItemsEditor() {
            InitializeComponent();
        }

        private void FItemsEditor_Load(object sender, EventArgs e) {
            var context = new PubContext();
            
            BindingSource bi = new BindingSource();
            context.Items.Load();
            bi.DataSource = context.ItemGroups.Local.ToBindingList();

            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn2.HeaderText = "Naziv";

            groupColumn.HeaderText = "Grupa";
            groupColumn.DataSource = context.ItemGroups.ToList();
            groupColumn.DisplayMember = "name";
            groupColumn.ValueMember = "Id";
            groupColumn.DataPropertyName = "group_Id";

            typeColumn.HeaderText = "Tip";
            typeColumn.DataSource = context.ItemTypes.ToList();
            typeColumn.DisplayMember = "name";
            typeColumn.ValueMember = "Id";
            typeColumn.DataPropertyName = "type_Id";

            measureUnitColumn.HeaderText = "JM";
            measureUnitColumn.DataSource = context.MeasureUnits.ToList();
            measureUnitColumn.DisplayMember = "name";
            measureUnitColumn.ValueMember = "Id";
            measureUnitColumn.DataPropertyName = "measureUnit_Id";

            dataGridViewTextBoxColumn6.Visible = false;

            dataGridViewTextBoxColumn7.HeaderText = "Cena 1";
            dataGridViewTextBoxColumn8.HeaderText = "Cena 2";
        }
        private void itemsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) {

        }

        private void itemsDataGridView_MouseDoubleClick(object sender, MouseEventArgs e) {
           
        }

        private void itemsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            //itemsDataGridView.Rows[e.RowIndex]
            List<Item> itemList = (List<Item>)itemsBindingSource.DataSource;
            
        }
    }
}
