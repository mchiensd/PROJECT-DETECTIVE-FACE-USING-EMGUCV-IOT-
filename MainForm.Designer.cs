namespace MultiFaceRec
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởTậpTinẢnhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoLưuDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phụcHồiDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.xóaDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinVềTôiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.imageBox3 = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUToolStripMenuItem
            // 
            this.mENUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởTậpTinẢnhToolStripMenuItem,
            this.quảnLíDữLiệuToolStripMenuItem,
            this.saoLưuDữLiệuToolStripMenuItem,
            this.phụcHồiDữLiệuToolStripMenuItem,
            this.xóaDữLiệuToolStripMenuItem,
            this.thôngTinVềTôiToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.mENUToolStripMenuItem.Name = "mENUToolStripMenuItem";
            this.mENUToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.mENUToolStripMenuItem.Text = "Bảng điều khiển";
            this.mENUToolStripMenuItem.Click += new System.EventHandler(this.mENUToolStripMenuItem_Click);
            // 
            // mởTậpTinẢnhToolStripMenuItem
            // 
            this.mởTậpTinẢnhToolStripMenuItem.Name = "mởTậpTinẢnhToolStripMenuItem";
            this.mởTậpTinẢnhToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.mởTậpTinẢnhToolStripMenuItem.Text = "Mở tập tin ảnh";
            this.mởTậpTinẢnhToolStripMenuItem.Click += new System.EventHandler(this.mởTậpTinẢnhToolStripMenuItem_Click);
            // 
            // quảnLíDữLiệuToolStripMenuItem
            // 
            this.quảnLíDữLiệuToolStripMenuItem.Name = "quảnLíDữLiệuToolStripMenuItem";
            this.quảnLíDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.quảnLíDữLiệuToolStripMenuItem.Text = "Quản lí dữ liệu";
            this.quảnLíDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.quảnLíDữLiệuToolStripMenuItem_Click);
            // 
            // saoLưuDữLiệuToolStripMenuItem
            // 
            this.saoLưuDữLiệuToolStripMenuItem.Name = "saoLưuDữLiệuToolStripMenuItem";
            this.saoLưuDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.saoLưuDữLiệuToolStripMenuItem.Text = "Sao lưu dữ liệu";
            this.saoLưuDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.saoLưuDữLiệuToolStripMenuItem_Click);
            // 
            // phụcHồiDữLiệuToolStripMenuItem
            // 
            this.phụcHồiDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.phụcHồiDữLiệuToolStripMenuItem.Name = "phụcHồiDữLiệuToolStripMenuItem";
            this.phụcHồiDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.phụcHồiDữLiệuToolStripMenuItem.Text = "Phục hồi dữ liệu";
            this.phụcHồiDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.phụcHồiDữLiệuToolStripMenuItem_Click);
            this.phụcHồiDữLiệuToolStripMenuItem.MouseEnter += new System.EventHandler(this.phụcHồiDữLiệuToolStripMenuItem_MouseEnter);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // xóaDữLiệuToolStripMenuItem
            // 
            this.xóaDữLiệuToolStripMenuItem.Name = "xóaDữLiệuToolStripMenuItem";
            this.xóaDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.xóaDữLiệuToolStripMenuItem.Text = "Xóa dữ liệu";
            this.xóaDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.xóaDữLiệuToolStripMenuItem_Click);
            // 
            // thôngTinVềTôiToolStripMenuItem
            // 
            this.thôngTinVềTôiToolStripMenuItem.Name = "thôngTinVềTôiToolStripMenuItem";
            this.thôngTinVềTôiToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.thôngTinVềTôiToolStripMenuItem.Text = "Thông tin";
            this.thôngTinVềTôiToolStripMenuItem.Click += new System.EventHandler(this.thôngTinVềTôiToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(22, 143);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(600, 400);
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(150, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(347, 31);
            this.label7.TabIndex = 10;
            this.label7.Text = "ĐỒ ÁN CHUYÊN NGÀNH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(508, 31);
            this.label8.TabIndex = 11;
            this.label8.Text = "NHẬN DIỆN KHUÔN MẶT (EMGUGV)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(353, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(269, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Giảng viên hướng dẫn: PGS.TS Võ Đình Bảy";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // imageBox3
            // 
            this.imageBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox3.Location = new System.Drawing.Point(522, 443);
            this.imageBox3.Name = "imageBox3";
            this.imageBox3.Size = new System.Drawing.Size(100, 100);
            this.imageBox3.TabIndex = 13;
            this.imageBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Số khuôn mặt nhận dạng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(263, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 42);
            this.label3.TabIndex = 15;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TMC-TrajanPro-Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(9, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 35);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nobody";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Hiển thị Face hiện tại";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(22, 549);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 151);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả: ";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(6, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Bắt đầu tranning";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(120, 25);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(100, 100);
            this.imageBox1.TabIndex = 5;
            this.imageBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 26);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Noname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tên : ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 247);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 26);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "3";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imageBox2
            // 
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox2.Location = new System.Drawing.Point(120, 131);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(100, 30);
            this.imageBox2.TabIndex = 13;
            this.imageBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số khung hình tranning : ";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(1, 391);
            this.trackBar1.Maximum = 250;
            this.trackBar1.Minimum = -100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(319, 45);
            this.trackBar1.TabIndex = 13;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(46, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Bật Camera & nhận diện";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(184, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 31);
            this.button3.TabIndex = 11;
            this.button3.Text = "Xóa tất cả";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(14, 167);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 24);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Đa nhận diện";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 24);
            this.label10.TabIndex = 14;
            this.label10.Text = "Độ sáng : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(166, 364);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 24);
            this.label11.TabIndex = 15;
            this.label11.Text = "00";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(201, 167);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(112, 24);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Focus mắt";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.imageBox2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(628, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 557);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Huấn Luyện: ";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 708);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.imageBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Trần Minh Chiến - Đồ án chuyên ngành - Nhận diện khuôn mặt (Emgugv)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mởTậpTinẢnhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoLưuDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phụcHồiDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinVềTôiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Emgu.CV.UI.ImageBox imageBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem xóaDữLiệuToolStripMenuItem;
    }
}

