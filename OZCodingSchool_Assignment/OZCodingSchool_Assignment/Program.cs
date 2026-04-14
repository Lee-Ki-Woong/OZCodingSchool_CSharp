using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal class LeeKiWoong
    {
        internal interface BattleAble
        {
            int Hp { get; }
            int ATK { get; }
        }

        internal interface PlayAble
        {

        }

        internal enum EntityType
        {
            None = 0,
            Player = 1,
            NPC = 2,
            Monster = 3,
        }



        internal class Entity : BattleAble
        {
            public string Name { get; private set; }
            public int Hp { get; private set; }
            public int ATK { get; private set; }
            public EntityType MyType { get; protected set; }

            public Entity(string name, int hp, int atk)
            {
                Name = name;
                Hp = hp;
                ATK = atk;
                MyType = EntityType.None;
            }

            public virtual void Attack(Entity entity)
            {
                UIManager.Instance.ViewingText($"{Name}은 {entity.Name}에게 {ATK}의 데미지를 입혔다!!");
                entity.TakeDamage(ATK);
            }

            public virtual void TakeDamage(int damage)
            {
                UIManager.Instance.ViewingText($"{Name}은 {damage}의 데미지를 받았다!!");
                Hp -= damage;

                if (Hp < 0)
                {
                    Hp = 0;
                }

                UIManager.Instance.ViewingText($"{Name}의 남은 체력 : {Hp}");
            }
        }

        internal class Player : Entity, PlayAble
        {
            public Player(string name, int hp, int atk) : base(name, hp, atk)
            {
                MyType = EntityType.Player;
            }

            public override void Attack(Entity entity)
            {
                UIManager.Instance.ViewingText($"플레이어 {Name}은 {entity.Name}에게 {ATK}의 데미지를 입혔다!!");
                entity.TakeDamage(ATK);
            }

            public override void TakeDamage(int damage)
            {
                base.TakeDamage(damage);
            }
        }

        internal class Monster : Entity
        {
            public Monster(string name, int hp, int atk) : base(name, hp, atk)
            {
                MyType = EntityType.Monster;
            }

            public override void Attack(Entity entity)
            {
                UIManager.Instance.ViewingText($"몬스터 {Name}은 {entity.Name}에게 {ATK}의 데미지를 입혔다!!");
                entity.TakeDamage(ATK);
            }

            public override void TakeDamage(int damage)
            {
                base.TakeDamage(damage);
            }
        }



        internal class BattleManager
        {
            private static BattleManager m_instance;
            private BattleManager() { }

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



            public void ReadyToBattle(Entity attacker, Entity defender)
            {
                UIManager.Instance.ViewingText($"{attacker.Name}가 {defender.Name}에게 싸움을 걸었다!");

                while (attacker.Hp > 0 && defender.Hp > 0)
                {
                    if (myTurn(attacker, defender)) return;

                    if (defender.Hp <= 0)
                    {
                        Defeat(defender.Name);
                        return;
                    }

                    if (myTurn(defender, attacker)) return;

                    if (attacker.Hp <= 0)
                    {
                        Defeat(attacker.Name);
                        return;
                    }
                }
            }

            public bool myTurn(Entity attacker, Entity defender)
            {
                if (attacker is PlayAble)
                {
                    UIManager.Instance.ViewingText($"{attacker.Name}이 취할 행동을 선택하여 주십시오", "1. 공격하기  그외. 도망가기");

                    int choice = InputManager.Instance.SelectNumberInBattle(Console.ReadLine());

                    if (choice != 1)
                    {
                        UIManager.Instance.ViewingText($"{attacker.Name}은 재빠르게 도망갔습니다!");
                        return true;
                    }
                }
                attacker.Attack(defender);
                return false;

            }

            public bool Defeat(string name)
            {
                UIManager.Instance.ViewingText($"{name}는 패배했습니다!");
                return true;
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

            public int SelectNumberInBattle(string number)
            {
                switch (number)
                {
                    case "1":
                        {
                            return 1;
                        }
                    case "2":
                        {
                            return 2;
                        }
                    default:
                        {
                            return 0;
                        }
                }
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
                Player kiwoong = new Player("기웅", 500, 50);
                Monster slime = new Monster("슬라임", 100, 5);

                BattleManager.Instance.ReadyToBattle(kiwoong, slime);

            }
        }
    }
}