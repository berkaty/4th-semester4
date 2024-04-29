using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class SepiaFilter : PixelFilter<SepiaParameters>
    {
        public override Pixel ProcessPixel(Pixel p, SepiaParameters parameters)
        {
            var q = Convertors.RGBToHSL(p);

            return Convertors.HSLToRGB(new PixelHSL(parameters.Hue/360, parameters.Saturation, q.L));
        }

        public override string ToString()
        {
            return "Сепия";
        }
    }
}

