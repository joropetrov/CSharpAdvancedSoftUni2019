using System;

namespace IDisposableUnhandledMemo
{
    public class DisposeImplementation : IDisposable
    {
        private bool isDisposed = false;
        public DisposeImplementation()
        {
            Console.WriteLine("Creating obj of DisposeImplementation");
        }
        ~DisposeImplementation()
        {
            if (!isDisposed)
            {
                Console.WriteLine("Inside the finalizer of class DisposeImplementation");
                this.Dispose();
            }
        }
        public void Dispose()
        {
            isDisposed = true;
            Console.WriteLine("Inside the dispose of class DisposeImplementation");

            // WITH USING
            //isDisposed = true;
            //GC.SuppressFinalize(this);
            //Console.WriteLine("inside the dispose of classs disposeimplementation");
        }
    }
}
