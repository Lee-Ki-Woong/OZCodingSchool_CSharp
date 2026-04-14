using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    namespace ConsoleApp1
    {


        public enum Grade : byte
        {
            None = 0,
            Normal = 1,
            Rare = 2,
            Unique = 3,
            Epic = 4,
            Lagendary = 5,

        }

        public enum ClassType : byte
        {
            None = 0,
            Warrior = 1,
            Archer = 2,
            Mage = 3,
            Rogue = 4,
            Astrologer = 5,
            ChronoMage = 6,
            Voider = 7,
            Tamer = 8,
            Healer = 9,
            Rabbit = 10,

        }

        public enum ArmourType : byte
        {

            None = 0,
            Cloth = 1,
            Leather = 2,
            LightArmour = 3,

        }

        public enum WeaponType : byte
        {

            None = 0,
            Sword = 1,
            Bow = 2,
            MageWand = 3,
            Dagger = 4,
            Grimoire = 5,
            Orb = 6,
            Whip = 7,
            Cross = 8,
            Carrot = 9,

        }



        public class Weapon
        {

            protected string m_name;
            protected int m_damage;
            protected int m_range;
            protected int m_speed;
            protected WeaponType m_class;
            protected int m_value;
            protected Grade m_grade;

        }

        public class Sword : Weapon
        {

            public Sword(string name, int damage, int range, int speed, int value, Grade grade)
            {

                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Sword;
                m_value = value;
                m_grade = grade;

            }

            public static List<Sword> Swords = new List<Sword>()
        {

            new Sword("낡은 검", 50, 25, 100, 1, Grade.Normal),
            new Sword("검", 100, 25, 100,1, Grade.Normal ),
            new Sword("강철 검", 150, 25, 100, 1, Grade.Rare),

        };

        }

        public class Bow : Weapon
        {
            public Bow(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Bow;
                m_value = value;
                m_grade = grade;

            }

            public static List<Bow> Bows = new List<Bow>()
        {

            new Bow("낡은 활", 50, 300, 100, 1, Grade.Normal),
            new Bow("활", 100, 300, 100, 1, Grade.Normal),
            new Bow("강철 활", 150, 300, 100, 1, Grade.Rare),


        };

        }

        public class MageWand : Weapon
        {
            public MageWand(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.MageWand;
                m_value = value;
                m_grade = grade;
            }

            public static List<MageWand> MageWands = new List<MageWand>()
        {
            new MageWand("낡은 지팡이", 100, 150, 200, 1, Grade.Normal),
            new MageWand("마법 지팡이", 200, 150, 200, 1, Grade.Normal),
            new MageWand("떡갈나무 지팡이", 300, 150, 200, 1, Grade.Rare),
        };

        }

        public class Dagger : Weapon
        {
            public Dagger(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Dagger;
                m_value = value;
                m_grade = grade;
            }

            public static List<Dagger> Daggers = new List<Dagger>()
        {
            new Dagger("낡은 단검", 25, 25, 50, 1, Grade.Normal),
            new Dagger("단검", 50, 25, 50, 1, Grade.Normal),
            new Dagger("강철 단검", 75, 25, 50, 1, Grade.Rare),
        };

        }

        public class Grimoire : Weapon
        {
            public Grimoire(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Grimoire;
                m_value = value;
                m_grade = grade;
            }

            public static List<Grimoire> Grimoires = new List<Grimoire>()
        {
            new Grimoire("낡은 마도서", 100, 200, 50, 1, Grade.Normal),
            new Grimoire("마도서", 200, 200, 50, 1, Grade.Normal),
            new Grimoire("상급 마도서", 300, 200, 50, 1, Grade.Rare),
        };

        }

        public class Orb : Weapon
        {
            public Orb(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Orb;
                m_value = value;
                m_grade = grade;
            }

            public static List<Orb> Orbs = new List<Orb>()
        {
            new Orb("금이 간 오브", 100, 200, 50, 1, Grade.Normal),
            new Orb("오브", 200, 200, 50, 1, Grade.Normal),
            new Orb("빛나는 오브", 300, 200, 50, 1, Grade.Rare),
        };

        }

        public class Whip : Weapon
        {
            public Whip(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Whip;
                m_value = value;
                m_grade = grade;
            }

            public static List<Whip> Whips = new List<Whip>()
        {
            new Whip("허름한 채찍", 100, 200, 50, 1, Grade.Normal),
            new Whip("채찍", 200, 200, 50, 1, Grade.Normal),
            new Whip("강철 채찍", 300, 200, 50, 1, Grade.Rare),
        };

        }

        public class Cross : Weapon
        {
            public Cross(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Cross;
                m_value = value;
                m_grade = grade;
            }

            public static List<Cross> Crosses = new List<Cross>()
        {
            new Cross("낡은 십자가", 100, 200, 50, 1, Grade.Normal),
            new Cross("십자가", 200, 200, 50, 1, Grade.Normal),
            new Cross("은빛 십자가", 300, 200, 50, 1, Grade.Rare),
        };

        }

        public class Carrot : Weapon
        {
            public Carrot(string name, int damage, int range, int speed, int value, Grade grade)
            {
                m_name = name;
                m_damage = damage;
                m_range = range;
                m_speed = speed;
                m_class = WeaponType.Carrot;
                m_value = value;
                m_grade = grade;
            }

            public static List<Carrot> Carrots = new List<Carrot>()
        {
            new Carrot("썩은 당근", 100, 200, 50, 1, Grade.Normal),
            new Carrot("당근", 200, 200, 50, 1, Grade.Normal),
        };

        }




        public class Armour
        {

            protected string m_name;
            protected int m_armour;
            protected ArmourType m_class;
            protected int m_value;
            protected Grade m_grade;

        }

        public class Cloth : Armour
        {
            public Cloth(string name, int armour, int value, Grade grade)
            {

                m_name = name;
                m_armour = armour;
                m_class = ArmourType.Cloth;
                m_value = value;
                m_grade = grade;

            }

            public static List<Cloth> Clothes = new List<Cloth>()
        {

            new Cloth("낡은 천옷", 25, 1, Grade.Normal),
            new Cloth("천옷", 50, 1, Grade.Normal),
            new Cloth("두꺼운 천옷", 75, 1, Grade.Rare),

        };

        }

        public class Leather : Armour
        {
            public Leather(string name, int armour, int value, Grade grade)
            {

                m_name = name;
                m_armour = armour;
                m_class = ArmourType.Leather;
                m_value = value;
                m_grade = grade;

            }

            public static List<Leather> Leathers = new List<Leather>()
        {
            new Leather("낡은 가죽 옷", 25, 1, Grade.Normal),
            new Leather("가죽 옷", 50, 1, Grade.Normal),
            new Leather("두꺼운 가죽 옷", 75, 1, Grade.Rare),

        };


        }

        public class LightArmour : Armour
        {
            public LightArmour(string name, int armour, int value, Grade grade)
            {

                m_name = name;
                m_armour = armour;
                m_class = ArmourType.LightArmour;
                m_value = value;
                m_grade = grade;

            }

            public static List<LightArmour> LightArmours = new List<LightArmour>()
        {

            new LightArmour("낡은 경갑 옷", 25, 1, Grade.Normal),
            new LightArmour("경갑 옷", 50, 1, Grade.Normal),
            new LightArmour("두꺼운 경갑 옷", 75, 1, Grade.Rare),

        };

        }



        public class Class
        {
            private string m_name;
            private int m_maxHp;
            private int m_hp;
            private ClassType m_class;

            public Class(string name, int maxHp, int hp, ClassType type)
            {
                m_name = name;
                m_maxHp = maxHp;
                m_hp = hp;
                m_class = type;

            }

            public static List<Class> Classes = new List<Class>()
        {

            new Class("초보자", 200, 200, ClassType.None),
            new Class("전사", 500, 500, ClassType.Warrior),
            new Class("궁수", 400, 400, ClassType.Archer),
            new Class("마법사", 350, 350, ClassType.Mage),
            new Class("도적", 450, 450, ClassType.Rogue),
            new Class("점성술사", 300, 300, ClassType.Astrologer),
            new Class("시간술사", 300, 300, ClassType.ChronoMage),
            new Class("공간술사", 300, 300, ClassType.Voider),
            new Class("부리미", 400, 400, ClassType.Tamer),
            new Class("힐러", 350, 350, ClassType.Healer),
            new Class("토끼", 250, 250, ClassType.Rabbit),

        };

            public string ClassNameCheck()
            {
                return m_name;
            }

        }



        public class Player
        {

            private string m_name;
            private Class m_class;
            private Weapon m_weapon;
            private Armour m_armour;
            private int m_level;

            public string PlayerNameCheck()
            {

                return m_name;

            }

            public string ClassNameCheckInPlayer()
            {

                return m_class.ClassNameCheck();

            }

            public int PlayerLevelCheck()
            {

                return m_level;

            }

            public void NewPlayerName(string playerName)
            {

                m_name = playerName;

            }

            public Player(string playerName, int playerClass)
            {
                m_name = playerName;
                m_class = Class.Classes[playerClass];
                m_level = 1;

                if (m_class.ClassNameCheck() == "전사")
                {
                    m_weapon = Sword.Swords[0];
                    m_armour = LightArmour.LightArmours[0];
                }

                if (m_class.ClassNameCheck() == "궁수")
                {
                    m_weapon = Bow.Bows[0];
                    m_armour = Leather.Leathers[0];
                }

                if (m_class.ClassNameCheck() == "마법사")
                {
                    m_weapon = MageWand.MageWands[0];
                    m_armour = Cloth.Clothes[0];
                }

                if (m_class.ClassNameCheck() == "도적")
                {
                    m_weapon = Dagger.Daggers[0];
                    m_armour = Leather.Leathers[0];
                }

                if (m_class.ClassNameCheck() == "점성술사")
                {
                    m_weapon = Grimoire.Grimoires[0];
                    m_armour = Cloth.Clothes[0];
                }

                if (m_class.ClassNameCheck() == "시간술사")
                {
                    m_weapon = Orb.Orbs[0];
                    m_armour = Cloth.Clothes[0];
                }

                if (m_class.ClassNameCheck() == "공간술사")
                {
                    m_weapon = Orb.Orbs[0];
                    m_armour = Cloth.Clothes[0];
                }

                if (m_class.ClassNameCheck() == "부리미")
                {
                    m_weapon = Whip.Whips[0];
                    m_armour = Leather.Leathers[0];
                }

                if (m_class.ClassNameCheck() == "토끼")
                {
                    m_weapon = Carrot.Carrots[0];
                    m_armour = LightArmour.LightArmours[0];
                }

            }

        }

        public class Monster
        {
            private string m_name;
            private int m_maxHp;
            private int m_hp;
            private int m_damage;
            private int m_armour;
            private int m_speed;
            private int m_range;

        }





        internal class Program
        {

            static void Main(string[] args)
            {

                MainMenu();

            }

            static bool IsTrueFalseCheck(string text)
            {

                string choice;
                bool isMiss = false;

                while (true)
                {

                    Console.Clear();

                    Console.WriteLine(text);
                    Console.WriteLine("1. 예 / 2. 아니오");

                    if (isMiss)
                    {

                        Console.WriteLine("\n\n잘못 입력하였습니다!! 다시 확인해주세요!!");
                        isMiss = false;

                    }
                    choice = Console.ReadLine();


                    if (choice == "1") return true;
                    else if (choice == "2") return false;
                    else isMiss = true;

                }

            }

            static int MainMenu()
            {
                bool isMiss = false;
                bool isNoContents = false;
                Player[] players = new Player[4];


                while (true)
                {

                    int playerCount = 0;

                    Console.Clear();

                    Console.WriteLine("1. 캐릭터 생성    2. 시작하기    3. 캐릭터 정보    4. 게임 종료");

                    if (isMiss) Console.WriteLine("\n잘못 입력하였습니다! 다시 확인해주세요.");

                    if (isNoContents) Console.WriteLine("죄송하지만 컨텐츠가 미구현입니다!! 오후11시까지 했는데도 여기까지만 만들었어요 ㅠㅠ");

                    isMiss = false;
                    isNoContents = false;

                    int.TryParse(Console.ReadLine(), out int choice);

                    for (int i = 0; i < 4; i++)
                    {
                        if (players[i] == null) { }
                        else { playerCount++; }
                    }

                    switch (choice)
                    {
                        case 1:
                            {
                                bool isMakePlayers = IsTrueFalseCheck($"캐릭터를 생성하시겠습니까? 현재 캐릭터 수는 {playerCount}명 입니다.");

                                if (isMakePlayers)
                                {
                                    MakePlayers(players);
                                }
                            }
                            break;
                        case 2:
                            {
                                isNoContents = true;
                            }
                            break;
                        case 3:
                            {
                                isNoContents = true;
                            }
                            break;
                        case 4: return 0;
                        default: isMiss = true; break;

                    }

                }

            }

            static Player[] MakePlayers(Player[] players)
            {
                bool isMiss = false;
                bool isChoiceNumber = false;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|                  캐릭터를 생성할 슬롯을 선택해 주십시오.              |");
                    Console.WriteLine("=========================================================================");
                    Console.WriteLine($"| {"슬롯",-6}\t| {"이름",-15}\t| {"직업",8}\t|{"레벨",8}\t|");
                    Console.WriteLine("=========================================================================");

                    for (int i = 0; i < 4; i++)
                    {
                        if (players[i] == null)
                        {
                            Console.WriteLine($"| {i + 1,-6}\t| {"비어있음",-15}\t| {"없음",8}\t| {"0",8}\t|");
                            continue;
                        }

                        Console.WriteLine($"| {i + 1,-6}\t| {players[i].PlayerNameCheck(),-15}\t| {players[i].ClassNameCheckInPlayer(),8}\t| {players[i].PlayerLevelCheck(),8}\t|");

                    }

                    Console.WriteLine("|\t\t|\t\t\t|\t\t|\t\t|");
                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|\t\t\t\t\t\t\t메인메뉴 - X\t|");
                    Console.WriteLine("=========================================================================");

                    if (isMiss) Console.WriteLine("\n잘못 입력하였습니다! 다시 확인해주세요.");
                    isMiss = false;

                    string text = Console.ReadLine();

                    if (text == "X" || text == "x" || text == "ㅌ") return players;

                    isChoiceNumber = int.TryParse(text, out int choice);

                    if (isChoiceNumber)
                    {

                        if (choice <= 4 && choice > 0)
                        {
                            string playerName = MakeName();
                            int playerClass = MakeClass();
                            players[choice - 1] = new Player(playerName, playerClass);
                            return players;

                        }
                        else isMiss = true;
                    }
                    else isMiss = true;

                }

            }

            static string MakeName()
            {
                while (true)
                {
                    Console.WriteLine("캐릭터명을 입력해주세요.");

                    string playerName = Console.ReadLine();

                    bool isPlayerName = IsTrueFalseCheck($"캐릭터명이 {playerName}가 맞습니까?");

                    if (isPlayerName)
                    {
                        return playerName;
                    }

                }

            }

            static int MakeClass()
            {
                bool isMiss = false;

                while (true)
                {
                    bool isChoiceNumber = false;

                    Console.WriteLine("원하시는 직업을 선택해주세요.");
                    Console.WriteLine("1. 전사     2. 궁수     3. 마법사     4. 도적     5. 점성술사");
                    Console.WriteLine("6. 시간술사 7. 공간술사 8. 부리미     9. 힐러     10. 토끼");

                    if (isMiss) Console.WriteLine("\n잘못 입력하였습니다! 다시 확인해주세요."); isMiss = false;

                    string playerClass = Console.ReadLine();

                    if (playerClass == "X" || playerClass == "x") return 0;

                    isChoiceNumber = int.TryParse(playerClass, out int choice);

                    if (isChoiceNumber)
                    {

                        switch (choice)
                        {

                            case 1:
                                {
                                    if (IsTrueFalseCheck("전사를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 2:
                                {
                                    if (IsTrueFalseCheck("궁수를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 3:
                                {
                                    if (IsTrueFalseCheck("마법사를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 4:
                                {
                                    if (IsTrueFalseCheck("도적을 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 5:
                                {
                                    if (IsTrueFalseCheck("점성술사를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 6:
                                {
                                    if (IsTrueFalseCheck("시간술사를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 7:
                                {
                                    if (IsTrueFalseCheck("공간술사를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 8:
                                {
                                    if (IsTrueFalseCheck("부리미를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 9:
                                {
                                    if (IsTrueFalseCheck("힐러를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            case 10:
                                {
                                    if (IsTrueFalseCheck("토끼를 선택하시겠습니까?")) return choice;
                                }
                                break;
                            default: isMiss = true; break;

                        }

                    }
                    else isMiss = true;

                }

            }


        }

    }


}
