using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TplExamples.Algorithms;

namespace TplExamples
{
    public partial class RenderManyLines : Form
    {
        private Bitmap _image;
        private int _lines;
        private List<int> _tpThreads;
        private List<int> _dedicatedThreads;
        public RenderManyLines()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;

            _lines = 720;
            _tpThreads = new List<int>();
            _dedicatedThreads = new List<int>();
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
                case "BadLongRunning":
                    return new BadLongRunningAlgorithm(_lines);
                case "GoodLongRunning":
                    return new GoodLongRunningAlgorithm(_lines);
            }

            return null;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] args = (object[])e.UserState;
            var threadId = (int) args[0];
            var isTP = (bool) args[2];
            var threadColor = ColorPicker.GetThreadColor(threadId, isTP);
            var line = (int)args[1];
            for (int i = 0; i < _lines; i++)
            {
                _image.SetPixel(i, line, threadColor);
            }
            panel1.Invalidate(new Rectangle(0, line, _image.Width, 1));

            if(isTP)
                _tpThreads.Add(threadId);
            else _dedicatedThreads.Add(threadId);
            var tpCount = _tpThreads.Distinct().Count();
            lblTpThreads.Text = tpCount.ToString();
            lblDedicated.Text = _dedicatedThreads.Distinct().Count().ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_image != null)
                e.Graphics.DrawImage(_image, 0, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
