using System.ComponentModel;

namespace TplExamples.Algorithms
{
    public interface IRenderingAlgorithm
    {
        void Calculate(object sender, DoWorkEventArgs e);
    }
}