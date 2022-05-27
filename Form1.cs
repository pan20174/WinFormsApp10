using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        private MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        private MySqlConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            builder.UserID = "root";
            builder.Password = "176164";
            builder.Server = "localhost";
            builder.Database = "new_schema";
            connection = new MySqlConnection(builder.ConnectionString);
            try
                {
                    //打开数据库连接
                    connection.Open();
                    MessageBox.Show("数据库已经连接了！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from student";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            mda.Fill(ds, "student");
            //显示数据
            dataGridView1.DataSource = ds.Tables["student"];
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "update student set s_birth = '2001-01-01' where s_name='张三'";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            mda.Fill(ds, "student");
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "insert into student set s_id ='99',s_name ='张三',s_birth='1989-07-01',s_sex='男'";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            mda.Fill(ds, "student");
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string sql = "delete from student where s_id=99";
            MySqlDataAdapter mda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            mda.Fill(ds, "student");
            connection.Close();
        }
    }
}