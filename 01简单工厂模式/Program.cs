using System;
using System.Globalization;

namespace _01简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Operation operation = OperationFactory.CreateOperation("-");
            operation.NumberA = 10;
            operation.NumberB = 5;
            Console.WriteLine(operation.GetResult());
        }

    }

    public class OperationFactory
    {
        public static Operation CreateOperation(string operate)
        {
            Operation operation = null;
            switch (operate)
            {
                case "+":
                    operation=new OperationAdd();
                    break;
                case "-":
                    operation=new OperationSub();
                    break;
                case "*":
                    operation=new OperationMul();
                    break;
                case "/":
                    operation=new OperationDiv();
                    break;
            }

            return operation;
        }
    }

    /// <summary>
    /// 运算类
    /// </summary>
    public class Operation
    {
        public double NumberA { get; set; } = 0;

        public double NumberB { get; set; } = 0;

        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }

    /// <summary>
    /// 加法运算类
    /// </summary>
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }

    /// <summary>
    /// 减法运算类
    /// </summary>
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }

    /// <summary>
    /// 乘法运算类
    /// </summary>
    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }

    /// <summary>
    /// 除法运算类
    /// </summary>
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if (NumberB==0)
            {
                throw new Exception("除数不能为0");
            }

            result = NumberA / NumberB;
            return result;
        }
    }

}
