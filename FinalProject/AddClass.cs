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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Accidentaly Added
        }

        db db = new db();

        private void button1_Click(object sender, EventArgs e)
        {
            //ADD CLASS

            string newId = string.Format("050-{0}-0001", DateTime.Now.Year);
            SqlCommand cmd = new SqlCommand("INSERT INTO Class VALUES (@classId, @ClassName)", db.c);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ClassName", textBox1.Text);
            cmd.Parameters.AddWithValue("@classId", newId);

            db.c.Open();
            cmd.ExecuteNonQuery();
            db.c.Close();

            MessageBox.Show("Class Added");

            textBox1.Text = "";

            this.Close();


        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            //ADDED ACCIDENTALLY
        }
    }
}
