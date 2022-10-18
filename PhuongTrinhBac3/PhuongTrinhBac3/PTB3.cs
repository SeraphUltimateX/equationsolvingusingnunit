using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuongTrinhBac3
{
    public class PTB3
    {
        public const double pi = 3.14159265359;
        public static double[] SolvePT3(double a, double b, double c, double d)
        {
            /*if(a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        throw new ArgumentOutOfRangeException("Phương trình vô nghiệm");
                    }
                }
            }
            else
            {*/
                double delta = b * b - 3 * a * c; //52
                double k = (double)((9 * a * b * c - 2 * b * b * b - 27 * a * a * d) / (2 * Math.Sqrt(Math.Abs(Math.Pow(delta, 3))))); //0.76467118026
                double x1, x2, x3;
                if (delta > 0)
                {
                    if (Math.Abs(k) <= 1)
                    {
                        x1 = (double)((2 * Math.Sqrt(delta) * Math.Cos(Math.Acos(k) / 3) - b) / 3 * a);

                        x2 = (double)((2 * Math.Sqrt(delta) * Math.Cos(Math.Acos(k) / 3 - (2 * pi) / 3) - b) / 3 * a);

                        x3 = (double)((2 * Math.Sqrt(delta) * Math.Cos(Math.Acos(k) / 3 + (2 * pi) / 3) - b) / 3 * a);
                        return new double[] { x1,x2,x3 };
                    }
                    else
                    {
                        x1 = (double)((((Math.Sqrt(delta) * Math.Abs(k)) / 3 * a * k) * ((Math.Cbrt(Math.Abs(k) + Math.Sqrt(k * k - 1))) + (Math.Cbrt(Math.Abs(k) - Math.Sqrt(k * k - 1))))) - (b / 3 * a));
                        return new double[] { x1 };
                    }

                }
                else if (delta == 0)
                {
                    x1 = (double)((-b + Math.Cbrt(b * b * b - (27 * a * a * d))) / 3 * a);
                    return new double[] { x1 };

                }
                else 
                {
                    x1 = (double)(((Math.Sqrt(Math.Abs(delta)) / 3 * a) * ((Math.Cbrt(k + Math.Sqrt(k * k + 1))) + (Math.Cbrt(k - Math.Sqrt(k * k + 1))))) - (b / 3 * a));
                    return new double[] { x1 };

                }
            /*}*/
            /*return new double[]{};*/
        }
        public static void Main()
        {
            SolvePT3(1,1,1,1/3);
        }
    }
}
