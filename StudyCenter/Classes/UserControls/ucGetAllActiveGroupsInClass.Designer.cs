namespace StudyCenterUI.Classes.UserControls
{
    partial class ucGetAllActiveGroupsInClass
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ucSubList1 = new StudyCenterUI.GeneralUserControls.ucSubList();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowGroupDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.temDeleteGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowAllStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucSubList1
            // 
            this.ucSubList1.BackColor = System.Drawing.Color.White;
            this.ucSubList1.ContextMenuStrip = this.cmsEditProfile;
            this.ucSubList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSubList1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSubList1.Location = new System.Drawing.Point(0, 0);
            this.ucSubList1.Name = "ucSubList1";
            this.ucSubList1.Size = new System.Drawing.Size(865, 283);
            this.ucSubList1.TabIndex = 3;
            this.ucSubList1.Title = "Title";
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowGroupDetails,
            this.toolStripSeparator6,
            this.tsmEditGroup,
            this.temDeleteGroup,
            this.ShowAllStudentsToolStripMenuItem,
            this.AddStudentToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(233, 222);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // tsmShowGroupDetails
            // 
            this.tsmShowGroupDetails.ForeColor = System.Drawing.Color.White;
            this.tsmShowGroupDetails.Image = global::StudyCenterUI.Properties.Resources.show_reservation_32;
            this.tsmShowGroupDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowGroupDetails.Name = "tsmShowGroupDetails";
            this.tsmShowGroupDetails.Size = new System.Drawing.Size(232, 38);
            this.tsmShowGroupDetails.Text = "Show Group Details";
            this.tsmShowGroupDetails.Click += new System.EventHandler(this.tsmShowGroupDetails_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(229, 6);
            // 
            // tsmEditGroup
            // 
            this.tsmEditGroup.ForeColor = System.Drawing.Color.White;
            this.tsmEditGroup.Image = global::StudyCenterUI.Properties.Resources.edit_reservation32;
            this.tsmEditGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditGroup.Name = "tsmEditGroup";
            this.tsmEditGroup.Size = new System.Drawing.Size(232, 38);
            this.tsmEditGroup.Text = "Edit";
            this.tsmEditGroup.Click += new System.EventHandler(this.tsmEditGroup_Click);
            // 
            // temDeleteGroup
            // 
            this.temDeleteGroup.ForeColor = System.Drawing.Color.White;
            this.temDeleteGroup.Image = global::StudyCenterUI.Properties.Resources.delete_reservation_40;
            this.temDeleteGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.temDeleteGroup.Name = "temDeleteGroup";
            this.temDeleteGroup.Size = new System.Drawing.Size(232, 38);
            this.temDeleteGroup.Text = "Delete";
            this.temDeleteGroup.Click += new System.EventHandler(this.temDeleteGroup_Click);
            // 
            // ShowAllStudentsToolStripMenuItem
            // 
            this.ShowAllStudentsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ShowAllStudentsToolStripMenuItem.Image = global::StudyCenterUI.Properties.Resources.subjects_32;
            this.ShowAllStudentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowAllStudentsToolStripMenuItem.Name = "ShowAllStudentsToolStripMenuItem";
            this.ShowAllStudentsToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.ShowAllStudentsToolStripMenuItem.Text = "Show Students";
            this.ShowAllStudentsToolStripMenuItem.Click += new System.EventHandler(this.ShowAllStudentsToolStripMenuItem_Click);
            // 
            // AddStudentToolStripMenuItem
            // 
            this.AddStudentToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.AddStudentToolStripMenuItem.Image = global::StudyCenterUI.Properties.Resources.assign_to_subject_32;
            this.AddStudentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddStudentToolStripMenuItem.Name = "AddStudentToolStripMenuItem";
            this.AddStudentToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.AddStudentToolStripMenuItem.Text = "Add Student";
            this.AddStudentToolStripMenuItem.Click += new System.EventHandler(this.AddStudentToolStripMenuItem_Click);
            // 
            // ucGetAllActiveGroupsInClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucSubList1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucGetAllActiveGroupsInClass";
            this.Size = new System.Drawing.Size(865, 283);
            this.cmsEditProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralUserControls.ucSubList ucSubList1;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmShowGroupDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmEditGroup;
        private System.Windows.Forms.ToolStripMenuItem temDeleteGroup;
        private System.Windows.Forms.ToolStripMenuItem ShowAllStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddStudentToolStripMenuItem;
    }
}
