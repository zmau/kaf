using kaf.dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaf.gui
{
    public partial class FUserEditor : Form
    {
        private User userToEdit;
        private bool inEditMode;

        public FUserEditor()
        {
            InitializeComponent();
            //ChangeLanguage("sr-Latn");
            cmbRole.Items.AddRange(PubContext.getInstance().Roles.ToArray());
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
        }
        private void ChangeLanguage(string lang)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FUserEditor));
            foreach (Control c in this.Controls) {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }
        public void loadData(User userToEdit)
        {
            if (userToEdit == null) {
                inEditMode = false;
            }
            else {
                inEditMode = true;
                this.userToEdit = userToEdit;
                txtName.Text = userToEdit.name;
                txtUserName.Text = userToEdit.userName;
                txtCode.Text = userToEdit.cardCode;
                cmbRole.SelectedItem = userToEdit.role;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!inEditMode)
                userToEdit = new User(); 

            userToEdit.name = txtName.Text;
            userToEdit.userName = txtUserName.Text;
            if(!txtPassword.Text.Equals(""))
                userToEdit.password = txtPassword.Text;
            userToEdit.cardCode = txtCode.Text;
            userToEdit.role = (Role)cmbRole.SelectedItem;

            if (!inEditMode)
                PubContext.getInstance().Users.Add(userToEdit);
            try {
                PubContext.getInstance().SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex){
                Exception cause = ex.GetBaseException();
                Console.Write( cause.Data);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
