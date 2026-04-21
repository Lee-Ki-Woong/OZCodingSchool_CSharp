using System;
using System.Collections.Generic;

namespace OZCodingSchool_Assignment
{
    internal enum MenuType : byte
    {
        None = 0,
        MainMenu = 1,
        BattleMonster = 2,
        MakePlayer = 3,
        PlayerInfo = 4,
        ExitGame = 5,
    }

    internal enum ChoiceType : byte
    {
        None = 0,
        True = 1,
        False = 2,
    }

    internal interface IBattleAble
    {
        int MaxHp { get; }
        int Hp { get; }
        int Damage { get; }

        void Damaged(string name, int damage);
    }

    internal class Entity
    {
        public string Name { get; protected set; }
        public int MaxHp { get; protected set; }
        public int Hp { get; protected set; }
        public int Damage { get; protected set; }


        public Entity(string name, int damage, int hp, int maxHp)
        {
            Name = name;
            Damage = damage;
            MaxHp = maxHp;
            Hp = hp;
        }
        public virtual void Damaged(string name, int damage)
        {
            Hp -= damage;
            Console.WriteLine($"{Name}은(는) {name}에게 {damage}만큼의 데미지를 받았다!!");
            Console.WriteLine($"남은 체력 = {Hp}");
        }

    }

    internal class Player : Entity, IBattleAble
    {
        public int Exp { get; private set; }
        public int Level { get; private set; }
        public int Gold { get; private set; }

        public Player() : base("", 50, 500, 500)
        {
            Name = MakePlayerName();
            Level = 1;
            Exp = 0;
            Gold = 0;
        }

        public void PlayerHeal()
        {
            Hp = MaxHp;
        }

