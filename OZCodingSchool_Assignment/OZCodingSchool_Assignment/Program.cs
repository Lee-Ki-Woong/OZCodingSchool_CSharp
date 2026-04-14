using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal class LeeKiWoong
    {
        internal interface IJumpable
        {
            void Jump();
        }

        internal interface ITransformable
        {
            void Transform();
        }

        internal interface ITerrorable
        {
            void Terror();
        }

        internal class Ball : IJumpable, ITransformable, ITerrorable
        {
            public string Name { get; protected set; }
            protected bool m_isTransform;


            public Ball(string name)
            {
                Name = name;
                m_isTransform = false;
            }

            public virtual void Jump()
            {
                if (m_isTransform)
                {
                    UIManager.Instance.ViewingText($"{Name}은 하늘 높이 날아올랐다!!", $"{Name} : 날 가지고 놀던 너희 인간들에게 심판을 내려주마!!");
                    return;
                }

                UIManager.Instance.ViewingText($"{Name}이 통통 튀었다.");
            }
            void ITransformable.Transform()
            {
                UIManager.Instance.ViewingText($"{Name}은 로봇으로 변신을 하였다.", "위잉 - 치킨");
                m_isTransform = true;
            }

            public void Terror()
            {
                if (m_isTransform)
                {
                    UIManager.Instance.ViewingText($"{Name}은 사람에 대한 무차별 공격을 가하기 시작했다!", $"{Name} : 인간 시대의 끝이 도래했다!!");
                    return;
                }

                UIManager.Instance.ViewingText($"{Name}이 이웃집의 창문을 깨부셨다!!", "이웃집 아주머니가 화가 난 거 같다!! 도망치자!!");
            }

        }

        internal class SmallBall : Ball, IJumpable
        {
            public SmallBall(string name) : base(name)
            {
                m_isTransform = false;
            }

            public override void Jump()
            {
                UIManager.Instance.ViewingText($"{Name}가 통! 하고 높이 뛰어올랐다!");
            }

        }




        internal class UIManager
        {
            private static UIManager m_instance;

            private UIManager() { }

            public static UIManager Instance
            {
                get
                {
                    if (m_instance == null)
                    {
                        m_instance = new UIManager();
                    }
                    return m_instance;
                }
            }



            public void ViewingText(string textOne)
            {
                Console.WriteLine(textOne);
                Console.WriteLine();
            }

            public void ViewingText(string textOne, string textTwo)
            {
                Console.WriteLine(textOne);
                Console.WriteLine(textTwo);
                Console.WriteLine();
            }

            public void ViewingText(string textOne, string textTwo, string textThree)
            {
                Console.WriteLine(textOne);
                Console.WriteLine(textTwo);
                Console.WriteLine(textThree);
                Console.WriteLine();
            }

        }

        internal class Program
        {
            static void Main(string[] leeKiWoong)
            {
                Ball ballOne = new Ball("축구공");
                ballOne.Jump();
                ballOne.Terror();

                Ball ballTwo = new Ball("공인척하는 메가트론");
                ballTwo.Jump();
                ballTwo.Terror();

                ((ITransformable)ballTwo).Transform();

                ballTwo.Jump();
                ballTwo.Terror();

                SmallBall ballThree = new SmallBall("탁구공");
                ballThree.Jump();

                List<IJumpable> jumpableList = new List<IJumpable>();

                jumpableList.Add(ballThree);
                jumpableList.Add(ballTwo);
                jumpableList.Add(ballOne);

                foreach (IJumpable jumpable in jumpableList)
                {
                    if (jumpable is Ball)
                    {
                        jumpable.Jump();
                    }

                }
            }
        }
    }
}
