using System;
using System.Windows.Forms;
using Transitions;

namespace ColorSplash.UI {
    public partial class Snackbar : UserControl {

        public bool isShowing;
        private float counter = 0;
        private float duration;

        public Snackbar() {
            InitializeComponent();

            this.Visible = false;
            timer.Interval = 100;
        }

        public void show(string text, float duration) {
            if (isShowing)
                end();

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
        }

        private void Timer_Tick(object sender, EventArgs e) {
            //Timer's interval is 100 milisecons (100 miliseconds = 0.1 second)
            counter += 0.1f;

            if (counter >= duration)
                end();
        }
    }
}
