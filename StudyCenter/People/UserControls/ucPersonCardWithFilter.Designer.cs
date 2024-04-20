namespace StudyCenterUI.People.UserControls
{
    partial class ucPersonCardWithFilter
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucPersonCard1 = new StudyCenterUI.People.UserControls.ucPersonCard();
            this.ucFilter1 = new StudyCenterUI.GeneralUserControls.ucFilter();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucPersonCard1
            // 
            this.ucPersonCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucPersonCard1.BackColor = System.Drawing.Color.White;
            this.ucPersonCard1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucPersonCard1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPersonCard1.Location = new System.Drawing.Point(0, 136);
            this.ucPersonCard1.Name = "ucPersonCard1";
            this.ucPersonCard1.Size = new System.Drawing.Size(862, 276);
            this.ucPersonCard1.TabIndex = 147;
            this.ucPersonCard1.Load += new System.EventHandler(this.ucPersonCard1_Load);
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
            this.ucFilter1.TabIndex = 148;
            this.ucFilter1.TextSearch = "";
            this.ucFilter1.OnFindNumericClick += new System.EventHandler<StudyCenterUI.GeneralUserControls.ucFilter.FindNumericClickEventArgs>(this.ucFilter1_OnFindNumericClick);
            this.ucFilter1.OnAddClick += new System.EventHandler(this.ucFilter1_OnAddClick);
            // 
            // ucPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucFilter1);
            this.Controls.Add(this.ucPersonCard1);
            this.Name = "ucPersonCardWithFilter";
            this.Size = new System.Drawing.Size(862, 412);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ucPersonCard ucPersonCard1;
        private GeneralUserControls.ucFilter ucFilter1;
    }
}
