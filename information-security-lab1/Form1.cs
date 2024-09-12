namespace information_security_lab1
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private Pen pen;
        private Point InformationPoint;
        private Point FirstWindowPoint;
        private Point SecondWindowPoint;
        private float yzab;
        private float xzab;
        private float yokn;
        private float xokn1;
        private float xokn2;
        private float yinf;
        private float xinf;
        private float left;
        private float right;
        private float top;
        private float bottom;
        private float xinvade;
        private float okninvade = 1;
        private float k1 = 2;
        private float k2 = 0.5f;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            pen = new Pen(Color.Black, 3f);
        }

        private void CoordinateAxesDraw()
        {
            g.Clear(Color.White);

            g.DrawLine(pen, 0, 0, 0, pictureBox1.Height);
            g.DrawLine(pen, 0, pictureBox1.Height, pictureBox1.Width, pictureBox1.Height);
        }

        private void Draw()
        {
            CoordinateAxesDraw();
            UpdateValues();
            DrawSecureObject();
            DrawWindows();
            DrawInvadeRoute();
        }

        private void DrawSecureObject()
        {
            g.DrawLine(pen, 0, yzab, xzab, yzab);
            g.DrawLine(pen, xzab, yzab, xzab, pictureBox1.Height);
            g.DrawRectangle(pen, left, top, right - left, bottom - top);
            g.DrawRectangle(pen, xinf - 5, yinf - 5, 10, 10);
        }

        private void DrawWindows()
        {
            Pen window = new Pen(Color.Blue, 5f);
            g.DrawLine(window, xokn1 - 10, yokn, xokn1 + 10, yokn);
            g.DrawLine(window, xokn2 - 10, yokn, xokn2 + 10, yokn);
        }

        private void DrawInvadeRoute()
        {
            Pen invade = new Pen(Color.Red, 2f);
            if (okninvade == 1)
            {
                g.DrawLine(invade, xinvade * 10, yzab, xokn1, yokn);
                g.DrawLine(invade, xokn1, yokn, xinf, yinf);
            }
            else
            {
                g.DrawLine(invade, xinvade * 10, yzab, xokn2, yokn);
                g.DrawLine(invade, xokn2, yokn, xinf, yinf);
            }
        }

        private void UpdateValues()
        {
            yzab = pictureBox1.Height - 10 * (float)numericUpDownYzab.Value;
            xzab = 10 * (float)numericUpDownXzab.Value;
            yokn = pictureBox1.Height - 10 * (float)numericUpDownYokn.Value;
            xokn1 = 10 * (float)numericUpDownXokn1.Value;
            xokn2 = 10 * (float)numericUpDownXokn2.Value;
            yinf = pictureBox1.Height - 10 * (float)numericUpDownYinf.Value;
            xinf = 10 * (float)numericUpDownXinf.Value;

            left = Math.Min(xokn1, xinf) - 20;
            right = Math.Max(xokn2, xinf) + 20;
            top = yokn;
            bottom = yinf + 20;
        }

        private void UpdateValuesMaximum()
        {
            numericUpDownYokn.Maximum = numericUpDownYzab.Value - 1;
            numericUpDownYinf.Maximum = numericUpDownYokn.Value - 1;
            numericUpDownXokn2.Maximum = numericUpDownXzab.Value - 2;
            numericUpDownXokn1.Maximum = numericUpDownXokn2.Value - 1;
            numericUpDownXinf.Maximum = numericUpDownXzab.Value - 1;
        }

        private void numericUpDownYzab_Leave(object sender, EventArgs e)
        {
            UpdateValuesMaximum();
            Count();
            Draw();
        }

        private void Count()
        {
            xinvade = 100;
            float step = (float)numericUpDownXzab.Value / 100;
            float l21 = DistanceBetweenTwoPoints((float)numericUpDownXokn1.Value, (float)numericUpDownYokn.Value, (float)numericUpDownXinf.Value, (float)numericUpDownYinf.Value);
            float l22 = DistanceBetweenTwoPoints((float)numericUpDownXokn2.Value, (float)numericUpDownYokn.Value, (float)numericUpDownXinf.Value, (float)numericUpDownYinf.Value);
            float res = 100;

            for (int i = 0; i <= 100; i++)
            {
                float l11 = DistanceBetweenTwoPoints(i * step, (float)numericUpDownYzab.Value, (float)numericUpDownXokn1.Value, (float)numericUpDownYokn.Value);
                float l12 = DistanceBetweenTwoPoints(i * step, (float)numericUpDownYzab.Value, (float)numericUpDownXokn2.Value, (float)numericUpDownYokn.Value);

                float res1 = k1 / l11 * (float)numericUpDownPokn1.Value * k2 / l21;
                if (res1 < res && res1 > 0) 
                { 
                    xinvade = i * step;
                    okninvade = 1;
                    res = res1;
                }

                float res2 = k1 / l12 * (float)numericUpDownPokn2.Value * k2 / l22;
                if (res2 < res && res2 > 0)
                {
                    xinvade = i * step;
                    okninvade = 2;
                    res = res2;
                }

            }
            if (res > 99) res = 0;

            labelResult.Text = res.ToString();
        }

        private float DistanceBetweenTwoPoints(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
