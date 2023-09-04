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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        db db = new db();

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Attendence WHERE Date = @date ", db.c);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            db.c.Open();
            var classes = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (classes.Read())
            {
                dataGridView1.Rows.Add(classes[1], classes[2], classes[3], classes[4]);
            }

            db.c.Close();
            MessageBox.Show(dateTimePicker1.Value.Date.ToString());
        }
    }
}
