namespace StudyCenterDesktopUI.Students.UserControls
{
    partial class ucStudentCardWithFilter
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
            this.ucStudentCard1 = new StudyCenterDesktopUI.Students.UserControls.ucStudentCard();
            this.ucFilter1 = new StudyCenterDesktopUI.GeneralUserControls.ucFilter();
            this.SuspendLayout();
            // 
            // ucStudentCard1
            // 
            this.ucStudentCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucStudentCard1.BackColor = System.Drawing.Color.White;
            this.ucStudentCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucStudentCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucStudentCard1.Location = new System.Drawing.Point(0, 137);
            this.ucStudentCard1.Name = "ucStudentCard1";
            this.ucStudentCard1.Size = new System.Drawing.Size(862, 428);
            this.ucStudentCard1.TabIndex = 0;
            this.ucStudentCard1.Load += new System.EventHandler(this.ucStudentCard1_Load);
            // 
            // ucFilter1
            // 
            this.ucFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucFilter1.BackColor = System.Drawing.Color.White;
            this.ucFilter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFilter1.FilterEnabled = true;
            this.ucFilter1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFilter1.Location = new System.Drawing.Point(0, 0);
            this.ucFilter1.Name = "ucFilter1";
            this.ucFilter1.ShowAddPersonButton = true;
            this.ucFilter1.Size = new System.Drawing.Size(862, 121);
            this.ucFilter1.TabIndex = 1;
            this.ucFilter1.TextSearch = "";
            this.ucFilter1.OnFindNumericClick += new System.EventHandler<StudyCenterDesktopUI.GeneralUserControls.ucFilter.FindNumericClickEventArgs>(this.ucFilter1_OnFindNumericClick);
            this.ucFilter1.OnAddClick += new System.EventHandler(this.ucFilter1_OnAddClick);
            // 
            // ucStudentCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.ucStudentCard1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucStudentCardWithFilter";
            this.Size = new System.Drawing.Size(862, 565);
            this.ResumeLayout(false);

        }

        #endregion

        private ucStudentCard ucStudentCard1;
        private GeneralUserControls.ucFilter ucFilter1;
    }
}
