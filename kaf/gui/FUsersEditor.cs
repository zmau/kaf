using kaf.dal;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace kaf.gui
{
    public partial class FUsersEditor : Form
    {
        public FUsersEditor()
        {
            try {
                InitializeComponent();
                PubContext pubContext = PubContext.getInstance();
                pubContext.Users.Load();
                gridUsers.DataSource = pubContext.Users.Local.ToBindingList();
                Show();
            }
            catch(SqlException e) {
                Console.WriteLine(e.StackTrace.ToString());
                throw e;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FUserEditor fUserEditor = new FUserEditor();
            fUserEditor.loadData(null);
            fUserEditor.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editSelectedUser();
        }

        private void gridUsers_DoubleClick(object sender, EventArgs e)
        {
            editSelectedUser();
        }

        private void editSelectedUser()
        {
            FUserEditor fUserEditor = new FUserEditor();
            User selectedUser = (User)gridUsers.SelectedRows[0].DataBoundItem;
            fUserEditor.loadData(selectedUser);
            fUserEditor.ShowDialog();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            gridUsers.DataSource = new BindingList<User>(
                PubContext.getInstance().Users.Local.ToBindingList().Where(
                user => user.name.StartsWith(txtSearchBox.Text)
                ).ToList<User>()
            );
        }
    }
}
