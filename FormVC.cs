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

namespace QBisnis
{
    public partial class FormVC : Form
    {
        int id = 0;
        static string connectionString = @"Data Source=LAPTOP-CKRPB9BI\MSSQLSERVER1;Initial Catalog=QBisnis;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(connectionString);

        public FormVC()
        {
            InitializeComponent();
            Clear();
            Sow();
            TotalSemua();
        }
        void Clear()
        {
            tbNominal.Text = tbKategori.Text = tbNote.Text = "";
        }

        private double TotalSemua()
        {
            double total = 0;
            tbTotalVC.Text = "0";
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                total += Convert.ToDouble(DataGridView1.Rows[i].Cells[2].Value);
            }
            tbTotalVC.Text = total.ToString();
            return total;

        }
        private void Sow()
        {
            
            SqlCommand command = connection.CreateCommand();
            command = new SqlCommand("Select * from VariableCost", connection);
            DataTable dt = new DataTable();

            connection.Open();

            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);

            connection.Close();

            DataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbNominal.Text != "" && tbKategori.Text != "" && tbNote.Text != "")
            {
                
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into VariableCost values (@Kategori,@Nominal,@Note)", connection);

                cmd.Parameters.AddWithValue("@Kategori", tbKategori.Text);
                cmd.Parameters.AddWithValue("@Nominal", double.Parse(tbNominal.Text));
                cmd.Parameters.AddWithValue("@Note", tbNote.Text);

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Record Successfully Saved");
                }
                else
                {
                    MessageBox.Show("Record Not Saved");
                }
                connection.Close();

                Sow();
                TotalSemua();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(DataGridView1.SelectedRows[0].Cells[0].Value);
            tbNominal.Text = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tbKategori.Text = DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            tbNote.Text = DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

       
        private void btnHapus_Click(object sender, EventArgs e)
        {
           foreach (DataGridViewRow item in this.DataGridView1.SelectedRows)
           {
                   using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = connection.CreateCommand();
                        int id = Convert.ToInt32(DataGridView1.SelectedRows[0].Cells[0].Value);
                        cmd.CommandText = "Delete from VariableCost where id='" + id + "'";

                        DataGridView1.Rows.RemoveAt(this.DataGridView1.SelectedRows[0].Index);
                        connection.Open();
                        cmd.ExecuteNonQuery();

                    }

           }
           TotalSemua();
        }

        private void FormVC_Load(object sender, EventArgs e)
        {
            Clear();
            Sow();
            TotalSemua();
        }

        public double totalvc()
        {
            double total;
            Sow();
            total = TotalSemua();
            return total;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormUtama form = new FormUtama(tbTotalVC.Text);
            form.Show();

            this.Hide();
        }
    }
}
