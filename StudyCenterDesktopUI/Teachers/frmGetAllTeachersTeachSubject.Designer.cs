namespace StudyCenterDesktopUI.Teachers
{
    partial class frmGetAllTeachersTeachSubject
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnAddTeacher = new Guna.UI2.WinForms.Guna2Button();
            this.ucGetAllTeachersTeachSubject1 = new StudyCenterDesktopUI.Teachers.UserControls.ucGetAllTeachersTeachSubject();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.lblTitle.Location = new System.Drawing.Point(1, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(883, 66);
            this.lblTitle.TabIndex = 211;
            this.lblTitle.Text = "Teachers Teach a Subject";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 20;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.btnClose.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(43)))), ((int)(((byte)(71)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::StudyCenterDesktopUI.Properties.Resources.close_48;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(720, 438);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(155, 45);
            this.btnClose.TabIndex = 219;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddTeacher
            // 
            this.btnAddTeacher.Checked = true;
            this.btnAddTeacher.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddTeacher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTeacher.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTeacher.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTeacher.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddTeacher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddTeacher.FillColor = System.Drawing.Color.White;
            this.btnAddTeacher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddTeacher.ForeColor = System.Drawing.Color.White;
            this.btnAddTeacher.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddTeacher.Image = global::StudyCenterDesktopUI.Properties.Resources.add_teacher;
            this.btnAddTeacher.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnAddTeacher.ImageSize = new System.Drawing.Size(45, 45);
            this.btnAddTeacher.Location = new System.Drawing.Point(823, 95);
            this.btnAddTeacher.Name = "btnAddTeacher";
            this.btnAddTeacher.Size = new System.Drawing.Size(50, 45);
            this.btnAddTeacher.TabIndex = 225;
            this.btnAddTeacher.Click += new System.EventHandler(this.btnAddTeacher_Click);
            // 
            // ucGetAllTeachersTeachSubject1
            // 
            this.ucGetAllTeachersTeachSubject1.BackColor = System.Drawing.Color.White;
            this.ucGetAllTeachersTeachSubject1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGetAllTeachersTeachSubject1.Location = new System.Drawing.Point(8, 146);
            this.ucGetAllTeachersTeachSubject1.Name = "ucGetAllTeachersTeachSubject1";
            this.ucGetAllTeachersTeachSubject1.Size = new System.Drawing.Size(865, 283);
            this.ucGetAllTeachersTeachSubject1.TabIndex = 212;
            // 
            // frmGetAllTeachersTeachSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 489);
            this.Controls.Add(this.btnAddTeacher);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucGetAllTeachersTeachSubject1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmGetAllTeachersTeachSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Teachers Teach Subject";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private UserControls.ucGetAllTeachersTeachSubject ucGetAllTeachersTeachSubject1;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2Button btnAddTeacher;
    }
}