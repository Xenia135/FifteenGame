using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLibrary
{
    public partial class GameTimer: UserControl
    {
        public GameTimer()
        {
            InitializeComponent();
        }

        public void Start()
        {
            display.Text = "00:00:00";
        }

        public DateTime date;
        public void StartGame()
        {
            display.Text = "00:00:00";
            timer1.Enabled = true;
            date = new DateTime();
        }
        public void Stop()
        {
            timer1.Enabled= false;
            display.Text="00:00:00";
        }
        private void time_Tick(object sender,EventArgs e)
        {
            date = date.AddSeconds(1);
            display.Text=date.ToString("HH:mm:ss");
        }

        public string GetTimer()
        { return display.Text; }
    }
}
