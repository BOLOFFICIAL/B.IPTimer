using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace B.IPTimer
{
    public partial class Form2 : Form
    {
        Stopwatch sw = new Stopwatch();
        Random rand = new Random();
        int number_mask = 0;
        double ip1 = 0;
        double ip2 = 0;
        double ip3 = 0;
        double ip4 = 0;
        double br1 = 0, br2 = 0, br3 = 0, br4 = 0;
        double nw1 = 0, nw2 = 0, nw3 = 0, nw4 = 0;
        string NETMASK = "";
        string NETWORK = "";
        string BROADCAST = "";
        string HOSTS = "";
        Boolean answer = false;
        double h = 0;

        int[,] MASK = new int[33, 4]{
        {0,  0,  0,  0  },
        {128,0,  0,  0  },
        {192,0,  0,  0  },
        {224,0,  0,  0  },
        {240,0,  0,  0  },
        {248,0,  0,  0  },
        {252,0,  0,  0  },
        {254,0,  0,  0  },
        {255,0,  0,  0  },
        {255,128,0,  0  },
        {255,192,0,  0  },
        {255,224,0,  0  },
        {255,240,0,  0  },
        {255,248,0,  0  },
        {255,252,0,  0  },
        {255,254,0,  0  },
        {255,255,0,  0  },
        {255,255,128,0  },
        {255,255,192,0  },
        {255,255,224,0  },
        {255,255,240,0  },
        {255,255,248,0  },
        {255,255,252,0  },
        {255,255,254,0  },
        {255,255,255,0  },
        {255,255,255,128},
        {255,255,255,192},
        {255,255,255,224},
        {255,255,255,240},
        {255,255,255,248},
        {255,255,255,252},
        {255,255,255,254},
        {255,255,255,255}
        };

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public Boolean TRUE(string NETMASK,string NETWORK,string BROADCAST,string HOSTS) {
            Boolean output = false;
            Boolean b1 = false;
            Boolean b2 = false;
            Boolean b3 = false;
            Boolean b4 = false;
            try
            {
                if (NETMASK == textBox1.Text) { b1 = true; }
                if (NETWORK == textBox4.Text) { b2 = true; }
                if (BROADCAST == textBox3.Text) { b3 = true; }
                if (HOSTS == textBox2.Text || int.Parse(HOSTS) == int.Parse(textBox2.Text) + 2) { b4 = true; }
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректные данные","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            output = b1 && b2 && b3 && b4;
            return output;
        }
        public double BR(double ip, double mod)
        {
            double br = 0;
            while (true)
            {
                br += mod;
                if (br >= ip) { return br; }
                br++;
            }
        }
        public void START() {
            string start = "";
            number_mask = rand.Next(15,31)%34;
            NETMASK = $"{MASK[number_mask, 0]}.{MASK[number_mask, 1]}.{MASK[number_mask, 2]}.{MASK[number_mask, 3]}";
            ip1 = rand.Next(256);
            ip2 = rand.Next(256);
            ip3 = rand.Next(256);
            ip4 = rand.Next(256);
            start = $"{ip1}.{ip2}.{ip3}.{ip4}/{number_mask}";
            HOSTS = $"{Math.Pow(2, (32 - number_mask))}";
            h = Math.Pow(2, ((32 - number_mask) % 8)) - 1;
            if (number_mask < 9)
            {
                br1 = BR(ip1, h);
                nw1 = br1 - h;
                br2 = br3 = br4 = 255;
                nw2 = nw3 = nw4 = 0;
            }
            else if (number_mask < 17)
            {
                br1 = nw1 = ip1;
                br2 = BR(ip2, h);
                nw2 = br2 - h;
                br3 = br4 = 255;
                nw3 = nw4 = 0;
            }
            else if (number_mask < 25)
            {
                br1 = nw1 = ip1;
                br2 = nw2 = ip2;
                br3 = BR(ip3, h);
                nw3 = br3 - h;
                br4 = 255;
                nw4 = 0;
            }
            else
            {
                br1 = nw1 = ip1;
                br2 = nw2 = ip2;
                br3 = nw3 = ip3;
                br4 = BR(ip4, h);
                nw4 = br4 - h;
            }
            BROADCAST = $"{br1}.{br2}.{br3}.{br4}";
            NETWORK = $"{nw1}.{nw2}.{nw3}.{nw4}";
            textBox5.Text = start;
            sw.Start();
        }
        public Form2()
        {
            InitializeComponent();
            START();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TRUE(NETMASK,NETWORK,BROADCAST,HOSTS))
            {
                sw.Stop();
                if (Convert.ToDouble(sw.ElapsedMilliseconds) / 1000 / 60 < 2)
                {
                    DialogResult res = MessageBox.Show($"Задание отправлено через \n" +
                        $"{Convert.ToDouble(sw.ElapsedMilliseconds) / 1000 / 60} минут\n\n" +
                        $"Вердикт:ТЕСТ ПРОЙДЕН");
                }
                else
                {
                    DialogResult res = MessageBox.Show($"Задание отправлено через " +
                        $"{Math.Round((Convert.ToDouble(sw.ElapsedMilliseconds) / 1000 / 60),1)} минут\n\n" +
                        $"Вердикт:ТЕСТ ПРОВАЛЕН");
                }
            }
            else {
                DialogResult res = MessageBox.Show("У тебя где-то ОШИБКА");
            }
        }
    }
}
