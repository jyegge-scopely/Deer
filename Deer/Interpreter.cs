using Antlr4.Runtime;

namespace Deer
{
    public class Interpreter
    {
        public void Interpret(string code)
        {
            AntlrInputStream input = new AntlrInputStream(code);
            DeerLexer lexer = new DeerLexer(input);
            DeerParser parser = new DeerParser(new CommonTokenStream(lexer));
        }
    }
}