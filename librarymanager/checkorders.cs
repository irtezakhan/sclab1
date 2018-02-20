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
    public partial class checkorders : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=librarymanager");
        public checkorders()
        {
            InitializeComponent();
        }

        private void checkorders_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            
        }
        public void fillbooks(string reg_no)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where reg_no='" + reg_no.ToString() +"' and return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            fillbooks(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[1].Value.ToString());
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where reg_no='" +i+ "' and return_date=''";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                bookname.Text = dr["book_name"].ToString();
                issuedate.Text = dr["issue_date"].ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[1].Value.ToString());
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update issue_books set return_date='"+dateTimePicker1.Value.ToString()+"'where reg_no="+i+"";
            cmd.ExecuteNonQuery();

            string issuedate1 = issuedate.Text;
            DateTime convertedissuedate = DateTime.Parse(issuedate1);
           int daysoverdue = DateTime.Now.Subtract(convertedissuedate).Days;
            if (dataGridView1.SelectedCells[6].Value.ToString()=="book")
            {
                if (daysoverdue > 30)
                {
                    int finedays = daysoverdue - 30;
                    int fine = 50 * finedays;
                    MessageBox.Show("book will be returned.pay Rs." + fine);
                }
                else
                {
                    MessageBox.Show("book was returned in time");
                }
            }
          else  if (dataGridView1.SelectedCells[6].Value.ToString() == "journal")
            {
                if (daysoverdue > 15)
                {
                    int finedays = daysoverdue - 15;
                    int fine = 100 * finedays;
                    MessageBox.Show("journal will be returned.pay Rs." + fine);
                }
                else
                {
                    MessageBox.Show("journal was returned in time");
                }
            }
        }
    }
}
