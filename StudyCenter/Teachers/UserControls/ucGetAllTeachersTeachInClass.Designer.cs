namespace StudyCenter.Teachers.UserControls
{
    partial class ucGetAllTeachersTeachInClass
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTeachersList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowTeacherDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowClassDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowGroupDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachersList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.lblNumberOfRecords);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.dgvTeachersList);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(865, 283);
            this.guna2GroupBox1.TabIndex = 5;
            this.guna2GroupBox1.Text = "Teachers Teach in Class";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(111, 258);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 211;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 210;
            this.label2.Text = "# Records:";
            // 
            // dgvTeachersList
            // 
            this.dgvTeachersList.AllowUserToAddRows = false;
            this.dgvTeachersList.AllowUserToDeleteRows = false;
            this.dgvTeachersList.AllowUserToOrderColumns = true;
            this.dgvTeachersList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeachersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvTeachersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvTeachersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeachersList.ColumnHeadersHeight = 35;
            this.dgvTeachersList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeachersList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeachersList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTeachersList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvTeachersList.Location = new System.Drawing.Point(12, 53);
            this.dgvTeachersList.Name = "dgvTeachersList";
            this.dgvTeachersList.ReadOnly = true;
            this.dgvTeachersList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeachersList.RowTemplate.Height = 33;
            this.dgvTeachersList.ShowCellToolTips = false;
            this.dgvTeachersList.Size = new System.Drawing.Size(834, 202);
            this.dgvTeachersList.TabIndex = 209;
            this.dgvTeachersList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTeachersList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachersList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvTeachersList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvTeachersList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTeachersList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTeachersList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTeachersList.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvTeachersList.ThemeStyle.ReadOnly = true;
            this.dgvTeachersList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvTeachersList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTeachersList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTeachersList.ThemeStyle.RowsStyle.Height = 33;
            this.dgvTeachersList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            this.dgvTeachersList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTeachersList.DoubleClick += new System.EventHandler(this.dgvTeachersList_DoubleClick);
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
            // ucGetAllTeachersTeachInClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2GroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucGetAllTeachersTeachInClass";
            this.Size = new System.Drawing.Size(865, 283);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachersList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTeachersList;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowTeacherDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowClassDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowGroupDetailsToolStripMenuItem;
    }
}
