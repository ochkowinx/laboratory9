using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб9
{
    public class Input
    {
            public static int GetPositiveInteger(string prompt)
        {
            int value;
            bool isInputValid = false;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= 0)
                {
                    isInputValid = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите положительное целое число.");
                }
            } while (!isInputValid);

            return value;
        }
    }
}
