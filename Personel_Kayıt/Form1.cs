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
    public partial class Form1 : Form
    {
        bool MStatus;
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        void clearText()
        {
            textBox1.Text = "";
            txtCity.Text = "";
            txtJob.Text = "";
            txtName.Text = "";
            txtSalary.Text = "";
            txtSurname.Text = "";
            radioMarried.Checked = false;
            radioNotMarried.Checked = false;
            txtName.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.personelVeriTabaniDataSet.Personel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert into Personel (Name, SurName, City, MaritalStatus, Salary, Job) values (@Name, @Surname, @city, @MaritalStatus, @Salary, @job)", connection);

            command.Parameters.AddWithValue("@Name", txtName.Text);
            command.Parameters.AddWithValue("@Surname", txtSurname.Text);
            command.Parameters.AddWithValue("@city", txtCity.Text);
            command.Parameters.AddWithValue("@MaritalStatus", MStatus);
            command.Parameters.AddWithValue("@Salary", txtSalary.Text);
            command.Parameters.AddWithValue("@job", txtJob.Text);
            command.ExecuteNonQuery();
            clearText();
            txtName.Focus();
            MessageBox.Show("Added succesfully!");
            connection.Close();
        }

        private void radioMarried_CheckedChanged(object sender, EventArgs e)
        {
            MStatus = true;
        }

        private void radioNotMarried_CheckedChanged(object sender, EventArgs e)
        {
            MStatus = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from Personel where PersonelId= @Id ", connection);
            //int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            command.Parameters.AddWithValue("@Id", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            clearText();
            txtName.Focus();
            MessageBox.Show("Deleted succesfully!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtCity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSalary.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtJob.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "True")
            {
                radioMarried.Checked = true;
                radioNotMarried.Checked = false;
            }
            else
            {
                radioMarried.Checked = false;
                radioNotMarried.Checked = true;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update Personel Set Name = @Name, surName = @surname, city = @City, Salary = @salary, MaritalStatus = @ms , job = @job where PersonelId = @Id", connection);

            command.Parameters.AddWithValue("@Name", txtName.Text);
            command.Parameters.AddWithValue("@Surname", txtSurname.Text);
            command.Parameters.AddWithValue("@City", txtCity.Text);
            command.Parameters.AddWithValue("@ms", MStatus);
            command.Parameters.AddWithValue("@salary", txtSalary.Text);
            command.Parameters.AddWithValue("@job", txtJob.Text);
            command.Parameters.AddWithValue("@Id", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            clearText();
            txtName.Focus();
            MessageBox.Show("Update succesfully");
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Statistic statistic = new Statistic();
            statistic.Show();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            Graphs graphs= new Graphs();
            graphs.Show();
        }
    }
}
