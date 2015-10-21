﻿namespace Husky.Tests.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Husky.Compiler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void GetNullTokenFromNullText()
        {
            Lexer lexer = new Lexer(null);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNullTokenFromEmptyText()
        {
            Lexer lexer = new Lexer(string.Empty);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetInteger()
        {
            Lexer lexer = new Lexer("42");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("42", token.Value);
            Assert.AreEqual(TokenType.Integer, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetName()
        {
            Lexer lexer = new Lexer("foo");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetTwoNames()
        {
            Lexer lexer = new Lexer("foo bar");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("foo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("bar", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetPlusAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("+");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetMinusAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("-");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("-", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetAsteriskAsArithmeticOperator()
        {
            Lexer lexer = new Lexer("*");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual("*", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetCommaAsDelimiter()
        {
            Lexer lexer = new Lexer(",");

            var token = lexer.NextToken();

            Assert.IsNotNull(token);
            Assert.AreEqual(",", token.Value);
            Assert.AreEqual(TokenType.Delimiter, token.Type);

            Assert.IsNull(lexer.NextToken());
        }
    }
}