using MyAttribute;
using System;

namespace MyLibrary
{
    public class MyLibrary
    {


        [ExecuteMe]
        public void M1() => Console.WriteLine("M1");

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(333)]
        public void M2(int a) => Console.WriteLine("M2 a={0}", a);

        [ExecuteMe("hello", "reflection")]
        public void M3(string s1, string s2) => Console.WriteLine("M3 s1={0} s2={1}", s1, s2);


    }

    public class MyLibrary2
    {
        private MyLibrary2() { }

        [ExecuteMe]
        public void M1() => Console.WriteLine("questo è un metodo di una classe con costruttore privato");

    }

    public class MyLibrary3
    {


        [ExecuteMe("tre")]
        public void C1(int a) => Console.WriteLine("C1: deve dare eccezione");

        [ExecuteMe]
        public void C2() => Console.WriteLine("C2: deve essere eseguito");


    }
}

