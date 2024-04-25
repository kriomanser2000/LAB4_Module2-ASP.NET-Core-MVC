namespace LAB4_Module2.Models
{
    public class Fraction
    {
        private static int LeastCommonMultiple(int a, int b)
        {
            int gcd = GreatestCommonDivisor(a, b);
            return (a * b) / gcd;
        }
        private static int GreatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
        }
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        public Fraction Add(Fraction other)
        {
            int commonDenominator = LeastCommonMultiple(this.Denominator, other.Denominator);
            int thisNumerator = this.Numerator * (commonDenominator / this.Denominator);
            int otherNumerator = other.Numerator * (commonDenominator / other.Denominator);

            int resultNumerator = thisNumerator + otherNumerator;
            Fraction result = new Fraction(resultNumerator, commonDenominator);
            return result.Simplify();
        }
        public Fraction Subtract(Fraction other)
        {
            int commonDenominator = LeastCommonMultiple(this.Denominator, other.Denominator);
            int thisNumerator = this.Numerator * (commonDenominator / this.Denominator);
            int otherNumerator = other.Numerator * (commonDenominator / other.Denominator);

            int resultNumerator = thisNumerator - otherNumerator;
            Fraction result = new Fraction(resultNumerator, commonDenominator);
            return result.Simplify();
        }
        public Fraction Multiply(Fraction other)
        {
            int resultNumerator = this.Numerator * other.Numerator;
            int resultDenominator = this.Denominator * other.Denominator;
            Fraction result = new Fraction(resultNumerator, resultDenominator);
            return result.Simplify();
        }
        public Fraction Divide(Fraction other)
        {
            int resultNumerator = this.Numerator * other.Denominator;
            int resultDenominator = this.Denominator * other.Numerator;
            Fraction result = new Fraction(resultNumerator, resultDenominator);
            return result.Simplify();
        }
        public Fraction Simplify()
        {
            int gcd = GreatestCommonDivisor(this.Numerator, this.Denominator);
            int simplifiedNumerator = this.Numerator / gcd;
            int simplifiedDenominator = this.Denominator / gcd;
            return new Fraction(simplifiedNumerator, simplifiedDenominator);
        }
        public double ToDecimal()
        {
            return (double)this.Numerator / this.Denominator;
        }
        public static Fraction FromDecimal(double value)
        {
            throw new NotImplementedException();
        }
    }
}