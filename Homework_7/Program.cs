using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassBuilder<A> cb1= new ClassBuilder<A>();
            ClassBuilder<B> cb2 = new ClassBuilder<B>();
            cb1.BuildClass();
            cb2.BuildClass();
            cb1.BuildClass();
            ClassBuilder<C> cb = new ClassBuilder<C>();
            cb.BuildClass();
            Console.ReadLine();
        }
    }

    class A
    {
        public string Name { get; set; }
        public int Age { get; private set; }

    }

    class B
    {
        public string Name { get; set; }
        public string Address { get; protected set; }
        public int Age { get; private set; }
    }
}
