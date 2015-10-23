﻿namespace Husky.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Lexer
    {
        private static char[] operators = new char[] { '+', '-', '*' };
        private static char[] delimiters = new char[] { ',', '(', ')' };

        private string text;
        private int length;
        private int position;

        public Lexer(string text)
        {
            this.text = text;
            
            if (text == null)
                this.length = 0;
            else
                this.length = text.Length;

            this.position = 0;
        }

        public Token NextToken()
        {
            while (position < length && char.IsWhiteSpace(this.text[position]))
                position++;

            if (position >= length)
                return null;

            char ch = this.text[position++];

            if (operators.Contains(ch))
                return new Token(ch.ToString(), TokenType.Operator);

            if (delimiters.Contains(ch))
                return new Token(ch.ToString(), TokenType.Delimiter);

            if (char.IsDigit(ch))
                return this.NextInteger(ch);

            string value = ch.ToString();

            while (position < length && !char.IsWhiteSpace(this.text[position]))
                value += this.text[position++];

            Token token = new Token(value, TokenType.Name);

            return token;
        }

        private Token NextInteger(char ch)
        {
            string value = ch.ToString();

            while (position < length && char.IsDigit(this.text[position]))
                value += this.text[position++];

            Token token = new Token(value, TokenType.Integer);

            return token;
        }
    }
}
