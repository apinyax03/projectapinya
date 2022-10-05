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
    public partial class bsk : Form
    {
        public bsk()
        {
            InitializeComponent();
        }
        private void bucket()
        {
           
            //เชื่อมข้อมูลชื่อลูกค้ากับdb เสิชหาสินค้าทุกอย่างที่อยุ่ในลูกค้าคนนี้และสถานที่ยังไม่จ่ายเงิน
            MySqlConnection conn_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            DataSet ds = new DataSet();
            conn_.Open();

            MySqlCommand cmd_;
            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT * FROM bucket WHERE ชื่อลูกค้า = '"+nameee+"' and สถานะ ='0'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd_);
            adapter.Fill(ds);
            conn_.Close();
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bsk_Load(object sender, EventArgs e)
        {

        }
        public static string nameee = main.user, tel;
        private void bsk_Load_1(object sender, EventArgs e) //รันฟังชัน
        {
            label2.Text=nameee;
            bucket();
            showEquiment();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuu menuu = new menuu();
            menuu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //ปุ่มพิมพ์ใบเสร็จ
        {
            //อัำเดทสถานะให้กับพวกสถานะ0 กลายเป็น1คือจ่ายแล้ว
            money money = new money();
            money.ShowDialog();
            string sql = "SELECT * FROM bucket WHERE ชื่อลูกค้า = '"+nameee+"'";
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MySqlConnection conn_ = databaseConnection();
                string sql_ = "UPDATE bucket SET สถานะ = '1' WHERE ชื่อสินค้า = '"+reader.GetString("ชื่อสินค้า")+"' and ชื่อลูกค้า = '"+nameee+"'";
                MySqlCommand cmd_ = new MySqlCommand(sql_, conn_);
                conn_.Open();
                int rows_ = cmd_.ExecuteNonQuery();
                conn_.Close();
            }
            bucket();



        }
        private MySqlConnection databaseConnection()
        {
            
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void showEquiment() //ค้นหาทุกอย่างของลูกค้าที่ล้อคอินเข้ามายังไม่จ่ายเงินเอามาแสดงในใบเสร็จและจ่ายเงิน
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM bucket WHERE ชื่อลูกค้า = '"+nameee+"' and สถานะ ='0'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text=nameee;
            bucket();
            showEquiment();
        }

        //ลบข้อมูลสินค้าในตะกร้า
        private void deleteBucket(int id) //ลบข้อมูลในตะกร้า
        {
            MySqlConnection conn = databaseConnection();

            string sql = "DELETE FROM bucket WHERE id = '"+id+"'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                showEquiment(); //โชว์อันที่ยังไม่จ่าย สามารุลบได้
                
            }

        }

        private void updateMenu(string food, int amount) //เวลาเรายกเลิกสินค้าจะกลับไปเก็บในสต๊อค
        {
            MySqlConnection conn = databaseConnection();

            string sql = "SELECT จำนวน FROM menu WHERE ชื่อสินค้า = '"+food+"'";
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            int amountstock = 0;
            while (dr.Read())
            {
                amountstock = dr.GetInt32("จำนวน");
            }
            conn.Close();

            sql = "UPDATE menu SET จำนวน = '"+ (amount + amountstock) +"' WHERE ชื่อสินค้า = '"+food+"'";
            cmd = new MySqlCommand(sql,conn);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("ลบออกจากตะกร้าเรียบร้อย");
            }
        }





        //ทุกครั้งที่กดปุ่มในdatagridviewจะเอาค่าที่กดไปเก่บในตัวแปร

        private int clickID = 0;
        private string food = "";
        private int amount = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //เมื่อเรากดdatagrid viewจะทำการบันทึกค่าเข้าไปในidที่อยู่ในdata gridview
                dataGridView1.CurrentRow.Selected = true;
                int selectedRow = dataGridView1.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].FormattedValue.ToString());
                food = dataGridView1.Rows[selectedRow].Cells["ชื่อสินค้า"].FormattedValue.ToString();
                amount = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["จำนวน"].FormattedValue.ToString());
                clickID = id;
            }
            catch
            {

            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToLongDateString(); 
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void delete_Click(object sender, EventArgs e)
        {

            deleteBucket(clickID);
            updateMenu(food, amount);
        }
    }

}
