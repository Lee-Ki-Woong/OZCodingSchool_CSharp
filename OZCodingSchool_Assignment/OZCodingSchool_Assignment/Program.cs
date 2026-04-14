using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_Assignment
{
    public enum InternalOrgansName : byte
    {

        None = 0,
        Gastro = 1,
        Liver = 2,
        Heart = 3,
        Kidney = 4,

    }

    public enum InternalOrgansStats : byte
    {

        None = 0,
        Idle = 1,
        Inflammation = 2,
        Infection = 3,
        Hemorrhage = 4,
        Cancer = 5,

    }

    public enum MedicationName : byte
    {

        None = 0,
        AntiInflammatoryDrug = 1,
        Antimicrobials = 2,
        Hemostatics = 3,

    }

    public class Medication
    {

        private MedicationName m_name;
        private int m_sideEffect;


        public Medication(MedicationName name, int sideEffect)
        {

            this.m_name = name;
            this.m_sideEffect = sideEffect;

        }

        public void CureGastritis(InternalOrgans name)
        {

            if (name.CheckGastritis() == true && name.CheckOrgansName(name) == InternalOrgansName.Gastro)
            {
                name.HealthDown(this.m_sideEffect);
                name.EatAntiInflammatoryDrug();

                Console.WriteLine($"\n위장약의 부작용으로 체력이 {this.m_sideEffect}만큼 감소되었습니다!");
            }

        }

    }

    public class InternalOrgans
    {

        private InternalOrgansName m_name;
        private InternalOrgansStats m_stats;
        private int m_health;
        private int m_satietyIndex;

        public InternalOrgans(InternalOrgansName name, InternalOrgansStats stats, int health, int satiety)
        {

            this.m_name = name;
            this.m_stats = stats;
            this.m_health = health;
            this.m_satietyIndex = satiety;
        }

        public void HealthDown(int damage)
        {

            this.m_health -= damage;

        }

        public InternalOrgansName CheckOrgansName(InternalOrgans name)
        {

            return this.m_name;

        }

        public void GetGastritis()
        {

            this.m_stats = InternalOrgansStats.Inflammation;

            this.m_health -= 20;

        }

        public void EatAntiInflammatoryDrug()
        {

            Console.WriteLine("당신은 위염약을 먹었다!! 약을 먹고 위염이 깨끗하게 나았다!!");
            this.m_stats = InternalOrgansStats.Idle;


        }

        public void Eat()
        {

            this.m_satietyIndex++;

        }

        public void NoEat()
        {

            this.m_satietyIndex--;

        }

        public bool CheckGastritis()
        {
            if (this.m_stats == InternalOrgansStats.Inflammation) return true;
            else return false;


        }

    }





    internal class Program
    {
        static bool TrueFalseCheck(string text)
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
                else isMiss = true; continue;

            }

        }

        static void Main(string[] args)
        {

            bool isMiss = false;


            InternalOrgans myGastro = new InternalOrgans(InternalOrgansName.Gastro, InternalOrgansStats.Idle, 100, 3);

            while (true)
            {

                Console.Clear();

                Console.WriteLine("당신의 앞에 엄청나게 맛있는 음식들이 한가득 있다. 음식점에서는 이 음식을 모두 무료로 준다고 하는데 어떻게 할까?");
                Console.WriteLine("\n\n1. 전부 다 먹는다 / 2. 먹을 수 있는 만큼 먹는다 3. 먹지 않는다");


                if (isMiss)
                {

                    Console.WriteLine("잘못 입력하였습니다. 다시 입력해주세요!!");
                    isMiss = false;

                }


                string choiceOne = Console.ReadLine();


                if (choiceOne == "1")
                {

                    Console.WriteLine("당신은 음식을 위에 부담이 갈 수준으로 많이 먹었다. 토할 것 같다...");
                    Console.WriteLine($"위의 상태 - 위장염 / 위 체력 -20");

                    myGastro.GetGastritis();
                    myGastro.Eat();
                    break;

                }
                else if (choiceOne == "2")
                {

                    Console.WriteLine("당신은 음식을 적당히 먹었다!!\n포만감이 올랐다!! 포만감 +1");

                    myGastro.Eat();
                    break;

                }
                else if (choiceOne == "3")
                {

                    Console.WriteLine("당신은 음식을 그냥 지나쳐가기로 했다.\n배가 고파진다... 포만감 -1");

                    myGastro.NoEat();
                    break;

                }
                else
                {

                    isMiss = true;

                }

            }


            Console.ReadKey();

            if (myGastro.CheckGastritis())
            {

                bool choice = TrueFalseCheck("근처에 병원이 있는 것 같다... 배가 쓰린데 병원에 가볼까??");

                if (choice)
                {

                    Console.WriteLine("당신은 병원에서 약을 처방 받았다!!\n\n위염약 Get!!");
                    Medication gastritisTreatment = new Medication(MedicationName.AntiInflammatoryDrug, 3);

                    Console.ReadKey();


                    choice = TrueFalseCheck("약을 먹을까??");

                    if (choice)
                    {

                        gastritisTreatment.CureGastritis(myGastro);

                        Console.ReadKey();

                    }

                }
                else if (choice == false)
                {

                    Console.WriteLine("당신은 병원을 그냥 지나쳐가기로 했다...\n\n그 후로도 계속 무리한 과식을 하다보니 위가 아프다... 위 체력 -30");

                    myGastro.HealthDown(30);


                }

            }

        }

    }

}
