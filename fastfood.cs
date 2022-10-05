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
    public partial class fastfood : Form
    {
        public fastfood()
        {
            InitializeComponent();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //ปุ่มสมัครสมาชิก
        {
            regist regist = new regist();
            regist.Show();
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e) //ปุ่มlog in
        {
            //เชื่อมข้อมูลusername passwordของสมาชิกที่สมัครแล้วทำให้สามารถlogin ได้
            string sql = "SELECT * FROM users WHERE username = '" + textBox1.Text + "' and password	='" + textBox2.Text + "' ";
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //ถ้าใส่usernameหรือpasswordถูกต้องจะเด้งหน้าmain
                main main = new main();
                main.Show();
                this.Hide();
                main.user = textBox1.Text; //ใส่ตัวแปรโยนค่าข้ามฟอร์มไปหน้าอื่นๆว่าหน้าlog inของเรา
                bsk.nameee=textBox1.Text; //โยนค่าข้ามฟอร์มจากtextbox1(ชื่อusername)ไปยังหน้าตะกร้า
                bsk.tel=reader.GetString("โทรศัพท์"); //เก็บค่าทรศไปแสดงค่าข้ามฟอร์ม



            }
            else //ถ้าใส่usernameหรือpasswordผิด จะไม่สามารถloginได้
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้องค่ะ");

            }
   
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void fastfood_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void userss(object sender, KeyPressEventArgs e) //ล็อคkeypressให้ใส่ได้เฉพาะภาษาอังกฤษกับตัวเลข
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar })>1)
            {
                {
                    MessageBox.Show("กรุณากรอกเฉพาะภาษาอังกฤษกับตัวเลขเท่านั้น", "ตรวจพบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            if ((e.KeyChar == ' '))
            {
                e.Handled=true;
            }
        }

        private void passw(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar })>1)
            {
                {
                    MessageBox.Show("กรุณากรอกเฉพาะภาษาอังกฤษกับตัวเลขเท่านั้น", "ตรวจพบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true;
            }
            if ((e.KeyChar == ' '))
            {
                e.Handled=true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
