using PhotoEnhancer.Filters.Transformations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            //mainForm.AddFilter(new LighteningFilter());
            //mainForm.AddFilter(new GrayScaleFilter());
            //mainForm.AddFilter(new HueFilter());

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (p, parameters) => p * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (p, parameters) =>
                {
                    var lightness = 0.3 * p.R + 0.6 * p.G + 0.1 * p.B;
                    return new Pixel(lightness, lightness, lightness);
                }
                ));

            mainForm.AddFilter(new PixelFilter<HueParameters>(
                "Оттенок",
                (p, parameters) =>
                {
                    var q = Convertors.RGBToHSL(p);

                    var hue = q.H * 360 + parameters.Shift;

                    if (hue >= 360)
                        hue -= 360;

                    return Convertors.HSLToRGB(new PixelHSL(hue / 360, q.S, q.L));
                }
                ));

            mainForm.AddFilter(new PixelFilter<SepiaParameters>(
                "Сепия",
                (p, parameters) =>
                {
                    var q = Convertors.RGBToHSL(p);

                    return Convertors.HSLToRGB(new PixelHSL(parameters.Hue / 360, parameters.Saturation, q.L));
                }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Поворот на 90° против ч.с.",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, point.X)
                ));

            mainForm.AddFilter(new TransformFilter(
                "Мозаика",
                size => new Size(size.Width*2, size.Height * 2),
                (point, size) => {
                    if (point.X < size.Width && point.Y < size.Height)
                        return new Point(point.X, point.Y); 
                    if (point.X >= size.Width && point.Y < size.Height)
                        return new Point(2 * size.Width - point.X - 1, point.Y); 
                    if (point.X < size.Width && point.Y >= size.Height)
                        return new Point(point.X, 2 * size.Height - point.Y - 1); 
                    else
                        return new Point(2 * size.Width - point.X - 1, 2 * size.Height - point.Y - 1);
                }
            ));

            mainForm.AddFilter(new TransformFilter<RotationParameters>(
                "Поворот на произвольный угол", new RotationTransformer()));

            Application.Run(mainForm);
        }
    }
}
