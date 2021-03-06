﻿namespace Husky.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Types;

    public class ValueExpression : IExpression
    {
        private IType type;
        private IExpression expression;
        private IExpression reduced;

        public ValueExpression(IType type)
        {
            this.type = type;
        }

        public IType Type { get { return this.type; } }

        public IExpression Expression { get { return this.expression; } }

        public IExpression Reduce()
        {
            if (this.expression == null)
                return this;

            if (this.reduced != null)
                return this.reduced;

            this.reduced = this.expression.Reduce();

            return this.reduced;
        }

        public bool Match(IExpression expr, Context<IExpression> ctx)
        {
            if (this.expression == null)
                return this.Equals(expr);

            return this.expression.Match(expr, ctx);
        }

        public void MapTo(IExpression expression)
        {
            if (!this.type.Equals(expression.Type))
                throw new InvalidOperationException("Non compatible type");

            this.expression = expression;
        }
    }
}
