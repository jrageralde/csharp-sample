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
using System.IO;

namespace RoyTekProjectSQL
{
    public partial class frmUserProfile : Form
    {
        public frmUserProfile()
        {
            InitializeComponent();

            this.pkrBirthdate.Format = DateTimePickerFormat.Custom;
            this.pkrBirthdate.CustomFormat = Globals.gdefaultDateFormat;
            
            this.btnSave.Enabled = false;
            this.SetTheme();
        }
        public void SetTheme()
        {
            this.BackColor = Globals.gDialogBackgroundColor;
            this.groupBox2.BackColor = Globals.gDialogBackgroundColor;
            this.pictBoxUser.BackColor = Globals.gDialogBackgroundColor;
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
            this.txtEmail.Focus();
        }

        private void frmUserProfile_RefreshUser()
        {
            String uname = "", uemail = "", ugender = "MALE", usmtphost="", usmtpport="";
            DateTime ubirthdate = Convert.ToDateTime("01/01/1900");

           // frmWait frm = new frmWait(GetUserPhotofromField,
           //    "Loading User Photo...");
           // frm.ShowDialog(this);
            this.GetUserPhotofromField();
            this.frmUserProfile_GetUser(Globals.gIdUser, ref uname, ref uemail,
                ref usmtphost, ref usmtpport,
                ref ubirthdate, ref ugender);

            this.txtLoginName.Text = uname;
            this.txtEmail.Text = uemail;
            this.txtSMTPHOST.Text = usmtphost;
            this.txtSMTPport.Text = usmtpport;

            this.pkrBirthdate.Value = ubirthdate;
            this.cbxGender.SelectedItem = ugender;

            this.btnSave.Enabled = false;

            this.txtEmail.Focus();



        }
        private void frmUserProfile_GetUser(long iduser, ref String loginName,
            ref String email,ref String smtphost, ref String smtpport,
            ref DateTime birthdate, ref String gender)
        {

            if (Globals.glOpenSqlConn())
            {
                SqlCommand cmd = new SqlCommand("spGetUserProfile",
                    Globals.sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@liduser", iduser);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    loginName = reader["loginName"].ToString();
                    email = reader["email"].ToString();
                    smtphost = reader["smtphost"].ToString();
                    smtpport = reader["smtpport"].ToString();

                    birthdate = Globals.glConvertBlankDate(reader["birthdate"].ToString());

                    gender = Globals.glConvertBlankGender(reader["gender"].ToString());

                }
                else csMessageBox.Show("No such User ID:" + iduser.ToString() + " is found!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Globals.glCloseSqlConn();
            
        }

        void GetUserPhotofromField()
        {
            if (Globals.glOpenSqlConn())
            {
                String qrystr = "Select isnull(photo,'') as photo from users where id=" + Globals.gIdUser.ToString();
                SqlCommand cmd = new SqlCommand(qrystr, Globals.sqlconn);

                SqlDataAdapter UserAdapter = new SqlDataAdapter(cmd);

                DataTable UserTable = new DataTable();
                UserAdapter.Fill(UserTable);

                if (UserTable.Rows[0][0] != null)
                {
                    byte[] UserImg = (byte[])UserTable.Rows[0][0];

                    MemoryStream imgstream = new MemoryStream(UserImg);

                    if (imgstream.Length > 0)
                        this.pictBoxUser.Image = Image.FromStream(imgstream);
                }
                UserAdapter.Dispose();
            }
            Globals.glCloseSqlConn();
            
        }
        private Image GetUserImage(byte[] img)
        {
            MemoryStream ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }
        private void frmUserProfile_UpdateUser()
        {
            if (Globals.glOpenSqlConn())
            {
                SqlCommand cmd = new SqlCommand("spUpdateUser", Globals.sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@lidUser", Globals.gIdUser);
                cmd.Parameters.AddWithValue("@lloginName", this.txtLoginName.Text);
                cmd.Parameters.AddWithValue("@lemail", this.txtEmail.Text);
                cmd.Parameters.AddWithValue("@lsmtphost", this.txtSMTPHOST.Text);
                cmd.Parameters.AddWithValue("@lsmtpport", this.txtSMTPport.Text);
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

        private void btnLoadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPhoto = new OpenFileDialog();
            openPhoto.Filter = "Choose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            if (openPhoto.ShowDialog() == DialogResult.OK)
            {
                pictBoxUser.Image = Image.FromFile(openPhoto.FileName);
                this.SavePhototoField();
            }
        }

        private void SavePhototoField()
        {
            MemoryStream ms = new MemoryStream();
            this.pictBoxUser.Image.Save(ms, pictBoxUser.Image.RawFormat);
            byte[] img = ms.ToArray();

            if (Globals.glOpenSqlConn())
            {
                String qrystr = "update users set photo=@img where id =" +
                    Globals.gIdUser.ToString();

                SqlCommand cmd = new SqlCommand(qrystr, Globals.sqlconn);

                cmd.Parameters.Add("@img",SqlDbType.Image ); //MySqlDbType.Blob
                cmd.Parameters["@img"].Value = img;

                if (cmd.ExecuteNonQuery() == 1)
                    csMessageBox.Show("New photo is saved...", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Globals.glCloseSqlConn();
        }
        private void ClearPhototoField()
        {
            if (Globals.glOpenSqlConn())
            {
                String qrystr = "update users set photo=null where id =" +
                    Globals.gIdUser.ToString();

                SqlCommand cmd = new SqlCommand(qrystr, Globals.sqlconn);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.pictBoxUser.Image = null;

                    csMessageBox.Show("User photo is cleared...", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Globals.glCloseSqlConn();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (csMessageBox.Show("User photo is cleared...", "Information",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.ClearPhototoField();
            }
        }

        private frmChangePassword ChangePasswordfrm;
        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            ChangePasswordfrm = new frmChangePassword(Globals.gIdUser,
               Globals.gLoginName);

            ChangePasswordfrm.FormClosed += ChangePasswordfrm_FormClosed;

            ChangePasswordfrm.ShowDialog();
        }

        private void ChangePasswordfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangePasswordfrm.Dispose();
            ChangePasswordfrm = null;
        }
    }
}