using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyTekProjectSQL
{
    public partial class frmRoles : Form
    {
        DataTable DTable;
        SqlDataAdapter DAdapter;
        SqlCommandBuilder DCommandBuilder;
        BindingSource DBindingSource;

        int idcolumn = 2;

        public frmRoles()
        {
            InitializeComponent();
           
            SetTheme();
            this.BindMainGrid();
            this.InitializeMainGrid();
            this.dgvMain.Focus();
            
        }
        public void InitializeMainGrid()
        {
             this.dgvMain.Columns[idcolumn].Visible = false;
        }
        public void BindMainGrid()
        {
            if (Globals.glOpenSqlConn())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Globals.sqlconn;

                cmd.CommandText = "select name,description,id from roles order by name;";

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
        }

        public void SetTheme()
        {
            this.BackColor = Globals.gDialogBackgroundColor;

            this.dgvMain.BackgroundColor = Globals.gGridOddRowColor;
            this.dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Globals.gGridEvenRowColor;

            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Globals.gGridHeaderColor;    
                    
        }
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            // use the following if you are using a Binding Source 
            // attach this to a save button
            // DataTable changes = ((DataTable)dgvMain.DataSource).GetChanges();

            // if (changes!=null)
            // {
            //    DAdapter.Update(DTable);
            //}
        }
         private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (this.dgvMain.CurrentRow!=null)
            {
                if (Globals.glOpenSqlConn())
                {

                    DataGridViewRow row = dgvMain.CurrentRow;

                    String rolename = row.Cells["name"].Value == DBNull.Value ? ""
                        : row.Cells["name"].Value.ToString().ToUpper();
                    String roledescription = row.Cells["description"].Value == DBNull.Value ? ""
                        : row.Cells["description"].Value.ToString();
                    if (row.Cells["name"].Value == DBNull.Value)
                    {
                        csMessageBox.Show("Please encode a valid role name", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvMain.CancelEdit();
                        
                    } else
                    {
                        try
                        {

                            SqlCommand cmd = new SqlCommand("sprolesAddEdit", Globals.sqlconn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            long idval = row.Cells[this.idcolumn].Value == DBNull.Value
                                 ? 0 : Convert.ToInt64(row.Cells[this.idcolumn].Value);

                            if (row.Cells[this.idcolumn].Value == DBNull.Value)
                            {
                                cmd.Parameters.AddWithValue("@rid", 0);
                              
                            }
                            else
                                cmd.Parameters.AddWithValue("@rid",
                                    Convert.ToInt64(row.Cells[this.idcolumn].Value));

                            cmd.Parameters.AddWithValue("@rname", rolename);
                            cmd.Parameters.AddWithValue("@rdescription", roledescription);
                            cmd.ExecuteNonQuery();
                           // if (idval == 0)
                            //    this.SearchName(rolename);

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
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindMainGrid();
            this.dgvMain.Focus();
        }

        private bool deleteRow()
        {
            bool cancel = true;

            DataGridViewRow row = this.dgvMain.CurrentRow;
            String rname = row.Cells["name"].Value.ToString().Trim();
           
           
                if (row.Cells[idcolumn].Value != DBNull.Value &&
                  csMessageBox.Show("Delete the role:" + rname, "Please confirm.",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Globals.glOpenSqlConn())
                    {

                        SqlCommand cmd = new SqlCommand("sprolesDelete", Globals.sqlconn);
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
            e.Cancel = deleteRow();
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
                     if (row.Cells["name"].Value.ToString().StartsWith(searchVal))
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
                this.btnSearch.PerformClick(); //Select();

            } else if (e.KeyCode == Keys.Escape)
            {
                this.txtSearch.Clear();
                this.dgvMain.Focus();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtSearch.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.btnRefresh.PerformClick();
        }

        private void dgvMain_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(
                    String.Format("{0,8}",(e.RowIndex + 1).ToString()),
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
            dgvMain.RowHeadersWidth = rowHeaderWitdh + 35;

        }
    }
}
