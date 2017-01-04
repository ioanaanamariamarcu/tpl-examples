using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplExamples.Algorithms
{
    static class ColorPicker
    {
        private static Color[] _newThreadColorTable = { Color.Red, Color.DarkRed,
            Color.IndianRed, Color.PaleVioletRed, Color.MediumVioletRed, Color.OrangeRed, Color.Violet, Color.Fuchsia };
        private static Color[] _threadPoolColorTable =
        {
            Color.Green, Color.GreenYellow, Color.DarkGreen, Color.DarkOliveGreen,
            Color.DarkSeaGreen, Color.ForestGreen, Color.LawnGreen, Color.MediumSeaGreen, Color.LightGreen,
            Color.LightSeaGreen, Color.LimeGreen, Color.MediumSpringGreen, Color.DarkGreen, Color.DarkOliveGreen,
            Color.PaleGreen, Color.CadetBlue, Color.LightSkyBlue, Color.MediumSlateBlue
        };

        public static Color GetThreadColor(int id, bool isThreadPoolThread)
        {
            var colorTable = isThreadPoolThread ? _threadPoolColorTable : _newThreadColorTable;
            return colorTable[id%colorTable.Length];
        }
    }
}
