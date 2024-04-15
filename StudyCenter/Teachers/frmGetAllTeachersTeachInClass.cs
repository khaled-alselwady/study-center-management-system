﻿using System;
using System.Windows.Forms;

namespace StudyCenter.Teachers
{
    public partial class frmGetAllTeachersTeachInClass : Form
    {
        public frmGetAllTeachersTeachInClass(int? classID)
        {
            InitializeComponent();

            ucGetAllTeachersTeachInClass1.LoadAllTeachersTeachSubject(classID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
