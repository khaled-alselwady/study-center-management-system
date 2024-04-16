namespace StudyCenter.Groups.UserControls
{
    partial class ucGroupsAreTaughtByTeacher
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
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowTeacherDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowClassDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowGroupDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucSubList1 = new StudyCenter.GeneralUserControls.ucSubList();
            this.cmsEditProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowTeacherDetailsToolStripMenuItem,
            this.ShowClassDetailsToolStripMenuItem,
            this.ShowGroupDetailsToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(243, 118);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // ShowTeacherDetailsToolStripMenuItem
            // 
            this.ShowTeacherDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ShowTeacherDetailsToolStripMenuItem.Image = global::StudyCenter.Properties.Resources.show_reservation_32;
            this.ShowTeacherDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowTeacherDetailsToolStripMenuItem.Name = "ShowTeacherDetailsToolStripMenuItem";
            this.ShowTeacherDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.ShowTeacherDetailsToolStripMenuItem.Text = "Show Teacher Details";
            this.ShowTeacherDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowTeacherDetailsToolStripMenuItem_Click);
            // 
            // ShowClassDetailsToolStripMenuItem
            // 
            this.ShowClassDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ShowClassDetailsToolStripMenuItem.Image = global::StudyCenter.Properties.Resources.subjects_32;
            this.ShowClassDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowClassDetailsToolStripMenuItem.Name = "ShowClassDetailsToolStripMenuItem";
            this.ShowClassDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.ShowClassDetailsToolStripMenuItem.Text = "Show Class Details";
            this.ShowClassDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowClassDetailsToolStripMenuItem_Click);
            // 
            // ShowGroupDetailsToolStripMenuItem
            // 
            this.ShowGroupDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ShowGroupDetailsToolStripMenuItem.Image = global::StudyCenter.Properties.Resources.assign_to_subject_32;
            this.ShowGroupDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowGroupDetailsToolStripMenuItem.Name = "ShowGroupDetailsToolStripMenuItem";
            this.ShowGroupDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.ShowGroupDetailsToolStripMenuItem.Text = "Show Group Details";
            this.ShowGroupDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowGroupDetailsToolStripMenuItem_Click);
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
            this.ucSubList1.TabIndex = 1;
            this.ucSubList1.Title = "Title";
            // 
            // ucGroupsAreTaughtByTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucSubList1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucGroupsAreTaughtByTeacher";
            this.Size = new System.Drawing.Size(865, 283);
            this.cmsEditProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowTeacherDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowClassDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowGroupDetailsToolStripMenuItem;
        private GeneralUserControls.ucSubList ucSubList1;
    }
}
