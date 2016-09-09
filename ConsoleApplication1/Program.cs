using System;
namespace HelloWorld
{
    class Hello
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Some number" + getSomeInt().ToString() );

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int getSomeInt()
        {
            return 42;
        }
    }
}