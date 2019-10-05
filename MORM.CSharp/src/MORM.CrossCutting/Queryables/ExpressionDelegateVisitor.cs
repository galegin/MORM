﻿using System;
using System.Linq.Expressions;

namespace MORM.CrossCutting
{
    internal sealed class ExpressionDelegateVisitor : ExpressionVisitor
    {
        private readonly Func<Expression, Expression> m_Visitor;
        private readonly bool m_Recursive;

        public static Expression Visit(Expression exp, Func<Expression, Expression> visitor, bool recursive)
        {
            return new ExpressionDelegateVisitor(visitor, recursive).Visit(exp);
        }

        private ExpressionDelegateVisitor(Func<Expression, Expression> visitor, bool recursive)
        {
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            m_Visitor = visitor;
            m_Recursive = recursive;
        }

        public override Expression Visit(Expression node)
        {
            if (m_Recursive)
            {
                return base.Visit(m_Visitor(node));
            }
            else
            {
                var visited = m_Visitor(node);
                if (visited == node) return base.Visit(visited);
                return visited;
            }
        }
    }
}