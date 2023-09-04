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
    public partial class AddStudent : Form
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.database1DataSet1.Class);
            // TODO: This line of code loads data into the 'database1DataSet1.Students' table. You can move, or remove it, as needed.
           // this.studentsTableAdapter.Fill(this.database1DataSet1.Students);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                db db = new db();
                SqlCommand cmd = new SqlCommand("INSERT INTO Students VALUES (@StdId, @ClassId,@StdName)", db.c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StdId", 1);
                cmd.Parameters.AddWithValue("@ClassId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@StdName", textBox3.Text);

                db.c.Open();
                cmd.ExecuteNonQuery();
                db.c.Close();

                MessageBox.Show("User Added Succesfully!");
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record not Insert");
            }

            

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Accedentaly added
        }
    }
}
