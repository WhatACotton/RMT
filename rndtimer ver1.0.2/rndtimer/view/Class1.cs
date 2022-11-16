using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace syy
{
    public partial class Form１ : Form
    {
        bool checking1 = true;
        bool checking2 = true;
        bool checking3 = true;
        bool checking4 = true;
        public int count = 0;
        public string text1 = "首相";
        public string text2 = "時間";
        public string text3 = "代";
        public string text4 = "回数";
        string fbangou;
        string[] listing;
        string linku;

        //インスタンスを取得
        Kansu kagi = new Kansu();
        public Form１()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //現在時刻を取得
            DateTime jikan = DateTime.Now;

            //インスタンスを用いてメソッドにアクセスしランダムな時間を取得
            DateTime rndjikan = kagi.Choosingtime(jikan);

            //取得した時間を形式をきれいにして表示
            label2.Text = rndjikan.ToString("yyyy/MM/dd");

            //ランダムな時間をメソッドに代入してその時が何代目の政権かを取得
            int bangou = kagi.Choosingbangou(rndjikan);

            //取得した数をきれいにして表示
            string bangoubun = "第" + bangou.ToString() + "代首相";
            label3.Text = bangoubun;

           

            count++;

            if (bangou < 10)
            {
                fbangou = "00" + bangou.ToString();
            }
            else if (bangou < 100)
            {
                fbangou = "0" + bangou.ToString();
            }
            else
            {
                fbangou = "https://www.kantei.go.jp/jp/rekidainaikaku/" + fbangou + ".html";
            }
            linku = "https://www.kantei.go.jp/jp/rekidainaikaku/" + fbangou + ".html";
            listing = new string[] { count.ToString(), rndjikan.ToString("yyyy/MM/dd"), bangou.ToString(), syushounamae };
            label4.Text = count.ToString() + "回目";
            var linksuru = "rekidai_index_" + fbangou;
            pictureBox1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(linksuru, Properties.Resources.Culture);



        }

        private void Form１_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checking1 == false & checking2 == true & checking4 == true)
            {
                checkBox3.Checked = true;
            }
            if (checking1 == true & checking2 == false & checking4 == false)
            {
                checkBox3.Checked = false;
            }

            if (checking1 == true)
            {
                checking1 = false;
                label1.Visible = false;
            }
            else
            {
                checking1 = true;
                label1.Visible = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checking1 == true & checking2 == false & checking4 == true)
            {
                checkBox3.Checked = true;
            }
            if (checking1 == false & checking2 == true & checking4 == false)
            {
                checkBox3.Checked = false;
            }
            if (checking2 == true)
            {
                checking2 = false;
                label3.Visible = false;
            }
            else
            {
                checking2 = true;
                label3.Visible = true;
            }



        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checking3 == true)
            {
                checking3 = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
            else
            {
                checking3 = true;
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox4.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("リセットしますか？",
       "確認",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.None,
       MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                count = 0;
                dataGridView1.Rows.Clear();
                label1.Text = text1;
                label2.Text = text2;
                label3.Text = text3;
                label4.Text = text4;
                pictureBox1.Image = null;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(linku);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checking1 == true & checking2 == true & checking4 == false)
            {
                checkBox3.Checked = true;
            }
            if (checking1 == false & checking2 == false & checking4 == true)
            {
                checkBox3.Checked = false;
            }
            if (checking4 == true)
            {
                checking4 = false;
                pictureBox1.Visible = false;
            }
            else
            {
                checking4 = true;
                pictureBox1.Visible = true;
            }

        }
        
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //取得した番号をもとに首相を特定
            string syushounamae = kagi.Choosingnamae(bangou);
            label1.Text = syushounamae;
            if (count != 0)
            {
                dataGridView1.Rows.Insert(0, listing);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}


