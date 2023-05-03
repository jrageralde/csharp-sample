using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyTekProjectSQL
{

    public partial class frmMain : Form
    {
        frmLogin fm;   // login form
        public frmMain()
        {
            InitializeComponent();
            Globals.glInitializeVariables();    
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bool mustchangepwd = false;

            Globals.glInitializeVariables();
            this.fm = new frmLogin();
         
            if (this.fm.ShowDialog() == DialogResult.Abort)
                this.Close();

            if (Globals.gLoginName != null)
            {
                this.txtUserName.Text = Globals.gLoginName;
            }

            if (Globals.gdbServerName != null)
            {
                this.txtServer.Text =  Globals.gdbServerName;
            }
            
            this.glSetSizeToDesktop();
            this.BringToFront();

            Globals.glUserMustChangePwd(Globals.gIdUser, ref mustchangepwd);

            if (mustchangepwd)
            {
                csMessageBox.Show("You are advised to change password",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.toolStripChangePassword.PerformClick();

                Globals.glRemoveMustChangePwd(Globals.gIdUser);
            }
              
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (csMessageBox.Show("Exit from this application?", "Please confirm.",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               this.Close();
            }
        }
        private void LOGoutMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dgResult;

            this.fm = new frmLogin();
           
            dgResult=this.fm.ShowDialog();

            if (dgResult == DialogResult.Abort)
                this.Close();

            if (dgResult == DialogResult.OK) 
            { 
                if (Globals.gLoginName != null)
                   this.txtUserName.Text = Globals.gLoginName;

                if (Globals.gdbServerName != null)
                   this.txtServer.Text = Globals.gdbServerName;
            }

            this.glSetSizeToDesktop();
            this.BringToFront();
        }

        void TestDelay()
        {
            Thread.Sleep(10000);
        }
     
        private void progressBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmWait frm = new frmWait(TestDelay, "Test delay..."))
            {
                frm.ShowDialog(this);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.exitToolStripMenuItem.PerformClick();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.LOGoutMenuItem.PerformClick();
        }

        private frmUserProfile UserProfilefrm;
        private void toolStripEditUserProfile_Click(object sender, EventArgs e)
        {
            if (UserProfilefrm == null)
            {
                UserProfilefrm = new frmUserProfile();
                UserProfilefrm.MdiParent = this;

                UserProfilefrm.FormClosed += UserProfilefrm_FormClosed;

                UserProfilefrm.Show();
            }
            else UserProfilefrm.Activate();

            this.txtUserName.Text = Globals.gLoginName;

        }

        private void UserProfilefrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserProfilefrm = null;
            
            this.txtUserName.Text = Globals.gLoginName;
        }

        public void updatetxtusername(String uname)
        {
            this.txtUserName.Text = Globals.gLoginName;
        }


        private frmChangePassword ChangePasswordfrm;

        private void toolStripChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordfrm = new frmChangePassword(Globals.gIdUser,Globals.gLoginName);
            ChangePasswordfrm.FormClosed += ChangePasswordfrm_FormClosed;

            ChangePasswordfrm.ShowDialog();
        }

        private void ChangePasswordfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangePasswordfrm = null;
        }

        private void customMessageBoxOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csMessageBox.Show("This a sample OK Message Box.", "Information",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void customMessageBoxWarningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csMessageBox.Show("This a sample Warning Message Box.", "Warning",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void customMessageBoxYesNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csMessageBox.Show("This a sample YesNo Message Box.", "Please confirm.",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void customMessageBoxYesNoCancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            csMessageBox.Show("This a sample YesNoCancel Message Box.", "Please confirm.",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private frmUsers Usersfrm;
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Usersfrm == null)
            {
                Usersfrm = new frmUsers();
                Usersfrm.MdiParent = this;

                Usersfrm.FormClosed += Usersfrm_FormClosed;

                Usersfrm.Show();
            }
            else Usersfrm.Activate();
        }


        private void Usersfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Usersfrm = null;
        }

        private frmUserProfileBS UserProfileBSfrm;
        private void toolStripUserProfile2_Click(object sender, EventArgs e)
        {
            if (UserProfileBSfrm == null)
            {
                UserProfileBSfrm = new frmUserProfileBS();
                UserProfileBSfrm.MdiParent = this;

                UserProfileBSfrm.FormClosed += UserProfileBSfrm_FormClosed;
                UserProfileBSfrm.Show();
            }
            else UserProfileBSfrm.Activate();

            this.txtUserName.Text = Globals.gLoginName;
        }

        private void UserProfileBSfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserProfileBSfrm = null;
            this.txtUserName.Text = Globals.gLoginName;

        }

        private frmRoles Rolesfrm;

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] RolestoUse= new String[] { "ADMINISTRATOR" };

            if (Globals.gCheckUserRole(Globals.gIdUser,ref RolestoUse))
            {
                if (Rolesfrm == null)
                {
                    Rolesfrm = new frmRoles();
                    Rolesfrm.MdiParent = this;

                    Rolesfrm.FormClosed += Rolesfrm_FormClosed;
                    Rolesfrm.Show();
                }
                else Rolesfrm.Activate();

            }
            else csMessageBox.Show("You are not allowed to use this portion.",
              "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Rolesfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Rolesfrm = null;
        }

        public void DisposeAllChildren(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != form)
                {
                    frm.Dispose();
                    frm.Close();
                }
            }
            return;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globals.sqlconn!=null) Globals.glCloseSqlConn();
        }

        private frmLockout fm2;
        private void btnLockout_Click(object sender, EventArgs e)
        {
            DialogResult dgResult;

            this.fm2 = new frmLockout(Globals.gLoginName);
            
            dgResult=this.fm2.ShowDialog();

            if (dgResult == DialogResult.Abort)
                this.Close();

            if ((dgResult == DialogResult.OK) && (Globals.gLoginName != null))
            {
                //this.txtUserName.Text = Globals.gLoginName;
                this.txtServer.Text = Globals.gdbServerName;
            }

            this.glSetSizeToDesktop();
            this.BringToFront();

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void askForAStringDialogBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            String retvalue="";

            rs = AskDialog.AskString("Sample String", "Please type a value.", ref retvalue);
        }

        private void askForAPasswordDialogBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            String retvalue = "";

            rs = AskDialog.AskPassword("Please type a password.", ref retvalue);

        }

        private void askForADateValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            DateTime retvalue = DateTime.Now;

            rs = AskDialog.AskDate("Please type a date value.", ref retvalue);
        }

        private void askForAnIntegerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            long retvalue = 0;

            rs = AskDialog.AskInt("Please type an integer value .",0, ref retvalue);


            csMessageBox.Show("The integer encoded is:" + retvalue.ToString("N0"), "Result",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void askForADoubleValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs;
            double retvalue = 0;

            rs = AskDialog.AskFloat("Please type a float value .","N4", 23323.232, ref retvalue);

            csMessageBox.Show("The float encoded is:" + retvalue.ToString("N4"), "Result",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
