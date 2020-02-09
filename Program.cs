using System;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// Программа проверяет, что две строки являются перестановками друг друга.
/// </summary>
namespace StringPermutation
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Проверяет является ли первая строка перестановкой второй
        /// </summary>
        /// <param name="firstString">Первая строка</param>
        /// <param name="secondString">Вторая строка</param>
        /// <returns>Булево значение ответа</returns>
        static bool CheckPermutation(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length) return false;
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < firstString.Length; i++)
            {
                if (!dict.ContainsKey(firstString[i]))
                {
                    dict.Add(firstString[i], 0);
                }
                if (!dict.ContainsKey(secondString[i]))
                {
                    dict.Add(secondString[i], 0);
                }
                dict[firstString[i]]++;
                dict[secondString[i]]--;
            }
            var check = true;
            foreach (var key in dict.Values)
            {
                if (key != 0)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        /// <summary>
        /// Функция оборачивает ответ в строку, понятную для человека
        /// </summary>
        /// <param name="answer">Булево значение ответа</param>
        /// <returns>Строковое значение ответа</returns>
        static string AnswerToString(bool answer)
        {
            var sayNo = "Nope, it is not permutation, honey";
            var sayYes = "Yeah, it is permutation, boy";
            if (answer) return sayYes;
            else return sayNo;
        }

        /// <summary>
        /// Функция реализует консольный ввод пользователем данных
        /// </summary>
        /// <returns>Массив из двух строк, введенных пользователем</returns>
        static string[] AskUserToImport()
        {
            Console.WriteLine("Write down your strings");
            Console.WriteLine();
            Console.Write("First string = ");
            var firstString = Console.ReadLine();
            Console.Write("Second string = ");
            var secondString = Console.ReadLine();
            string[] res = { firstString, secondString };
            return res;
        }

        static string[] FileImport()
        {
            string[] lines = File.ReadAllLines("input.txt");
            return lines;
        }

        /// <summary>
        /// Функция реализует вывод в файл
        /// </summary>
        /// <param name="outputString">Стройка для вывода</param>
        static void OutputToFile(string outputString)
        {
            File.WriteAllText("output.txt", outputString);
        }
        static void Main(string[] args)
        {
            try
            {
                string[] lines = FileImport();
                var res = AnswerToString(CheckPermutation(lines[0], lines[1]));
                Console.WriteLine(res);
                OutputToFile(res);
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dear, I can't find file input.txt");
                Console.ResetColor();
                Console.WriteLine();
                var lines = AskUserToImport();
                var res = AnswerToString(CheckPermutation(lines[0], lines[1]));
                Console.WriteLine(res);
                OutputToFile(res);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I, can't understaund you, buddy");
                Console.ResetColor();
                Console.WriteLine();
                var lines = AskUserToImport();
                var res = AnswerToString(CheckPermutation(lines[0], lines[1]));
                Console.WriteLine(res);
                OutputToFile(res);
            }
        }
    }
}
