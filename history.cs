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

namespace WindowsFormsApp1
{
    public partial class history : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showdataGridView1()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bucket";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public history()
        {
            InitializeComponent();
            showdataGridView1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //ค้นหารายชื่อลูกค้า
        {
            if (textBox1.Text != "")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = ($"SELECT*FROM bucket WHERE ชื่อลูกค้า like\"%{textBox1.Text}\""); //ค้นหาชื่อลูกค้าในดาต้าเบส
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MySqlConnection conn2 = databaseConnection();
                    conn2.Open();
                    MySqlCommand cmd2;
                    cmd2 = conn2.CreateCommand(); /
                    cmd2.CommandText = ($"SELECT SUM(ราคา) FROM bucket WHERE ชื่อลูกค้า like\"%{textBox1.Text}\""); //รวมราคาของลูกค้าคนนั้น
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        textBox2.Text = Convert.ToString(dr2[0]); // จะขึ้นโชว์ราคารวมทั้งหมดที่ textBox2
                    }
                    conn2.Close();
                }
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0].DefaultView; // โชว์ข้อมูลลูกค้าใน dataGridView
            }
            else //ถ้าไม่เสิชชื่อจะปรากฎชื่อลูกค้าทั้งหมด
            {
                showdataGridView1(); //หากไม่เสิร์ชชื่อ ก็จะโชว์ข้อมูลลูกค้าทุกคนทั้งหมด
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void history_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //วันที่เวลา
        {
            textBox2.Text = "0"; 
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            //เป็นการหาวันที่เวลาที่ซื้อขายจากfrom bucket 
            cmd.CommandText = ($"SELECT*FROM bucket WHERE วันที่ BETWEEN \"{dateTimePicker1.Text}\" AND \"{dateTimePicker2.Text}\"");
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                MySqlConnection conn2 = databaseConnection();
                conn2.Open();
                MySqlCommand cmd2;
                cmd2 = conn2.CreateCommand(); // เอาราคา ในระหว่างวันนั้นๆที่เราเลือกในปฏิทินมารวมกัน
                //เอายอดขายระหว่างวันที่ที่เราเลือกมาคำนวณราคายอดขายทั้งหมด
                cmd2.CommandText = ($"SELECT SUM(ราคา) FROM bucket WHERE วันที่ BETWEEN \"{dateTimePicker1.Text}\" AND \"{dateTimePicker2.Text}\"");
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {

                    textBox2.Text = Convert.ToString(dr2[0]); // จะขึ้นโชว์ ราคารวมยอดขายทั้งหมดที่ textBox2
                }
                conn2.Close();
            }
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
