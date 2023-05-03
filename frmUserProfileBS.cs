using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;

namespace RoyTekProjectSQL
{
    public partial class frmUserProfileBS : Form
    {
        public frmUserProfileBS()
        {
            InitializeComponent();
            this.btnSave.Enabled = false;
        }
        private void txtLoginName_KeyDown(object sender, KeyEventArgs e)
        {
            this.btnSave.Enabled = true; ;
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true; // PUT THE DING OFF
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }
        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            this.frmUserProfile_RefreshUser();
            
            this.txtLoginName.Focus();
        }
        private void frmUserProfile_RefreshUser()
        {
            this.frmUserProfile_GetUser(Globals.gIdUser);

            this.btnSave.Enabled = false;

            this.txtLoginName.Focus();
        }

        private SqlDataAdapter sqldaUserProfile;
        DataTable UserTable;
        private void frmUserProfile_GetUser(long iduser)
        {
            if (Globals.glOpenSqlConn())
            {
                String qrystr;
                qrystr = "select loginName,email," +
                    "isnull(birthdate,\"1900/01/01\") as birthdate,"+
                    "isnull(gender,\"FEMALE\") as gender " +
                    "from users where id="
                     + Globals.gIdUser.ToString();

                SqlCommand cmd = new SqlCommand(qrystr, Globals.sqlconn);

                sqldaUserProfile = null;
                sqldaUserProfile = new SqlDataAdapter();

                UserTable = null;
                UserTable = new DataTable();
                UserTable.Rows.Clear();

                SqlCommandBuilder cmdbuilder = new SqlCommandBuilder();

                cmdbuilder.DataAdapter = sqldaUserProfile;
                sqldaUserProfile.SelectCommand = cmd;

                sqldaUserProfile.Fill(UserTable);
                UserTable.AcceptChanges();

                this.txtLoginName.DataBindings.Clear();
                this.txtLoginName.DataBindings.Add("Text", UserTable, "loginName",
                     false, DataSourceUpdateMode.OnPropertyChanged);

                this.txtEmail.DataBindings.Clear();
                this.txtEmail.DataBindings.Add("Text", UserTable, "email",
                    false, DataSourceUpdateMode.OnPropertyChanged);

                this.pkrBirthdate.DataBindings.Clear();
                this.pkrBirthdate.DataBindings.Add("Value", UserTable, "birthdate",
                    false, DataSourceUpdateMode.OnPropertyChanged);

                this.cbxGender.DataBindings.Clear();
                this.cbxGender.DataBindings.Add("Text", UserTable, "gender",
                    false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }
        private void frmUserProfile_UpdateUser()
        {
            /* this approach still does not work */
            /* Option #1
            CurrencyManager DataBindingManager
                = (CurrencyManager) this.BindingContext[sqldaUserProfile];
            DataBindingManager.EndCurrentEdit();

            if(UserTable.GetChanges()!=null)
            {
                sqldaUserProfile.Update(UserTable);
            }
             End of Option 1 */

            if (Globals.glOpenSqlConn())
            {

                SqlCommand cmd = new SqlCommand("spUpdateUser", Globals.sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@lidUser", Globals.gIdUser);
                cmd.Parameters.AddWithValue("@lloginName", this.txtLoginName.Text);
                cmd.Parameters.AddWithValue("@lemail", this.txtEmail.Text);
                cmd.Parameters.AddWithValue("@lbirthdate",
                     Globals.glConvertBlankDate(this.pkrBirthdate.Value.ToString()));
                cmd.Parameters.AddWithValue("@lgender",
                    Globals.glConvertBlankGender(this.cbxGender.SelectedItem.ToString()));
                cmd.ExecuteNonQuery();
            }
            Globals.glCloseSqlConn();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.frmUserProfile_RefreshUser();        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtLoginName.Text.Trim() == "")
            {
                csMessageBox.Show("Please provide a valid login name.", "Empty Login Name",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.frmUserProfile_UpdateUser();
               
                this.btnSave.Enabled = false;
                Globals.gLoginName = this.txtLoginName.Text;
            }
                 
        }
        private void frmUserProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.btnSave.Enabled)
            {
                DialogResult dr;

                dr = csMessageBox.Show("Changes not saved! Save changes", "Please confirm.",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (dr)
                {   
                    case DialogResult.Yes:
                        if (this.txtLoginName.Text.Trim() == "")
                        {
                            csMessageBox.Show("Please provide a valid login name.", "Empty Login Name",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            this.txtLoginName.Focus();

                        }
                        else
                        {
                            this.frmUserProfile_UpdateUser();
                            Globals.glCloseSqlConn();

                            Globals.gLoginName = this.txtLoginName.Text;

                        }
                       break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                } 
            }
        }

        private void pkrBirthdate_ValueChanged(object sender, EventArgs e)
        {
            this.btnSave.Enabled = true; ;

            if (this.GetNextControl(ActiveControl, true) != null)
            {

                this.GetNextControl(ActiveControl, true).Focus();
            }
        }
    }
}
