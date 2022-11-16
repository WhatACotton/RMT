namespace rndtimer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.メニューToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readmeを開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプを表示するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了するToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.song = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.musicduration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("HGPｺﾞｼｯｸE", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(573, 127);
            this.button1.TabIndex = 0;
            this.button1.Text = "再生！";
            this.toolTip1.SetToolTip(this.button1, "音楽を再生します");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000000000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateBlue;
            this.button2.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.ForeColor = System.Drawing.Color.Khaki;
            this.button2.Location = new System.Drawing.Point(9, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(242, 182);
            this.button2.TabIndex = 1;
            this.button2.Text = "ファイルを選択";
            this.toolTip1.SetToolTip(this.button2, "1つの音楽を選択できます");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.numericUpDown1.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(106, 47);
            this.numericUpDown1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numericUpDown1, "開始の位置を指定できます");
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.numericUpDown2.Location = new System.Drawing.Point(3, 4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            60001,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(106, 47);
            this.numericUpDown2.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDown2, "終わりの位置を指定できます");
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(116, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "開始";
            this.toolTip1.SetToolTip(this.label1, "開始の位置を指定できます");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(115, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 40);
            this.label2.TabIndex = 5;
            this.label2.Text = "終了";
            this.toolTip1.SetToolTip(this.label2, "終わりの位置を指定できます");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(426, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 18);
            this.label4.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Purple;
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 92);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "曲名";
            this.toolTip1.SetToolTip(this.groupBox1, "曲が表示されます");
            // 
            // button12
            // 
            this.button12.Enabled = false;
            this.button12.Image = global::rndtimer.Properties.Resources.AddTransition;
            this.button12.Location = new System.Drawing.Point(522, 39);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(44, 41);
            this.button12.TabIndex = 29;
            this.toolTip1.SetToolTip(this.button12, "現在の音楽をリストに追加できます");
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(6, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(510, 58);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(-3, 57);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(326, 69);
            this.trackBar1.TabIndex = 10;
            this.toolTip1.SetToolTip(this.trackBar1, "終わりの位置を指定できます");
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(9, 478);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(573, 88);
            this.button4.TabIndex = 12;
            this.button4.Text = "停止";
            this.toolTip1.SetToolTip(this.button4, "音楽を強制終了させます");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1178, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 15);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Fuchsia;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Location = new System.Drawing.Point(257, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 90);
            this.panel1.TabIndex = 18;
            this.toolTip1.SetToolTip(this.panel1, "終わりの位置を指定できます");
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.メニューToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1178, 33);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // メニューToolStripMenuItem
            // 
            this.メニューToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readmeを開くToolStripMenuItem,
            this.ヘルプを表示するToolStripMenuItem,
            this.終了するToolStripMenuItem});
            this.メニューToolStripMenuItem.Name = "メニューToolStripMenuItem";
            this.メニューToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.メニューToolStripMenuItem.Text = "メニュー";
            // 
            // readmeを開くToolStripMenuItem
            // 
            this.readmeを開くToolStripMenuItem.Name = "readmeを開くToolStripMenuItem";
            this.readmeを開くToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.readmeを開くToolStripMenuItem.Text = "readmeを開く";
            this.readmeを開くToolStripMenuItem.Click += new System.EventHandler(this.readmeを開くToolStripMenuItem_Click);
            // 
            // ヘルプを表示するToolStripMenuItem
            // 
            this.ヘルプを表示するToolStripMenuItem.Checked = true;
            this.ヘルプを表示するToolStripMenuItem.CheckOnClick = true;
            this.ヘルプを表示するToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ヘルプを表示するToolStripMenuItem.Name = "ヘルプを表示するToolStripMenuItem";
            this.ヘルプを表示するToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.ヘルプを表示するToolStripMenuItem.Text = "ヘルプを表示する";
            this.ヘルプを表示するToolStripMenuItem.Click += new System.EventHandler(this.ヘルプを表示するToolStripMenuItem_Click);
            // 
            // 終了するToolStripMenuItem
            // 
            this.終了するToolStripMenuItem.Name = "終了するToolStripMenuItem";
            this.終了するToolStripMenuItem.Size = new System.Drawing.Size(237, 34);
            this.終了するToolStripMenuItem.Text = "終了する";
            this.終了するToolStripMenuItem.Click += new System.EventHandler(this.終了するToolStripMenuItem_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.song,
            this.musicduration,
            this.location});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(599, 153);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(567, 413);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // Number
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Number.DefaultCellStyle = dataGridViewCellStyle1;
            this.Number.HeaderText = "No.";
            this.Number.MinimumWidth = 8;
            this.Number.Name = "Number";
            this.Number.Width = 45;
            // 
            // song
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("HGSｺﾞｼｯｸM", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.song.DefaultCellStyle = dataGridViewCellStyle2;
            this.song.HeaderText = "曲名";
            this.song.MinimumWidth = 8;
            this.song.Name = "song";
            this.song.Width = 300;
            // 
            // musicduration
            // 
            this.musicduration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.musicduration.HeaderText = "長さ";
            this.musicduration.MinimumWidth = 8;
            this.musicduration.Name = "musicduration";
            this.musicduration.Width = 50;
            // 
            // location
            // 
            this.location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.location.HeaderText = "場所";
            this.location.MinimumWidth = 8;
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Fuchsia;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.trackBar2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Location = new System.Drawing.Point(258, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 88);
            this.panel2.TabIndex = 19;
            this.toolTip1.SetToolTip(this.panel2, "開始の位置を指定できます");
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // trackBar2
            // 
            this.trackBar2.Enabled = false;
            this.trackBar2.Location = new System.Drawing.Point(3, 56);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(326, 69);
            this.trackBar2.TabIndex = 5;
            this.toolTip1.SetToolTip(this.trackBar2, "開始の位置を指定できます");
            this.trackBar2.Value = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(599, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(567, 25);
            this.textBox2.TabIndex = 27;
            // 
            // button13
            // 
            this.button13.Enabled = false;
            this.button13.Font = new System.Drawing.Font("HGｺﾞｼｯｸE", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button13.Image = global::rndtimer.Properties.Resources.DirectXThreeD;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button13.Location = new System.Drawing.Point(1044, 58);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(109, 47);
            this.button13.TabIndex = 29;
            this.button13.Text = "RANDOM OFF";
            this.button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.button13, "ランダムに曲を選ぶか選択できます");
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Image = global::rndtimer.Properties.Resources.AddRow;
            this.button11.Location = new System.Drawing.Point(944, 59);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(44, 46);
            this.button11.TabIndex = 28;
            this.toolTip1.SetToolTip(this.button11, "プレイリストの追加");
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Image = global::rndtimer.Properties.Resources.Delete;
            this.button10.Location = new System.Drawing.Point(826, 59);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(44, 46);
            this.button10.TabIndex = 26;
            this.toolTip1.SetToolTip(this.button10, "クリア");
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Image = global::rndtimer.Properties.Resources.Add;
            this.button9.Location = new System.Drawing.Point(892, 59);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(46, 46);
            this.button9.TabIndex = 25;
            this.toolTip1.SetToolTip(this.button9, "曲の追加");
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Image = global::rndtimer.Properties.Resources.SaveAs;
            this.button8.Location = new System.Drawing.Point(776, 59);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(44, 46);
            this.button8.TabIndex = 24;
            this.toolTip1.SetToolTip(this.button8, "名前を付けて保存");
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Image = global::rndtimer.Properties.Resources.Save;
            this.button7.Location = new System.Drawing.Point(723, 59);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 46);
            this.button7.TabIndex = 23;
            this.toolTip1.SetToolTip(this.button7, "保存");
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Image = global::rndtimer.Properties.Resources.DeleteTableRow;
            this.button6.Location = new System.Drawing.Point(994, 59);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(44, 46);
            this.button6.TabIndex = 22;
            this.toolTip1.SetToolTip(this.button6, "選択音楽を削除");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Image = global::rndtimer.Properties.Resources.AddDocument;
            this.button5.Location = new System.Drawing.Point(599, 59);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 46);
            this.button5.TabIndex = 21;
            this.toolTip1.SetToolTip(this.button5, "新しいプレイリストを作成できます");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Image = global::rndtimer.Properties.Resources.OpenFolder;
            this.button3.Location = new System.Drawing.Point(654, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 46);
            this.button3.TabIndex = 20;
            this.toolTip1.SetToolTip(this.button3, "プレイリストを開きます");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1178, 610);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(300, 100);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Form1";
            this.Text = "ランダムストップ！";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem メニューToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readmeを開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプを表示するToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了するToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn song;
        private System.Windows.Forms.DataGridViewTextBoxColumn musicduration;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
    }
}

