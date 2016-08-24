using System;
using System.Text;

namespace Xamarin.Course.Intro.CSharp.DotNet.InheritanceExercise
{
    public abstract class Expression
    {
        public abstract double Evaluate();
    }

    public sealed class ConstantExpression : Expression
    {
        private readonly double value;

        public ConstantExpression(double value)
        {
            this.value = value;
        }

        public override double Evaluate()
        {
            return value;
        }

        public override string ToString()
        {
            return "" + value;
        }
    }

    public abstract class BinaryExpression : Expression
    {
        protected readonly Expression left;
        protected readonly Expression right;

        protected BinaryExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        protected abstract string OperatorSymbol { get; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", left, OperatorSymbol, right);
            
            // Alternatively:
            //var sb = new StringBuilder();
            //sb.Append(left)
            //    .Append(" ")
            //    .Append(OperatorSymbol)
            //    .Append(" ")
            //    .Append(right);
            //return sb.ToString();
        }
    }

    public class PlusExpression : BinaryExpression
    {
        public PlusExpression(Expression left, Expression right)
            : base(left, right) { }

        protected override string OperatorSymbol => "+";

        public override double Evaluate()
        {
            return left.Evaluate() + right.Evaluate();
        }
    }

    public static class ExpressionExtensions
    {
        public static Expression ToExpression(this double constant)
        {
            return new ConstantExpression(constant);
        }
    }
}
