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
    public partial class studentlogin : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=librarymanager");
        int count = 0;
        public studentlogin()
        {
            InitializeComponent();
        }

        private void adminlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from user where username= '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("username and password doesnot match");

            }
            else
            {
                this.Hide();
                MDIParent1 ad = new MDIParent1();
                ad.ShowDialog();
            }
            con.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            studentui ui1 = new studentui();
            ui1.ShowDialog();
        }
    }
}
