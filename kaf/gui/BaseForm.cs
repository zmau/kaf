using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaf.gui {
    public partial class BaseForm : Form {
        public BaseForm() {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e) {
            embedForm(new FItemsEditor());
        }

        private void embedForm(Form frm) {
            while (panel.Controls.Count > 0) panel.Controls[0].Dispose();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            panel.Controls.Add(frm);
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e) {
            embedForm(new FUsersEditor());
        }

        private void grupeArtikalaToolStripMenuItem_Click(object sender, EventArgs e) {
            embedForm(new FItemGroupEditor());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            embedForm(new FItemsEditor());
        }
    }
}
