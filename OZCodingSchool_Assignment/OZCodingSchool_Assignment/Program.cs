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
    public interface IDamageAble
    {
        string Name { get; }
        int Damage { get; }
    }

    internal class Entity
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Entity(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        
    }

    internal class Cocoa : Entity, IDamageAble
    {
        public event Action<string, int> OnDamaged;

        public Cocoa(string name ,int damage) : base (name, damage) { }

        public void BindDamagedEvent(Action<string, int> damaged)
        {
            OnDamaged += damaged;
        }

        public void CocoaDamaged(Func<bool> damaged, Action NoDamagedCallback)
        {
            bool isChoice = damaged();
            
            if(isChoice)
            {
                OnDamaged?.Invoke(Name, Damage);
            }
            else
            {
                NoDamagedCallback();
            }
        }
    }

    internal class SuperStone : Entity
    {
        public event Action<string, int> OnDamaged;

        public SuperStone(string name, int damage) : base (name, damage) { }

        public void BindDamagedEvent(Action<string, int> damaged)
        {
            OnDamaged += damaged;
        }
        public void SuperStoneDamaged(Func<bool> damaged, Action NoDamagedCallback)
        {
            bool isChoice = damaged();

            if (isChoice)
            {
                OnDamaged?.Invoke(Name, Damage);
            }
            else
            {
                NoDamagedCallback();
            }
        }
    }

    internal class Damaged
    {
        private static Damaged m_instance;
        private Damaged() { }
        public static Damaged Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new Damaged();
                }
                return m_instance;
            }
        }


        public bool CheckAttack()
        {
            Console.WriteLine("공격을 하시겠습니까?");
            string choice = Console.ReadLine();

            choice = choice.ToLower();

            if (choice == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EntityDamaged<T>(string name, int damage) where T : IDamageAble
        {
            Console.WriteLine($"{name}은 {damage}만큼의 데미지를 받았다!!");
        }

        public void EntityDamaged(string name, int damage)
        {
            Console.WriteLine($"{name}은 데미지를 받지 않는다!! {damage}만큼의 데미지가 무시되었다!!");
        }

        public void EntityNoDamaged()
        {
            Console.WriteLine("데미지를 받지 않았다!!");
        }
    }

    internal class Test
    {
        public void Ramda()
        {
            Action<string> asdf = (string aaa) => { Console.WriteLine("야호"); };
        }
    
    }

    internal class Program
    {
        static void Main(string[] leeKiWoong)
        {
            Cocoa goodCocoa = new Cocoa("코코아", 10);
            SuperStone BadSuperStone = new SuperStone("무적돌", 500);


            goodCocoa.BindDamagedEvent(Damaged.Instance.EntityDamaged<Cocoa>);
            BadSuperStone.BindDamagedEvent(Damaged.Instance.EntityDamaged);


            goodCocoa.CocoaDamaged(Damaged.Instance.CheckAttack, Damaged.Instance.EntityNoDamaged);
            BadSuperStone.SuperStoneDamaged(Damaged.Instance.CheckAttack, Damaged.Instance.EntityNoDamaged);



        }
    }
}