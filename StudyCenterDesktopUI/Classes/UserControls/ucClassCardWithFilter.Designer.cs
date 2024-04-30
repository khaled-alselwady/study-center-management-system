namespace StudyCenterDesktopUI.Classes.UserControls
{
    partial class ucClassCardWithFilter
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
            this.ucFilter1 = new StudyCenterDesktopUI.GeneralUserControls.ucFilter();
            this.ucClassCard1 = new StudyCenterDesktopUI.Classes.UserControls.ucClassCard();
            this.SuspendLayout();
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
            this.ucFilter1.TabIndex = 2;
            this.ucFilter1.TextSearch = "";
            this.ucFilter1.OnFindNumericClick += new System.EventHandler<StudyCenterDesktopUI.GeneralUserControls.ucFilter.FindNumericClickEventArgs>(this.ucFilter1_OnFindNumericClick);
            this.ucFilter1.OnAddClick += new System.EventHandler(this.ucFilter1_OnAddClick);
            // 
            // ucClassCard1
            // 
            this.ucClassCard1.BackColor = System.Drawing.Color.White;
            this.ucClassCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucClassCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucClassCard1.Location = new System.Drawing.Point(0, 140);
            this.ucClassCard1.Name = "ucClassCard1";
            this.ucClassCard1.Size = new System.Drawing.Size(862, 196);
            this.ucClassCard1.TabIndex = 3;
            this.ucClassCard1.Load += new System.EventHandler(this.ucClassCard1_Load);
            // 
            // ucClassCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucClassCard1);
            this.Controls.Add(this.ucFilter1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucClassCardWithFilter";
            this.Size = new System.Drawing.Size(862, 336);
            this.ResumeLayout(false);

        }

        #endregion

        private GeneralUserControls.ucFilter ucFilter1;
        private ucClassCard ucClassCard1;
    }
}
