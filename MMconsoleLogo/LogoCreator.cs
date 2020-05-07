using System;
using System.Text;

namespace MMconsoleLogo
{
    public class LogoCreator : IDrawable
    {
        private int stars;
        private int slashes;
        private int changingStarsNum;
        private int middleRow;
        public LogoCreator(int num)
        {
            this.stars = num;
            this.slashes = num;
            this.middleRow = num / 2;
            this.changingStarsNum = num;
        }
        public void CreateLogo() 
        {
            for (int i = this.stars; i >= 0; i--)
            {
                if (i == this.stars)
                {
                    FirtsRow();
                    FirtsRow();
                }
                else if (i == 0)
                {
                    LastRow();
                    LastRow();
                }
                else if (i == this.middleRow)
                {
                    this.slashes = 1;
                    MiddleRowAndBelow(i);
                    MiddleRowAndBelow(i);
                }
                else
                {
                    if (i > this.middleRow)
                    {
                        this.slashes -= 2;
                        this.changingStarsNum += 2;
                        UpperRows(i);
                        UpperRows(i);
                    }
                    else
                    {
                        changingStarsNum -= 2;
                        slashes += 2;
                        MiddleRowAndBelow(i);
                        MiddleRowAndBelow(i);
                    }
                }
                Console.WriteLine();
            }
        }
        public void FirtsRow()
        {
            Console.Write(Repeat('-',this.stars));
            Console.Write(Repeat('*',this.stars));
            Console.Write(Repeat('-',this.stars));
            Console.Write(Repeat('*',this.stars));
            Console.Write(Repeat('-',this.stars));
        }
        public void LastRow()
        {
            Console.Write(Repeat('*', stars));
            Console.Write(Repeat('-', stars));
            Console.Write(Repeat('*', stars));
            Console.Write(Repeat('-', stars));
            Console.Write(Repeat('*', stars));
        }
        public void MiddleRowAndBelow(int i)
        {
            Console.Write(Repeat('-', i));
            Console.Write(Repeat('*', stars));
            Console.Write(Repeat('-', slashes));
            Console.Write(Repeat('*', changingStarsNum));
            Console.Write(Repeat('-', slashes));
            Console.Write(Repeat('*', stars));
            Console.Write(Repeat('-', i));
        }
        public void UpperRows(int i)
        {
            Console.Write(Repeat('-', i));
            Console.Write(Repeat('*', changingStarsNum));
            Console.Write(Repeat('-', slashes));
            Console.Write(Repeat('*', changingStarsNum));
            Console.Write(Repeat('-', i));
        }
        internal string Repeat(char character, int repeat)
        {
            var sb = new StringBuilder();

            for (int index = repeat; index >= 1; index--)
            {
                sb.Append(character);
            }
            return sb.ToString();
        }
    }
}
