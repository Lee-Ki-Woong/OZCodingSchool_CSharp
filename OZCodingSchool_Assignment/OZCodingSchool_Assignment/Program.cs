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

    namespace OZCodingSchool_Assignment
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

        public enum MapType
        {
            None = 0,
            Town = 1,
            Forest = 2,
            SnowField = 3,
            Volcano = 4,
            Tower = 5,
        }

        public enum Time
        {
            None = 0,
            Day = 1,
            Night = 2,
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

            public string WeaponNameCheck()
            {
                return m_name;
            }

            public int WeaponDamageCheck()
            {
                return m_damage;
            }

            public virtual int Attack(int monsterArmour, Player player)
            {
                int finalDamage = m_damage - monsterArmour;
                Console.WriteLine($"{m_name}으로 공격! {finalDamage}만큼의 데미지를 입혔다!!");
                return finalDamage;

            }

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

            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Warrior)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}으로 휘두르기!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}으로 휘두르기!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }

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
            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Archer)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 사격!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}로 사격!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }
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
            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Mage)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 마법 사용!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}로 마법 사용!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }

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
            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Rogue)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}으로 찌르기!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}으로 찌르기!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }

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

            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Astrologer)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 별무리 소환!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}로 별무리 소환!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }
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

            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Voider)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 공간 마법 사용! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else if (player.ClassCheck() == ClassType.ChronoMage)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 시간 마법 사용! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}로 마법 사용! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }
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

            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Tamer)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 채찍질!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}로 채찍질!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }

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

            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Healer)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}로 신성마법 사용!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}로 신성마법 사용!! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }

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
            public override int Attack(int monsterArmour, Player player)
            {
                if (player.ClassCheck() == ClassType.Rabbit)
                {
                    int finalDamage = (m_damage * 3 / 2) - monsterArmour;
                    Console.WriteLine($"{m_name}으로 당근 투척?! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }
                else
                {
                    int finalDamage = m_damage - monsterArmour;
                    Console.WriteLine($"{m_name}으로 당근 투척?! {finalDamage}만큼의 데미지를 입혔다!!");
                    return finalDamage;
                }

            }
        }




        public class Armour
        {

            protected string m_name;
            protected int m_armour;
            protected ArmourType m_class;
            protected int m_value;
            protected Grade m_grade;

            public string ArmourNameCheck()
            {
                return m_name;
            }
            public int ArmourArmourCheck()
            {
                return m_armour;
            }

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

            new Cloth("낡은 천옷", 15, 1, Grade.Normal),
            new Cloth("천옷", 30, 1, Grade.Normal),
            new Cloth("두꺼운 천옷", 45, 1, Grade.Rare),

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

            new LightArmour("낡은 경갑 옷", 35, 1, Grade.Normal),
            new LightArmour("경갑 옷", 70, 1, Grade.Normal),
            new LightArmour("두꺼운 경갑 옷", 105, 1, Grade.Rare),

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

            public ClassType ClassTypeCheck()
            {
                return m_class;
            }

            public int ClassHealthPointCheck()
            {
                return m_hp;
            }

            public void PlayerGetDamage(int damage)
            {
                m_hp -= damage;
            }

        }



        public class Player
        {

            private string m_name;
            private Class m_class;
            private Weapon m_weapon;
            private Armour m_armour;
            private int m_level;

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

                if (m_class.ClassNameCheck() == "힐러")
                {
                    m_weapon = Cross.Crosses[0];
                    m_armour = Cloth.Clothes[0];
                }

                if (m_class.ClassNameCheck() == "토끼")
                {
                    m_weapon = Carrot.Carrots[0];
                    m_armour = LightArmour.LightArmours[0];
                }

            }

            public string PlayerNameCheck()
            {

                return m_name;

            }

            public string ClassNameCheckInPlayer()
            {

                return m_class.ClassNameCheck();

            }

            public ClassType ClassCheck()
            {
                return m_class.ClassTypeCheck();
            }

            public int PlayerLevelCheck()
            {

                return m_level;

            }

            public void PlayerInfo()
            {
                Console.WriteLine("=========================================================================");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("=========================================================================");
                Console.WriteLine($"|\t이름\t|\t\t\t{m_name}\t\t\t\t|");
                Console.WriteLine("|\t\t|\t\t\t\t\t\t\t|");
                Console.WriteLine("=========================================================================");
                Console.WriteLine($"|\t직업\t|\t\t\t{m_class.ClassNameCheck()}\t\t\t\t|");
                Console.WriteLine($"|\t레벨\t|\t\t\t{m_level}\t\t\t\t|");
                Console.WriteLine("=========================================================================");
                Console.WriteLine($"|\t무기\t|\t\t\t{m_weapon.WeaponNameCheck()}\t\t\t\t|");
                Console.WriteLine($"|\t공격력\t|\t\t\t{m_weapon.WeaponDamageCheck()}\t\t\t\t|");
                Console.WriteLine("=========================================================================");
                Console.WriteLine($"|\t방어구\t|\t\t\t{m_armour.ArmourNameCheck()}\t\t\t|");
                Console.WriteLine($"|\t방어력\t|\t\t\t{m_armour.ArmourArmourCheck()}\t\t\t\t|");
                Console.WriteLine("=========================================================================");
                Console.WriteLine("|\t\t\t\t\t아무키나 눌러 메인메뉴로\t|");
                Console.WriteLine("=========================================================================");

            }

            public void Walk(Map map)
            {

                int x = map.NowXPoint();
                int y = map.NowYPoint();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char walking = keyInfo.KeyChar;

                if (walking == 'W' || walking == 'w' || walking == 'w') y--;
                else if (walking == 'S' || walking == 's' || walking == 'ㄴ') y++;
                else if (walking == 'A' || walking == 'a' || walking == 'ㅁ') x--;
                else if (walking == 'D' || walking == 'd' || walking == 'ㅇ') x++;


                if (x < 25 && x >= 0 && y < 25 && y >= 0 && map.NextPlayerPoint(x, y) != 1)
                {
                    map.NextXPoint(x);
                    map.NextYPoint(y);

                }

            }

            public Weapon WeaponCheck()
            {
                return m_weapon;
            }

            public Armour ArmourCheck()
            {
                return m_armour;
            }

            public void PlayerGetDamage(int damage)
            {
                m_class.PlayerGetDamage(damage);
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

            public Monster(string name, int maxHp, int hp, int damage, int armour, int speed, int range)
            {
                m_name = name;
                m_maxHp = maxHp;
                m_hp = hp;
                m_damage = damage;
                m_armour = armour;
                m_speed = speed;
                m_range = range;
            }

            public void FightMonster(Player[] players)
            {

                bool isFirstMeet = true;

                while (m_hp > 0)
                {


                    for (int i = 0; i < 4; i++)
                    {
                        if (players[i] != null)
                        {
                            if (isFirstMeet)
                            {
                                Console.WriteLine($"몬스터 {m_name}이(가) 나타났다!!");
                                isFirstMeet = false;
                            }
                            else Console.WriteLine();

                            Console.WriteLine($"| 이름 : {m_name} | 체력 : {m_hp} | 공격력 : {m_damage} | 방어력 : {m_armour}|");

                            Console.WriteLine($"| 1. 공격한다 | 2. 스킬을 사용한다 | 3. 방어한다 | 4. 도망간다 |");

                            string choice = Console.ReadLine();

                            if (choice == "1")
                            {
                                m_hp -= players[i].WeaponCheck().Attack(m_armour, players[i]);

                            }
                            else if (choice == "2" || choice == "3")
                            {
                                Console.WriteLine("아직 미구현입니다!! ");
                            }
                            else if (choice == "4")
                            {
                                return;
                            }


                        }

                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (players[i] != null)
                        {
                            int finalDamage = m_damage - players[i].ArmourCheck().ArmourArmourCheck();
                            Console.WriteLine($"{m_name}의 공격!! {players[i]}는 {finalDamage}만큼의 데미지를 입었다!");
                            players[i].PlayerGetDamage(finalDamage);

                            break;

                        }

                    }

                }

            }

            public void Attack(Player players)
            {



            }


        }



        public class PlayerInfo
        {

            public static void PlayersInfo(Player[] players)
            {


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


            }


        }



        public class Map
        {
            private string m_mapName;
            private MapType m_type;
            private int m_mapCode;
            private int[,] m_mapData;
            private int m_playerPointX;
            private int m_playerPointY;

            public Map(string mapName, MapType mapType, int mapCode, int[,] mapData)
            {
                m_mapName = mapName;
                m_type = mapType;
                m_mapCode = mapCode;
                m_mapData = mapData;

            }

            public static List<Map> Maps = new List<Map>()
        {

            new Map("시작 마을", MapType.Town, 1,
                new int[25,25]
                {
                   {1,1,1,1,1,1,1,1,1,1,23,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                   {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,1,1,1 },
                   {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1 },
                   {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                   {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                   {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                   {1,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,0,1 },
                   {1,1,1,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,25,1,0,0,1 },
                   {1,1,1,0,0,0,0,0,5,0,0,0,0,0,3,0,0,0,0,0,25,1,0,0,1 },
                   {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1 },
                   {1,1,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                   {1,1,24,0,0,0,0,0,2,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,1 },
                   {1,1,1,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1 },
                   {1,1,1,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1 },
                   {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21 },
                   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1 },
                   {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,26,1,0,0,1 },
                   {1,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,26,1,0,1,1 },
                   {1,1,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,0,0,0,1,1,0,1,1 },
                   {1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                   {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
                   {1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1 },
                   {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,22,1,1,1,1,1,1,1,1,1 }

                }

            ),
            new Map("숲 1", MapType.Forest, 1,
                new int[25,25]
                {
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {21,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
                }

            ),

        };

            public int PlayerPoint()
            {
                return m_mapData[m_playerPointY, m_playerPointX];
            }

            public MapType MapTypeCheck()
            {
                return m_type;
            }

            public string MapNameCheck()
            {
                return m_mapName;
            }

            public int NextPlayerPoint(int x, int y)
            {
                return m_mapData[y, x];
            }

            public void NextXPoint(int x)
            {
                m_playerPointX = x;
            }

            public void NextYPoint(int y)
            {
                m_playerPointY = y;
            }

            public int NowXPoint()
            {
                return m_playerPointX;
            }

            public int NowYPoint()
            {
                return m_playerPointY;
            }

            public void ViewMap()
            {
                int x = m_playerPointX;
                int y = m_playerPointY;

                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine($"| 현재 위치 : {m_mapName}\t\t현재 좌표 : {m_playerPointX + 1}, {m_playerPointY + 1} |");
                Console.WriteLine("====================================================");


                for (int i = 0; i < 25; i++)
                {
                    Console.Write("|");

                    for (int j = 0; j < 25; j++)
                    {

                        if (i == y && j == x)
                        {
                            Console.Write("★ ");
                        }
                        else if (m_mapData[i, j] == 1)
                        {
                            Console.Write("■ ");
                        }
                        else if (m_mapData[i, j] > 1 && m_mapData[i, j] <= 10)
                        {
                            Console.Write("● ");
                        }
                        else if (m_mapData[i, j] > 10 && m_mapData[i, j] <= 20)
                        {
                            Console.Write("◆ ");
                        }
                        else if (m_mapData[i, j] > 20 && m_mapData[i, j] <= 24)
                        {
                            Console.Write("□ ");
                        }
                        else if (m_mapData[i, j] == 25)
                        {
                            Console.Write("☆ ");
                        }
                        else if (m_mapData[i, j] == 26)
                        {
                            Console.Write("○ ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }

                    }

                    Console.Write("|");

                    Console.WriteLine();

                }
                Console.WriteLine("====================================================");
            }

        }


        internal class LeeKiWoong
        {

            static void Main(string[] leeKiWoong)
            {

                MainMenu();

            }



            static int IsTrueFalseCheckinMenuOne(string text, Player[] players)
            {

                string choice;
                bool isMiss = false;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine($"|\t{text}\t\t|");

                    PlayerInfo.PlayersInfo(players);

                    Console.WriteLine($"|\t\t\t1 .예\t\t2. 아니오\t\t\t|");
                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|\t\t\t\t\t\t\t메인메뉴 - X\t|");
                    Console.WriteLine("=========================================================================");

                    if (isMiss)
                    {

                        Console.WriteLine("\n\n잘못 입력하였습니다!! 다시 확인해주세요!!");
                        isMiss = false;

                    }
                    choice = Console.ReadLine();


                    if (choice == "1") return 1;
                    else if (choice == "2") return 2;
                    else if (choice == "X" || choice == "x" || choice == "ㅌ") return 0;
                    else isMiss = true;

                }

            }

            static int IsTrueFalseCheckinMenuTwo(string text, Player[] players)
            {

                string choice;
                bool isMiss = false;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine($"|\t\t{text}\t\t|");

                    PlayerInfo.PlayersInfo(players);

                    Console.WriteLine($"|\t\t\t1 .예\t\t2. 아니오\t\t\t|");
                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|\t\t\t\t\t\t\t뒤로가기 - X\t|");
                    Console.WriteLine("=========================================================================");

                    if (isMiss)
                    {

                        Console.WriteLine("\n\n잘못 입력하였습니다!! 다시 확인해주세요!!");
                        isMiss = false;

                    }
                    choice = Console.ReadLine();


                    if (choice == "1") return 1;
                    else if (choice == "2") return 2;
                    else if (choice == "X" || choice == "x" || choice == "ㅌ") return 0;
                    else isMiss = true;

                }

            }



            static int MainMenu()
            {
                bool isMiss = false;
                bool isNoPlayer = false;
                bool goMain = false;
                Player[] players = new Player[4];
                Map myMap = Map.Maps[0];
                myMap.NextXPoint(12);
                myMap.NextYPoint(12);

                while (true)
                {

                    int playerCount = 0;

                    Console.Clear();

                    Console.WriteLine("1. 캐릭터 생성    2. 시작하기    3. 캐릭터 정보    4. 게임 종료");

                    if (isMiss) Console.WriteLine("\n잘못 입력하였습니다! 다시 확인해주세요.");
                    if (isNoPlayer) Console.WriteLine("캐릭터가 없습니다! 캐릭터를 만들어주세요!");
                    if (goMain) Console.WriteLine("메인화면으로 돌아갑니다.");

                    isMiss = false;
                    isNoPlayer = false;
                    goMain = false;

                    int.TryParse(Console.ReadLine(), out int choice);

                    for (int i = 0; i < 4; i++)
                    {
                        if (players[i] != null) playerCount++;
                    }

                    switch (choice)
                    {
                        case 1:
                            {
                                int isMakePlayers = IsTrueFalseCheckinMenuOne($"캐릭터를 생성하시겠습니까? 현재 캐릭터 수는 {playerCount}명 입니다.", players);

                                if (isMakePlayers == 1)
                                {
                                    MakePlayers(players);
                                    break;
                                }
                                else goMain = true;
                            }
                            break;
                        case 2:
                            {
                                int isPlayGame = IsTrueFalseCheckinMenuOne($"게임을 시작하시겠습니까? 현재 캐릭터 수는 {playerCount}명 입니다.", players);

                                if (isPlayGame == 1 && playerCount != 0)
                                {
                                    PlayGame(players, myMap);
                                    break;
                                }
                                else if (isPlayGame == 1 && playerCount == 0)
                                {
                                    isNoPlayer = true;
                                    break;
                                }

                                goMain = true;
                            }
                            break;
                        case 3:
                            {
                                PlayerInfoCheck(players);
                            }
                            break;
                        case 4: return 0;
                        default: isMiss = true; break;

                    }

                }

            }



            static void MakePlayers(Player[] players)
            {
                bool isMiss = false;
                bool isChoiceNumber = false;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|                  캐릭터를 생성할 슬롯을 선택해 주십시오.              |");

                    PlayerInfo.PlayersInfo(players);

                    Console.WriteLine("|\t\t\t\t\t\t\t메인메뉴 - X\t|");
                    Console.WriteLine("=========================================================================");

                    if (isMiss) Console.WriteLine("\n잘못 입력하였습니다! 다시 확인해주세요.");
                    isMiss = false;

                    string text = Console.ReadLine();

                    if (text == "X" || text == "x" || text == "ㅌ") return;

                    isChoiceNumber = int.TryParse(text, out int choice);

                    if (isChoiceNumber)
                    {

                        if (choice <= 4 && choice > 0)
                        {
                            string playerName = MakeName(players);
                            int playerClass = MakeClass(players);
                            players[choice - 1] = new Player(playerName, playerClass);
                            return;

                        }
                        else isMiss = true;
                    }
                    else isMiss = true;

                }

            }

            static string MakeName(Player[] players)
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|                  캐릭터를 생성할 슬롯을 선택해 주십시오.              |");

                    PlayerInfo.PlayersInfo(players);


                    Console.WriteLine("|\t\t\t캐릭터명을 입력해주세요.\t\t\t|");
                    Console.WriteLine("=========================================================================");

                    string playerName = Console.ReadLine();


                    int isPlayerName = IsTrueFalseCheckinMenuTwo($"\t캐릭터명이 {playerName}가 맞습니까?\t", players);

                    if (isPlayerName == 1)
                    {
                        return playerName;
                    }

                }

            }

            static int MakeClass(Player[] players)
            {
                bool isMiss = false;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine("|                  캐릭터를 생성할 슬롯을 선택해 주십시오.              |");

                    PlayerInfo.PlayersInfo(players);

                    bool isChoiceNumber = false;

                    Console.WriteLine("|\t\t\t원하시는 직업을 선택해주세요.\t\t\t|");
                    Console.WriteLine("|\t1. 전사     2. 궁수     3. 마법사     4. 도적     5. 점성술사\t|");
                    Console.WriteLine("|\t6. 시간술사 7. 공간술사 8. 부리미     9. 힐러     10. 토끼\t|");
                    Console.WriteLine("=========================================================================");


                    if (isMiss) Console.WriteLine("\n잘못 입력하였습니다! 다시 확인해주세요."); isMiss = false;

                    string playerClass = Console.ReadLine();

                    isChoiceNumber = int.TryParse(playerClass, out int choice);

                    if (isChoiceNumber)
                    {

                        switch (choice)
                        {

                            case 1:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t전사를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 2:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t궁수를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 3:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t마법사를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 4:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t도적을 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 5:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t점성술사를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 6:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t시간술사를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 7:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t공간술사를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 8:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t부리미를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 9:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t힐러를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            case 10:
                                {
                                    if (IsTrueFalseCheckinMenuTwo("\t토끼를 선택하시겠습니까?\t", players) == 1) return choice;
                                }
                                break;
                            default: isMiss = true; break;

                        }

                    }
                    else isMiss = true;

                }

            }



            static void PlayGame(Player[] players, Map mymap)
            {
                int playerNumber = 0;
                int playerCount = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (players[i] != null)
                    {
                        playerCount++;
                        playerNumber = i;
                    }
                }

                if (playerCount == 0) return;

                while (true)
                {
                    mymap.ViewMap();
                    players[playerNumber].Walk(mymap);

                    if (mymap.PlayerPoint() == 11 && mymap.MapTypeCheck() == MapType.Forest)
                    {
                        Monster slime = new Monster("슬라임", 300, 300, 100, 25, 100, 25);
                        slime.FightMonster(players);

                        Console.WriteLine("슬라임을 처치했다!! +200Gold ,  +100Exp ( 미구현 ) ");
                        Console.Read();

                    }

                    if (mymap.PlayerPoint() == 21 && mymap.MapNameCheck() == "시작 마을")
                    {
                        mymap = Map.Maps[1];
                        mymap.NextXPoint(1);
                        mymap.NextYPoint(16);
                    }

                    if (mymap.PlayerPoint() == 21 && mymap.MapNameCheck() == "숲 1")
                    {
                        mymap = Map.Maps[0];
                        mymap.NextXPoint(23);
                        mymap.NextYPoint(15);
                    }

                }

            }




            static void PlayerInfoCheck(Player[] players)
            {

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("=========================================================================");
                    Console.WriteLine($"|\t\t확인할 캐릭터의 캐릭터 슬롯을 선택해주십시오.\t\t|");

                    PlayerInfo.PlayersInfo(players);

                    Console.WriteLine("|\t\t\t\t\t\t\t메인메뉴 - X\t|");
                    Console.WriteLine("=========================================================================");



                    bool isChoiceNumber = int.TryParse(Console.ReadLine(), out int choice);

                    if (isChoiceNumber && choice < 5 && choice >= 1 && players[choice - 1] != null)
                    {
                        players[choice - 1].PlayerInfo();

                        Console.ReadKey();
                        return;

                    }
                    else return;

                }

            }

        }
    }

}
