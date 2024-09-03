using System;

namespace CustomExceptionExample
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Exception[] exceptions = new Exception[]
            {
                new DivideByZeroException("Деление на ноль"),
                new NullReferenceException("Ссылка на объект не установлена"),
                new ArgumentException("Неверный аргумент"),
                new InvalidOperationException("Недопустимая операция"),
                new MyCustomException("Мое собственное исключение")
            };
            foreach (var ex in exceptions)
            {
                try
                { 

                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Поймано исключение: {e.Message}");
                }
                finally
                {
                    Console.WriteLine("Блок finally выполняется.");
                }
                Console.WriteLine();
            }
        }
    }
}