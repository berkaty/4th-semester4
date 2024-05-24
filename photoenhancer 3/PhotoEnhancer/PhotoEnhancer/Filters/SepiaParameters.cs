using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class SepiaParameters : IParameters
    {
        public double Hue { get; set; }
        public double Saturation { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Оттенок",
                    MinValue = 0,
                    MaxValue = 359.95,
                    DefaultValue = 40,
                    Increment = 0.05
                },
                new ParameterInfo()
                {
                    Name = "Насыщенность",
                    MinValue = 0,
                    MaxValue = 1,
                    DefaultValue = 0.2,
                    Increment = 0.01
                }
            };
        }

        public void SetValues(double[] values)
        {
            Hue = values[0];
            Saturation = values[1];
        }
    }
}
