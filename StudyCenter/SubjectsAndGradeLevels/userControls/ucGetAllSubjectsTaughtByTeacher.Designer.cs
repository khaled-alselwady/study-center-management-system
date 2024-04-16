namespace StudyCenter.SubjectsAndGradeLevels.userControls
{
    partial class ucGetAllSubjectsTaughtByTeacher
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
            this.ShowDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucSubList1 = new StudyCenter.GeneralUserControls.ucSubList();
            this.cmsEditProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailsToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(185, 42);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // ShowDetailsToolStripMenuItem
            // 
            this.ShowDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ShowDetailsToolStripMenuItem.Image = global::StudyCenter.Properties.Resources.show_reservation_32;
            this.ShowDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowDetailsToolStripMenuItem.Name = "ShowDetailsToolStripMenuItem";
            this.ShowDetailsToolStripMenuItem.Size = new System.Drawing.Size(184, 38);
            this.ShowDetailsToolStripMenuItem.Text = "Show Details";
            this.ShowDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowDetailsToolStripMenuItem_Click);
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
            // ucGetAllSubjectsTaughtByTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucSubList1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucGetAllSubjectsTaughtByTeacher";
            this.Size = new System.Drawing.Size(865, 283);
            this.cmsEditProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsToolStripMenuItem;
        private GeneralUserControls.ucSubList ucSubList1;
    }
}
