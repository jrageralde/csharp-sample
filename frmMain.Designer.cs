
namespace RoyTekProjectSQL
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.SystemToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripEditUserProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.LOGoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripEditUserProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripChangeUserPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStriplogoutUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripexit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEMOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.customMessageBoxOKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMessageBoxWarningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMessageBoxYesNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customMessageBoxYesNoCancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.askForAStringDialogBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.askForAPasswordDialogBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.askForADateValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripTop = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnMinimize = new System.Windows.Forms.ToolStripButton();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.btnLockout = new System.Windows.Forms.ToolStripButton();
            this.toolStripBottom = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtUserName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtServer = new System.Windows.Forms.ToolStripTextBox();
            this.askForAnIntegerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.askForADoubleValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.ToolStripTop.SuspendLayout();
            this.toolStripBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemToolItem,
            this.systemToolStripSystem,
            this.toolStripAdmin,
            this.dEMOSToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // SystemToolItem
            // 
            this.SystemToolItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditUserProfile,
            this.toolStripChangePassword,
            this.LOGoutMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.SystemToolItem.Name = "SystemToolItem";
            this.SystemToolItem.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStripEditUserProfile
            // 
            this.toolStripEditUserProfile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEditUserProfile.Image")));
            this.toolStripEditUserProfile.Name = "toolStripEditUserProfile";
            this.toolStripEditUserProfile.Size = new System.Drawing.Size(194, 22);
            this.toolStripEditUserProfile.Text = "&Edit User Profile";
            this.toolStripEditUserProfile.Click += new System.EventHandler(this.toolStripEditUserProfile_Click);
            // 
            // toolStripChangePassword
            // 
            this.toolStripChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("toolStripChangePassword.Image")));
            this.toolStripChangePassword.Name = "toolStripChangePassword";
            this.toolStripChangePassword.Size = new System.Drawing.Size(194, 22);
            this.toolStripChangePassword.Text = "Change User Password";
            this.toolStripChangePassword.Click += new System.EventHandler(this.toolStripChangePassword_Click);
            // 
            // LOGoutMenuItem
            // 
            this.LOGoutMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LOGoutMenuItem.Image")));
            this.LOGoutMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.LOGoutMenuItem.Name = "LOGoutMenuItem";
            this.LOGoutMenuItem.Size = new System.Drawing.Size(194, 22);
            this.LOGoutMenuItem.Text = "&Logout";
            this.LOGoutMenuItem.Click += new System.EventHandler(this.LOGoutMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // systemToolStripSystem
            // 
            this.systemToolStripSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripEditUserProfile,
            this.ToolStripChangeUserPassword,
            this.toolStripMenuItem2,
            this.ToolStriplogoutUser,
            this.ToolStripexit});
            this.systemToolStripSystem.Name = "systemToolStripSystem";
            this.systemToolStripSystem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripSystem.Text = "System";
            // 
            // editToolStripEditUserProfile
            // 
            this.editToolStripEditUserProfile.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripEditUserProfile.Image")));
            this.editToolStripEditUserProfile.Name = "editToolStripEditUserProfile";
            this.editToolStripEditUserProfile.Size = new System.Drawing.Size(194, 22);
            this.editToolStripEditUserProfile.Text = "Edit User Profile";
            this.editToolStripEditUserProfile.Click += new System.EventHandler(this.toolStripEditUserProfile_Click);
            // 
            // ToolStripChangeUserPassword
            // 
            this.ToolStripChangeUserPassword.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripChangeUserPassword.Image")));
            this.ToolStripChangeUserPassword.Name = "ToolStripChangeUserPassword";
            this.ToolStripChangeUserPassword.Size = new System.Drawing.Size(194, 22);
            this.ToolStripChangeUserPassword.Text = "Change User Password";
            this.ToolStripChangeUserPassword.Click += new System.EventHandler(this.toolStripChangePassword_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
            // 
            // ToolStriplogoutUser
            // 
            this.ToolStriplogoutUser.Image = ((System.Drawing.Image)(resources.GetObject("ToolStriplogoutUser.Image")));
            this.ToolStriplogoutUser.Name = "ToolStriplogoutUser";
            this.ToolStriplogoutUser.Size = new System.Drawing.Size(194, 22);
            this.ToolStriplogoutUser.Text = "Logout User";
            this.ToolStriplogoutUser.Click += new System.EventHandler(this.LOGoutMenuItem_Click);
            // 
            // ToolStripexit
            // 
            this.ToolStripexit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripexit.Image")));
            this.ToolStripexit.Name = "ToolStripexit";
            this.ToolStripexit.Size = new System.Drawing.Size(194, 22);
            this.ToolStripexit.Text = "Exit";
            this.ToolStripexit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripAdmin
            // 
            this.toolStripAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.rolesToolStripMenuItem});
            this.toolStripAdmin.Name = "toolStripAdmin";
            this.toolStripAdmin.Size = new System.Drawing.Size(55, 20);
            this.toolStripAdmin.Text = "Admin";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rolesToolStripMenuItem.Image")));
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // dEMOSToolStripMenuItem
            // 
            this.dEMOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.customMessageBoxOKToolStripMenuItem,
            this.customMessageBoxWarningToolStripMenuItem,
            this.customMessageBoxYesNoToolStripMenuItem,
            this.customMessageBoxYesNoCancelToolStripMenuItem,
            this.toolStripSeparator1,
            this.askForAStringDialogBoxToolStripMenuItem,
            this.askForAPasswordDialogBoxToolStripMenuItem,
            this.askForADateValueToolStripMenuItem,
            this.askForAnIntegerToolStripMenuItem,
            this.askForADoubleValueToolStripMenuItem});
            this.dEMOSToolStripMenuItem.Name = "dEMOSToolStripMenuItem";
            this.dEMOSToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.dEMOSToolStripMenuItem.Text = "DEMOS";
            // 
            // progressBarToolStripMenuItem
            // 
            this.progressBarToolStripMenuItem.Name = "progressBarToolStripMenuItem";
            this.progressBarToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.progressBarToolStripMenuItem.Text = "Indeterminate Progress Bar";
            this.progressBarToolStripMenuItem.Click += new System.EventHandler(this.progressBarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(262, 6);
            // 
            // customMessageBoxOKToolStripMenuItem
            // 
            this.customMessageBoxOKToolStripMenuItem.Name = "customMessageBoxOKToolStripMenuItem";
            this.customMessageBoxOKToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.customMessageBoxOKToolStripMenuItem.Text = "Custom Message Box (OK)";
            this.customMessageBoxOKToolStripMenuItem.Click += new System.EventHandler(this.customMessageBoxOKToolStripMenuItem_Click);
            // 
            // customMessageBoxWarningToolStripMenuItem
            // 
            this.customMessageBoxWarningToolStripMenuItem.Name = "customMessageBoxWarningToolStripMenuItem";
            this.customMessageBoxWarningToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.customMessageBoxWarningToolStripMenuItem.Text = "Custom Message Box (Warning)";
            this.customMessageBoxWarningToolStripMenuItem.Click += new System.EventHandler(this.customMessageBoxWarningToolStripMenuItem_Click);
            // 
            // customMessageBoxYesNoToolStripMenuItem
            // 
            this.customMessageBoxYesNoToolStripMenuItem.Name = "customMessageBoxYesNoToolStripMenuItem";
            this.customMessageBoxYesNoToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.customMessageBoxYesNoToolStripMenuItem.Text = "Custom Message Box (YesNo)";
            this.customMessageBoxYesNoToolStripMenuItem.Click += new System.EventHandler(this.customMessageBoxYesNoToolStripMenuItem_Click);
            // 
            // customMessageBoxYesNoCancelToolStripMenuItem
            // 
            this.customMessageBoxYesNoCancelToolStripMenuItem.Name = "customMessageBoxYesNoCancelToolStripMenuItem";
            this.customMessageBoxYesNoCancelToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.customMessageBoxYesNoCancelToolStripMenuItem.Text = "Custom MessageBox (YesNoCancel)";
            this.customMessageBoxYesNoCancelToolStripMenuItem.Click += new System.EventHandler(this.customMessageBoxYesNoCancelToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(262, 6);
            // 
            // askForAStringDialogBoxToolStripMenuItem
            // 
            this.askForAStringDialogBoxToolStripMenuItem.Name = "askForAStringDialogBoxToolStripMenuItem";
            this.askForAStringDialogBoxToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.askForAStringDialogBoxToolStripMenuItem.Text = "Ask for a String Dialog box";
            this.askForAStringDialogBoxToolStripMenuItem.Click += new System.EventHandler(this.askForAStringDialogBoxToolStripMenuItem_Click);
            // 
            // askForAPasswordDialogBoxToolStripMenuItem
            // 
            this.askForAPasswordDialogBoxToolStripMenuItem.Name = "askForAPasswordDialogBoxToolStripMenuItem";
            this.askForAPasswordDialogBoxToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.askForAPasswordDialogBoxToolStripMenuItem.Text = "Ask for  a Password Dialog box";
            this.askForAPasswordDialogBoxToolStripMenuItem.Click += new System.EventHandler(this.askForAPasswordDialogBoxToolStripMenuItem_Click);
            // 
            // askForADateValueToolStripMenuItem
            // 
            this.askForADateValueToolStripMenuItem.Name = "askForADateValueToolStripMenuItem";
            this.askForADateValueToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.askForADateValueToolStripMenuItem.Text = "Ask for a Date Value";
            this.askForADateValueToolStripMenuItem.Click += new System.EventHandler(this.askForADateValueToolStripMenuItem_Click);
            // 
            // ToolStripTop
            // 
            this.ToolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnMinimize,
            this.btnLogout,
            this.btnLockout});
            this.ToolStripTop.Location = new System.Drawing.Point(0, 24);
            this.ToolStripTop.Name = "ToolStripTop";
            this.ToolStripTop.Size = new System.Drawing.Size(800, 43);
            this.ToolStripTop.TabIndex = 1;
            this.ToolStripTop.Text = "toolStripTop";
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.AutoSize = false;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 40);
            this.btnExit.ToolTipText = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 40);
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.ToolTipText = "Minimize";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLogout.AutoSize = false;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(45, 40);
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnLogout.ToolTipText = "Logout User";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLockout
            // 
            this.btnLockout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLockout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLockout.Image = ((System.Drawing.Image)(resources.GetObject("btnLockout.Image")));
            this.btnLockout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLockout.Name = "btnLockout";
            this.btnLockout.Size = new System.Drawing.Size(23, 40);
            this.btnLockout.ToolTipText = "Lock Out";
            this.btnLockout.Click += new System.EventHandler(this.btnLockout_Click);
            // 
            // toolStripBottom
            // 
            this.toolStripBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtUserName,
            this.toolStripLabel2,
            this.txtServer});
            this.toolStripBottom.Location = new System.Drawing.Point(0, 425);
            this.toolStripBottom.Name = "toolStripBottom";
            this.toolStripBottom.Size = new System.Drawing.Size(800, 25);
            this.toolStripBottom.TabIndex = 2;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "User:";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel2.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.AutoSize = false;
            this.txtServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServer.Name = "txtServer";
            this.txtServer.ReadOnly = true;
            this.txtServer.Size = new System.Drawing.Size(200, 25);
            // 
            // askForAnIntegerToolStripMenuItem
            // 
            this.askForAnIntegerToolStripMenuItem.Name = "askForAnIntegerToolStripMenuItem";
            this.askForAnIntegerToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.askForAnIntegerToolStripMenuItem.Text = "Ask for an Integer";
            this.askForAnIntegerToolStripMenuItem.Click += new System.EventHandler(this.askForAnIntegerToolStripMenuItem_Click);
            // 
            // askForADoubleValueToolStripMenuItem
            // 
            this.askForADoubleValueToolStripMenuItem.Name = "askForADoubleValueToolStripMenuItem";
            this.askForADoubleValueToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.askForADoubleValueToolStripMenuItem.Text = "Ask for a Double Value";
            this.askForADoubleValueToolStripMenuItem.Click += new System.EventHandler(this.askForADoubleValueToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripBottom);
            this.Controls.Add(this.ToolStripTop);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "frmMain";
            this.Text = "RoyTek Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ToolStripTop.ResumeLayout(false);
            this.ToolStripTop.PerformLayout();
            this.toolStripBottom.ResumeLayout(false);
            this.toolStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem SystemToolItem;
        private System.Windows.Forms.ToolStripMenuItem LOGoutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ToolStripTop;
        private System.Windows.Forms.ToolStrip toolStripBottom;
        private System.Windows.Forms.ToolStripMenuItem toolStripEditUserProfile;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtUserName;
        private System.Windows.Forms.ToolStripMenuItem dEMOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem progressBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.ToolStripMenuItem toolStripChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customMessageBoxOKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customMessageBoxWarningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customMessageBoxYesNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customMessageBoxYesNoCancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripSystem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripEditUserProfile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripChangeUserPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStriplogoutUser;
        private System.Windows.Forms.ToolStripMenuItem ToolStripexit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtServer;
        private System.Windows.Forms.ToolStripButton btnLockout;
        private System.Windows.Forms.ToolStripButton btnMinimize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem askForAStringDialogBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem askForAPasswordDialogBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem askForADateValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem askForAnIntegerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem askForADoubleValueToolStripMenuItem;
    }
}

