using System;

namespace IDisposableUnhandledMemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DisposeImplementation d = new DisposeImplementation();
            d.Dispose();
            d = null;
            GC.Collect();
            Console.ReadLine();

            //WITH USING
            //using (DisposeImplementation d = new DisposeImplementation())
            //{
            //    throw new Exception("In here");
            //}
        }
    }
}
