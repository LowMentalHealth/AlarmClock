using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace будильник
{
    public partial class Form1 : Form
    {
        private int Music = 0;
        private string NameFile = "";

        private string Hour = "";
        private string Minute = "";
        private string Second = "";

        private string HourNow = "";
        private string MinuteNow = "";
        private string SecondNow = "";

        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(Timer1_Tick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hour = DateTime.Now.Hour.ToString();
            Minute = DateTime.Now.Minute.ToString();
            Second = DateTime.Now.Second.ToString();

            if (Hour.Length == 1)
            {
                Hour = "0" + Hour;
            }
            if (Minute.Length == 1)
            {
                Minute = "0" + Minute;
            }
            if (Second.Length == 1)
            {
                Second = "0" + Second;
            }

            textBox1.Text = Hour;
            textBox2.Text = Minute;
            textBox3.Text = Second;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string extension = "";

            if (Music == 0)
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    NameFile = openFileDialog1.FileName;
                    extension = Path.GetExtension(NameFile);

                    if (extension != ".mp3")
                    {
                        MessageBox.Show("Укажите файл в формате mp3");
                        return;
                    }

                    button1.Text = "Трек выбран";

                }
            }
            else
            {
                WMP.controls.stop();
                button1.Text = "Трек выбран";
                Music = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Выключение")
            {
                if (Music == 1)
                {
                    WMP.controls.stop();
                    button1.Text = "Трек выбран";
                }

                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;

                timer1.Enabled = false;

                button2.BackColor = Color.LimeGreen;
                button2.Text = "Запуск";

            }
            else
            {



                if (textBox1.Text == "")
                {
                    MessageBox.Show("Дурной?");
                    return;
                }

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Дурной?");
                    return;
                }

                if (textBox3.Text == "")
                {
                    MessageBox.Show("Дурной?");
                    return;
                }

                if (!(Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) <= 23))
                {
                    MessageBox.Show("Все нормально с головой?");
                    return;
                }

                if (!(Convert.ToInt32(textBox2.Text) >= 0 && Convert.ToInt32(textBox2.Text) <= 59))
                {
                    MessageBox.Show("Все нормально с головой?");
                    return;
                }

                if (!(Convert.ToInt32(textBox3.Text) >= 0 && Convert.ToInt32(textBox3.Text) <= 59))
                {
                    MessageBox.Show("Все нормально с головой?");
                    return;
                }

                if (button1.Text == "выбор трека")
                {
                    MessageBox.Show("Поставь трек");
                }
                else
                {
                    button2.BackColor = Color.Red;
                    button2.Text = "Выключение";

                    Hour = textBox1.Text;
                    Minute = textBox2.Text;
                    Second = textBox3.Text;

                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;


                }

                timer1.Enabled = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            HourNow = DateTime.Now.Hour.ToString();
            MinuteNow = DateTime.Now.Minute.ToString();
            SecondNow = DateTime.Now.Second.ToString();

            if (HourNow.Length == 1)
            {
                HourNow = "0" + HourNow;
            }
            
            if (MinuteNow.Length ==1)
            {
                MinuteNow="0" + MinuteNow;
            }

            if (SecondNow.Length == 1)
            {
                SecondNow="0" + SecondNow;
            }

            if (Hour == HourNow && Minute == MinuteNow && Second == SecondNow)
            {
                WMP.URL = NameFile;
                WMP.settings.volume = 100;
                WMP.controls.play();

                Music = 1;

                button1.Text = "Выключить музыку";
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >='0' && e.KeyChar <= '9')
            {
                if (textBox1.Text.Length >= 0 && textBox1.Text.Length <=1) 
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char) Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (textBox2.Text.Length >= 0 && textBox2.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (textBox3.Text.Length >= 0 && textBox3.Text.Length <= 1)
                {
                    return;
                }
            }

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length ==1)
            {
                textBox1.Text = "0" + textBox1.Text;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 1)
            {
                textBox2.Text = "0" + textBox2.Text;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 1)
            {
                textBox3.Text = "0" + textBox3.Text;
            }
        }
    }
}
