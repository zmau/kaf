using kaf.dal;
using System;
using System.Linq;
using System.Windows.Forms;

namespace kaf.gui {
    public partial class FItemEditor : Form {
        private int itemID;

        public FItemEditor(int itemID) {
            InitializeComponent();
            this.itemID = itemID;
        }

        private void FItemEditor_Load(object sender, EventArgs e) {
            Item artikl = PubContext.getInstance().Items.First(item => item.id == itemID);
            if (artikl != null) {
                txtID.Text = Convert.ToString(artikl.id);
                txtName.Text = artikl.name;
                cmbGroup.Items.AddRange(PubContext.getInstance().ItemGroups.ToArray());
                cmbGroup.SelectedItem = artikl.group;
                cmbType.Items.AddRange(PubContext.getInstance().ItemTypes.ToArray());
                cmbType.SelectedItem = artikl.type;
                cmbMeasureUnit.Items.AddRange(PubContext.getInstance().MeasureUnits.ToArray());
                cmbMeasureUnit.SelectedItem = artikl.measureUnit;
                cbIzbacen.Checked = artikl.izbacen; 
            }
        }
    }
}
