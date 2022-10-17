namespace EquationSolving;

public class QuadraticEquation
{  
    public static double[] Solve(double a, double b, double c)
    {
        if (a == 0) throw new ArgumentOutOfRangeException("a", "Coefficient of the quadratic term cannot be 0");
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

public class LinearEquation
{
    public static double[] LinearEquationSolve(double a, double b)
    {
        if (a == 0)
        {
            if (b != 0)
            {
                throw new ArgumentOutOfRangeException("The 1st coefficient must not be 0");
            }
            return new double[] { b };

        }
        else
        {
            if (b == 0)
            {
                return new double[] { 0 };
            }
            else
            {
                return new double[] { -b / a };
            }
        }
    }
}
