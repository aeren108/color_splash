using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorSplash {
    public partial class Snackbar : UserControl {

        private bool isShowing;
        private float counter = 0;
        private float duration;

        public Snackbar() {
            InitializeComponent();

            this.Visible = false;
            timer.Interval = 100;
        }

        public void show(string text, float duration) {
            if (isShowing)
                timer.Stop();

            this.duration = duration;
            this.text.Text = text.ToUpper();
            this.Visible = true;

            timer.Start();

            isShowing = true;
        }

        private void end() {
            timer.Stop();
            counter = 0;
            isShowing = false;
            this.Visible = false;

            this.Update();

            Console.WriteLine("Bitti...");
        }

        private void Timer_Tick(object sender, EventArgs e) {
            //Timer's interval is 100 milisecons, so this method will run every 100 miliseconds (0.1 sec)
            counter += 0.1f;
           
            if (counter >= duration) {
                
                end();

            }
        }
    }
}
