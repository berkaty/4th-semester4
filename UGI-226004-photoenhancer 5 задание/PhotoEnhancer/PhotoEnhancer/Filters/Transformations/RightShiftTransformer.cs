using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer.Filters.Transformations
{
    public class RightShiftTransformer : ITransformer<RightShiftParameters>
    {
        Size oldSize;
        public Size ResultSize { get; private set; }
        double percent;
        double shiftPixels;

        public void Initialize(Size oldSize, RightShiftParameters parameters)
        {
            this.oldSize = oldSize;
            ResultSize = oldSize;
            percent = parameters.Percent / 100;
            shiftPixels = oldSize.Width * percent;

        }

        public Point? MapPoint(Point newPoint)
        {
            var p = new Point(newPoint.X, newPoint.Y);
            var x = (int)(newPoint.X - shiftPixels + oldSize.Width) % oldSize.Width;

            if (x < 0 || x >= oldSize.Width || p.Y < 0 || p.Y >= oldSize.Height)
                return null;

            return new Point(x, p.Y);
        }
    }
}
