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
    public partial class addartifact : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=librarymanager");
        public addartifact()
        {
            InitializeComponent();
            combosource.Items.Add("donation");
            combosource.Items.Add("purchased"); }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into artifact(ISBN,title,publication_year,language,genre,type,author,no_of_copies_actual,price,source) values('" + txtisbn.Text + "','" + texttitle.Text + "','" + txtpublicationyear.Text + "','" + txtlanguage.Text + "','" + txtgenre.Text + "','" + txttype.Text + "','" + txtauthor.Text + "','" + txtcopies.Text + "','" + txtprice.Text + "','" + combosource.SelectedItem.ToString()+"')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("addition successful");
            clear();
            this.Hide();
            
            con.Close();
        }
        void clear()
        {
            txtisbn.Text = texttitle.Text = txtpublicationyear.Text = txtlanguage.Text = txtgenre.Text = txttype.Text = txtauthor.Text = txtcopies.Text = txtprice.Text = "";
        }
        private void combosource_SelectedIndexChanged(object sender, EventArgs e)
        {}
    }
    
}
