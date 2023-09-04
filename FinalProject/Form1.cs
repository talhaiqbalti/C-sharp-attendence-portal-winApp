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

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        db db = new db();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "1234")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SignUpTable VALUES (@userName, @pass)", db.c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                db.c.Open();
                cmd.ExecuteNonQuery();
                db.c.Close();

                MessageBox.Show("User Added Succesfully!");

                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();

            }
            else
            {
                MessageBox.Show("Please Enter Correct PIN!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ALREADY HAVE AN ACCOUNT

            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
