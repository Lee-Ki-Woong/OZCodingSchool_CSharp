using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool isMiss = false;

            int b = 0;
            string c = "";
            int e = 0;
            int f = 0;
            float g = 0;

            Console.WriteLine("계산기 입니다. 정수를 입력해주십시오.");

            int a = int.Parse(Console.ReadLine());

            while (true)
            {

                Console.WriteLine($"{a}를 입력하였습니다. 계산할 방식을 선택하여 주십시오. \n1. 더하기   2. 빼기   3. 곱하기   4. 나누기   5. 나누기 후 몫과 나머지 값 확인하기");

                if (isMiss)

                {

                    Console.WriteLine("잘못 입력하였습니다! 다시 확인해주세요.");

                    isMiss = false;

                }

                b = int.Parse(Console.ReadLine());

                switch (b)
                {

                    case 1:
                        {

                            c = "더할";


                        }
                        break;
                    case 2:
                        {

                            c = "뺄";

                        }
                        break;
                    case 3:
                        {

                            c = "곱할";

                        }
                        break;
                    case 4:
                        {

                            c = "나눌";

                        }
                        break;
                    case 5:
                        {

                            c = "나눈 후 몫과 나머지를 확인 할";

                        }
                        break;
                    default:
                        {

                            isMiss = true;

                        }
                        continue;




                }

                break;

            }

            Console.WriteLine($"{a}와 " + c + " 값을 입력해 주십시오.");

            int d = int.Parse(Console.ReadLine());

            switch (b)
            {

                case 1:
                    {

                        e = a + d;

                    }
                    break;
                case 2:
                    {

                        e = a - d;

                    }
                    break;
                case 3:
                    {

                        e = a * d;

                    }
                    break;
                case 4:
                    {

                        g = (float)a / d;

                    }
                    break;
                case 5:
                    {

                        e = a / d;
                        f = a % d;

                    }
                    break;




            }

            switch (b)
            {
                case 1:
                case 2:
                case 3:
                    {

                        Console.WriteLine($"계산 값은 {e} 입니다. ");

                    }
                    break;
                case 4:
                    {

                        Console.WriteLine($"계산 값은 {g}입니다.");

                    }
                    break;
                case 5:
                    {

                        Console.WriteLine($"몫은 {e}며 나머지는 {f}입니다.");

                    }
                    break;

            }

        }

    }
}
