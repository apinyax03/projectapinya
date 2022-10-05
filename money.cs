using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class money : Form
    {
        public money()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void money_Load(object sender, EventArgs e)
        {

        }

        private void money_Shown(object sender, EventArgs e)
        {
            label10.Text=bsk.nameee; //เรียกค่าข้ามฟอร์มusername
            label11.Text=bsk.tel; //เรียกค่าข้ามฟอร์มโทรศัพท์
            string conn_ = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(conn_);
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `bucket` WHERE ชื่อลูกค้า = '"+label10.Text+"' and สถานะ ='0' "; //เอารายการที่ยังไม่จ่าบ(0)มาโชว์
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;

            string sql = "SELECT * FROM `bucket` WHERE ชื่อลูกค้า = '" + label10.Text + "' and สถานะ ='0'  ";
            MySqlConnection connq = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            MySqlCommand cmd_ = new MySqlCommand(sql, connq);
            connq.Open();
            MySqlDataReader reader = cmd_.ExecuteReader();
            int d = 0;
            while (reader.Read())
            {
                d+=reader.GetInt32(3);
            }
            label12.Text=$"{d}"; //คำนวณราคาที่ยังไม่จ่าย



        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
