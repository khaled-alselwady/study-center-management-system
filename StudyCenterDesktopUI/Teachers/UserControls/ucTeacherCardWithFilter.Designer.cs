namespace StudyCenterDesktopUI.Teachers.UserControls
{
    partial class ucTeacherCardWithFilter
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
            this.ucTeacherCard1 = new StudyCenterDesktopUI.Teachers.UserControls.ucTeacherCard();
            this.ucFilter1 = new StudyCenterDesktopUI.GeneralUserControls.ucFilter();
            this.SuspendLayout();
            // 
            // ucTeacherCard1
            // 
            this.ucTeacherCard1.BackColor = System.Drawing.Color.White;
            this.ucTeacherCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucTeacherCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTeacherCard1.Location = new System.Drawing.Point(0, 139);
            this.ucTeacherCard1.Name = "ucTeacherCard1";
            this.ucTeacherCard1.Size = new System.Drawing.Size(862, 504);
            this.ucTeacherCard1.TabIndex = 0;
            this.ucTeacherCard1.Load += new System.EventHandler(this.ucTeacherCard1_Load);
            // 
            // ucFilter1
            // 
            this.ucFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucFilter1.BackColor = System.Drawing.Color.White;
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
            // ucTeacherCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.ucTeacherCard1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucTeacherCardWithFilter";
            this.Size = new System.Drawing.Size(862, 643);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTeacherCard ucTeacherCard1;
        private GeneralUserControls.ucFilter ucFilter1;
    }
}
