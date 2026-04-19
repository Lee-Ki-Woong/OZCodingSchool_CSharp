using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal class Program
    {
        class BubbleSort
        {
            public static void Bubble(int[] sequence)
            {
                int TradeNumber = 0;

                for (int j = 0; j < sequence.Length - 1; j++)
                {
                    for (int i = 0; i < sequence.Length - 1; i++)
                    {

                        int FirstNumber = sequence[i];
                        int SecondNumber = sequence[i + 1];
                        int SaveNumber = SecondNumber;

                        if (FirstNumber > SecondNumber)
                        {
                            TradeNumber++;
                            SecondNumber = FirstNumber;
                            FirstNumber = SaveNumber;
                            sequence[i] = FirstNumber;
                            sequence[i + 1] = SecondNumber;
                        }
                    }
                }

                Console.WriteLine($"교환 횟수 = {TradeNumber}");
            }
        }

        internal class SelectionSort
        {
            public static void Selection(int[] sequence)
            {
                int TradeNumber = 0;

                for (int j = 0; j < sequence.Length - 1; j++)
                {
                    int lowNumber = sequence[j];
                    int choiceNumber = j;

                    for (int i = j; i < sequence.Length; i++)
                    {
                        if (sequence[i] < lowNumber)
                        {
                            lowNumber = sequence[i];
                            choiceNumber = i;
                        }
                    }

                    TradeNumber++;
                    sequence[choiceNumber] = sequence[j];
                    sequence[j] = lowNumber;
                }
                Console.WriteLine($"교환 횟수 = {TradeNumber}");

            }
        }

        internal class InsertionSort
        {
            public static void Insertion(int[] sequence)
            {
                int tradeNumber = 0;

                for (int j = 1; j < sequence.Length; j++)
                {
                    int insertNumber = sequence[j];
                    int length = j;

                    for (int i = j - 1; i >= 0; i--)
                    {
                        int checkNumber = sequence[i];


                        if (insertNumber < checkNumber)
                        {
                            sequence[i + 1] = checkNumber;
                            length = i;
                        }
                        else break;
                    }

                    tradeNumber++;
                    sequence[length] = insertNumber;
                }
                Console.WriteLine($"교환 횟수 = {tradeNumber}");
            }
        }

        static void Main(string[] leekiwoong)
        {
            int[] sortOne = new int[20] { 17, 1, 3, 9, 13, 4, 19, 7, 16, 14, 20, 6, 5, 10, 12, 18, 2, 15, 8, 11 };


            //BubbleSort.Bubble(sortOne);

            //SelectionSort.Selection(sortOne);

            InsertionSort.Insertion(sortOne);

            Console.WriteLine(string.Join(",", sortOne));


        }
    }
}
