using MyAttribute;
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;

namespace Executer
{
    class Program
    {

        static void Main(string[] args)
        {

            //assembly_load("MyLibrary.dll"); //funziona solo con il riferimento a MyLibrary

            assembly_load(GetPath_assembly()); //funziona senza riferimento dfjfnkrnfkenfkn
            Console.ReadLine();
        }

        static String GetPath_assembly()
        {
            String Localpath = Directory.GetCurrentDirectory();

            var str = Localpath.Split("Executer");
            return (str[0] + "MyLibrary\\bin\\Debug\\netstandard2.0\\MyLibrary.dll");
        }

        static void assembly_load(String path)
        {
            var a = Assembly.LoadFrom(path); //carico assembly

            foreach (var type in a.GetTypes())
            { // itero sèu ogni classe presente nel assembly

                foreach (var method in type.GetMethods())
                { //itero ogni metodo della classe

                    if (method.GetCustomAttributes(typeof(ExecuteMe), false).Length <= 0) continue; //se non corrisponde al tipo giusto, ignoralo
                    foreach (ExecuteMe attribute in method.GetCustomAttributes(typeof(ExecuteMe), false))
                    { //ciclo su ogni attributo
                        var param = attribute.Value;

                        try
                        {
                            var istanza = Activator.CreateInstance(type);
                            Console.WriteLine(method.Invoke(istanza, param));

                        }
                        catch (MissingMethodException e) //MissingMethodException
                        {
                            //Console.WriteLine("eccezione costruttore: "+e.Message);
                            continue;
                        }
                        catch (ArgumentException e)
                        {
                            //Console.WriteLine("eccezione tipi: "+e.Message);
                            continue;
                        }
                    }
                }
            }
        }


    }
}



