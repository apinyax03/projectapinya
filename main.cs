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
    public partial class main : Form
    {

        public static string user = "หนูนา"; //เก็บค่าตัวแปรไว้ใช้ข้ามฟอร์ม
        public main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fastfood fastfood = new fastfood();
            fastfood.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) //ปุ่มสั่งอาหาร
        {
            menuu menuu = new menuu();
            menuu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            profile profile = new profile();
            profile.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //ปุ่่มสต๊อคสินค้าเฉพาะพนักงาน
        {

            password ps = new password();
            ps.Show();
            this.Hide();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //ปุ่มประวัติการสั่งซื้อเฉพาะพนักงาน
        {
            pw pw = new pw();
            pw.Show();
            this.Hide();
        }
    }
}

