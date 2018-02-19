using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace librarymanager
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=librarymanager");
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1submit_Click(object sender, EventArgs e)
        {   if (txtusername.Text == "" || txtpass.Text == "")
                MessageBox.Show("please fill mandatory fields");
            else if (txtpass.Text != txtcpass.Text)
                MessageBox.Show("passwords donot match");
        else
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into user(firstname,lastname,reg_no,contact,address,username,password) values('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtreg.Text + "','" + txtcontact.Text + "','" + txtaddress.Text + "','" + txtusername.Text + "','" + txtpass.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("registration successful");
            clear();
            con.Close();
        }
        void clear()
        {
            txtfirstname.Text = txtlastname.Text = txtreg.Text = txtcontact.Text = txtaddress.Text = txtusername.Text = txtpass.Text = txtcpass.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
