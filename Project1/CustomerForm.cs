using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Project1
{
    public partial class CustomerForm : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dimit\source\repos\Project1\Project1\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        MySqlCommand com = new MySqlCommand();
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string server = "sql5.freesqldatabase.com";
            string database = "sql5673207";
            string username = "sql5673207";
            string password = "8PH51R8Euv";

            MySqlConnection cnn;
            connetionString = "Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";";
            cnn = new MySqlConnection(connetionString);
            try
            {
                if (MessageBox.Show("Are you sure you want to save this customer?", "Saving record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cmd = new SqlCommand("INSERT INTO customer (first_name, last_name, sex, birth_date) VALUES (@first_name, @last_name, @sex, @birth_date)", con);
                    cnn.Open();
                    MySqlCommand com = cnn.CreateCommand();
                    com.CommandText = "INSERT INTO customer (first_name, last_name, sex, birth_date) VALUES (@first_name, @last_name, @sex, @birth_date)";
                    com.Parameters.AddWithValue("@first_name", txtName.Text);
                    com.Parameters.AddWithValue("@last_name", txtSurname.Text);
                    com.Parameters.AddWithValue("@sex", txtSex.Text);
                    com.Parameters.AddWithValue("@birth_date", txtBirthDate.Value);
                    com.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Record saved successfully");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtSex.Items.Clear();
            txtBirthDate.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
