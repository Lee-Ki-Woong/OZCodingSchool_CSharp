using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_LvUp_Assignment
{
    internal class Gagu
    {
        private static int m_id = 0;
        public int m_myId;
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        internal Gagu(string name, string description)
        {
            m_id++;
            m_myId = m_id;
            Name = name;
            Description = description;
        }
    }

    internal class GaguShop
    {
        private Dictionary<string, Gagu> m_todaysGagu = new Dictionary<string, Gagu>();

        internal void GetTodaysGagu()
        {

            Gagu gaguOne = new Gagu("가구", "가구");
            Gagu gaguTwo = new Gagu("이상한 가구", "우리가 알던 가구가 아니다");
            Gagu gaguThree = new Gagu("가구2", "그렇다");
            Gagu gaguFour = new Gagu("가글", "가글과 가구");
            Gagu gaguFive = new Gagu("귀찮은 가구", "For문써서 생성할걸");
            Gagu gaguSix = new Gagu("낭만주의자 가구", "하지만 모든 가구의 이름이 똑같다면 낭만이 없는걸");
            Gagu gaguSeven = new Gagu("수납장", "진짜 가구");
            Gagu gaguEight = new Gagu("생선처럼 보이는 가구", "가구가 아닌 정어리");
            Gagu gaguNine = new Gagu("윗 가구 따라 흘러온 가구", "참치");
            Gagu gaguTen = new Gagu("코더 가구", "for(int i=0; i < 10; i++) { Gagu gagu = new Gagu(\"가구\"); }");

            m_todaysGagu.Add("삼백원", gaguOne);
            m_todaysGagu.Add("오백원", gaguTwo);
            m_todaysGagu.Add("천원", gaguThree);
            m_todaysGagu.Add("이천원", gaguFour);
            m_todaysGagu.Add("오천원", gaguFive);
            m_todaysGagu.Add("만원", gaguSix);
            m_todaysGagu.Add("오만원", gaguSeven);
            m_todaysGagu.Add("십억원", gaguEight);
            m_todaysGagu.Add("일달러", gaguNine);
            m_todaysGagu.Add("이달러", gaguTen);
        }

        internal void OpenShop()
        {
            foreach (string key in m_todaysGagu.Keys)
            {
                Console.WriteLine($"가격 : {key}");
                Gagu gagu = m_todaysGagu[key];

                Console.WriteLine(gagu.Name);
                Console.WriteLine(gagu.Description);
            }
        }
    }



    internal class Program
    {
        static void Main(string[] leeKiWoong)
        {
            GaguShop newGaguShop = new GaguShop();

            newGaguShop.GetTodaysGagu();

            newGaguShop.OpenShop();



        }

    }
}
