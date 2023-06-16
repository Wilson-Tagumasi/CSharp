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
    public partial class Form1 : Form
    {
        private OleDbConnection conx = new OleDbConnection();
        public Form1()
        {
            //This line of code initiates the connection with database
            InitializeComponent();
            conx.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Student Information.accdb;
            Persist Security Info=False;";
        }
        String getgender;
        private void button1_Click(object sender, EventArgs e)
        {
            //adding student info to the database
            try
            {
                
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photo = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo, 0, photo.Length);

                conx.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conx;
                cmd.CommandText = "INSERT INTO Student(Student_ID, FName, Minitial, LName, Age, Gender, Address, YrLevel, Student_Sec, Picture)values('" + student_id.Text + "','" + fname.Text + "','" + mi.Text + "','" + lname.Text + "','" + txt_age.Text + "','" + getgender + "','" + txt_address.Text + "','" + cmb_yrlvl.Text + "','" + cmb_section.Text + "', @pic)";

                cmd.Parameters.AddWithValue("@pic", photo);
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.ExecuteReader();
                conx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fname_Enter(object sender, EventArgs e)
        {
            if (fname.Text == "First Name")
            {
                fname.Text = "";
                fname.ForeColor = Color.Black;
            }
        }

        private void fname_Leave(object sender, EventArgs e)
        {
            if (mi.Text == "")
            {
                fname.Text = "First Name";
                fname.ForeColor = Color.LightGray;
            }
        }

        private void mi_Enter(object sender, EventArgs e)
        {
            if (mi.Text == "MI")
            {
                mi.Text = "";
                mi.ForeColor = Color.Black;
            }
        }

        private void mi_Leave(object sender, EventArgs e)
        {
            if (mi.Text == "")
            {
                mi.Text = "MI";
                mi.ForeColor = Color.LightGray;
            }
        }

        private void lname_Enter(object sender, EventArgs e)
        {
            if (lname.Text == "Last Name")
            {
                lname.Text = "";
                lname.ForeColor = Color.Black;
            }
        }

        private void lname_Leave(object sender, EventArgs e)
        {
            if (lname.Text == "")
            {
                lname.Text = "Last Name";
                lname.ForeColor = Color.LightGray;
            }
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            //this is for uploading image to the picturebox
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            getgender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            getgender = "Female";
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            //code to display the student data to the data grid view
            try
            {
                string txt = "select Student_ID as STUDENT_ID, FName as FIRST_NAME, Minitial as INITIAL, LName as LAST_NAME, Age as AGE, Gender as GENDER, Address as ADDRESS, YrLevel as YEAR_LEVEL, Student_Sec as SECTION_, Picture as PHOTO from [Student]";
                OleDbDataAdapter dtv = new OleDbDataAdapter(txt, conx);
                DataSet dts = new DataSet();

                dtv.Fill(dts);
                data_view.DataSource = dts.Tables[0];

            }
            catch (Exception x)
            {
                MessageBox.Show(x + "");
            }
        }





    }
}
