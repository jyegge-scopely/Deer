using System;
using Deer;

namespace Deer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter();
            
            interpreter.Interpret("a = 1" +
                                  "b = a");
        }
    }
}