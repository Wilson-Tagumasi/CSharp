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
    public partial class LoginForm : Form
    {

        private OleDbConnection conx = new OleDbConnection();
        public LoginForm()
        {
            InitializeComponent();

            //This line of code initiates the connection with database
            conx.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Student Information.accdb;
            Persist Security Info=False;";
        }

        private void lik_reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this code display the registration form
            pn_register.Height = pn_login.Height;
            pn_login.Location = new Point(5, 5);
            pn.Location = new Point(349, 9);
            pn_register.Location = new Point(9, 9);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            //this code will close the registration form and display the login form
            pn_register.Height = 0;
            pn_login.Location = new Point(349, 5);
            pn.Location = new Point(5, 5);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            //this is the code for the login button where it select and validate the username and password from the database
            conx.Open();//opening a database connection
            OleDbCommand cmd1 = new OleDbCommand();
            string login = "SELECT * FROM UserAccounts WHERE username = '"+txt_username.Text+"' and password='"+txt_password.Text+"'";
            cmd1 = new OleDbCommand(login, conx);
            OleDbDataReader dr = cmd1.ExecuteReader();
            OleDbDataAdapter dta = new OleDbDataAdapter(cmd1);
            DataTable dtbl = new DataTable();
            //dtbl.Fill(dtbl);
           // global.userid = Convert.ToString
            if (dr.Read() == true)
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again","Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Text = "";
                txt_password.Text = "";
                txt_username.Focus(); 
            }
            conx.Close();//closing the database connection

        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            //If condition for the registration where it validates if the username or password fields are empty
            if (reg_username.Text == "" && reg_password.Text == "" && reg_password.Text == "")
            {
                MessageBox.Show("Username and Password fields are Empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                //Else if condition that will validate if the password fields are match
            else if (reg_password.Text == reg_password.Text)
            {
                conx.Open();
                OleDbCommand cmd = new OleDbCommand();
                string register = "INSERT INTO UserAccounts VALUES('" + reg_username.Text + "','" + reg_password.Text + "','" + id_number.Text+ "')";
                cmd = new OleDbCommand(register, conx);
                cmd.ExecuteReader();
                conx.Close();

                MessageBox.Show("Account Successfully Created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
                //Else condition if passwords are match and fields are filled 
            {
                MessageBox.Show("Passwords Does not match.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reg_password.Text= "";
                reg_password.Text = "";
                reg_password.Focus();
            }
        }












       
    }


}
