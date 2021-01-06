using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace Deer
{
    public class Interpreter
    {
        class DeerVisitor : DeerBaseVisitor<Object>
        {
            private Dictionary<string, object> variables = new Dictionary<string, object>();
            public override object VisitAssignment(DeerParser.AssignmentContext context)
            {
                var variableName = context.children[0].GetText();

                var rhs = (ITerminalNode)context.children[2];
                object rhsValue;
                switch (rhs.Symbol.Type)
                {
                    case DeerLexer.NUMBER:
                        rhsValue = int.Parse(rhs.GetText());
                        break;
                    default:
                        rhsValue = variables[rhs.GetText()];
                        break;
                }
                variables[variableName] = rhsValue;
                Console.WriteLine($"Assigning value '{rhsValue}' to variable '{variableName}'");
                return base.VisitAssignment(context);
            }

            public override object VisitModule(DeerParser.ModuleContext context)
            {
                return base.VisitModule(context);
            }

            public override object VisitStatement(DeerParser.StatementContext context)
            {
                return base.VisitStatement(context);
            }
        }
        public void Interpret(string code)
        {
            AntlrInputStream input = new AntlrInputStream(code);
            DeerLexer lexer = new DeerLexer(input);
            DeerParser parser = new DeerParser(new CommonTokenStream(lexer));
            
            var visitor = new DeerVisitor();
            visitor.Visit(parser.module());
        }
    }
}