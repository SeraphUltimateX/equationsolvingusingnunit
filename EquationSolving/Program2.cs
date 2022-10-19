using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace PhuongTrinhBac3
{
    class Program
    {
        public  const double pi = 3.14159265359;
        static double x1, a, b, c, d;
        public static void InputData()
        {
            char input;
            do
            {
                Console.Clear(); 
                Console.WriteLine("Nhap vao gia tri cua cac he so cua phuong trinh"); 
                Console.Write("He so a = "); a = double.Parse(Console.ReadLine()); 
                Console.Write("He so b = "); b = double.Parse(Console.ReadLine()); 
                Console.Write("He so c = "); c = double.Parse(Console.ReadLine()); 
                Console.Write("He so d = "); d = double.Parse(Console.ReadLine()); 
                Console.Write("Ban muon nhap lai he so hay khong? Co hoac Khong:");
                input = char.Parse(Console.ReadLine()); Console.WriteLine("\n");
            } while ((input == 'C') || (input == 'c'));

        }
        public static void giaiPTBac2(double a, double b, double c)
        {
            // kiem tra cac he so
            if (a == 0)
            {
                if (b == 0)
                {
                    Console.Write("Phuong trinh vo nghiem!");
                }
                else
                {
                    Console.Write("Phuong trinh co mot nghiem: x = {0}", (-c / b));
                }
                return;
            }
            // tinh delta
            double delta = b * b - 4 * a * c;
            double x1;
            double x2;
            // tinh nghiem
            if (delta > 0)
            {
                x1 = (double)((-b + Math.Sqrt(delta)) / (2 * a));
                x2 = (double)((-b - Math.Sqrt(delta)) / (2 * a));
                Console.Write("Phuong trinh co 2 nghiem la: x1 = {0} va x2 = {1}", x1, x2);
            }
            else if (delta == 0)
            {
                x1 = (-b / (2 * a));
                Console.Write("Phong trinh co nghiem kep: x1 = x2 = {0}", x1);
            }
            else
            {
                Console.Write("Phuong trinh vo nghiem!");
            }
        }
        public static void giaiPhuongTrinhBac3(double a, double b, double c , double d)
        {
            if(a == 0)
            {
                if(b == 0)
                {
                    if(c == 0)
                    {
                        Console.Write("Phuong trinh vo nghiem!");
                    }
                    else
                    {
                        giaiPhuongTrinhBac1(c, d);
                    }
                }
                else
                {
                    giaiPTBac2(b, c, d);
                }
            }
            else
            {
                double delta = b * b - 3 * a * c;
                double k = (double)((9 * a * b * c - 2 * b * b * b - 27 * a * a * d) / 2 * Math.Sqrt(Math.Abs(Math.Pow(delta, 3))));
                double x1, x2, x3;
                if(delta > 0)
                {
                    if(Math.Abs(k) <= 1)
                    {
                        x1 = (double)((2 * Math.Sqrt(delta) * Math.Cos(Math.Acos(k) / 3) - b) / 3 * a);

                        x2 = (double)((2 * Math.Sqrt(delta) * Math.Cos(Math.Acos(k) / 3 - (2 * pi) / 3) - b) / 3 * a);

                        x3 = (double)((2 * Math.Sqrt(delta) * Math.Cos(Math.Acos(k) / 3 + (2 * pi) / 3) - b) / 3 * a);
                        Console.Write("Phuong trinh co 3 nghiem x1 = {0} , x2 = {1} , x3 = {2}", x1, x2, x3);
                    }
                    else
                    {
                        x1 = (double)((((Math.Sqrt(delta) * Math.Abs(k)) / 3 * a * k ) * ((Math.Cbrt(Math.Abs(k) + Math.Sqrt(k * k - 1))) + (Math.Cbrt(Math.Abs(k) - Math.Sqrt(k * k - 1))))) - (b / 3 * a));
                        Console.Write("Phuong trinh co 1 nghiem duy nhat: x = {0}", x1);
                    }
                   
                }else if (delta == 0)
                {
                    x1  = (double)((-b + Math.Cbrt(b * b * b - (27 * a * a *d))) / 3 * a);
                    Console.Write("Phuong trinh co nghiem kep: x = {0}", x1);

                }
                else
                {
                    x1 = (double)(((Math.Sqrt(Math.Abs(delta))  / 3 * a ) * ((Math.Cbrt(k + Math.Sqrt(k * k + 1))) + (Math.Cbrt(k - Math.Sqrt(k * k + 1))))) - (b / 3 * a));
                    Console.Write("Phuong trinh co 1 nghiem duy nhat: x = {0}", x1);

                }
            }
        }
        public static void giaiPhuongTrinhBac1(double a, double b)
        {
            if(a == 0)
            {
               
                    Console.Write("Phuong trinh vo nghiem!");
            }
            else
            {
                Console.Write("Phuong trinh co 1 nghiem: x = {0}", (-b / a));

            }
            return;
        }
/*        public static void Main() 
        { 
            InputData();
            giaiPhuongTrinhBac3(a, b, c, d);
        }*/
    }
}




