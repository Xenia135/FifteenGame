using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Par2
{
    //Par2
    public partial class UserControl1: UserControl
    {
        DateTime date;

        public UserControl1()
        {
            InitializeComponent();
        }

        public void Start()
        {
            date = new DateTime();
            timer1.Enabled = true;
            Label.Text = "Время: 00:00:00";
        }
        public void Stop()
        {
            timer1.Enabled = false;
        }
        public string GetTime()
        {
            return date.ToString("HH:mm:ss");
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            date = date.AddSeconds(1);
            UpdateTimeToDisplay();
        }

        private void UpdateTimeToDisplay()
        {
            Label.Text = "Время: " + date.ToString("HH:mm:ss");
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
