﻿using System.Linq.Expressions;

namespace Application.Tools.Expressions
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.AndAlso(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {

            ParameterExpression p = a.Parameters[0];

            SubstExpressionVisitor visitor = new();
            visitor.subst[b.Parameters[0]] = p;

            Expression body = Expression.OrElse(a.Body, visitor.Visit(b.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static Expression<Func<T, bool>> CombineWithOr<T>(this IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            var combined = predicates.Aggregate((current, next) => current.Or(next));
            return combined;
        }

        public static Expression<Func<T, bool>> CombineWithAnd<T>(this IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            var combined = predicates.Aggregate((current, next) => current.And(next));
            return combined;
        }
    }

    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> subst = [];

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (subst.TryGetValue(node, out Expression newValue))
            {
                return newValue;
            }
            return node;
        }
    }
}
