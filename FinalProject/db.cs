using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject
{
    internal class db
    {
        static public string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\FinalProject\FinalProject\Database1.mdf;Integrated Security=True";
        public SqlConnection c = new SqlConnection(con);
        public void start()
    {
        
            try
            {
                c.Open();
            }
            catch
            {
                MessageBox.Show("Database Connection Failed :/ ");
            }
    }
    }
}