        public string MakePlayerName()
        {
            bool isMiss = false;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("원하는 닉네임을 적어주세요");

                if (isMiss)
                {
                    Console.WriteLine("다시 입력하여주세요.");
                }

                string name = Console.ReadLine();

                Console.Clear();
                Console.WriteLine($"{name}이 맞습니까??");
                Console.WriteLine($"1. 예 // 2. 아니오");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    return name;
                }
                else
                {
                    isMiss = true;
                }
            }
        }

        public override void Damaged(string name, int damage)
        {
            Hp -= damage;
            Console.WriteLine($"플레이어 {Name}은(는) {name}에게 {damage}만큼의 데미지를 받았다!!");
            Console.WriteLine($"남은 체력 = {Hp}");
        }

        public void GainExp(int exp)
        {
            Exp += exp;
            while(Exp >= 100)
            {
                Level++;
                MaxHp += 100;
                Damage += 20;
                Exp -= 100;
                Console.WriteLine($"{Name}의 레벨이 상승했다!! Lv. {Level}이 되었다!!");
                Console.WriteLine($"최대 체력이 100 증가해서 {MaxHp}가 되었다!! 공격력이 20 증가해서 {Damage}가 되었다!!");
            }
        }

        public void ShowPlayerInfo()
        {
            Console.Clear();
            Console.WriteLine($"이름 : {Name}");
            Console.WriteLine($"레벨 : {Level}");
            Console.WriteLine($"경험치 : {Exp}");
            Console.WriteLine($"체력 : {Hp} / {MaxHp}");
            Console.WriteLine($"공격력 : {Damage}");
            Console.WriteLine($"골드 : {Gold}");
            Console.ReadKey();
        }
    }

    internal class Monster : Entity, IBattleAble
    {
        public Monster(string name, int damage, int hp, int maxHp) : base(name, damage, hp, maxHp) { }
        public override void Damaged(string name, int damage)
        {
            Hp -= damage;
            Console.WriteLine($"몬스터 {Name}은(는) {name}에게 {damage}만큼의 데미지를 받았다!!");
            Console.WriteLine($"남은 체력 = {Hp}");
        }

        public void MonsterHeal()
        {
            Hp = MaxHp;
        }
    }

    internal class BattleManager
    {
        private static BattleManager m_instance;
        private Dictionary<string, Monster> m_monsterData = new Dictionary<string, Monster>()
        {
            { "슬라임", new Monster("슬라임", 30, 200, 200) },
            { "늑대", new Monster("늑대", 50, 500, 500) },
            { "트롤", new Monster("트롤", 100, 1000, 1000) },
            { "오크", new Monster("오크", 150, 2000, 2000) },
            { "오우거",  new Monster("오우거", 250, 3000, 3000) },
            { "골렘", new Monster("골렘", 400, 5000, 5000) },
            { "발록", new Monster("발록", 700, 10000, 10000) },
        };
        private Predicate<string> m_choice;
        private BattleManager()
        {
            UIData uiData = new UIData();
            m_choice = uiData.ClearTextAndChoice;
        }
        public static BattleManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new BattleManager();
                }
                return m_instance;
            }
        }



        public string ChoiceMonster()
        {
            bool isMiss = false;
            string monsterName = null;

            while (true)
            {
                Console.WriteLine("전투를 원하시는 몬스터를 선택하십시오.");
                Console.WriteLine("1. 슬라임 // 2. 늑대 // 3. 트롤 // 4. 오크");
                Console.Write("5. 오우거 // 6. 골렘");

                if (m_monsterData.ContainsKey("발록"))
                {
                    Console.WriteLine(" // 7. 발록");
                }
                else
                {
                    Console.WriteLine();
                }


                if (isMiss)
                {
                    Console.WriteLine("잘못 선택하였습니다!! 다시 확인해주세요");
                    isMiss = false;
                }

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            monsterName = "슬라임";
                            return monsterName;
                        }
                    case "2":
                        {
                            monsterName = "늑대";
                            return monsterName;
                        }
                    case "3":
                        {
                            monsterName = "트롤";
                            return monsterName;
                        }
                    case "4":
                        {
                            monsterName = "오크";
                            return monsterName;
                        }
                    case "5":
                        {
                            monsterName = "오우거";
                            return monsterName;
                        }
                    case "6":
                        {
                            monsterName = "골렘";
                            return monsterName;
                        }
                    case "7":
                        {
                            if (m_monsterData.ContainsKey("발록"))
                            {
                                monsterName = "발록";
                                return monsterName;
                            }
                            else
                            {
                                isMiss = true;
                            }
                            continue;
                        }
                    default:
                        {
                            isMiss = true;
                        }
                        continue;
                }
            }
        }

        public Player StartBattle(Player player)
        {
            Monster battleMonster = null;
            bool isMiss = false;

            while (true)
            {
                bool isChoiceMonster = m_monsterData.TryGetValue(ChoiceMonster(), out Monster monster);

                if (isChoiceMonster == false || monster == null)
                {
                    Console.Clear();
                    Console.WriteLine("몬스터가 없습니다!! 메인 화면으로 돌아갑니다.");
                    Console.ReadKey();
                    return player;
                }

                bool? choiceOne = m_choice?.Invoke($"선택한 몬스터가 {monster.Name}이 맞습니까??" +
                        $"\n몬스터의 체력 : {monster.Hp}" +
                        $"\n몬스터의 공격력: {monster.Damage}");

                if (choiceOne == true)
                {
                    battleMonster = monster;
                    break;
                }
                else continue;
            }

            while(player.Hp > 0 && battleMonster.Hp > 0)
            {
                Console.Clear();
                Console.WriteLine($"몬스터 - {battleMonster.Name} - ");
                Console.WriteLine($"Hp : {battleMonster.Hp} / {battleMonster.MaxHp}");
                Console.WriteLine($"공격력 : {battleMonster.Damage}");
                Console.WriteLine("1. 공격하기 // 2. 도망가기");
                
                if(isMiss)
                {
                    Console.WriteLine("잘못 입력하였습니다!");
                    isMiss = false;
                }
                string choice = Console.ReadLine();

                if(choice == "1")
                {
                    battleMonster.Damaged(player.Name, player.Damage);
                    Console.ReadKey();

                    if(battleMonster.Hp <= 0 && battleMonster.Name == "발록")
                    {

                        Console.WriteLine($"당신은 마침내 {battleMonster.Name}을 무찔렀다!!");
                        Console.WriteLine($"이 소식은 왕국 전역에 퍼져나갔으며, 왕국의 사람들은 당신의 이름인 {player.Name}를 크게 연호하였습니다!!");
                        Console.WriteLine("당신의 영웅담은 후손들에 의해 먼 미래까지 계승될 것입니다!!");
                        Console.WriteLine($"축하합니다!! {player.Name}!!");
                        Console.WriteLine("GOOD END");
                        m_monsterData.Remove("발록");
                        Console.ReadKey();
                        player.PlayerHeal();

                        return player;
                    }

                    if (battleMonster.Hp <= 0)
                    {
                        Console.WriteLine($"당신은 몬스터 {battleMonster.Name}에게 이겼다!! 경험치를 {battleMonster.MaxHp / 5}만큼 얻었다!!");
                        player.GainExp(battleMonster.MaxHp / 5);
                        player.PlayerHeal();
                        battleMonster.MonsterHeal();
                        Console.ReadKey();

                        return player;
                    }
                }
                else if(choice == "2")
                {
                    Console.WriteLine($"당신은 몬스터 {battleMonster.Name}에게서 도망쳤다!!");
                    Console.ReadKey();
                    return player;
                }
                else
                {
                    isMiss = true;
                    continue;
                }

                player.Damaged(battleMonster.Name, battleMonster.Damage);

                if (player.Hp <= 0)
                {
                    Console.WriteLine($"당신은 몬스터 {battleMonster.Name}에게 패배했다. 눈 앞이 깜깜해진다...");
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine($"\n\n{player.Name}은(는) 몬스터에게 패배했지만, 새로운 용사가 모험을 기다리는 것 같다!! 새로운 용사를 만들어 발록을 잡고 게임을 승리해보자!!");
                    player = null;
                    Console.ReadKey();
                    return player;
                }

                Console.ReadKey();
            }

            Console.WriteLine("에러부분");
            Console.ReadKey();
            return player;
        }
    }

    internal class GameManager
    {
        private static GameManager m_instance;
        private MenuType m_munuType;
        public Player MyPlayer { get; private set; } = null;
        private GameManager()
        {
            m_munuType = MenuType.MainMenu;
        }

        public static GameManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new GameManager();
                }
                return m_instance;
            }
        }

        public void GameStart()
        {
            Console.Clear();

            while (true)
            {
                switch (m_munuType)
                {
                    case MenuType.MainMenu:
                        {
                            Console.WriteLine("1. 전투 시작 / 2. 캐릭터 생성 / 3. 내 정보 / 4. 게임 종료");
                            m_munuType = InputManager.Instance.GetMenuType();
                        }
                        break;
                    case MenuType.BattleMonster:
                        {
                            if (MyPlayer != null)
                            {
                                MyPlayer = BattleManager.Instance.StartBattle(MyPlayer);
                            }
                            else PlayerIsNull();
                            m_munuType = MenuType.MainMenu;
                        }
                        break;
                    case MenuType.MakePlayer:
                        {
                            MyPlayer = new Player();
                            m_munuType = MenuType.MainMenu;
                        }
                        break;
                    case MenuType.PlayerInfo:
                        {
                            if (MyPlayer != null)
                            {
                                MyPlayer?.ShowPlayerInfo();
                            }
                            else PlayerIsNull();

                            m_munuType = MenuType.MainMenu;
                        }
                        break;
                    case MenuType.ExitGame:
                        {
                            return;
                        }
                }
            }
        }

        public void PlayerIsNull()
        {
            Console.WriteLine("플레이어가 없습니다!! 플레이어를 먼저 생성해주세요!!");
        }
    }

    internal class UIData
    {
        public bool ClearTextAndChoice(string text)
        {
            bool isMiss = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(text);
                Console.WriteLine("예 - Y // 아니오 - N");

                if (isMiss)
                {
                    Console.WriteLine("잘못 입력하였습니다!!");
                    isMiss = false;
                }
                string choice = Console.ReadLine();
                choice = choice.ToLower();

                if (choice == "y")
                {
                    return true;
                }
                else if (choice == "n")
                {
                    return false;
                }
                else
                {
                    isMiss = true;
                }
            }
        }
    
    }

    internal class InputManager
    {
        private static InputManager m_instance;
        private InputManager() { }
        public static InputManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new InputManager();
                }
                return m_instance;
            }
        }

        public MenuType GetMenuType()
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        return MenuType.BattleMonster;
                    }
                case "2":
                    {
                        return MenuType.MakePlayer;
                    }
                case "3":
                    {
                        return MenuType.PlayerInfo;
                    }
                case "4":
                    {
                        return MenuType.ExitGame;
                    }
                default:
                    {
                        return MenuType.MainMenu;
                    }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] leeKiWoong)
        {
            GameManager.Instance.GameStart();
        }
    }
}