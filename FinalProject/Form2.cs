using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //ADDED EXTRA
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //EXIT BUTTON
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // REDIRECT TO SIGNUP PAGE

            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();

        }

        db db = new db();
        private void button1_Click(object sender, EventArgs e)
        {
            //GET DATA FROM DATABASE AND CHECK FOR AUTHENTICATION

            SqlCommand cmd = new SqlCommand("SELECT * FROM SignUpTable WHERE userName = @userName AND pass = @pass ", db.c );
            cmd.Parameters.AddWithValue("@userName", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            db.c.Open();
            int i = cmd.ExecuteNonQuery();
            db.c.Close();
            if (dt.Rows.Count > 0)
            {
                  this.Hide();
                MessageBox.Show("Login Success");
                var Dashboard = new Dashboard();
                Dashboard.Closed += (s, args) => this.Close();
                Dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
