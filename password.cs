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
    public partial class password : Form
    {
        public password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string correct_password = "250346";

            string password = textBox1.Text;
            if (password == correct_password)
            {
                stk stk = new stk();
                stk.Show();
                this.Hide();
 
            } 
            else
            {
                MessageBox.Show("รหัสผ่านไม่ถูกต้องค่ะ", "ตรวจพบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void password_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
            this.Hide();
        }
    }
}
