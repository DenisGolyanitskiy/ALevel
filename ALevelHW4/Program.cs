using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements: ");
            int uzerElement = Convert.ToInt32(Console.ReadLine());
            int[] elementArrey = new int[uzerElement];
            Random random = new Random();

            for (int i = 0; i < elementArrey.Length; i++)
            {
                elementArrey[i] = random.Next(1, 27);
            }

            Console.Write("\nRandom numbers ");
            foreach (int num in elementArrey)
            {
                Console.Write(num + " ");
            }

            int[] evenArray = EvenNumber(elementArrey);
            int[] oddArray = OddNumber(elementArrey);

            Console.Write("\n\nEven numbers: ");
            foreach (int num in evenArray)

            {
                Console.Write(num + " ");
            }

            Console.Write("\n\nOdd numbers: ");
            foreach (int num in oddArray)
            {
                Console.Write(num + " ");
            }

            char[] evenLetters = ConvertToUpperLetters(evenArray);
            char[] oddLetters = ConvertToUpperLetters(oddArray);

            Console.Write("\n\nLetters for even numbers: ");

            foreach (char letter in evenLetters)
            {
                Console.Write(letter + " ");
            }

            Console.Write("\n\nLetters for odd numbers: ");

            foreach (char letter in oddLetters)
            {
                Console.Write(letter + " ");
            }

            int upperLetterCounterEven = CountUppercaseLetters(evenLetters);
            int upperLetterCounterOdd = CountUppercaseLetters(oddLetters);

            if (upperLetterCounterEven > upperLetterCounterOdd)
            {
                Console.WriteLine("\n\nArray with more capital letters: Even");
            }
            else if (upperLetterCounterOdd > upperLetterCounterEven)
            {
                Console.WriteLine("\n\nМArray with more capital letters: Odd");
            }
            else
            {
                Console.WriteLine("\n\nBoth arrays have the same numbers of capital letters");
            }


            Console.ReadKey();
        }

        static int[] EvenNumber(int[] elementArray)
        {
            int evenCounter = 0;

            foreach (int num in elementArray)
            {
                if (num % 2 == 0)
                {
                    evenCounter++;
                }
            }

            int[] evenArray = new int[evenCounter];
            int index = 0;

            foreach (int num in elementArray)
            {
                if (num % 2 == 0)
                {
                    evenArray[index] = num;
                    index++;
                }
            }

            return evenArray;
        }

        static int[] OddNumber(int[] elementArray)
        {
            int oddCounter = 0;

            foreach (int num in elementArray)
            {
                if (num % 2 != 0)
                {
                    oddCounter++;
                }
            }

            int[] oddArray = new int[oddCounter];
            int index = 0;

            foreach (int num in elementArray)
            {
                if (num % 2 != 0)
                {
                    oddArray[index] = num;
                    index++;
                }
            }

            return oddArray;
        }

        static char[] ConvertToUpperLetters(int[] numbers)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] letters = new char[numbers.Length];


            for (int i = 0; i < numbers.Length; i++)
            {
                char letter = alphabet[numbers[i] - 1];
                {
                    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'd' || letter == 'h' || letter == 'j')
                    {
                        letter = char.ToUpper(letter);
                    }

                    letters[i] = letter;
                }
            }

            return letters;
        }

        static int CountUppercaseLetters(char[] letters)
        {
            return letters.Count(letter => char.IsUpper(letter));
        }
    }
}