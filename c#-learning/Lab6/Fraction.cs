namespace csharplearning.Lab6
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        private long gcd(long a, long b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }
        private void Simplify()
        {
            long gcd = this.gcd(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
        }
        public Fraction(long _numerator, long _denominator)
        {
            if (_denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero");
            if (_denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }
            numerator = _numerator;
            denominator = _denominator;
            Simplify();
        }
        public Fraction(long numerator) : this(numerator, 1) { }
        public Fraction Reciprocal()
        {
            long temp = numerator;
            numerator = denominator;
            denominator = temp;
            return new Fraction(numerator, denominator);
        }
        public static implicit operator Fraction(long value) => new(value);
        public static explicit operator long(Fraction value) => value.numerator / value.denominator;
        public static explicit operator double (Fraction value) => (double)value.numerator / value.denominator;
        public static Fraction operator +(Fraction a, Fraction b)
        {
            long _numerator = 1;
            long _denominator = 1;
            try
            {
                checked
                {
                    _numerator = a.numerator * b.denominator + b.numerator * a.denominator;
                    _denominator = a.denominator * b.denominator;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"OVERFLOW: {ex.Message}");
            }
            Fraction result = new(_numerator, _denominator);
            result.Simplify();
            return result;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + new Fraction(-b.numerator, b.denominator);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            long _numerator = 1;
            long _denominator = 1;
            try
            {
                checked
                {
                    _numerator = a.numerator * b.numerator;
                    _denominator = a.denominator * b.denominator;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"OVERFLOW: {ex.Message}");
            }
            Fraction result = new(_numerator, _denominator);
            result.Simplify();
            return result;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * b.Reciprocal();
        }
        public static bool operator ==(Fraction a, Fraction b) => a.numerator == b.numerator && a.denominator == b.denominator;
        public static bool operator !=(Fraction a, Fraction b) => !(a == b);
        public static bool operator <(Fraction a, Fraction b)
        {
            long _numerator_a = 1;
            long _numerator_b = 1;
            try
            {
                checked
                {
                    _numerator_a = a.numerator * b.denominator;
                    _numerator_b = a.denominator * b.numerator;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"OVERFLOW: {ex.Message}");
            }
            return _numerator_a < _numerator_b;
        }
        public static bool operator >(Fraction a, Fraction b) => (b < a) && (b!=a);
        public static bool operator >=(Fraction a, Fraction b) => (b < a) || (b == a);
        public static bool operator <=(Fraction a, Fraction b) => (b > a) || (b == a);
        public static Fraction operator -(Fraction a) => new(-a.numerator, a.denominator);
        public override string ToString()
        {
            var whole = numerator / denominator;
            var num = numerator - whole * denominator;
            var sign = numerator > 0;

            var str = string.Empty;
            if (!sign)
            {
                str += "-";
                num = -num;
                whole = -whole;
            }
            if (num == 0)
                str += $"[{whole}]";
            else if (whole != 0)
                str += $"[{whole} {num}/{denominator}]";
            else
                str += $"[{num}/{denominator}]";

            return str;
        }
        public long Numerator
        {
            get { return numerator; }
            set
            {
                numerator = value;
                Simplify();
            }
        }
        public long Denominator
        {
            get { return denominator; }
            set
            {
                denominator = value;
                Simplify();
            }
        }
    }
}
