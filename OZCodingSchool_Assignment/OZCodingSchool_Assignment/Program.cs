using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal class LeeKiWoong
    {


        static string m_yourName;

        static int m_yourMoney;


        static bool isTrueFalseCheck(string text)
        {

            while (true)
            {

                Console.WriteLine(text);

                string choice = Console.ReadLine();

                if (choice == "1" || choice == "YES" || choice == "예"/* 도대체 왜? */ || choice == "yes" || choice == "Yes" /* 도대체 왜?2 */)
                {

                    return true;

                }
                else if (choice == "2" || choice == "NO" || choice == "아니오" || choice == "no" || choice == "No")
                {

                    return false;

                }
                else
                {

                    Console.WriteLine("잘못 입력하신 거 같은데요? 다시 돌려드릴테니 다음엔 제대로 선택해주세요!!");

                }

            }

        }

        static int ArbeitOne()
        {

            int arbeitPoint = 0;

            Console.WriteLine("자 먼저 자료형의 무게를 말해보게! 이건 정말 쉬울거야");

            Console.WriteLine("\n1. int numberOne = 8;");


            Console.WriteLine("\n\n아 참고로 뒤에 bytes는 자동으로 붙으니 숫자만 입력해주게");

            string choiceOne = Console.ReadLine();


            if (choiceOne == "4")
            {

                Console.WriteLine("호오 정답일세");
                arbeitPoint++;

            }
            else
            {

                Console.WriteLine("자네 공부를 제대로 안 했군!! int의 무게는 4bytes라네");

            }


            Console.WriteLine("\n\n자 그럼 두번째 자료형일세 무게를 말해주게\n2. bool isNumberTwo = true;");

            choiceOne = Console.ReadLine();


            if (choiceOne == "1")
            {

                Console.WriteLine("호오 정답일세");
                arbeitPoint++;

            }
            else
            {

                if (arbeitPoint == 0)
                {

                    Console.WriteLine("자네 공부를 포기한건가!! bool의 무게는 1byte라네");

                }
                else
                {

                    Console.WriteLine("자네 공부를 제대로 안 했군!! bool의 무게는 1byte라네");

                }

            }


            Console.WriteLine("\n\n자 그럼 세번째 자료형일세 이 친구는 조금 어렵겠구먼... 무게를 말해주게\n3. double numberThree = (int)3.14159");

            choiceOne = Console.ReadLine();


            if (choiceOne == "8")
            {

                Console.WriteLine("호오 정답일세 리터럴의 자료형이 int로 바뀐다고 해도 numberThree의 자료형은 여전히 double이라 8bytes지");
                arbeitPoint++;

            }
            else
            {

                Console.WriteLine("아쉽게 되었네... 리터럴의 자로형이 int로 바뀐다고 하여도 numberThree의 자료형은 바뀌지 않는다네 그래서 8bytes가 정담이였다네..");

            }


            Console.WriteLine("\n\n이걸 말해주게\n 4. char numberFour = 'C' ");

            choiceOne = Console.ReadLine();


            if (choiceOne == "2")
            {

                Console.WriteLine("정답일세! C++에서 C#으로 넘어오면서 UTF+8에서 UTF+16으로 성장을 하였지... 그로 인해 char 자료형 내부가 영문이어도 한글과 동일하게 2bytes로 바뀌게 되었지");
                arbeitPoint++;

            }
            else
            {

                Console.WriteLine("아쉽게 되었네... C++를 생각했다면 큰 오산이야... C++에서 C#으로 넘어오면서 UTF+8에서 UTF+16으로 바뀌어 char 자료형 내부가 영문이어도 한글과 동일하게 2bytes로 바뀌었다네... 오답일세");

            }


            Console.WriteLine("\n\n흐음... 자료형 무게 측정은 이게 마지막일 것 같군... 이걸 말해주게\n 4. string numberFour = \"💩\" << (??로 보이지만 이모지입니다!!)");

            choiceOne = Console.ReadLine();


            if (choiceOne == "4")
            {

                Console.WriteLine("정답일세! C#에서 이모지의 무게를 측정해보면 2bytes라고 나오지만 그건 사실 이모지가 char 2개로 나뉘어 관리되어 있어 그렇게 나오는 것 뿐이고, 실제 무게는 4bytes라네 ");
                arbeitPoint++;

            }
            else
            {

                Console.WriteLine("아쉽게 되었네... C#에서 이모지의 무게를 측정해본다면 2bytes라고 나오지만 그건 사실 이모지가 char 2개로 나뉘어져 있어서 그렇다네... 실제론 char 2개를 합쳐서 4bytes지... 오답일세");

            }



            Console.WriteLine($"자네 지금까지 {arbeitPoint}번 나를 도와주었군... 고맙네 감사의 의미로 " + arbeitPoint * 5000 + "원의 돈을 주지");

            arbeitPoint = arbeitPoint * 5000;


            return arbeitPoint;

        }

        static int Main(string[] leeKiWoong)
        {


            m_yourMoney = 100;

            Console.WriteLine($"당신이 가진 돈은 {m_yourMoney}원 입니다.");

            int mommoney = 5000;

            Console.WriteLine($"엄마가 가진 돈은 {mommoney}원 입니다.");


            while (true)
            {

                Console.WriteLine("당신의 이름은?");

                m_yourName = Console.ReadLine();

                if (m_yourName == "엄마")
                {

                    Console.WriteLine($"엥? 이름이 엄마가 맞나요?? 이상하다 분명 엄마가 가진 돈은 {mommoney}라고 했는데, 당신은 {m_yourMoney}만큼의 돈만 있는 걸?");
                    continue;
                }
                else
                {


                    Console.WriteLine($"{m_yourName}님 {m_yourMoney}원을 가지고 있으시군요!!");
                    break;

                }

            }

            bool isChoiceOne = isTrueFalseCheck($"{m_yourName}님 돈을 벌러 가보실까요? 1. YES 2. NO");

            if (isChoiceOne == true)
            {

                Console.WriteLine("돈을 벌러 가보실까요?! 고고");

            }
            else if (isChoiceOne == false)
            {

                Console.WriteLine("돈도 없는데 일도 안 하겠다니!! 이런 나쁜사람을 봤나!! 내 프로그램에서 나가!!");
                return 0;

            }

            Console.WriteLine("자!! 여기 아르바이트가 있어요~ C#에서의 자료형을 정리하는 아르바이트가 있어요~ 아르바이트를 해보실래요? 돈은 많이 드리겠습니다");

            bool isChoiceTwo = isTrueFalseCheck("돈을 많이 주는 아르바이트라는데 참여해볼까요??");

            if (isChoiceOne == true)
            {

                m_yourMoney = ArbeitOne();

            }
            else if (isChoiceOne == false)
            {

                Console.WriteLine("돈을 많이 주겠다고 했는데 안한다니!! 이런 나쁜사람을 봤나!! 내 앞에서 사라져!!");
                Console.WriteLine("\n당신은 가게 주인한테 맞아 기절하였습니다 ㅜㅜ");
                return 0;

            }

            Console.WriteLine($"{m_yourName}님 {m_yourMoney}만큼의 돈을 버셨군요!! 축하합니다!! 하지만 저런! 개발자가 과제 내용을 이해하고 계산기를 만들러 떠났습니다!!");



            return 0;

        }

    }
}
