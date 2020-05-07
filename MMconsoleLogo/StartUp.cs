using System;

namespace MMconsoleLogo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (num <= 0)
                {
                    throw new Exception("The Integer should be bigger than Zero");
                }

                LogoCreator mmLogo = new LogoCreator(num);
                mmLogo.CreateLogo();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

