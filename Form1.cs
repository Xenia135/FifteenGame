using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {

        Game game;

        private int count_move = 0;
        public Form1()
        {
            InitializeComponent();
            game = new Game(4);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int position = Convert.ToInt16(((Button)sender).Tag);
            if(game.Shift(position))
            {
                this.count_move++;
                this.Text = "Пятнашки " + "Ход: " + this.count_move;
            }
            refresh();
            
            //step.Text = "Ход: " + game.Count.ToString();
            if (game.Check())
            {
                MessageBox.Show("ВАУ!!!! ТЫ СМОГ!!!");
                this.count_move = 0;
                start_game();
                timer1.Start();
            }
        }

        private Button button(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }
        private void начатьГToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            start_game();
            this.tableLayoutPanel1.Enabled = true;
            timer1.Start();
        }
        private void start_game()
        {
            this.count_move = 0;
            this.Text = "Пятнашки " + "Ход: " + this.count_move;
            game.Start();
            for (int j = 0; j < 100; j++)
                game.ShiftRandom();
            refresh();
        }

        private void refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                int nr = game.GetNumber(position);
                button(position).Text = nr.ToString();
                button(position).Visible = (nr > 0);
            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// функция отмены хода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z && game.counter != 0)
            {
                Memento m = game.caraTaker.Pop();
                game.field = (int[,])m.State;
                game.space_x = m.space_x;
                game.space_y = m.space_y;
                game.counter--;
                Text = "Пятнашки" + "   Ход: " + game.counter.ToString();
                this.refresh();
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.count_move>0)
            {
                Memento m = game.caraTaker.Pop();
                game.field = (int[,])m.State;
                game.space_x = m.space_x;
                game.space_y = m.space_y;
                count_move--;
                Text = "Пятнашки" + "   Ход: " + this.count_move;
                this.refresh();
            }
        }
    }
}
