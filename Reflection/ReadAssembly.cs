using System;
using System.Reflection;

namespace Reflection
{
    class ReadAssembly
    {
        static void Main(string[] args)
        {
            ReadAssemblyWithReflection();
        }
        static private void ReadAssemblyWithReflection()
        {
            string path = @"some path";
            Assembly assembly = Assembly.LoadFile(path);

            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Class: " + type.Name);

                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("--Method: " + method.Name);

                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var param in parameters)
                    {
                        Console.WriteLine($"=== Parameter: {param.Name} : {param.ParameterType}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
