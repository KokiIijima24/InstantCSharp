using System.Linq.Expressions;

namespace workspace
{
    public class ExpressionSample
    {
        public Expression ConstructGreetingExpression()
        {
            var personNameParameter = Expression.Parameter(typeof(string), "personName");

            // Condition
            var isNullOrWhiteSpaceMethod = typeof(string)
                .GetMethod(nameof(string.IsNullOrWhiteSpace));

            var condition = Expression.Not(
                Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

            // True clause
            var trueClause = Expression.Add(
                Expression.Constant("Greetings, "),
                personNameParameter);

            // False clause
            var falseClause = Expression.Constant(null, typeof(string));

            // Ternary conditional
            return Expression.Condition(condition, trueClause, falseClause);
        }
    }
}