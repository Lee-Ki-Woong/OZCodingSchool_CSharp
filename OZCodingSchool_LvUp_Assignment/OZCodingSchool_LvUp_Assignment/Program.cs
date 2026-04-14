using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZCodingSchool_LvUp_Assignment
{
    public enum MusicType
    {
        None = 0,
        Jazz = 101,
        Pop = 201,
        KPop = 202,
        JPop = 203,
        Rock = 301,
        Metal = 302,
        HipHop = 401,
        HardCore = 501,
        ArtCore = 502,

    }

    public class Music
    {
        protected string m_name;
        protected MusicType m_type;

        public Music(string name)
        {
            m_name = name;
            m_type = MusicType.None;
        }

        public virtual void Play()
        {
            Console.WriteLine($"당신은 {m_type} 장르의 {m_name}을 들었다!!");
        }

    }

    public class Jazz : Music
    {

        public Jazz(string name) : base(name)
        {
            m_type = MusicType.Jazz;
        }

        public override void Play()
        {
            base.Play();
        }

    }

    public class Pop : Music
    {
        public Pop(string name) : base(name)
        {
            m_type = MusicType.Pop;
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine("당신은 잔잔한 팝송을 듣고 마음이 편안해졌다!!");
        }

    }

    public class Rock : Music
    {
        public Rock(string name) : base(name)
        {
            m_type = MusicType.Rock;
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine("당신은 일렉기타의 소리에 의해서 마음이 흥분되기 시작했다!!");
        }

    }

    public class ArtCore : Music
    {
        public ArtCore(string name) : base(name)
        {
            m_type = MusicType.ArtCore;
        }

        public override void Play()
        {
            base.Play();
            Console.WriteLine("당신은 기분이 좋아졌다!!");
        }

    }

    internal class LeeKiWoong
    {
        static void Main(string[] leekiwoong)
        {

            ArtCore artCore = new ArtCore("Orchid");
            artCore.Play();

            Music pop = new Pop("set fire to the rain");
            pop.Play();

            Pop realpop = pop as Pop;

            realpop.Play();


        }
    }
}
