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

namespace Personel_Kayıt
{
    public partial class Graphs : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Graphs()
        {
            InitializeComponent();
        }

        private void Graphs_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select City , Count(*) from Personel Group by City",connection);
            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                Cities.Series["Cities"].Points.AddXY(rd[0], rd[1]);
            }
            rd.Close();
            SqlCommand command1 = new SqlCommand("Select Job, avg(Salary) as 'totalSalary' from Personel Group by job",connection);
            SqlDataReader rd1 = command1.ExecuteReader();
            while (rd1.Read())
            {
                chart2.Series["Job-Salary"].Points.AddXY(rd1[0], rd1[1]);

            }
            
            rd1.Close();
            connection.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void Cities_Click(object sender, EventArgs e)
        {

        }
    }
}
