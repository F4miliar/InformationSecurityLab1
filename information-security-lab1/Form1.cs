namespace information_security_lab1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        Point InformationPoint;
        Point FirstWindowPoint;
        Point SecondWindowPoint;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void InitialDraw()
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            pen = new Pen(Color.Black, 3f);

            g.DrawLine(pen, 0, 0, 0, pictureBox1.Height);
            g.DrawLine(pen, 0, pictureBox1.Height, pictureBox1.Width, pictureBox1.Height);
        }

        private void Draw()
        {
            InitialDraw();
            float yzab = pictureBox1.Height - 10 * (float)numericUpDownYzab.Value;
            float xzab = 10 * (float)numericUpDownXzab.Value;
            float yokn = pictureBox1.Height - 10 * (float)numericUpDownYokn.Value;
            float xokn1 = 10 * (float)numericUpDownXokn1.Value;
            float xokn2 = 10 * (float)numericUpDownXokn2.Value;
            float yinf = pictureBox1.Height - 10 * (float)numericUpDownYinf.Value;
            float xinf = 10 * (float)numericUpDownXinf.Value;

            float left = Math.Min(xokn1, xinf) - 20;
            float right = Math.Max(xokn2, xinf) + 20;
            float top = yokn;
            float bottom = yinf + 20;

            g.DrawLine(pen, 0, yzab, xzab, yzab);
            g.DrawLine(pen, xzab, yzab, xzab, pictureBox1.Height);
            g.DrawRectangle(pen, left, top, right - left, bottom - top);
            g.DrawRectangle(pen, xinf - 5, yinf - 5, 10, 10);

            Pen window = new Pen(Color.Blue, 5f);
            g.DrawLine(window, xokn1 - 5, yokn, xokn1 + 5, yokn);
            g.DrawLine(window, xokn2 - 5, yokn, xokn2 + 5, yokn);
        }

        private void Check()
        {
            numericUpDownYokn.Maximum = numericUpDownYzab.Value - 1;
            numericUpDownYinf.Maximum = numericUpDownYokn.Value - 1;
            numericUpDownXokn2.Maximum = numericUpDownXzab.Value - 1;
            numericUpDownXokn1.Maximum = numericUpDownXokn2.Value - 1;
            numericUpDownXinf.Maximum = numericUpDownXzab.Value - 1;
        }

        private void numericUpDownYzab_Leave(object sender, EventArgs e)
        {
            Check();
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialDraw();
        }
    }
}
