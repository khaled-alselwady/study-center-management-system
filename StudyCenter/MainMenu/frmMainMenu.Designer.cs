namespace StudyCenterUI.MainMenu
{
    partial class frmMainMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelChildForms = new Guna.UI2.WinForms.Guna2Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.bntSubjects = new Guna.UI2.WinForms.Guna2Button();
            this.btnStudents = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnClasses = new Guna.UI2.WinForms.Guna2Button();
            this.btnGroups = new Guna.UI2.WinForms.Guna2Button();
            this.btnTeachers = new Guna.UI2.WinForms.Guna2Button();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbImgaeSlide = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.panelChildForms.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgaeSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1562, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 824);
            this.panel1.TabIndex = 22;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this.panelChildForms;
            // 
            // panelChildForms
            // 
            this.panelChildForms.BackColor = System.Drawing.Color.White;
            this.panelChildForms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.panelChildForms.BorderRadius = 10;
            this.panelChildForms.Controls.Add(this.panelTitle);
            this.panelChildForms.Location = new System.Drawing.Point(218, 21);
            this.panelChildForms.Name = "panelChildForms";
            this.panelChildForms.Size = new System.Drawing.Size(1343, 797);
            this.panelChildForms.TabIndex = 23;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1343, 50);
            this.panelTitle.TabIndex = 22;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(-5, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1349, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "HOME";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.panelMenu.Controls.Add(this.bntSubjects);
            this.panelMenu.Controls.Add(this.btnStudents);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btnClasses);
            this.panelMenu.Controls.Add(this.btnGroups);
            this.panelMenu.Controls.Add(this.btnTeachers);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Controls.Add(this.pbImgaeSlide);
            this.panelMenu.Controls.Add(this.btnLogOut);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 15);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(218, 824);
            this.panelMenu.TabIndex = 20;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(218, 124);
            this.panelLogo.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 47);
            this.label1.TabIndex = 7;
            this.label1.Text = "Study";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(123, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Center";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1573, 15);
            this.panel2.TabIndex = 21;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(218, 824);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1344, 15);
            this.panel3.TabIndex = 19;
            // 
            // bntSubjects
            // 
            this.bntSubjects.BackColor = System.Drawing.Color.Transparent;
            this.bntSubjects.BorderRadius = 22;
            this.bntSubjects.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.bntSubjects.CheckedState.FillColor = System.Drawing.Color.White;
            this.bntSubjects.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.bntSubjects.CheckedState.Image = global::StudyCenterUI.Properties.Resources.subjects_blue_64;
            this.bntSubjects.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bntSubjects.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bntSubjects.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bntSubjects.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bntSubjects.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.bntSubjects.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSubjects.ForeColor = System.Drawing.Color.White;
            this.bntSubjects.Image = global::StudyCenterUI.Properties.Resources.subjects_white_64;
            this.bntSubjects.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bntSubjects.ImageOffset = new System.Drawing.Point(-5, 0);
            this.bntSubjects.ImageSize = new System.Drawing.Size(40, 40);
            this.bntSubjects.Location = new System.Drawing.Point(0, 360);
            this.bntSubjects.Name = "bntSubjects";
            this.bntSubjects.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bntSubjects.Size = new System.Drawing.Size(218, 43);
            this.bntSubjects.TabIndex = 29;
            this.bntSubjects.Text = "Subjects";
            this.bntSubjects.UseTransparentBackground = true;
            this.bntSubjects.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.bntSubjects.Click += new System.EventHandler(this.bntSubjects_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.Transparent;
            this.btnStudents.BorderRadius = 22;
            this.btnStudents.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnStudents.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnStudents.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnStudents.CheckedState.Image = global::StudyCenterUI.Properties.Resources.students_blue_64;
            this.btnStudents.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStudents.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStudents.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStudents.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStudents.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnStudents.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Image = global::StudyCenterUI.Properties.Resources.students_white_64;
            this.btnStudents.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStudents.ImageSize = new System.Drawing.Size(35, 35);
            this.btnStudents.Location = new System.Drawing.Point(0, 220);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnStudents.Size = new System.Drawing.Size(218, 43);
            this.btnStudents.TabIndex = 21;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseTransparentBackground = true;
            this.btnStudents.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderRadius = 22;
            this.btnSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSettings.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnSettings.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnSettings.CheckedState.Image = global::StudyCenterUI.Properties.Resources.settings_blue_64;
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::StudyCenterUI.Properties.Resources.settings_white_64;
            this.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.ImageOffset = new System.Drawing.Point(-1, 0);
            this.btnSettings.ImageSize = new System.Drawing.Size(35, 35);
            this.btnSettings.Location = new System.Drawing.Point(0, 570);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(218, 43);
            this.btnSettings.TabIndex = 18;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseTransparentBackground = true;
            this.btnSettings.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.BackColor = System.Drawing.Color.Transparent;
            this.btnClasses.BorderRadius = 22;
            this.btnClasses.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnClasses.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnClasses.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnClasses.CheckedState.Image = global::StudyCenterUI.Properties.Resources.classes_blue_64;
            this.btnClasses.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClasses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClasses.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClasses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClasses.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnClasses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClasses.ForeColor = System.Drawing.Color.White;
            this.btnClasses.Image = global::StudyCenterUI.Properties.Resources.classes_white_64;
            this.btnClasses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClasses.ImageOffset = new System.Drawing.Point(-5, 0);
            this.btnClasses.ImageSize = new System.Drawing.Size(50, 50);
            this.btnClasses.Location = new System.Drawing.Point(0, 430);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClasses.Size = new System.Drawing.Size(218, 43);
            this.btnClasses.TabIndex = 23;
            this.btnClasses.Text = "Classes";
            this.btnClasses.UseTransparentBackground = true;
            this.btnClasses.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.BackColor = System.Drawing.Color.Transparent;
            this.btnGroups.BorderRadius = 22;
            this.btnGroups.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGroups.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnGroups.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnGroups.CheckedState.Image = global::StudyCenterUI.Properties.Resources.groups_blue_64;
            this.btnGroups.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGroups.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGroups.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGroups.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGroups.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnGroups.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroups.ForeColor = System.Drawing.Color.White;
            this.btnGroups.Image = global::StudyCenterUI.Properties.Resources.groups_white_64;
            this.btnGroups.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGroups.ImageOffset = new System.Drawing.Point(-1, 0);
            this.btnGroups.ImageSize = new System.Drawing.Size(35, 35);
            this.btnGroups.Location = new System.Drawing.Point(0, 500);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGroups.Size = new System.Drawing.Size(218, 43);
            this.btnGroups.TabIndex = 20;
            this.btnGroups.Text = "Groups";
            this.btnGroups.UseTransparentBackground = true;
            this.btnGroups.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnGroups.Click += new System.EventHandler(this.btnGroups_Click);
            // 
            // btnTeachers
            // 
            this.btnTeachers.BackColor = System.Drawing.Color.Transparent;
            this.btnTeachers.BorderRadius = 22;
            this.btnTeachers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTeachers.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTeachers.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnTeachers.CheckedState.Image = global::StudyCenterUI.Properties.Resources.teachers_blue_64;
            this.btnTeachers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTeachers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTeachers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTeachers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTeachers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnTeachers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeachers.ForeColor = System.Drawing.Color.White;
            this.btnTeachers.Image = global::StudyCenterUI.Properties.Resources.teachers_white_64;
            this.btnTeachers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTeachers.ImageSize = new System.Drawing.Size(35, 35);
            this.btnTeachers.Location = new System.Drawing.Point(0, 290);
            this.btnTeachers.Name = "btnTeachers";
            this.btnTeachers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTeachers.Size = new System.Drawing.Size(218, 43);
            this.btnTeachers.TabIndex = 22;
            this.btnTeachers.Text = "Teachers";
            this.btnTeachers.UseTransparentBackground = true;
            this.btnTeachers.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnTeachers.Click += new System.EventHandler(this.btnTeachers_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BorderRadius = 22;
            this.btnDashboard.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDashboard.Checked = true;
            this.btnDashboard.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnDashboard.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnDashboard.CheckedState.Image = global::StudyCenterUI.Properties.Resources.dashboard_blue_64;
            this.btnDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDashboard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::StudyCenterUI.Properties.Resources.dashboard_white_64;
            this.btnDashboard.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDashboard.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDashboard.Location = new System.Drawing.Point(0, 150);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(218, 43);
            this.btnDashboard.TabIndex = 17;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseTransparentBackground = true;
            this.btnDashboard.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Image = global::StudyCenterUI.Properties.Resources.study_center_white_125;
            this.pictureBox2.Location = new System.Drawing.Point(5, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pbImgaeSlide
            // 
            this.pbImgaeSlide.BackColor = System.Drawing.Color.Transparent;
            this.pbImgaeSlide.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbImgaeSlide.Image = global::StudyCenterUI.Properties.Resources.ImageSlide;
            this.pbImgaeSlide.Location = new System.Drawing.Point(183, 130);
            this.pbImgaeSlide.Name = "pbImgaeSlide";
            this.pbImgaeSlide.Size = new System.Drawing.Size(38, 84);
            this.pbImgaeSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImgaeSlide.TabIndex = 10;
            this.pbImgaeSlide.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BorderRadius = 22;
            this.btnLogOut.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLogOut.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnLogOut.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnLogOut.CheckedState.Image = global::StudyCenterUI.Properties.Resources.logout_blue_64;
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = global::StudyCenterUI.Properties.Resources.logout_white_64;
            this.btnLogOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogOut.ImageOffset = new System.Drawing.Point(-1, 0);
            this.btnLogOut.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogOut.Location = new System.Drawing.Point(0, 773);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(218, 43);
            this.btnLogOut.TabIndex = 28;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseTransparentBackground = true;
            this.btnLogOut.CheckedChanged += new System.EventHandler(this.btn_CheckedChanged);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1573, 839);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelChildForms);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainMenu";
            this.panelChildForms.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgaeSlide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnStudents;
        private System.Windows.Forms.Panel panelMenu;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnClasses;
        private Guna.UI2.WinForms.Guna2Button btnGroups;
        private Guna.UI2.WinForms.Guna2Button btnTeachers;
        private Guna.UI2.WinForms.Guna2Button btnDashboard;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbImgaeSlide;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Panel panelChildForms;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button bntSubjects;
    }
}