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

namespace MCQ_Test
{
    public partial class class1 : Form
    {
        public class1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True");

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox4.Text != string.Empty)
                {
                    conn.Open();
                    string str = "insert into employeemst values(@eid,@name,@addd,@email)";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@eid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@addd", textBox3.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    bindgrid();
                }
                else
                {
                    MessageBox.Show("Please Enter Value In All Fields", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clearall();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bindgrid()
        {
            try
            {
                string str = "select *from employeemst";
                SqlDataAdapter adpt = new SqlDataAdapter(str, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearall()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.ReadOnly = false;
            textBox1.Focus();
        }

        private void class_Load(object sender, EventArgs e)
        {
            bindgrid();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    textBox3.Text = row.Cells[2].Value.ToString();
                    textBox4.Text = row.Cells[3].Value.ToString();
                    textBox1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox4.Text != string.Empty)
                {
                    conn.Open();
                    string str = "update employeemst set name=@name, addd=@add, email=@email where eid=@eid";
                    //string str = "update employeemst set name=@name, [addd]=@adddd, email=@email where eid=@eid";

                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@eid", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@add", textBox3.Text);
                    cmd.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    bindgrid();
                }
                else
                {
                    MessageBox.Show("Please Enter Value In Fields", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearall();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    conn.Open();
                    string str = "delete from employeemst where eid=@eid";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@eid", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    bindgrid();
                }
                else
                {
                    MessageBox.Show("Please Enter Value In Fields", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearall();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



