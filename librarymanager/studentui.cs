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
    public partial class studentui : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=librarymanager");
        int count = 0;
        public studentui()
        {
            InitializeComponent();
        }

        private void studentui_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from artifact";
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from artifact where title like('%" + textBox1.Text + "%') or author like('%" + textBox1.Text + "%') or genre like('%" + textBox1.Text + "%')";
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            MySqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from issue_books where reg_no= '" + txtreg.Text +  "'";
            cmd1.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd1);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (txttype.Text == "book")
            {
                if (count > 2)
                {
                    MessageBox.Show("book cannot be issued");

                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into issue_books(reg_no,dept,issue_date,book_name,type) values('" + txtreg.Text + "','" + txtdept.Text + "','" + dateTimePicker1.Value.ToString() + "','" + txttitle.Text + "','" + txttype.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("issue successful");
                    clear();
                    con.Close();
                }
            }
            else if(txttype.Text=="journal")
            {
                if (count > 1)
                {
                    MessageBox.Show("journal cannot be issued");

                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into issue_books(reg_no,dept,issue_date,book_name) values('" + txtreg.Text + "','" + txtdept.Text + "','" + dateTimePicker1.Text + "','" + txttitle.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("issue successful");
                    clear();
                    con.Close();
                }
            }
        
        }
        void clear()
        {
            txtreg.Text = txtdept.Text = dateTimePicker1.Text = txttitle.Text = "";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainpage m1 = new mainpage();
            m1.ShowDialog();
        }
    }
}
