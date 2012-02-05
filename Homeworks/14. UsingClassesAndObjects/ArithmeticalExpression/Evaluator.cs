using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace ArithmeticalExpression
{
    public class Evaluator
    {
        private const string codeFormat = @"
        using System;
        namespace ExpressionEvaluation
        {
            public class EvaluatorHelper
            {
                public double Evaluate()
                {
                    return {0};
                }
            }
        }";
        private CSharpCodeProvider cSharpCodeProvider;
        private CompilerParameters cp;

        private string PrepareExpression(string expression)
        {
            StringBuilder expressionBuilder =
                new StringBuilder(expression);
            expressionBuilder.Replace("sqrt", "Math.Sqrt");
            expressionBuilder.Replace("ln", "Math.Log");
            expressionBuilder.Replace("pow", "Math.Pow");
            //return string.Format(codeFormat, expressionBuilder);
            return codeFormat.Replace("{0}",
                expressionBuilder.ToString());
        }

        public Evaluator()
        {
            cSharpCodeProvider = new CSharpCodeProvider();
            cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.GenerateInMemory = true;
        }

        public bool TryEvaluate(string expression,
            out double result)
        {
            try
            {
                result = this.Evaluate(expression);
                return true;
            }
            catch (Exception)
            {
                result = 0;
                return false;
            }
        }

        public double Evaluate(string expression)
        {
            try
            {
                expression = this.PrepareExpression(expression);
                CompilerResults compilerResults =
                    cSharpCodeProvider.
                    CompileAssemblyFromSource(cp, expression);
                Assembly assembly =
                    compilerResults.CompiledAssembly;
                object instance = assembly.CreateInstance(
                    "ExpressionEvaluation.EvaluatorHelper");
                object invokeResult = instance.GetType().
                    GetMethod("Evaluate").Invoke(instance, null);
                double result = 0;
                double.TryParse(
                    invokeResult.ToString(), out result);
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}