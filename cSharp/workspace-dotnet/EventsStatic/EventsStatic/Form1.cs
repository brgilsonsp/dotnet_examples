using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsStatic
{
    public partial class Form1 : Form
    {
        private static System.Windows.Forms.Timer _timerTest = new System.Windows.Forms.Timer();
        private static int _count = 1;

        static Form1()
        {
            _timerTest.Interval = 100;
            _timerTest.Tick += new System.EventHandler(_timerTest_Tick);
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        private static void _timerTest_Tick(object sender, EventArgs e)
        {
            Console.WriteLine($"Executou o tick {_count++} vezes");
        }

        private void startTick_Click(object sender, EventArgs e)
        {
            startClockMethod();
        }

        private void stopTick_Click(object sender, EventArgs e)
        {
            _timerTest.Stop();
        }

        private static void startClockMethod()
        {
            _timerTest.Start();
        }
    }
}
