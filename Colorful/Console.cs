using System.Drawing;
using System.Text;

namespace Colorful
{
    class Console
    {
        #region Basic things
        internal static List<Color> rainbowColors =
            [
                Color.FromArgb(255, 255, 0, 0),    // Red
                Color.FromArgb(255, 255, 165, 0),   // Orange
                Color.FromArgb(255, 255, 255, 0),   // Yellow
                Color.FromArgb(255, 0, 128, 0),     // Green
                Color.FromArgb(255, 0, 0, 255),     // Blue
                Color.FromArgb(255, 75, 0, 130),    // Indigo
                Color.FromArgb(255, 238, 130, 238)  // Violet
            ];
        internal static Dictionary<ConsoleColor, Color> ColorMap = new()
{
    { ConsoleColor.Black,       Color.FromArgb(0, 0, 0) },
    { ConsoleColor.DarkBlue,    Color.FromArgb(0, 0, 128) },
    { ConsoleColor.DarkGreen,   Color.FromArgb(0, 128, 0) },
    { ConsoleColor.DarkCyan,    Color.FromArgb(0, 128, 128) },
    { ConsoleColor.DarkRed,     Color.FromArgb(128, 0, 0) },
    { ConsoleColor.DarkMagenta, Color.FromArgb(128, 0, 128) },
    { ConsoleColor.DarkYellow,  Color.FromArgb(128, 128, 0) },
    { ConsoleColor.Gray,        Color.FromArgb(192, 192, 192) },
    { ConsoleColor.DarkGray,    Color.FromArgb(128, 128, 128) },
    { ConsoleColor.Blue,        Color.FromArgb(0, 0, 255) },
    { ConsoleColor.Green,       Color.FromArgb(0, 255, 0) },
    { ConsoleColor.Cyan,        Color.FromArgb(0, 255, 255) },
    { ConsoleColor.Red,         Color.FromArgb(255, 0, 0) },
    { ConsoleColor.Magenta,     Color.FromArgb(255, 0, 255) },
    { ConsoleColor.Yellow,      Color.FromArgb(255, 255, 0) },
    { ConsoleColor.White,       Color.FromArgb(255, 255, 255) }
};
        internal static Dictionary<string, string> AnsiCodes = new()
        {
            { "ResetColors", "\x1b[0m" },
            { "SwapColors", "\x1b[7m" },
            { "ResetFore", "\x1b[39m" },
            { "ResetBack", "\x1b[49m" },
            { "Bold", "\x1b[1m" },
            { "Faint", "\x1b[2m" },
            { "ResetWeight", "\x1b[22m" },
            { "Italic", "\x1b[3m" },
            { "ResetItalic", "\x1b[23m" },
            { "Underline", "\x1b[4m" },
            { "ResetUnderline", "\x1b[24m" },
            { "Hidden", "\x1b[8m" },
            { "ResetHidden", "\x1b[28m" },
            { "CrossedOut", "\x1b[9m" },
            { "ResetCrossedOut", "\x1b[29m" },
            { "Overline", "\x1b[53m" },
            { "DoubleUnderline", "\x1b[21m" },
            { "ResetOverline", "\x1b[55m" },
            { "Blink", "\x1b[5m" },
            { "ResetBlink", "\x1b[25m" }
        };
        public enum PixelType
        {
            Small,
            Big,
            Solid
        }
        public enum FadeType
        {
            Inverse,
            Reverse,
            Pulsing
        }
        #endregion

        #region Styling stuff
        public static void Write(string text, Color color, short type)
        {
            switch (type)
                { 
                case 0:
                    ForegroundColor = color;
                    break;
                case 1:
                    BackgroundColor = color;
                    break;
                case 2:
                    ForegroundColor = color;
                    BackgroundColor = color;
                    break;
            }
            Write(text);
            ResetColors();
        }
        public static void WriteLine(string text, Color color, PixelType type)
        {
            Write(text, color, type);
            WriteLine();
        }

        public static void Write(string text, Color color)
        {
            ForegroundColor = color;
            Write(text);
            ResetColors();
        }
        public static void WriteLine(string text, Color color)
        {
            ForegroundColor = color;
            Write(text, color);
            WriteLine();
        }

        public static void Write(string text, ConsoleColor color)
        {
            Write(text, ColorMap[color]);
        }
        public static void WriteLine(string text, ConsoleColor color)
        {
            WriteLine(text, ColorMap[color]);
        }

        public static void Write(string text, ConsoleColor color, PixelType type)
        {
            switch (type)
            {
                case PixelType.Small:
                    ForegroundColor = ColorMap[color];
                    break;
                case PixelType.Big:
                    BackgroundColor = ColorMap[color];
                    break;
                case PixelType.Solid:
                    ForegroundColor = ColorMap[color];
                    BackgroundColor = ColorMap[color];
                    break;
            }
            Write(text);
            ResetColors();
        }
        public static void WriteLine(string text, ConsoleColor color, PixelType type)
        {
            Write(text, color, type);
            WriteLine();
        }
        #endregion

