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

namespace Personel_Kayıt
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void Statistic_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select Count(*) from Personel" , connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {   
                label2.Text = reader[0].ToString();

            }
            reader.Close();
            SqlCommand command2 = new SqlCommand("Select Count(*) from personel where MaritalStatus = 'true'", connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read()) 
            {   
                label4.Text = reader2[0].ToString();
            }
            reader2.Close();
            SqlCommand command3 = new SqlCommand("Select sum(Salary) from Personel", connection);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                label6.Text = reader3[0].ToString();
            }
            reader3.Close();
            SqlCommand command4 = new SqlCommand("Select Avg(Salary) from Personel", connection);
            SqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                label8.Text = reader4[0].ToString();
            }
            reader4.Close();
            
            connection.Close();
        }
    }
}
