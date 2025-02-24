using System.Drawing;
using static Colorful.Console;

namespace Colorful
{
    internal class Program
    {
        static void Main()
        {
            ResetColor();
            ForegroundColor = Color.Blue;
            WriteLine("Hello, World!");
            WriteLine("Hello, World!");
            ResetColor();
            Write("{/Blink}{/Fore(255,0,0)}he{/}{/} {/Fore(0,25,255)}hi{/} {/Faint}hello{/} {/Bold}sup{/} {/Back(2,34,134)}non{/}");
            ResetColor();
            WriteLine("\nHello, World!");
            WriteLine("Hello, World!");
            WriteLine("Hello, World!");
            WriteLine("Hello, World!");
            Write(ConsoleColor.Red, ColoringType.Pixel);
            //WriteLine(ConsoleColor.Red, "yes");
            //Write(Color.Green, "ff");
            //WriteLine(Color.Cyan, "aw");
            //Console.WriteLine(ConsoleColor.Blue, "no");
            //Console.WriteLine(Color.FromArgb(0, 255, 0), "Hi");
            //Console.WriteLine(Color.Cyan, "yesssss");
            //Console.RainbowWriteLine("Rainbow");
            //Console.RainbowWriteLine("An other Rainbow");
            //Console.TransparentWriteLine("100% visibility", 0);
            //Console.TransparentWriteLine("90% visibility", .1);
            //Console.TransparentWriteLine("75% visibility", .25);
            //Console.TransparentWriteLine("50% visibility", .5);
            //Console.TransparentWriteLine("25% visibility", .75);
            //Console.TransparentWriteLine("5% visibility", .95);
            //Console.TransparentWriteLine(ConsoleColor.Red, "Red 50%", .5);
            //Console.TransparentWriteLine(Color.Red, "Red 50%", .5f);
            //Console.TransparentWriteLine(ConsoleColor.Blue, "Blue 75%", .25);
            //Console.TransparentWriteLine(Color.Blue, "Blue 25%", .75f);
            //Console.TransparentWriteLine(ConsoleColor.Yellow, "Yellow 90%", .1);
            //Console.TransparentWriteLine(Color.Yellow, "Yellow 10%", .9f);
            //Console.FadingWriteLine("Yooooooooooooooooooooooooooooooooooooooo");
            //Console.FadingWriteLine("Yooooooooooooooooooooooooooooooooooooooo");
            //Console.FadingWriteLine("Yooooooooooooooooooooooooooooooooooooooo", FadeType.Reverse);
            //Console.FadingWriteLine("Yooooooooooooooooooooooooooooooooooooooo", FadeType.Pulsing);
            //Console.Numberify("NUMBERIFY\n");
            //Console.Numberify("numberify\n");
            //Console.WriteLine(""); //Styled            
            //Console.WriteLine(""); //Styled           
            //Console.FadingWriteLine(ConsoleColor.Red, "", FadeType.Inverse);
            //Console.FadingWriteLine(Color.Blue, "", FadeType.Reverse);
            //Console.ASCII("");
            ReadKey(true);
        }
    }
}