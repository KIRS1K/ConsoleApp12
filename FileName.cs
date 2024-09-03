using System;
using System.Collections.Generic;
using System.Linq;

namespace SurnameSorter
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
    public class SurnameSorter
    {
        public event Action<List<string>, bool> OnSortRequested;

        private List<string> surnames;

        public SurnameSorter(List<string> surnames)
        {
            this.surnames = surnames;
        }

        public void RequestSort(bool ascending)
        {
            OnSortRequested?.Invoke(surnames, ascending);
        }

        public void SortSurnames(List<string> surnames, bool ascending)
        {
            surnames.Sort((x, y) => ascending ? string.Compare(x, y) : string.Compare(y, x));
        }

        public void DisplaySurnames()
        {
            Console.WriteLine("Фамилии:");
            foreach (var surname in surnames)
            {
                Console.WriteLine(surname);
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            List<string> surnames = new List<string> { "Иванов", "Сталин", "Сидорович", "Ленин", "Мармеладыч", "Юрыч" };
            SurnameSorter sorter = new SurnameSorter(surnames);

            sorter.OnSortRequested += sorter.SortSurnames;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите 1 если от А до Я и 2 если наобарот");
                    string input = Console.ReadLine();

                    if (input == null)
                    {
                        throw new InvalidInputException("Введите верное число");
                    }

                    int choice = int.Parse(input);

                    if (choice == 1)
                    {
                        sorter.RequestSort(true);
                    }
                    else if (choice == 2)
                    {
                        sorter.RequestSort(false);
                    }
                    else
                    {
                        throw new InvalidInputException("Введите 1 или 2");
                    }

                    sorter.DisplaySurnames();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите число");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Татальный ерор: {ex.Message}");
                }
            }
        }
    }
}