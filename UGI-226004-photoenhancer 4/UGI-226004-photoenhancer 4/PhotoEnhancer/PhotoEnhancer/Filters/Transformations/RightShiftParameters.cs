using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class RightShiftParameters : IParameters
    {
        public double Percent { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo()
                {
                    Name = "Процент сдвига",
                    MinValue = 0,
                    MaxValue = 100,
                    DefaultValue = 0,
                    Increment = 5
                }
            };
        }

        public void SetValues(double[] values)
        {
            Percent = values[0];
        }
    }
}
