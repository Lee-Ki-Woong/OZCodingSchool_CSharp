using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    internal enum ItemGrade
    {
        None = 0,
        Normal = 1,
        Rare = 2,
        Unique = 3,
        Epic = 4,
    }

    internal enum ItemType
    {
        None = 0,
        Weapon = 1,
        Armour = 2,
        ETC = 3,
    }

    internal enum WeaponType
    {
        None = 0,
        Sword = 1,
        Bow = 2,
        Wand = 3,
    }

    internal enum ArmourType
    {
        None = 0,
        LightArmour = 1,
        Leather = 2,
        Cloth = 3,
    }

    internal enum MenuType
    {
        None = 0,
        MainMenu = 1,
        ItemCategory = 2,
        WeaponAttack = 3,
        MyInventory = 4,
        Exit = 5,
        WeaponCategory = 6,
        ArmourCategory = 7,
        ETCCategory = 8,
        SwordCategory = 9,
        BowCategory = 10,
    }




    internal class Item
    {
        public string m_name { get; protected set; }
        public ItemGrade m_ItemGrade { get; protected set; }
        public string m_itemInfo { get; protected set; }

        public Item(string name, ItemGrade ItemGrade, string itemInfo)
        {
            m_name = name;
            m_ItemGrade = ItemGrade;
            m_itemInfo = itemInfo;
        }


    }



    internal class EquipItem : Item
    {
        public EquipItem(string name, ItemGrade ItemGrade, string itemInfo) : base(name, ItemGrade, itemInfo)
        {

        }

    }



    internal class Weapon : EquipItem
    {
        public WeaponType m_weaponType { get; protected set; }
        public int m_attackDamage { get; protected set; }

        public Weapon(string name, ItemGrade ItemGrade, string itemInfo, int attackDamage) : base(name, ItemGrade, itemInfo)
        {
            m_weaponType = WeaponType.None;
            m_attackDamage = attackDamage;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{m_name}으로 공격!! {m_attackDamage}만큼의 피해를 입혔다!");
        }

    }

    internal class Sword : Weapon
    {
        public Sword(string name, ItemGrade ItemGrade, string itemInfo, int attackDamage) : base(name, ItemGrade, itemInfo, attackDamage)
        {
            m_weaponType = WeaponType.Sword;
        }

        public override void Attack()
        {
            Console.WriteLine($"{m_name}으로 베기 공격!! {m_attackDamage}만큼의 피해를 입혔다!");
        }
    }

    internal class Bow : Weapon
    {
        public Bow(string name, ItemGrade ItemGrade, string itemInfo, int attackDamage) : base(name, ItemGrade, itemInfo, attackDamage)
        {
            m_weaponType = WeaponType.Bow;
        }
        public override void Attack()
        {
            Console.WriteLine($"{m_name}으로 화살 발사!! {m_attackDamage}만큼의 피해를 입혔다!");
        }
    }



    internal class Armour : EquipItem
    {
        public ArmourType m_armourType { get; protected set; }
        public int m_armourPoint { get; protected set; }

        public Armour(string name, ItemGrade ItemGrade, string itemInfo, int armourPoint) : base(name, ItemGrade, itemInfo)
        {
            m_armourType = ArmourType.None;
            m_armourPoint = armourPoint;
        }

    }

    internal class LightArmour : Armour
    {
        public LightArmour(string name, ItemGrade ItemGrade, int armourPoint, string itemInfo) : base(name, ItemGrade, itemInfo, armourPoint)
        {
            m_armourType = ArmourType.LightArmour;
        }

    }

    internal class Leather : Armour
    {
        public Leather(string name, ItemGrade ItemGrade, int armourPoint, string itemInfo) : base(name, ItemGrade, itemInfo, armourPoint)
        {
            m_armourType = ArmourType.Leather;
        }

    }

    internal class Cloth : Armour
    {
        public Cloth(string name, ItemGrade ItemGrade, int armourPoint, string itemInfo) : base(name, ItemGrade, itemInfo, armourPoint)
        {
            m_armourType = ArmourType.Cloth;
        }

    }



    internal class ETC : Item
    {
        internal ETC(string name, ItemGrade ItemGrade, string itemInfo) : base(name, ItemGrade, itemInfo)
        {

        }

    }



    internal class ItemList
    {
        public static List<Item> m_swordList = new List<Item>
        {
            new Sword("검", ItemGrade.Normal, "평범한 검이다.", 50),
            new Sword("강철 검", ItemGrade.Rare, "강철로 만들어진 검이다.", 100),
            new Sword("장인이 만든 검", ItemGrade.Unique, "한 장인이 삼일 밤낮을 두드려 만들어낸 검이다.", 200),
        };

        public static List<Item> m_bowList = new List<Item>
        {
            new Bow("활", ItemGrade.Normal, "평범한 활이다.", 50),
            new Bow("강철 활", ItemGrade.Rare, "강철로 만든 활이다.", 100),
            new Bow("장인이 만든 활", ItemGrade.Unique, "장인이 고품질의 목재와 끈을 가지고 만들어낸 활이다.", 200),
        };

        public static List<Item> m_etcList = new List<Item>
        {
            new ETC("나뭇잎", ItemGrade.None, "나무에서 떨어져버린 나뭇잎이다."),
            new ETC("강철", ItemGrade.Rare, "매우 단단한 금속이다."),
            new ETC("다이아몬드", ItemGrade.Unique, "경도가 높은 결정체이다. 필요에 따라 보석이나 고품질의 장비를 제작할 수 있다."),
        };

    }



    internal class Menu
    {
        public MenuType m_menu { get; private set; } = MenuType.MainMenu;


        public void MenuList()
        {
            List<Item> myInventory = new List<Item>();

            while (true)
            {
                switch (m_menu)
                {
                    case MenuType.MainMenu:
                        {
                            UI.HeadLine("메뉴");
                            UI.ChoiceLine("아이템 정보 및 인벤토리에 담기", "무기 휘둘러보기", "인벤토리 확인하기", "종료");
                            m_menu = IOChecker.MainMenuChoice(Console.ReadLine());
                        }
                        break;
                    case MenuType.ItemCategory:
                        {
                            UI.HeadLine("아이템 카테고리");
                            UI.ChoiceLine("무기", "기타", "뒤로가기");
                            m_menu = IOChecker.ItemCategoryChoice(Console.ReadLine());
                        }
                        break;
                    case MenuType.WeaponAttack:
                        {
                            UI.WeaponAttack(myInventory);
                            m_menu = MenuType.MainMenu;
                        }
                        break;
                    case MenuType.MyInventory:
                        {
                            UI.ShowInventory(myInventory);
                            m_menu = MenuType.MainMenu;
                        }
                        break;
                    case MenuType.Exit:
                        {
                            return;
                        }
                    case MenuType.WeaponCategory:
                        {
                            UI.HeadLine("무기 타입");
                            UI.ChoiceLine("검", "활", "뒤로가기");
                            m_menu = IOChecker.WeaponCategoryChoice(Console.ReadLine());

                        }
                        break;
                    case MenuType.ArmourCategory:
                        {
                            UI.HeadLine("방어구 타입");
                            UI.ChoiceLine("천", "가죽", "경갑", "뒤로가기"); // 미완성
                        }
                        break;
                    case MenuType.ETCCategory:
                        {
                            UI.HeadLine("기타 아이템");
                            UI.ChoiceLine("나뭇잎", "강철", "다이아몬드", "뒤로가기");
                            m_menu = IOChecker.ETCCategoryChoice(Console.ReadLine(), myInventory);

                        }
                        break;
                    case MenuType.SwordCategory:
                        {
                            UI.HeadLine("검");
                            UI.ChoiceLine("검", "강철 검", "장인이 만든 검", "뒤로가기");
                            m_menu = IOChecker.SwordCategoryChoice(Console.ReadLine(), myInventory);
                        }
                        break;
                    case MenuType.BowCategory:
                        {
                            UI.HeadLine("활");
                            UI.ChoiceLine("활", "강철 활", "장인이 만든 활", "뒤로가기");
                            m_menu = IOChecker.BowCategoryChoice(Console.ReadLine(), myInventory);
                        }
                        break;
                }
            }
        }
    }

    internal class UI
    {
        public static void HeadLine(string text)
        {
            Console.WriteLine($"원하는 {text}를(을) 선택하여 주십시오.");
        }

        public static void ChoiceLine(string textOne, string textTwo)
        {
            Console.WriteLine($"1. {textOne} // 2. {textTwo}");
        }

        public static void ChoiceLine(string textOne, string textTwo, string textThree)
        {
            Console.WriteLine($"1. {textOne} // 2. {textTwo} // 3. {textThree}");
        }

        public static void ChoiceLine(string textOne, string textTwo, string textThree, string textFour)
        {
            Console.WriteLine($"1. {textOne} // 2. {textTwo} // 3. {textThree} // 4. {textFour}");
        }

        public static void ShowInventory(List<Item> myinventory)
        {
            int i = 0;
            Console.Clear();
            Console.WriteLine($"소지하고 있는 아이템 개수 = {myinventory.Count}개");

            foreach (Item item in myinventory)
            {
                i++;

                Console.WriteLine($"슬롯 {i}번");
                Console.WriteLine($"아이템 이름 : {item.m_name}");
                Console.WriteLine($"아이템 정보 : {item.m_itemInfo}");
            }

            Console.ReadKey();
        }

        public static void ShowItem(Item item)
        {
            Console.Write($"이름: {item.m_name}");

            if (item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                Console.WriteLine($"공격력 : {weapon.m_attackDamage}");
            }

            if (item is Armour)
            {
                Armour armour = (Armour)item;
                Console.WriteLine($"방어력 : {armour.m_armourPoint}");

            }

            Console.Write($"정보: {item.m_name}");

        }

        public static void WeaponAttack(List<Item> myinventory)
        {
            Console.Clear();

            int i = 0;

            foreach (Item item in myinventory)
            {
                if (item is Weapon)
                {
                    i++;
                    Console.Write($"{i}번째 무기 ");
                    Weapon weapon = (Weapon)item;
                    weapon.Attack();
                }
            }

            Console.ReadKey();
        }

        public static void ChoiceMunber(string text)
        {
            Console.WriteLine($"{text} 개수를 입력하여 주십시오.");
        }

    }

    internal class IOChecker
    {
        public static MenuType MainMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    {
                        return MenuType.ItemCategory;
                    }
                case "2":
                    {
                        return MenuType.WeaponAttack;
                    }
                case "3":
                    {
                        return MenuType.MyInventory;
                    }
                case "4":
                    {
                        return MenuType.Exit;
                    }
                default:
                    {
                        return MenuType.MainMenu;
                    }

            }

        }

        public static MenuType ItemCategoryChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    {
                        return MenuType.WeaponCategory;
                    }
                case "2":
                    {
                        return MenuType.ETCCategory;
                    }
                case "3":
                    {
                        return MenuType.MainMenu;
                    }
                default:
                    {
                        return MenuType.ItemCategory;
                    }

            }

        }

        public static MenuType WeaponCategoryChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    {
                        return MenuType.SwordCategory;
                    }
                case "2":
                    {
                        return MenuType.BowCategory;
                    }
                case "3":
                    {
                        return MenuType.WeaponCategory;
                    }
                default:
                    {
                        return MenuType.ItemCategory;
                    }

            }
        }

        public static MenuType ETCCategoryChoice(string choice, List<Item> myinventory)
        {
            switch (choice)
            {
                case "1":
                    {
                        GetItem.GetItemName(choice);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "2":
                    {
                        GetItem.GetItemName(choice);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "3":
                    {
                        GetItem.GetItemName(choice);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "4":
                    {
                        return MenuType.ItemCategory;
                    }
                default:
                    {
                        return MenuType.ETCCategory;
                    }

            }
        }

        public static MenuType SwordCategoryChoice(string choice, List<Item> myinventory)
        {
            switch (choice)
            {
                case "1":
                    {
                        GetItem.GetItemName(choice, WeaponType.Sword);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "2":
                    {
                        GetItem.GetItemName(choice, WeaponType.Sword);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "3":
                    {
                        GetItem.GetItemName(choice, WeaponType.Sword);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "4":
                    {
                        return MenuType.WeaponCategory;
                    }
                default:
                    {
                        return MenuType.SwordCategory;
                    }
            }
        }

        public static MenuType BowCategoryChoice(string choice, List<Item> myinventory)
        {
            switch (choice)
            {
                case "1":
                    {
                        GetItem.GetItemName(choice, WeaponType.Bow);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "2":
                    {
                        GetItem.GetItemName(choice, WeaponType.Bow);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "3":
                    {
                        GetItem.GetItemName(choice, WeaponType.Bow);
                        GetItem.GetItemNumber();
                        GetItem.GetItemInInventory(myinventory);
                        return MenuType.MainMenu;
                    }
                case "4":
                    {
                        return MenuType.WeaponCategory;
                    }
                default:
                    {
                        return MenuType.BowCategory;
                    }
            }

        }

    }

    internal class GetItem
    {
        public static int m_getItemNumber { get; private set; } = 0;
        public static Item m_item { get; private set; }

        public static void GetItemInInventory(List<Item> inventory)
        {
            for (int i = 0; i < m_getItemNumber; i++)
            {
                inventory.Add(m_item);
            }
        }

        public static void GetItemNumber()
        {
            while (true)
            {
                UI.ChoiceMunber($"원하시는 {m_item.m_name}의 ");
                bool isTrue = int.TryParse(Console.ReadLine(), out int itemNumber);
                if (isTrue)
                {
                    m_getItemNumber = itemNumber;
                    return;
                }
            }
        }

        public static void GetItemName(string number, WeaponType weaponType)
        {
            int.TryParse(number, out int i);

            switch (weaponType)
            {
                case WeaponType.Sword:
                    {
                        m_item = ItemList.m_swordList[i - 1];
                    }
                    break;
                case WeaponType.Bow:
                    {
                        m_item = ItemList.m_bowList[i - 1];
                    }
                    break;
            }
        }

        public static void GetItemName(string number, ArmourType armourType)
        {
            int.TryParse(number, out int i);

            switch (armourType)
            {
                case ArmourType.LightArmour:
                    {

                    }
                    break;
            }

        }

        public static void GetItemName(string number)
        {
            int.TryParse(number, out int i);

            m_item = ItemList.m_etcList[i - 1];

        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MenuList();
        }
    }
}
