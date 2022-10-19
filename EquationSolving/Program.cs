namespace EquationSolving;

public class QuadraticEquation

{
    public static void Main()
    {
        Array.ForEach(Solve(12, -50, 1), Console.WriteLine);

        /*        object[] o = (new double[] { 1, 2, 23 }).Cast<object>().ToArray();
                object[,] o2 = (new Double[,]
                {
                   {0, 8, 6565},
                    {0, 9.215454, -66662.1 },
                    {0, 0, 0 },
                   {0, -35451515, 69995965}
                }).Cast<object>().ToArray();
                Array.ForEach(o, Console.WriteLine);*/
    }
    public static double[] Solve(double a, double b, double c)
    {
        if (a == 0) throw new ArgumentOutOfRangeException(nameof(a), "Coefficient of the quadratic term cannot be 0");
        double delta = b * b - 4 * a * c;
        if (delta < 0)
        {
            return Array.Empty<double>();
        }
        if (delta == 0)
        {
            return new double[] { (-b) / (2 * a) };
        }
        else
        {
            return new double[] { ((-b + (double)Math.Sqrt(delta)) / (2 * a)), ((-b - (double)Math.Sqrt(delta)) / (2 * a)) };

        }
    }


    public static double[] Solve(double[] coeffs)
    {
        return Solve(coeffs[0], coeffs[1], coeffs[2]);
    }

    public static double[] Solve_Po_Shen_Loh(double a, double b, double c)
    {
        if (a == 0) throw new ArgumentOutOfRangeException("a", "Coefficient of the quadratic term cannot be 0");
        double tb = b;
        double tc = c;
        tb /= a;
        tc /= a;
        double mid = -tb / 2;
        double w = mid * mid - tc;
        if (w < 0)
        {
            return Array.Empty<double>();
        }
        if (w == 0)
        {
            return new double[] { mid };
        }
        double u = Math.Sqrt(mid * mid - tc);
        return new double[] { mid + u, mid - u };
    }

}