        #region Wrapper
        // --- Properties ---
        private static Color _foregroundColor;
        private static Color _backgroundColor;
        public Console()
        {
            _foregroundColor = Color.FromArgb(255, 255, 255);
            _backgroundColor = Color.FromArgb(0, 0, 0); ;
            Write($"\x1b[38;2;{_foregroundColor.R};{_foregroundColor.G};{_foregroundColor.B}m\x1b[48;2;{_backgroundColor.R};{_backgroundColor.G};{_backgroundColor.B}m");
        }
        public static Color ForegroundColor
        {
            get => _foregroundColor;
            set => _foregroundColor = UpdateFore(value);
        }
        private static Color UpdateFore(Color value)
        {
            Write($"\x1b[38;2;{value.R};{value.G};{value.B}m");
            return value;
        }
        public static Color BackgroundColor
        {
            get => _backgroundColor;
            set => _backgroundColor = UpdateBack(value);
        }
        private static Color UpdateBack(Color value)
        {
            Write($"\x1b[48;2;{value.R};{value.G};{value.B}m");
            return value;
        }
        // --- ANSI Styling Methods ---
        public static void ResetColors() => Write(AnsiCodes["ResetColors"]);
        public static void SwapColors() => Write(AnsiCodes["SwapColors"]);
        public static void ResetForeground() => Write(AnsiCodes["ResetFore"]);
        public static void ResetBackground() => Write(AnsiCodes["ResetBack"]);

        public static void Bold() => Write(AnsiCodes["Bold"]);
        public static void Faint() => Write(AnsiCodes["Faint"]);
        public static void ResetBoldFaint() => Write(AnsiCodes["ResetWeight"]);

        public static void Italic() => Write(AnsiCodes["Italic"]);
        public static void ResetItalic() => Write(AnsiCodes["ResetItalic"]);

        public static void Underline() => Write(AnsiCodes["Underline"]);
        public static void ResetUnderline() => Write(AnsiCodes["ResetUnderline"]);

        public static void Hidden() => Write(AnsiCodes["Hidden"]);
        public static void ResetHidden() => Write(AnsiCodes["ResetHidden"]);

        public static void CrossedOut() => Write(AnsiCodes["CrossedOut"]);
        public static void ResetCrossedOut() => Write(AnsiCodes["ResetCrossedOut"]);

        public static void Overline() => Write(AnsiCodes["Overline"]);
        public static void ResetOverline() => Write(AnsiCodes["ResetOverline"]);

        public static void Blink() => Write(AnsiCodes["Blink"]); 
        public static void ResetBlink() => Write(AnsiCodes["ResetBlink"]);

        public static int BufferHeight => System.Console.BufferHeight;
        public static int BufferWidth => System.Console.BufferWidth;
        public static int CursorLeft => System.Console.CursorLeft;
        public static int CursorTop => System.Console.CursorTop;
        public static bool CursorVisible => System.Console.CursorVisible;
        public static int WindowHeight => System.Console.WindowHeight;
        public static int WindowWidth => System.Console.WindowWidth;
        public static int WindowLeft => System.Console.WindowLeft;
        public static int WindowTop => System.Console.WindowTop;
        public static string Title => System.Console.Title;
        public static bool TreatControlCAsInput => System.Console.TreatControlCAsInput;
        public static Encoding InputEncoding => System.Console.InputEncoding;
        public static Encoding OutputEncoding => System.Console.OutputEncoding;
        public static TextReader In => System.Console.In;
        public static TextWriter Out => System.Console.Out;
        public static TextWriter Error => System.Console.Error;

        // --- Events ---
        public static event ConsoleCancelEventHandler CancelKeyPress
        {
            add => System.Console.CancelKeyPress += value;
            remove => System.Console.CancelKeyPress -= value;
        }

        // --- Methods ---
        public static void Beep() => System.Console.Beep();
        public static void Beep(int frequency, int duration) => System.Console.Beep(frequency, duration);

        public static void Clear()=> System.Console.Clear();

        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop) => System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        public static void MoveBufferArea(int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight, int targetLeft, int targetTop, char sourceChar, ConsoleColor sourceForeColor, ConsoleColor sourceBackColor) => System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, sourceChar, sourceForeColor, sourceBackColor);

        public static void SetBufferSize(int width, int height) => System.Console.SetBufferSize(width, height);
        public static void SetCursorPosition(int left, int top) => System.Console.SetCursorPosition(left, top);
        public static void SetWindowPosition(int left, int top) => System.Console.SetWindowPosition(left, top);
        public static void SetWindowSize(int width, int height) => System.Console.SetWindowSize(width, height);

        public static int Read() => System.Console.Read();
        public static ConsoleKeyInfo ReadKey() => System.Console.ReadKey();
        public static ConsoleKeyInfo ReadKey(bool intercept) => System.Console.ReadKey(intercept);
        public static string ReadLine() => System.Console.ReadLine();

        public static void Write<T>(T value) => System.Console.Write(value);
        public static void Write(string format, params object[] args) => System.Console.Write(format, args);
        public static void Write(ReadOnlySpan<char> buffer) => System.Console.Out.Write(buffer);

        public static void WriteLine<T>(T value) => System.Console.WriteLine(value);
        public static void WriteLine() => System.Console.WriteLine();
        public static void WriteLine(string format, params object[] args) => System.Console.WriteLine(format, args);
        public static void WriteLine(ReadOnlySpan<char> buffer) => System.Console.Out.WriteLine(buffer);
        #endregion
    }
}