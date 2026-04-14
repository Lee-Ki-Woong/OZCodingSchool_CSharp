using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal class Program
    {
        static void Main(string[] agrs)
        {
            List<string> text = new List<string>();

            text.Add("0번");
            text.Add("1번");
            text.Add("3번인 척 하는 2번");

            Console.WriteLine(text[0]);
            Console.WriteLine(text[1]);
            Console.WriteLine(text[2]);

            Dictionary<int, string> textTwo = new Dictionary<int, string>();

            textTwo.Add(1, "1번");
            textTwo.Add(2, "2번");
            textTwo.Add(50, "50번");
            textTwo.Add(3, "이번엔 진짜 3번");

            Console.WriteLine(textTwo[1]);
            Console.WriteLine(textTwo[3]);
            Console.WriteLine(textTwo[50]);

            Queue<string> textThree = new Queue<string>();

            textThree.Enqueue("1번");
            textThree.Enqueue("2번");
            textThree.Enqueue("3번");
            textThree.Enqueue("나 3번인가?!");

            textThree.Dequeue();
            textThree.Dequeue();

            Console.WriteLine($"과연 누가 나올까? 정답은 {textThree.Dequeue()}!");

            Stack<string> textFour = new Stack<string>();

            textFour.Push(textThree.Dequeue());
            textFour.Push("새로운 1번");
            textFour.Push("새로운 2번");
            textFour.Push("새로운 3번");

            textFour.Pop();
            textFour.Pop();
            textFour.Pop();

            Console.WriteLine($"과연 누가 나올까? 설마 이번에도... {textFour.Pop()}");

            HashSet<string> textFive = new HashSet<string>();

            textFive.Add("1");
            textFive.Add("2");
            textFive.Add("3");
            bool isIn = textFive.Add("2");

            Console.WriteLine();

            Console.WriteLine("과연 textFive.Add(\"2\")는 들어갔을까?");

            if (isIn)
            {
                Console.WriteLine("들어갔네!");
            }
            else if (isIn == false)
            {
                Console.WriteLine("아니네!");
            }

            Console.WriteLine($"그렇다면 textFive의 데이터 총 개수는? {textFive.Count}개!");

        }

    }
}
