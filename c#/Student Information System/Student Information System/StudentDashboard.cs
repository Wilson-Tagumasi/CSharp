using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Student_Information_System
{
    public partial class StudentDashboard : Form
    {
        private OleDbConnection conx = new OleDbConnection();
        public StudentDashboard()
        {
            InitializeComponent();
            conx.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Student Information.accdb;
            Persist Security Info=False;";
        }

        private void student_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_userid_Load(object sender, EventArgs e)
        {
            conx.Open();
           // OleDbCommand cmd1 = new OleDbCommand("SELECT User_ID FROM UserAccounts where User_ID='"+global.userid+"'");
           // OleDbDataAdapter dtv = new OleDbDataAdapter(cmd1, conx);
           // DataSet dts = new DataSet();


            //txt_userid.Fill(dts);
        }





       
    }
}
