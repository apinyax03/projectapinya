namespace WindowsFormsApp1
{
    partial class bsk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("MN SASHIMI New", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(842, 660);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "กลับไปเลือกสินค้าใหม่";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Font = new System.Drawing.Font("MN SASHIMI New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(779, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("MN SASHIMI New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(923, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "xxxxxxxxxxxx";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MN SASHIMI New", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 55);
            this.label3.TabIndex = 3;
            this.label3.Text = "รายการของฉัน🛒";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(594, 551);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Font = new System.Drawing.Font("MN SASHIMI New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(152, 659);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 53);
            this.button3.TabIndex = 8;
            this.button3.Text = "พิมพ์ใบเสร็จ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("MN SASHIMI New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.delete.Location = new System.Drawing.Point(359, 661);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(145, 52);
            this.delete.TabIndex = 10;
            this.delete.Text = "ลบข้อมูล";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.Color.Transparent;
            this.date.Font = new System.Drawing.Font("MN SASHIMI New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(24, 28);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(48, 30);
            this.date.TabIndex = 11;
            this.date.Text = "date";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.Color.Transparent;
            this.time.Font = new System.Drawing.Font("MN SASHIMI New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.Location = new System.Drawing.Point(24, 64);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(47, 30);
            this.time.TabIndex = 12;
            this.time.Text = "time";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bsk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.งานนำเสนอ_การลงประกาศ_ผู้ซื้ออสังหาริมทรัพย์_บล็อก_เส้นทแยงมุม_สีเขียวเข้มและสีขาว__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 747);
            this.Controls.Add(this.time);
            this.Controls.Add(this.date);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "bsk";
            this.Text = "bsk";
            this.Load += new System.EventHandler(this.bsk_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer timer1;
    }
}