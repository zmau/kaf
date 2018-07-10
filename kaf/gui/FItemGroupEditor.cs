using kaf.dal;
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
    public partial class FItemGroupEditor : Form {

        Boolean newrow = false;
        public FItemGroupEditor() {
            InitializeComponent();
        }

        private void FItemGroupEditor_Load(object sender, EventArgs e) {
            try {
                var context = new PubContext();
                BindingSource bi = new BindingSource();
                context.ItemGroups.Load();
                bi.DataSource = context.ItemGroups.Local.ToBindingList();
                dataGridView1.DataSource = bi;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Naziv";
                dataGridView1.Columns[2].HeaderText = "Front pozicija";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;

                //add new button column to the DataGridView
                //This column displays a delete icon in each row
                DataGridViewImageColumn btnRemove = new DataGridViewImageColumn();
                btnRemove.Image = Properties.Resources.delete_icon;
                btnRemove.Width = 20;
                btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns.Add(btnRemove);
            }
            catch (NotSupportedException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex == dataGridView1.NewRowIndex) {
                dataGridView1.Columns[0].ReadOnly = false; //enable id column
                newrow = true; //this flag indicates that the user clicks to add a row in the DataGridView
                               //change icon of the new row from delete to save icon
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = Properties.Resources.save_icon;

            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == dataGridView1.NewRowIndex) {
                dataGridView1.Columns[0].ReadOnly = false; //enable id column
                newrow = true; //this flag indicates that the user clicks to add a row in the DataGridView
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = Properties.Resources.save_icon;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0 && newrow != true) //delete icon button is clicked
            {
                int bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Do you want to delete this record?", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) {
                    removeGroup(bid);
                    dataGridView1.Rows.RemoveAt(e.RowIndex); //delete the row from the DataGridView
                }
            }
            else if (e.ColumnIndex == 7 && newrow) //save icon button is clicked
            {
                try {
                    int bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    String name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int frontPosition = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    /*String frontPic = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    int picture = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    int color = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    int type = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    */
                    addGroup(name, frontPosition, "", 1, 1, 1/*frontPic, picture, color, type*/);
                    newrow = false;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = Properties.Resources.delete_icon;
                }
                catch (Exception ex) {
                    MessageBox.Show("Unable to save the record. The problem might come from the following:\n1. Blank fields\n2. Duplicate record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void removeGroup(int id) {
            ItemGroup groupToRemove = PubContext.getInstance().ItemGroups.First(group => group.id == id);
            if (groupToRemove != null) {
                PubContext.getInstance().ItemGroups.Remove(groupToRemove);
                PubContext.getInstance().SaveChanges();
            }
        }

        private void addGroup(String pname, int pfrontPosition, String pfrontPic, int ppicture, int pcolor, int ptype) {
            ItemGroup newGroup = new ItemGroup {
                name = pname,
                frontPosition = pfrontPosition,
                frontPic = pfrontPic,
                picture = ppicture,
                color = pcolor,
                type = ptype
            };
            PubContext.getInstance().ItemGroups.Add(newGroup);
            PubContext.getInstance().SaveChanges();
        }

    }
}
