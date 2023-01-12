using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B.IPTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void оПРОГРАММЕToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show
                (
                "Программа создана \n" +
                "Cтудентом ЯГТУ группы ЭИСБ-24 \n" +
                "Болониным Михаилом Александровичем \n" +
                "По просьбе Вологина Александра Николаевича"
                );
        }

        private void инствукцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show
                (
                "После нажатия на кнопку\n" +
                "Будут представлены IP адрес и номер маски\n" +
                "По этим данным нужно отпределить:\n" +
                "1)Netmask\n" +
                "2)Network\n" +
                "3)Broadcast\n" +
                "4)Hosts\n" +
                "На выполнение задания дается 2 минуты"
                );
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
