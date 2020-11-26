using System;

namespace delegate_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Cat cat = new Cat("Tom");
            Mouse m1 = new Mouse("Jerry");
            Mouse m2 = new Mouse("Jack");

            //
            cat.CatShout += new Cat.CatShoutEventHandler(m1.Run);
            cat.CatShout += new Cat.CatShoutEventHandler(m2.Run);

            cat.Shout();


        }


    }

    class Cat
    {
        private string name;

        public Cat(string name)
        {
            this.name = name;
        }

        public delegate void CatShoutEventHandler(object sender, CatShoutEventArgs args);

        public event CatShoutEventHandler CatShout;

        public void Shout()
        {
            Console.WriteLine($"喵，我是{name}");
            if (CatShout != null)
            {
                CatShoutEventArgs e = new CatShoutEventArgs();
                e.Name = this.name;
                CatShout(this, e);
            }
        }
    }

    class Mouse
    {
        private string name;

        public Mouse(string name)
        {
            this.name = name;
        }

        public void Run(object sender, CatShoutEventArgs args)
        {
            Console.WriteLine($"{args.Name}猫来了，{name}快跑");
        }
    }

    public class CatShoutEventArgs : EventArgs
    {
        public string Name { get; set; }
    }
}