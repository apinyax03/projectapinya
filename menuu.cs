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
    public partial class menuu : Form
    {
        public menuu()
        {
            InitializeComponent();
        }
       
        int a = 1, b = 2, c = 3; //ประกาศรูปที่แสดง หน้าเมนูแสดงทีละ3รูปภาพ
       
        string[] food = new string[8]; //อาเลที่เก็บรูปภาพ
        int[] ราคา = new int[8]; 
        private void app() /////เอาชื่อเมนูราคาจากในสต๊อคดาต้าเบสมาใส่ในอาเลที่อยุ่ข้างบน
        {
            string sql2_ = "SELECT * FROM menu"; //เชื่อมรายการอาหารและสต๊อคจากดาต้าเบส
            MySqlConnection conn2 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            MySqlCommand cmd2 = new MySqlCommand(sql2_, conn2);
            conn2.Open();
            DataTable dt = new DataTable();
            new MySqlDataAdapter(cmd2).Fill(dt);
            MySqlDataReader weep__ = cmd2.ExecuteReader();
            food[0] = "อาหาร";
            ราคา[0] = 1; //สมมติราคาสินค้าที่เคยซื้อไป5อย่างเมื่อซื้อไปแล้วจะกลับมาเป็น1เหมือนเดิมงับ
            while (weep__.Read()) //ทำให้ชื่อสินค้าและราคามันหมุนได้
            {
                food[Convert.ToInt32(weep__.GetString("id"))] = weep__.GetString("ชื่อสินค้า");
                ราคา[Convert.ToInt32(weep__.GetString("id"))] = Convert.ToInt32(weep__.GetString("ราคา"));
            }
        }
        private void button3_Click(object sender, EventArgs e) //ปุ่มตะกร้าสินค้า
        {
            bsk bsk = new bsk();
            bsk.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
      
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //เพิ่มสินค้าเข้าตะกร้าในอิโมจิรถเข็น
        {
            
            string sql = "SELECT * FROM menu WHERE ชื่อสินค้า = '" + label1.Text + "'  "; //เชื่อมชื่อสินค้าที่อยู่ในดาต้าเบสเข้ากับช่องlabelที่สร้างไว้ ให้แสดงในตำแหน่งlabel1
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            // ในตะกร้าเราสามารถซื้อได้สูงสุดเท่าที่มีในสต๊อค เพิ่มสินค้าตามที่เราต้องการ
            if (reader.Read()&& Convert.ToInt32(reader.GetString("จำนวน")) < Convert.ToInt32(numericUpDown1.Value)
                && Convert.ToInt32(reader.GetString("จำนวน"))>0) //ถ้าจำนวนในสต๊อคน้อยกว่าจำนวนที่เราเลือกและมากกว่า0 ตอนเลือกสินค้าจะเลือกได้สูงสุดแค่เท่าในสต๊อค
            {
                numericUpDown1.Value = Convert.ToInt32(reader.GetString("จำนวน"));

            }
        }

        private void menuu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            app();
        }
      
        

        private void button4_Click(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
            this.Hide();
        }

        //อัพเดทสต๊อค
        //โค้ดจัดสต๊อค เสิชหาจำนวนที่เหลืออยุ้่ในสต๊อคลบด้วยจำนวนที่ซื้อแล้วอัพเดทเข้าไปใหม่
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM menu WHERE ชื่อสินค้า = '" + label1.Text + "'  ";  //เชื่อมชื่อสินค้าที่อยู่ในดาต้าเบสเข้ากับช่องlabelที่สร้างไว้ ให้แสดงในตำแหน่งlabel1
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open(); 
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()&& Convert.ToInt32(reader.GetString("จำนวน")) >= Convert.ToInt32(numericUpDown1.Value)
                && Convert.ToInt32(reader.GetString("จำนวน"))>0) //ถ้าจำนวนในสต๊อคมีมากกว่าที่เราต้องการ(มากพอที่จะซื้อของตามจำนวนที่เราต้องการได้)และไม่ได้หมดสต๊อค สามารถซื้อได้และเก็บเจ้าตะกร้าในดาต้าเบส
            {
                //ของมีในสต๊อคเลือกได้จะเก็บข้อมูลของลูกค้าที่เลือกซื้อสินค้าแต่ละอย่างเข้าดาต้าเบสตามคอลัมน์ในเทเบิลbucket
                string conn1 = "datasource=127.0.0.1;port=3306;username=root;password=;database=project;";
                string sql1 = "INSERT INTO bucket (ชื่อสินค้า,จำนวน,ราคา,ชื่อลูกค้า,วันที่,เวลา) VALUES" +
                    "('" + label1.Text + "','" + Convert.ToInt32(numericUpDown1.Value) + "','"+Convert.ToInt32(reader.   
                        GetString("ราคา"))*Convert.ToInt32(numericUpDown1.Value)+"','"+bsk.nameee+"','" + day.Text + "','" + time.Text + "' ) ";
                MySqlConnection con1 = new MySqlConnection(conn1);
                MySqlCommand cmd1 = new MySqlCommand(sql1, con1);
                con1.Open();
                int rows1 = cmd1.ExecuteNonQuery();
                con1.Close();

                //อัพเดทสต๊อค การคำนวณ จำนวนสินค้าในดาต้าเบส(สต๊อค)เมื่อที่เราซื้อ
                int number = Convert.ToInt32(reader.GetString("จำนวน")) - Convert.ToInt32(numericUpDown1.Value); //จำนวนในสต็อคลบจำนวนที่เราเลือกคือซื้อได้เพราะในสต๊อคมีเยอะกว่าที่เราเลือก
                string sql2 = $"UPDATE `menu` SET `จำนวน` = {number} WHERE `ชื่อสินค้า` = '{label1.Text}' "; //อัพเดทสต๊อคว่าเหลือเท่าไหร่แล้วตอนล่าสุดแล้วเก็บเข้าดาต้าเบส
                MySqlConnection con2 = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=project;");
                MySqlCommand cmd2 = new MySqlCommand(sql2, con2);
                con2.Open();
                int rows2 = cmd2.ExecuteNonQuery();
                con2.Close();

                MessageBox.Show("เพิ่มในตะกร้าเรียบร้อยแล้ว"); //เมื่อซื้อได้แล้วจะเพิ่มข้อมูลสินค้าในตะกร้า
                numericUpDown1.Value = 1; //ทุกครั้งที่ซื้อเสร็จสินค้าจะเซ็ตค่าเป็น1


            } else
            {
                MessageBox.Show("ขออภัยสินค้าของทางร้าน\nเหลือ : " + Convert.ToInt32(reader.GetString("จำนวน"))); //ในกรณีที่ไม่สามารถซื้อสินค้าได้เพราะของที่ต้องการซื้อมากกว่าของในสต๊อคจะโชว์message boxบอกจำนวนสินค้าในสต๊อคที่เหลืออยุ่
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            day.Text = DateTime.Now.ToShortDateString(); //โชว์วันที่
            time.Text = DateTime.Now.ToShortTimeString(); //โชว์เวลา
        }

        private void day_Click(object sender, EventArgs e)
        {

        }


        //คลิกปุ่มขวารูปจะเลื่อนที่ละ1รูป ชื่อและราคาจะเปลี่ยนตามรูปไปด้วย
        private void button2_Click(object sender, EventArgs e)
        {
            a += 1;
            b += 1;
            c += 1;
            // ทุกครั้งที่กด1ครั้ง จะทำการหมุนรูปทีละ1รูป

            if (a == 8)
            {
                a = 1;
            }
            if (b == 8)
            {
                b = 1;
            }
            if (c == 8)
            {
                c = 1;
            }


            pictureBox1.Image = Image.FromFile("C:\\รูป\\"+a+".jpg");
            pictureBox2.Image = Image.FromFile("C:\\รูป\\"+b+".jpg");
            pictureBox3.Image = Image.FromFile("C:\\รูป\\"+c+".jpg");
            label1.Text = food[b];
            label3.Text = $"{ราคา[b]}";//ทำให้ราคาเลื่อนไปด้วยที่ดึงมาจากดาตา้เบส
        }

        //คลิกปุ่มขวารูปจะเลื่อนที่ละ1รูป ชื่อและราคาจะเปลี่ยนตามรูปไปด้วย
        private void button1_Click(object sender, EventArgs e)
        {
            a -= 1;
            b -= 1;
            c -= 1;
            
            if (a == 0)
            {
                a = 7;
            }
            if (b == 0)
            {
                b = 7;
            }
            if (c == 0)
            {
                c = 7;
            }


            pictureBox1.Image = Image.FromFile("C:\\รูป\\"+a+".jpg");
            pictureBox2.Image = Image.FromFile("C:\\รูป\\"+b+".jpg");
            pictureBox3.Image = Image.FromFile("C:\\รูป\\"+c+".jpg");
            label1.Text = food[b];
            label3.Text = $"{ราคา[b]}";

        }
    }
}
