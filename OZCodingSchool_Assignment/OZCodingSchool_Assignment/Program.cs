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
    public interface DamageAble
    {

    }


    internal class Cocoa : DamageAble
    {
        public string Name {  get; private set; }
        public int Damage { get; private set; }

        public event Action<string, int> OnDamaged;

        public Cocoa(string name ,int damage)
        {
            Name = name;
            Damage = damage;
        }

        public void BindCocoaDamagedEvent(Action<string, int> damagedCallback)
        {
            OnDamaged += damagedCallback;
        }

        public void CocoaDamaged(int damaged)
        {
            if (OnDamaged != null)
            {
                OnDamaged.Invoke(Name, damaged);
            }
        }
    }

    internal class SuperStone
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }

        public event Action<string, int> OnDamaged;

        public SuperStone(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public void BindSuperStoneDamagedEvent(Action<string, int> damagedCallback)
        {
            OnDamaged += damagedCallback;
        }

        public void SuperStoneDamaged(int damaged)
        {
            if (OnDamaged != null)
            {
                OnDamaged.Invoke(Name, damaged);
            }
        }
    }

    internal class Damaged
    {
        public void EntityDamaged<T>(string name, int damage) where T : DamageAble
        {
            Console.WriteLine($"{name}은 {damage}만큼의 데미지를 받았다!!");
        }

        public void EntityDamaged(string name, int damage)
        {
            Console.WriteLine($"{name}은 데미지를 받지 않는다!! {damage}만큼의 데미지가 무시되었다!!");
        }
    }

    internal class Program
    {
        static void Main(string[] leeKiWoong)
        {
            Cocoa goodCocoa = new Cocoa("코코아", 10);
            SuperStone BadSuperStone = new SuperStone("무적돌", 500);

            // 뭔가 static 클래스와 매서드로 있어야 될 거 같은 클래스긴 한데,
            // 이벤트 구조를 잘 쓰기 위해서 = static이면 델리게이트로 접근하는 방식이 의미가 없으니까 일부러 일반 클래스로 만들었습니다.
            Damaged damaged = new Damaged();

            goodCocoa.BindCocoaDamagedEvent(damaged.EntityDamaged<Cocoa>);
            goodCocoa.CocoaDamaged(BadSuperStone.Damage);


            //주강사님의 포크를 보고 미리 예습한 제네릭 사용해보기!
            //SuperStone은 DamageAble을 상속받지 않기 때문에,  Entity_Damaged<T> 제네릭 메서드를 사용할 수 없다!
            //BadSuperStone.Bind_SuperStone_Damaged_Event(damaged.Entity_Damaged<SuperStone>);

            BadSuperStone.BindSuperStoneDamagedEvent(damaged.EntityDamaged);
            BadSuperStone.SuperStoneDamaged(goodCocoa.Damage);


        }
    }
}