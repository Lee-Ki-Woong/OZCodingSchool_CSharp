using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OZCodingSchool_Assignment
{
    internal class Entity
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Entity(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
        public virtual void Damaged(string name, int damage)
        {
            Console.WriteLine($"{Name}은 {name}에게 {damage}만큼의 데미지를 받았다!!");
        }

    }

    internal class Cocoa : Entity
    {
        public Cocoa(string name ,int damage) : base (name, damage) { }

        public override void Damaged(string name, int damage)
        {
            base.Damaged(name, damage);
        }
        
    }

    internal class SuperStone : Entity
    {
        public SuperStone(string name, int damage) : base (name, damage) { }
        public override void Damaged(string name, int damage)
        {
            Console.WriteLine($"{Name}은 데미지를 받지 않는다!! {name}의 {damage}만큼의 데미지가 무시되었다!!");
        }
    }

    internal class DamagedManager
    {
        private static DamagedManager m_instance;
        private DamagedManager() { }
        public static DamagedManager Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new DamagedManager();
                }
                return m_instance;
            }
        }

        public void Attack(string attacker, int damage, Action<string, int> defenderAction)
        {
            Console.WriteLine("공격을 하시겠습니까?");
            Console.WriteLine("예 = Y / 아니오 = 그 외");
            string choice = Console.ReadLine();

            choice = choice.ToLower();

            if (choice == "y")
            {
                defenderAction?.Invoke(attacker, damage);
                return;
            }

            EntityNoDamaged();
            
        }

        public void EntityNoDamaged()
        {
            Console.WriteLine("데미지를 받지 않았다!!");
        }
    }

    internal class Program
    {
        static void Main(string[] leeKiWoong)
        {
            Cocoa goodCocoa = new Cocoa("코코아", 10);
            SuperStone BadSuperStone = new SuperStone("무적돌", 500);

            DamagedManager.Instance.Attack(BadSuperStone.Name, BadSuperStone.Damage, goodCocoa.Damaged);
            DamagedManager.Instance.Attack(goodCocoa.Name, goodCocoa.Damage, BadSuperStone.Damaged);



        }
    }
}