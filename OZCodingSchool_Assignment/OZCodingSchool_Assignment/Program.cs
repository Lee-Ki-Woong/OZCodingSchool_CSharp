using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OZCodingSchool_Assignment
{
    internal interface AttackAble
    {
        int Max_Hp { get; }
        int Hp {  get; }
        int Damage {  get; }
        int Armour { get; }

        void TakeDamage(int damage);
    }

    internal enum EntityType
    {
        None = 0,
        Player = 1,
        NPC = 2,
        Monster = 3,
    }

    internal delegate void AttackAction(string name, int hp, int damage);

    internal class Entity
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public EntityType MyEntityType { get; protected set; }



        public Entity(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            MyEntityType = EntityType.Player;
        }
    }


    internal class Player : Entity, AttackAble
    {
        public int Max_Hp { get; private set; }
        public int Hp { get; private set; }
        public int Damage { get; private set; }
        public int Armour { get; private set; }

        public event AttackAction OnDamaged;

        public event Action<string, string, int, int> OnDamagedTwo;

        public Player(string  id, string name, string description, int max_Hp, int hp, int damage, int armour) : base (id, name,  description)
        {
            Max_Hp = max_Hp;
            Hp = hp;
            Damage = damage;
            Armour = armour;
            MyEntityType = EntityType.Player;
        }

        public void TakeDamage(int damage)
        {
            int finalDamage = damage - Armour;

            if (finalDamage <= 0) finalDamage = 0;

            Hp -= finalDamage;

            OnDamaged?.Invoke(Name, Hp, finalDamage);
        }

        public void TakeDamage(int damage, string name)
        {
            int finalDamage = damage - Armour;

            if (finalDamage <= 0) finalDamage = 0;

            Hp -= finalDamage;

            OnDamagedTwo?.Invoke(name, Name, Hp, finalDamage);
        }
    }

    internal class Monster : Entity, AttackAble
    {
        public int Max_Hp { get; private set; }
        public int Hp { get; private set; }
        public int Damage { get; private set; }
        public int Armour { get; private set; }

        public event Action<bool> OnDamaged;

        public event Func<string, int, int, bool> OnDamagedTwo;


        public Monster(string id, string name, string description, int max_Hp, int hp, int damage, int armonur) : base(id, name, description)
        {
            Max_Hp = max_Hp;
            Hp = hp;
            Damage = damage;
            Armour = armonur;
            MyEntityType = EntityType.Monster;
        }

        public void TakeDamage(int damage)
        {
            int finalDamage = damage - Armour;

            if (finalDamage <= 0) finalDamage = 0;

            Hp -= finalDamage;

            if(OnDamagedTwo != null)
            {
                bool isDamaged = OnDamagedTwo.Invoke(Name, Hp, finalDamage);
                OnDamaged?.Invoke(isDamaged);
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
                if(m_instance == null)
                {
                    m_instance = new UIManager();
                }
                return m_instance;
            }
        }

        public void AttackUI(string name, int hp, int damage)
        {
            Console.WriteLine($"{name}은 {damage}의 피해를 받아 체력이 {hp}만큼 남았다!!");
        }

        public bool AttackUITwo(string name, int hp, int damage)
        {
            Console.WriteLine($"{name}은 {damage}의 피해를 받아 체력이 {hp}만큼 남았다!!");
            return true;
        }

        public void AttackUIThree(string attackerName, string defenderName, int hp, int damage)
        {
            Console.WriteLine($"{defenderName}은 {attackerName}에게 {damage}의 피해를 받아 체력이 {hp}만큼 남았다!!");
        }

        public void Damaged(bool isTrue)
        {
            if(isTrue)
            {
                Console.WriteLine("데미지를 받았구나!");
            }
        }

        

    }

    internal class Program
    {
        public static void RefreshAttackUI(string name, int hp, int damage)
        {
            UIManager.Instance.AttackUI(name, hp, damage);
            UIManager.Instance.AttackUITwo(name, hp, damage);
        }

        static void Main(string[] leeKiWoong)
        {
            Player kiwoong = new Player("Entity_Player_01", "기웅", "사람이다.", 500, 500, 50, 25);
            Monster slime = new Monster("Entity_Monster_Slime_Normal_01", "슬라임", "평범한 슬라임이다", 100, 100, 50, 0);


            slime.OnDamagedTwo += (UIManager.Instance.AttackUITwo);
            slime.OnDamaged += (UIManager.Instance.Damaged);

            slime.TakeDamage(kiwoong.Damage);


            kiwoong.OnDamaged += RefreshAttackUI;

            kiwoong.TakeDamage(slime.Damage);

            kiwoong.OnDamaged -= RefreshAttackUI;
            kiwoong.OnDamagedTwo += (UIManager.Instance.AttackUIThree);

            kiwoong.TakeDamage(slime.Damage, slime.Name);


        }
    }

}