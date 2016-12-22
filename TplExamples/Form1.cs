using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TplExamples.Algorithms;

namespace TplExamples
{
    public partial class Form1 : Form
    {
        private Color[] _colorTable;
        private Bitmap _image;
        private int _lines;
        public Form1()
        {
            InitializeComponent();
            _colorTable = new Color[8];  
            _colorTable[0] = Color.Red;
            _colorTable[1] = Color.Blue;
            _colorTable[2] = Color.Yellow;
            _colorTable[3] = Color.Green;
            _colorTable[4] = Color.LightBlue;
            _colorTable[5] = Color.Fuchsia;
            _colorTable[6] = Color.Sienna;
            _colorTable[7] = Color.SpringGreen;
            panel1.Paint += panel1_Paint;

            _lines = 300;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _image?.Dispose();

            panel1.Width = _lines;
            panel1.Height = _lines;

            _image = new Bitmap(_lines, _lines);
            panel1.Invalidate();

            var worker = new BackgroundWorker {WorkerReportsProgress = true};

            var algorithm = GetAlgorithm(comboBox1.Text);

            worker.DoWork += algorithm.Calculate;
            worker.ProgressChanged += Worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        private IRenderingAlgorithm GetAlgorithm(string algorithm)
        {
            switch (algorithm)
            {
                case "Parallel":
                    return new ParallelAlgorithm(_lines);
                case "Sequential":
                    return new SequentialAlgorithm(_lines);
            }

            return null;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] args = (object[])e.UserState;
            
            int thread = (int)args[0];
            int line = (int)args[1];
            var c = _colorTable[thread % _colorTable.Length];
            for (int i = 0; i < _lines; i++)
            {
                _image.SetPixel(i, line, c);
            }
            panel1.Invalidate(new Rectangle(0, line, _image.Width, 1));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_image != null)
                e.Graphics.DrawImage(_image, 0, 0);
        }
    }
}
