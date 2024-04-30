namespace StudyCenterDesktopUI.Teachers
{
    partial class frmListTeachers
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbPages = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTeachersList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsEditProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowTeacherDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditTeacher = new System.Windows.Forms.ToolStripMenuItem();
            this.temDeleteTeacher = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmAssignToSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.SubjectsHeTeachesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClassesHeTeachesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEducationLevels = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddStudent = new Guna.UI2.WinForms.Guna2Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachersList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPages
            // 
            this.cbPages.BackColor = System.Drawing.Color.Transparent;
            this.cbPages.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.cbPages.BorderRadius = 17;
            this.cbPages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPages.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbPages.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbPages.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbPages.ForeColor = System.Drawing.Color.Black;
            this.cbPages.ItemHeight = 30;
            this.cbPages.Location = new System.Drawing.Point(915, 256);
            this.cbPages.Name = "cbPages";
            this.cbPages.Size = new System.Drawing.Size(132, 36);
            this.cbPages.TabIndex = 223;
            this.cbPages.SelectedIndexChanged += new System.EventHandler(this.cbPages_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(854, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 222;
            this.label3.Text = "Page:";
            // 
            // dgvTeachersList
            // 
            this.dgvTeachersList.AllowUserToAddRows = false;
            this.dgvTeachersList.AllowUserToDeleteRows = false;
            this.dgvTeachersList.AllowUserToOrderColumns = true;
            this.dgvTeachersList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTeachersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvTeachersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTeachersList.ColumnHeadersHeight = 35;
            this.dgvTeachersList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTeachersList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTeachersList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTeachersList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvTeachersList.Location = new System.Drawing.Point(15, 298);
            this.dgvTeachersList.Name = "dgvTeachersList";
            this.dgvTeachersList.ReadOnly = true;
            this.dgvTeachersList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTeachersList.RowTemplate.Height = 33;
            this.dgvTeachersList.ShowCellToolTips = false;
            this.dgvTeachersList.Size = new System.Drawing.Size(1318, 415);
            this.dgvTeachersList.TabIndex = 221;
            this.dgvTeachersList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTeachersList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTeachersList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTeachersList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvTeachersList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvTeachersList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTeachersList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTeachersList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTeachersList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTeachersList.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvTeachersList.ThemeStyle.ReadOnly = true;
            this.dgvTeachersList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvTeachersList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTeachersList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tsmShowTeacherDetails,
            this.toolStripSeparator6,
            this.tsmEditTeacher,
            this.temDeleteTeacher,
            this.toolStripMenuItem1,
            this.tsmAssignToSubject,
            this.SubjectsHeTeachesToolStripMenuItem,
            this.ClassesHeTeachesToolStripMenuItem});
            this.cmsEditProfile.Name = "contextMenuStrip1";
            this.cmsEditProfile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsEditProfile.Size = new System.Drawing.Size(243, 266);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // tsmShowTeacherDetails
            // 
            this.tsmShowTeacherDetails.ForeColor = System.Drawing.Color.White;
            this.tsmShowTeacherDetails.Image = global::StudyCenterDesktopUI.Properties.Resources.show_reservation_32;
            this.tsmShowTeacherDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmShowTeacherDetails.Name = "tsmShowTeacherDetails";
            this.tsmShowTeacherDetails.Size = new System.Drawing.Size(242, 38);
            this.tsmShowTeacherDetails.Text = "Show Teacher Details";
            this.tsmShowTeacherDetails.Click += new System.EventHandler(this.tsmShowTeacherDetails_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(239, 6);
            // 
            // tsmEditTeacher
            // 
            this.tsmEditTeacher.ForeColor = System.Drawing.Color.White;
            this.tsmEditTeacher.Image = global::StudyCenterDesktopUI.Properties.Resources.edit_reservation32;
            this.tsmEditTeacher.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmEditTeacher.Name = "tsmEditTeacher";
            this.tsmEditTeacher.Size = new System.Drawing.Size(242, 38);
            this.tsmEditTeacher.Text = "Edit";
            this.tsmEditTeacher.Click += new System.EventHandler(this.tsmEditTeacher_Click);
            // 
            // temDeleteTeacher
            // 
            this.temDeleteTeacher.ForeColor = System.Drawing.Color.White;
            this.temDeleteTeacher.Image = global::StudyCenterDesktopUI.Properties.Resources.delete_reservation_40;
            this.temDeleteTeacher.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.temDeleteTeacher.Name = "temDeleteTeacher";
            this.temDeleteTeacher.Size = new System.Drawing.Size(242, 38);
            this.temDeleteTeacher.Text = "Delete";
            this.temDeleteTeacher.Click += new System.EventHandler(this.temDeleteTeacher_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(239, 6);
            // 
            // tsmAssignToSubject
            // 
            this.tsmAssignToSubject.ForeColor = System.Drawing.Color.White;
            this.tsmAssignToSubject.Image = global::StudyCenterDesktopUI.Properties.Resources.assign_to_subject_32;
            this.tsmAssignToSubject.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmAssignToSubject.Name = "tsmAssignToSubject";
            this.tsmAssignToSubject.Size = new System.Drawing.Size(242, 38);
            this.tsmAssignToSubject.Text = "Assign To Subject";
            this.tsmAssignToSubject.Click += new System.EventHandler(this.tsmAssignToSubject_Click);
            // 
            // SubjectsHeTeachesToolStripMenuItem
            // 
            this.SubjectsHeTeachesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SubjectsHeTeachesToolStripMenuItem.Image = global::StudyCenterDesktopUI.Properties.Resources.subjects_32;
            this.SubjectsHeTeachesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SubjectsHeTeachesToolStripMenuItem.Name = "SubjectsHeTeachesToolStripMenuItem";
            this.SubjectsHeTeachesToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.SubjectsHeTeachesToolStripMenuItem.Text = "Subjects he Teaches";
            this.SubjectsHeTeachesToolStripMenuItem.Click += new System.EventHandler(this.SubjectsHeTeachesToolStripMenuItem_Click);
            // 
            // ClassesHeTeachesToolStripMenuItem
            // 
            this.ClassesHeTeachesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ClassesHeTeachesToolStripMenuItem.Image = global::StudyCenterDesktopUI.Properties.Resources.assign_to_subject_32;
            this.ClassesHeTeachesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ClassesHeTeachesToolStripMenuItem.Name = "ClassesHeTeachesToolStripMenuItem";
            this.ClassesHeTeachesToolStripMenuItem.Size = new System.Drawing.Size(242, 38);
            this.ClassesHeTeachesToolStripMenuItem.Text = "Classes he Teaches";
            this.ClassesHeTeachesToolStripMenuItem.Click += new System.EventHandler(this.GroupsHeTeachesToolStripMenuItem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderColor = System.Drawing.Color.Gray;
            this.txtSearch.BorderRadius = 17;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.txtSearch.Location = new System.Drawing.Point(334, 256);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(273, 36);
            this.txtSearch.TabIndex = 217;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.cbFilter.BorderRadius = 17;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Teacher ID",
            "Name",
            "Gender",
            "Education Level",
            "Age"});
            this.cbFilter.Location = new System.Drawing.Point(93, 256);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(218, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 220;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.Transparent;
            this.cbGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.cbGender.BorderRadius = 17;
            this.cbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbGender.ForeColor = System.Drawing.Color.Black;
            this.cbGender.ItemHeight = 30;
            this.cbGender.Items.AddRange(new object[] {
            "All",
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(334, 256);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(118, 36);
            this.cbGender.StartIndex = 0;
            this.cbGender.TabIndex = 218;
            this.cbGender.Visible = false;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(113, 720);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 215;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 720);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 214;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 213;
            this.label1.Text = "Filter By:";
            // 
            // cbEducationLevels
            // 
            this.cbEducationLevels.BackColor = System.Drawing.Color.Transparent;
            this.cbEducationLevels.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.cbEducationLevels.BorderRadius = 17;
            this.cbEducationLevels.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEducationLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEducationLevels.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbEducationLevels.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(41)))), ((int)(((byte)(123)))));
            this.cbEducationLevels.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbEducationLevels.ForeColor = System.Drawing.Color.Black;
            this.cbEducationLevels.ItemHeight = 30;
            this.cbEducationLevels.Location = new System.Drawing.Point(334, 256);
            this.cbEducationLevels.Name = "cbEducationLevels";
            this.cbEducationLevels.Size = new System.Drawing.Size(260, 36);
            this.cbEducationLevels.TabIndex = 219;
            this.cbEducationLevels.Visible = false;
            this.cbEducationLevels.SelectedIndexChanged += new System.EventHandler(this.cbEducationLevels_SelectedIndexChanged);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Checked = true;
            this.btnAddStudent.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddStudent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddStudent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddStudent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddStudent.FillColor = System.Drawing.Color.White;
            this.btnAddStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddStudent.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddStudent.Image = global::StudyCenterDesktopUI.Properties.Resources.add_student;
            this.btnAddStudent.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnAddStudent.ImageSize = new System.Drawing.Size(45, 45);
            this.btnAddStudent.Location = new System.Drawing.Point(1281, 247);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(50, 45);
            this.btnAddStudent.TabIndex = 224;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::StudyCenterDesktopUI.Properties.Resources.teachers_list;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(499, 42);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(325, 169);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 216;
            this.pbImage.TabStop = false;
            // 
            // frmListTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 797);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.cbPages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvTeachersList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEducationLevels);
            this.Controls.Add(this.pbImage);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListTeachers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Teachers";
            this.Text = "frmListTeachers";
            this.Load += new System.EventHandler(this.frmListTeachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachersList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddStudent;
        private Guna.UI2.WinForms.Guna2ComboBox cbPages;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTeachersList;
        private System.Windows.Forms.ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmShowTeacherDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmEditTeacher;
        private System.Windows.Forms.ToolStripMenuItem temDeleteTeacher;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbEducationLevels;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmAssignToSubject;
        private System.Windows.Forms.ToolStripMenuItem SubjectsHeTeachesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClassesHeTeachesToolStripMenuItem;
    }
}