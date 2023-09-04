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
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Back
            this.Hide();

            var Dashboard = new Dashboard();
            Dashboard.Closed += (s, args) => this.Close();
            Dashboard.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //ADDED ACEDENTALLY

        }

        private void Attendence_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Attendence' table. You can move, or remove it, as needed.
            //this.attendenceTableAdapter.Fill(this.database1DataSet1.Attendence);
            // TODO: This line of code loads data into the 'database1DataSet1.Class' table. You can move, or remove it, as needed.
           //// this.classTableAdapter.Fill(this.database1DataSet1.Class);
            // TODO: This line of code loads data into the 'database1DataSet1.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.database1DataSet1.Class);
            //ADDED ACCEDENTALLY
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddStudent sd = new AddStudent();
            sd.ClassName = comboBox1.Text;
            sd.ClassId = (string)comboBox1.SelectedValue;
            sd.ShowDialog();
        }
        db db = new db();
        private void button4_Click(object sender, EventArgs e)
        {
            string classs = comboBox1.Text;
            string dt = dateTimePicker1.Value.ToString();
            /*try
            {*/


            SqlCommand cmd = new SqlCommand("Select * from Students WHERE classId = @classId ", db.c);
            cmd.Parameters.AddWithValue("@classId", comboBox1.Text);
            db.c.Open();
            var classes = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (classes.Read())
            {
                dataGridView1.Rows.Add(classes[1], classes[2]);
            }

            db.c.Close();


            // }
            //catch (Exception ex)
            // {
            //    MessageBox.Show("Record not Insert");
            // }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // WAIT
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["Present"].Index && e.RowIndex >= 0)
            {
                string className = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string studentName = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                SqlCommand cmd = new SqlCommand("INSERT INTO Attendence VALUES (@RecNum, @StudentId, @ClassId, @Date, @Status)", db.c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RecNum", 1);
                cmd.Parameters.AddWithValue("@ClassId", className);
                cmd.Parameters.AddWithValue("@StudentId", studentName);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Status", "Present");


                db.c.Open();
                cmd.ExecuteNonQuery();
                db.c.Close();
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
            if (e.ColumnIndex == dataGridView1.Columns["Absent"].Index && e.RowIndex >= 0)
            {
                string className = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string studentName = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                SqlCommand cmd = new SqlCommand("INSERT INTO Attendence VALUES (@RecNum, @StudentId, @ClassId, @Date, @Status)", db.c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@RecNum", 1);
                cmd.Parameters.AddWithValue("@ClassId", className);
                cmd.Parameters.AddWithValue("@StudentId", studentName);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Status", "Absent");


                db.c.Open();
                cmd.ExecuteNonQuery();
                db.c.Close();

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
