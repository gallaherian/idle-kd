using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Collections.Specialized;

namespace idleKD
{
    public partial class Form1 : Form
    {
        Timer timer;
        DateTime lastIdle;
        double largestIdle_s = 0;
        double largestFocus_s = 0;
        int idleThreshold_s = 60;
        DateTime lunchStart, lunchEnd;
        int updatePeriod_ms = 500;
        int lunchIdle = 0;
        int totalIdleTime_ms = 0;
        int totalTime_ms;
        DateTime lastReset = DateTime.Now;


        static int totalIdleTime = 0;
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(out LASTINPUTINFO plii);

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf =
                   Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public int dwTime;
        }

        public Form1()
        {
            InitializeComponent();

            idleThreshold_s = Convert.ToInt32(Properties.Settings.Default["IdleThreshold_s"]);
            updatePeriod_ms = Convert.ToInt32(Properties.Settings.Default["UpdatePeriod_ms"]);
            lunchStart = Convert.ToDateTime(Properties.Settings.Default["LunchTimeStart"]);
            lunchEnd = Convert.ToDateTime(Properties.Settings.Default["LunchTimeEnd"]);

            if (Convert.ToInt32(Properties.Settings.Default["LastDay"]) == DateTime.Now.Day)
            {
                largestFocus_s = Convert.ToInt32(Properties.Settings.Default["LastFocus"]);
                largestIdle_s = Convert.ToInt32(Properties.Settings.Default["LastIdle"]);
            }

            label1.Text = "";
            timer = new Timer();
            timer.Interval = updatePeriod_ms;
            timer.Tick += Timer_Tick;
            timer.Start();

            lastIdle = DateTime.Now;
        }

        private void idleLabel_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            //this.Visible = false;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //this.Visible = true;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //this.Visible = false;
            //var currentTime = DateTime.Now;
            //while((DateTime.Now - currentTime).TotalSeconds < 5)
            //{
            //}
            //this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalTime_ms = 0;
            largestIdle_s = 0;
            largestFocus_s = 0;
        }

        private void totLabel_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;
            //totalTime_ms += updatePeriod_ms;

            int envTicks = Environment.TickCount;

            if (GetLastInputInfo(out lastInputInfo))
            {
                int lastInputTick = lastInputInfo.dwTime;
                idleTime = envTicks - lastInputTick;
                //totalIdleTime_ms += idleTime;
            }

            // Calc total ToT
            totLabel.Text = "TOT: " + TimeSpan.FromMilliseconds(totalTime_ms - totalIdleTime_ms).ToString(@"hh\:mm\:ss");

            if (idleTime > (idleThreshold_s * 1000)) // Been idle for longer than threshold
            {
                if (DateTime.Compare(DateTime.Now, lunchStart) == 1 && DateTime.Compare(DateTime.Now, lunchEnd) == -1)
                {
                    this.label1.Text = "  BREAK";
                    this.label1.ForeColor = Color.DarkGray;
                    lastIdle = DateTime.Now;
                    return;
                }
                else if (DateTime.Compare(DateTime.Now, lunchEnd) == 1 && (DateTime.Now - lunchEnd).TotalMilliseconds < updatePeriod_ms)
                {
                    // If we have JUST exited lunch, and are still in a idle period
                    lunchIdle = idleTime;
                }

                var time = TimeSpan.FromMilliseconds(idleTime - lunchIdle);
                this.label1.Text = time.ToString(@"hh\:mm\:ss");
                this.label1.ForeColor = Color.Red;
                lastIdle = DateTime.Now;

                if (time.TotalSeconds > largestIdle_s)
                    largestIdle_s = (int)time.TotalSeconds;
            }
            else
            {
                totalTime_ms += updatePeriod_ms;
                lunchIdle = 0;
                var duration = (DateTime.Now - lastIdle);

                if (duration.TotalSeconds > largestFocus_s)
                    largestFocus_s = duration.TotalSeconds;
                
                this.label1.Text = duration.ToString(@"hh\:mm\:ss");
                this.label1.ForeColor = Color.Green;
            }

            var idleSpan = TimeSpan.FromSeconds(largestIdle_s);
            var focusSpan = TimeSpan.FromSeconds(largestFocus_s);
            focusLabel.Text = focusSpan.ToString(@"hh\:mm\:ss");
            idleLabel.Text = idleSpan.ToString(@"hh\:mm\:ss");

            this.BringToFront(); // Keep window in front of others

            //percLabel.Text = ((int)(100 * (double)totalTime_ms / (double)totalIdleTime_ms)).ToString() + "%";

            Properties.Settings.Default["LastFocus"] = ((int)largestFocus_s).ToString();
            Properties.Settings.Default["LastIdle"] = ((int)largestIdle_s).ToString();
            Properties.Settings.Default["LastDay"] = DateTime.Now.Day.ToString();
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }
    }
}
