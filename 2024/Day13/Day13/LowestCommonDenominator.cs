namespace Day13;

public class LowestCommonDenominator {

    public static long GCD(long a, long b) {
        while (b != 0) {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Method to compute LCM (Least Common Multiple)
    public static long LCM(long a, long b) {
        return Math.Abs(a * b) / GCD(a, b);
    }

    public static long Calculate(long num1, long num2)
    {
        return GCD(num1, num2);
    }
}
