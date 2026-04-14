using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    public enum MonsterType
    {
        None = 0,
        Slime = 1,
        Wolf = 2,
        Troll = 3,
        Orc = 4,
        Ogre = 5,
        BossMonster = 101,
    }

    public enum MapType
    {
        None = 0,
        Forest = 1,
        IceLand = 2,
        Volcano = 3,
        Jungle = 4,
    }

    internal class Monster
    {
        public string m_name { get; protected set; }
        public MonsterType m_monsterType { get; protected set; }
        public MapType m_mapType { get; protected set; }

        public Monster(string name, MapType mapType)
        {
            m_name = name;
            m_monsterType = MonsterType.None;
            m_mapType = mapType;
        }

        public virtual void Info()
        {
            Console.WriteLine("버그 방지를 위한 텍스트! 발견한다면 즉시 신고데스크에 신고해주세요.");
        }
    }

    internal class Slime : Monster
    {
        public Slime(string name, MapType mapType) : base(name, mapType)
        {
            m_monsterType = MonsterType.Slime;
        }

        public override void Info()
        {
            Console.WriteLine("원소의 기운이 모여 젤리형태로 변환된 몬스터이다. 만지면 말랑말랑하다");
        }
    }

    internal class Wolf : Monster
    {
        public Wolf(string name, MapType mapType) : base(name, mapType)
        {
            m_monsterType = MonsterType.Wolf;
        }

        public override void Info()
        {
            Console.WriteLine("사람의 손길이 닿지 않는 구역을 떠돌아 다니는 몬스터이다. 행동이 매우 재빠르며, 날카로운 송곳니는 치명적일 수 있다.");
        }
    }

    internal class Troll : Monster
    {
        public Troll(string name, MapType mapType) : base(name, mapType)
        {
            m_monsterType = MonsterType.Troll;
        }

        public override void Info()
        {
            Console.WriteLine("부족 사회를 이루어 살아가며, 사람보단 못하지만 지성이 어느 정도 있는 몬스터이다. 트롤이 한 마리라도 근처에 보인다면 트롤 부족이나 트롤 무리가 주변에 있을 가능성이 매우 높으니 주의하자!!");
        }
    }

    internal class Orc : Monster
    {
        public Orc(string name, MapType mapType) : base(name, mapType)
        {
            m_monsterType = MonsterType.Orc;
        }

        public override void Info()
        {
            Console.WriteLine("커다란 덩치를 가지고 있으며, 힘이 매우 센 몬스터이다. 기초적인 사고를 할 줄 알아 무리가 많을 땐 멀리서 지켜보지만, 혼자 있을 경우 만만하다고 생각해 공격을 하니 혼자 있다면 각별히 조심을 해야 한다.");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Monster> monsterDictionary = new Dictionary<string, Monster>();
            Monster slime = new Slime("숲슬라임", MapType.Forest);
            Monster wolf = new Wolf("숲늑대", MapType.Forest);
            Monster orc = new Orc("화산오크", MapType.Volcano);
            Monster troll = new Troll("숲트롤", MapType.Forest);
            Monster slimeTwo = null;

            monsterDictionary.Add("슬라임", slime);
            monsterDictionary.Add("늑대", wolf);
            monsterDictionary.Add("오크", orc);
            monsterDictionary.Add("트롤", troll);
            monsterDictionary.Add("오류슬라임", slimeTwo);

            Console.WriteLine(monsterDictionary["오크"].m_name);
            monsterDictionary["오크"].Info();

            Console.WriteLine();

            Console.WriteLine(monsterDictionary["트롤"].m_name);
            monsterDictionary["트롤"].Info();

            Console.WriteLine();

            Console.WriteLine("몬스터 사전에서 오크 제거!");
            monsterDictionary.Remove("오크");

            if (monsterDictionary.ContainsKey("오크") == false)
            {
                Console.WriteLine("이제 몬스터 도감에 오크란 단어는 없습니다!");
            }

            Console.WriteLine();

            if (monsterDictionary["오류슬라임"] == null)
            {
                Console.WriteLine($"비상! 사전에 이상한 데이터가 있는 것 같습니다. 사전에 있는 오류데이터를 삭제합니다!!");
                monsterDictionary.Remove("오류슬라임");

            }


        }
    }
}
