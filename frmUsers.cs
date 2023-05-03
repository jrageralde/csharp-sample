using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
//using MySql.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace RoyTekProjectSQL
{
    public partial class frmUsers : Form
    {
        DataTable DTable;
        //DataSet DTable;
        SqlDataAdapter DAdapter;
        SqlCommandBuilder DCommandBuilder;
        BindingSource DBindingSource;
        int idcolumn = 0;
        public frmUsers()
        {
            InitializeComponent();
            SetTheme();
            BindMainGrid();
            InitializeMainGrid();
            SetTheme();

            this.dgvMain.Focus();

        }

        public void SetTheme()
        {
            this.BackColor = Globals.gDialogBackgroundColor;

            this.dgvMain.BackgroundColor = Globals.gGridOddRowColor;
            this.dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Globals.gGridEvenRowColor;

            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Globals.gGridHeaderColor;

        }
        public void InitializeMainGrid()
        {
            this.dgvMain.Columns[idcolumn].Visible = false;
            this.dgvMain.Columns[idcolumn].ReadOnly = true;
            this.dgvMain.Columns[idcolumn].HeaderText = "User ID";
            this.dgvMain.Columns[idcolumn].Width = 50;

            this.dgvMain.Columns["loginname"].HeaderText = "Login Name";
            this.dgvMain.Columns["active"].HeaderText = " Active";
            this.dgvMain.Columns["active"].Width = 40;

            this.dgvMain.Columns["mustchangepwd"].HeaderText = "Must Change Password";
            this.dgvMain.Columns["mustchangepwd"].Width = 60;

            this.dgvMain.Columns["email"].HeaderText = "                            User Email";
            this.dgvMain.Columns["email"].Width = 300;

            this.dgvMain.Columns["gender"].HeaderText = "  Gender";
            this.dgvMain.Columns["gender"].Width = 80;
            this.dgvMain.Columns["gender"].ReadOnly = true;

            this.dgvMain.Columns["smtphost"].Visible=false;
            this.dgvMain.Columns["smtpport"].Visible = false;
            // this.dgvMain.Columns["gender"] = cmbGender;

            this.dgvMain.Columns["birthdate"].HeaderText = "   Birth Date";
           // this.dgvMain.Columns["birthdate"].ReadOnly = true;

        }
        public void BindMainGrid()
        {
            if (Globals.glOpenSqlConn())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Globals.sqlconn;

                cmd.CommandText = "spGetAllUsers";
                cmd.CommandType = CommandType.StoredProcedure;

               // cmd.CommandText ="select id, loginname, active, mustchangepwd, email, " +
               //        "gender, birthdate "+
               //        "from users order by loginname";

                DTable = new DataTable();
                DAdapter = new SqlDataAdapter();
                DCommandBuilder = new SqlCommandBuilder();

                DCommandBuilder.DataAdapter = DAdapter;

                DAdapter.SelectCommand = cmd;
                DAdapter.Fill(DTable);

                DBindingSource = new BindingSource();

                DBindingSource.DataSource = DTable;

                bindingNavigator1.BindingSource = DBindingSource;

                dgvMain.DataSource = DBindingSource;// DTABLE if fields are bounded;
            }
            Globals.glCloseSqlConn();

           // this.setRowNumbers();

        }

        private void setRowNumbers()
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }

            dgvMain.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

        }
        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            long userid =0;

            if (this.dgvMain.CurrentRow != null)
            {
                if (Globals.glOpenSqlConn())
                {

                    DataGridViewRow row = dgvMain.CurrentRow;

                    String uloginname = row.Cells["loginname"].Value == DBNull.Value ? ""
                        : row.Cells["loginname"].Value.ToString().ToUpper();
                    //int uactive = row.Cells["active"].Value == DBNull.Value ? 0
                    //    : Convert.ToInt32(row.Cells["active"].Value);
                    int uactive = row.Cells["active"].Value == DBNull.Value
                         ? 0 : Convert.ToInt32(row.Cells["active"].Value);

                    int umustchangepwd = row.Cells["mustchangepwd"].Value == DBNull.Value
                        ? 0 : Convert.ToInt32(row.Cells["mustchangepwd"].Value);

                    String uemail = row.Cells["email"].Value == DBNull.Value ? ""
                        : row.Cells["email"].Value.ToString();
                  
                  
                    if (row.Cells["loginname"].Value == DBNull.Value)
                    {
                        csMessageBox.Show("Please encode a valid user name", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvMain.CancelEdit();

                    }
                    else
                    {
                        try
                        {

                            SqlCommand cmd = new SqlCommand("spusersAddEdit", Globals.sqlconn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            if (row.Cells[this.idcolumn].Value == DBNull.Value)
                               userid = 0;
                            else
                               userid=Convert.ToInt64(row.Cells[this.idcolumn].Value);

                            cmd.Parameters.AddWithValue("@uid", userid);

                            cmd.Parameters.AddWithValue("@uloginname", uloginname);
                            cmd.Parameters.AddWithValue("@uactive", uactive);
                            cmd.Parameters.AddWithValue("@umustchangepwd", umustchangepwd);
                            cmd.Parameters.AddWithValue("@uemail", uemail);
                    
                           // CustomMessageBox.ShowMessage("uid:"+userid+" birthdate:"+ubirthdate
                           //     , "Warning",
                            // MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmd.ExecuteNonQuery();

                          //  if (userid == 0)
                            //    this.SearchName(uloginname);

                        }
                        catch (Exception ex)
                        {

                            csMessageBox.Show("Exception Error:" + ex.Message,
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    Globals.glCloseSqlConn();
                    //this.BindMainGrid();

                }
                Globals.glCloseSqlConn();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindMainGrid();
            this.dgvMain.Focus();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.btnRefresh.PerformClick();
        }

        private Boolean SearchName(String searchVal)
        {
            bool resultVal = false;
            int rowIndex = -1;

            searchVal = searchVal.Trim().ToUpper();
            if (searchVal != "")
            {
                this.bindingNavigator1.MoveFirstItem.PerformClick();

                foreach (DataGridViewRow row in dgvMain.Rows)
                {
                    try
                    {
                        if (row.Cells["loginname"].Value.ToString().StartsWith(searchVal))
                        {
                            rowIndex = row.Index;
                            dgvMain.Rows[row.Index].Selected = true;
                            resultVal = true;
                            break;
                        }
                        this.bindingNavigator1.MoveNextItem.PerformClick();
                    }
                    catch
                    {
                        break;
                    }
                } // foreach
                if (!resultVal)
                    csMessageBox.Show("Record not found.", "Search Result",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);

            } // if
            return resultVal;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String searchVal = txtSearch.Text.Trim().ToUpper();

            if (this.SearchName(searchVal))
            {
                this.txtSearch.Clear();
                this.dgvMain.Focus();

            }
            else
            {
                this.txtSearch.Focus();
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                this.btnSearch.PerformClick(); //.Select();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                // CustomMessageBox.ShowMessage("Escape key is pressed", "Result",
                //     MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSearch.Clear();
                this.dgvMain.Focus();
            }
        }

        private frmEditUser EditUserfrm; 
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            long userid;
            DataGridViewRow row = dgvMain.CurrentRow;

            if (row.Cells[this.idcolumn].Value == DBNull.Value)
                userid = 0;
            else
                userid = Convert.ToInt64(row.Cells[this.idcolumn].Value);

            if (userid != 0)
            {
                EditUserfrm = new frmEditUser(userid);
                EditUserfrm.MdiParent = this.MdiParent;
                EditUserfrm.Show();
            }
       
        }

        private void dgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(
                    String.Format("{0,10}", (e.RowIndex + 1).ToString()),
                    e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
           }

        }

        private void dgvMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int firstDisplayedCellIndex = dgvMain.FirstDisplayedCell.RowIndex;
            int lastDisplayedCellIndex = firstDisplayedCellIndex + dgvMain.DisplayedRowCount(true);

            Graphics Graphics = dgvMain.CreateGraphics();
            int measureFirstDisplayed = (int)(Graphics.MeasureString(firstDisplayedCellIndex.ToString(), dgvMain.Font).Width);
            int measureLastDisplayed = (int)(Graphics.MeasureString(lastDisplayedCellIndex.ToString(), dgvMain.Font).Width);

            int rowHeaderWitdh = System.Math.Max(measureFirstDisplayed, measureLastDisplayed);
            dgvMain.RowHeadersWidth = rowHeaderWitdh + 40;
        }

        private bool deleteRow()
        {
            bool cancel = true;

            DataGridViewRow row = this.dgvMain.CurrentRow;
            String name = row.Cells["loginname"].Value.ToString().Trim();

            if (row.Cells[idcolumn].Value != DBNull.Value &&
               csMessageBox.Show("Delete the user:" + name, "Please confirm.",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Globals.glOpenSqlConn())
                {

                    SqlCommand cmd = new SqlCommand("dbo.spusersDelete", Globals.sqlconn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rid", Convert.ToInt64(row.Cells[idcolumn].Value));
                    cmd.ExecuteNonQuery();

                    cancel = false;

                }
                Globals.glCloseSqlConn();
            }
            return cancel;
        }
        private void dgvMain_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = this.deleteRow();            
           
        }

        private frmUserEmail UserEmailfrm;
        private void tspChangePassword_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvMain.CurrentRow;
            String lname = row.Cells["loginname"].Value.ToString().Trim();
            String lemail = row.Cells["email"].Value.ToString().Trim();

            UserEmailfrm = new frmUserEmail(lname,lemail);
            UserEmailfrm.MdiParent = this.MdiParent;
            
            UserEmailfrm.FormClosed += UserEmailfrm_FormClosed;

            UserEmailfrm.Show(); //ShowDialog();
        }

        private void UserEmailfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserEmailfrm = null;
        }

        private frmChangePassword ChangePasswordfrm;
        private void tspChangePassword_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dgvMain.CurrentRow;
            long liduser = int.Parse(row.Cells[idcolumn].Value.ToString());
            String lname = row.Cells["loginname"].Value.ToString().Trim();

            ChangePasswordfrm = new frmChangePassword(liduser, lname);

            ChangePasswordfrm.FormClosed += ChangePasswordfrm_FormClosed;

            ChangePasswordfrm.ShowDialog();
        }

        private void ChangePasswordfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangePasswordfrm=null;
        }
    }

}
