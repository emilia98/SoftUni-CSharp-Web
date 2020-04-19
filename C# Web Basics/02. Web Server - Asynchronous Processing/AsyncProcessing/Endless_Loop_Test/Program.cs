using System;

namespace Endless_Loop_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Does not take up the whole resources on the proccessor
            int i = 0;

            while(true)
            {
                i++;
                i--;
            }
        }
    }
}
