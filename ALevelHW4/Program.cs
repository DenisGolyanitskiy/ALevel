using System;

namespace ALevelHW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Specify the number of elements in the array: ");
            int uzerElement = int.Parse(Console.ReadLine());
            int[] elementArray = new int[uzerElement];
            Random random = new Random();

            // Random number output
            for (int i = 0; i < uzerElement; i++)
            {
                elementArray[i] = random.Next(1, 27);
            }

            foreach (int num in elementArray)
            {
                Console.Write(num + " ");
            }
            int[] evenNumber = new int[uzerElement];
            int[] oddNumber = new int[uzerElement];

            int evenCounter = 0;
            int oddCounter = 0;

            // Determination of even and odd numbers
            for (int i = 0; i < uzerElement; i++)
            {
                if (elementArray[i] % 2 == 0)
                {
                    evenNumber[evenCounter] = elementArray[i];
                    evenCounter++;
                }
                else
                {
                    oddNumber[oddCounter] = elementArray[i];
                    oddCounter++;
                }
            }

            // Creating an Alphabet and Defining Capital Letters
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < evenCounter; i++)
            {
                char letter = alphabet[evenNumber[i] - 1];

                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'd' || letter == 'h' || letter == 'j')
                {
                    letter = char.ToUpper(letter);
                }

                evenNumber[i] = letter;
            }

            for (int i = 0; i < oddCounter; i++)
            {
                char letter = alphabet[oddNumber[i] - 1];

                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'd' || letter == 'h' || letter == 'j')
                {
                    letter = char.ToUpper(letter);
                }

                oddNumber[i] = letter;
            }

            // Console output
            Console.WriteLine("\n\nArray with even numbers: ");
            foreach (char letter in evenNumber)
            {
                Console.Write(letter + " ");
            }

            Console.WriteLine("\n\nArray with odd numbers: ");
            foreach (char letter in oddNumber)
            {
                Console.Write(letter + " ");
            }

            int upperLetterCounterEven = UpperLetterCounter(evenNumber);
            int upperLetterCounterOdd = UpperLetterCounter(oddNumber);

            Console.Write("\n\nResult: ");

            if (upperLetterCounterEven < upperLetterCounterOdd)
            {
                Console.WriteLine("An array with even numbers has more capital letters");
            }
            else if (upperLetterCounterOdd < upperLetterCounterEven)
            {
                Console.WriteLine("\nAn array with odd numbers has more capital letters");
            }
            else
            {
                Console.WriteLine("Both arrays have the same number of capital letters");
            }

            Console.Write("\nВведите Exit что бы завершить программу: ");

            Console.Clear();
            Console.ReadKey();
        }

        static int UpperLetterCounter(int[] array)
        {
            int counter = 0;

            foreach (int num in array)
            {
                if (char.IsUpper((char)num))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
