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
    public partial class addadmin : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=librarymanager");
        public addadmin()
        {
            InitializeComponent();
        }
        private void btn1submit_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into admins(name,username,password) values('" + txtname.Text + "','" + txtuname.Text + "','" + txtpass.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("addition successful");
            clear();
            this.Hide();  
            con.Close();
        }
        void clear()
        {
            txtname.Text = txtuname.Text = txtpass.Text = "";
        }
    }
}











