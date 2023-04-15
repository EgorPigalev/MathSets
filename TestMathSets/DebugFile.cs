using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace TestMathSets
{
    public static class DebugFile
    {
        private static string _path = Directory.GetParent // Путь к файлу  с отладочной информацией.
        (
            Directory.GetParent(Environment.CurrentDirectory).Parent.FullName
        ).Parent.FullName + "\\TestResult.txt";

        public static List<string> TestMethods = new(); // Названия тестовых методов.
        public static List<UnitTestOutcome> TestStatuses = new(); // Статусы выполнения тестов.

        /// <summary>
        /// Создаёт отладочный файл
        /// </summary>
        public static void CreateDebugFile()
        {
            FileStream fileStream = File.Create(_path);
            fileStream.Close();
        }

        /// <summary>
        /// Записывает результаты тестирования в отладочный файл
        /// </summary>
        public static void WriteToFile()
        {
            List<string> methodsPassed = new();
            List<string> methodsFailed = new();
            List<string> methodsOther = new();

            for (int i = 0; i < TestMethods.Count; i++)
            {
                if (TestStatuses[i] == UnitTestOutcome.Passed)
                {
                    methodsPassed.Add(TestMethods[i]);
                }
                else if (TestStatuses[i] == UnitTestOutcome.Failed)
                {
                    methodsFailed.Add(TestMethods[i]);
                }
                else
                {
                    methodsOther.Add(TestMethods[i]);
                }
            }

            WriteToFile("Успешно", methodsPassed);
            WriteToFile("Завершено с ошибками", methodsFailed);
            WriteToFile("Прочие невыполненные методы", methodsOther);
        }

        /// <summary>
        /// Записывает группу тестовых методов с их заголовком в отладочный файл
        /// </summary>
        /// <param name="header">заголовок группы методов</param>
        /// <param name="methods">список методов</param>
        private static void WriteToFile(string header, List<string> methods)
        {
            if (methods.Count == 0)
            {
                return;
            }

            WriteToFile(header + ":");

            for (int i = 0; i < methods.Count; i++)
            {
                WriteToFile("\t" + (i + 1).ToString() + ". " + methods[i] + "();");
            }
        }

        /// <summary>
        /// Записывает сообщение в отладочный файл
        /// </summary>
        /// <param name="message">сообщение</param>
        public static void WriteToFile(string message)
        {
            File.AppendAllText(_path, message + "\n");
        }
    }
}