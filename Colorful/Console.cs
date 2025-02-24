using System;
using System.Drawing;
using System.Text;

namespace Colorful
{
    /// <summary>
    /// Provides enhanced console color management.
    /// </summary>
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
            { "ResetBoldFaint", "\x1b[22m" },
            { "Italic", "\x1b[3m" },
            { "ResetItalic", "\x1b[23m" },
            { "Underline", "\x1b[4m" },
            { "ResetUnderline", "\x1b[24m" },
            { "Hidden", "\x1b[8m" },
            { "ResetHidden", "\x1b[28m" },
            { "CrossedOut", "\x1b[9m" },
            { "ResetCrossedOut", "\x1b[29m" },
            { "Overline", "\x1b[53m" },
            { "ResetOverline", "\x1b[55m" },
            { "Blink", "\x1b[5m" },
            { "ResetBlink", "\x1b[25m" }
        };
        public enum ColoringType
        {
            Foreground,
            Background,
            Pixel
        }
        public  enum FadeType
        {
            Inverse,
            Reverse,
            Pulsing
        }
        private static readonly Color OGForegroundColor;
        private static readonly Color OGBackgroundColor;
        private static Color _foregroundColor;
        private static Color _backgroundColor;
        static Console()
        {
            // Capture the default console colors exactly once.
            OGForegroundColor = ColorMap[System.Console.ForegroundColor];
            OGBackgroundColor = ColorMap[System.Console.BackgroundColor];
            _foregroundColor = OGForegroundColor;
            _backgroundColor = OGBackgroundColor;
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
        public static void SetBackgroundColor(Color color) => BackgroundColor = color;
        #endregion

        #region Not Fun - Basic Console Wrapping
        public static void Write(string text) => System.Console.Write(StyledText(text));
        public static void Write(bool value) => System.Console.Write(value);
        public static void Write(char value) => System.Console.Write(value);
        public static void Write(char[]? buffer) => System.Console.Write(buffer);
        public static void Write(decimal value) => System.Console.Write(value);
        public static void Write(double value) => System.Console.Write(value);
        public static void Write(float value) => System.Console.Write(value);
        public static void Write(int value) => System.Console.Write(value);
        public static void Write(long value) => System.Console.Write(value);
        public static void Write(object? value) => System.Console.Write(value);
        public static void Write(uint value) => System.Console.Write(value);
        public static void Write(ulong value) => System.Console.Write(value);
        public static void Write(string format, object? arg0) => System.Console.Write(format, arg0);
        public static void Write(string format, params object?[]? arg) => System.Console.Write(format, arg);
        public static void Write(string format, params ReadOnlySpan<object?> arg) => System.Console.Write(format, arg);
        public static void Write(char[] buffer, int index, int count) => System.Console.Write(buffer, index, count);
        public static void Write(string format, object? arg0, object? arg1) => System.Console.Write(format, arg0, arg1);
        public static void Write(string format, object? arg0, object? arg1, object? arg2) => System.Console.Write(format, arg0, arg1, arg2);

        public static void WriteLine() => Write('\n');
        public static void WriteLine(string? text) => Write(text + "\n");

        public static void WriteLine(bool value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(char value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(char[]? buffer)
        {
            Write(buffer);
            Write('\n');
        }

        public static void WriteLine(decimal value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(double value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(float value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(int value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(long value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(object? value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(uint value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(ulong value)
        {
            Write(value);
            Write('\n');
        }

        public static void WriteLine(string format, object? arg0)
        {
            Write(format, arg0);
            Write('\n');
        }

        public static void WriteLine(string format, params object?[]? arg)
        {
            Write(format, arg);
            Write('\n');
        }

        public static void WriteLine(string format, params ReadOnlySpan<object?> arg)
        {
            Write(format, arg);
            Write('\n');
        }

        public static void WriteLine(char[] buffer, int index, int count)
        {
            Write(buffer, index, count);
            Write('\n');
        }

        public static void WriteLine(string format, object? arg0, object? arg1)
        {
            Write(format, arg0, arg1);
            Write('\n');
        }

        public static void WriteLine(string format, object? arg0, object? arg1, object? arg2)
        {
            Write(format, arg0, arg1, arg2);
            Write('\n');
        }
        public static int BufferHeight
        {
            get => System.Console.BufferHeight;
            set => System.Console.BufferHeight = value;
        }

        public static int BufferWidth
        {
            get => System.Console.BufferWidth;
            set => System.Console.BufferWidth = value;
        }

        public static event ConsoleCancelEventHandler CancelKeyPress
        {
            add { System.Console.CancelKeyPress += value; }
            remove { System.Console.CancelKeyPress -= value; }
        }

        public static bool CapsLock => System.Console.CapsLock;

        public static int CursorLeft
        {
            get => System.Console.CursorLeft;
            set => System.Console.CursorLeft = value;
        }

        public static int CursorTop
        {
            get => System.Console.CursorTop;
            set => System.Console.CursorTop = value;
        }

        public static int CursorSize
        {
            get => System.Console.CursorSize;
            set => System.Console.CursorSize = value;
        }

        public static bool CursorVisible
        {
            get => System.Console.CursorVisible;
            set => System.Console.CursorVisible = value;
        }

        public static TextWriter Error => System.Console.Error;
        public static TextReader In => System.Console.In;

        public static Encoding InputEncoding
        {
            get => System.Console.InputEncoding;
            set => System.Console.InputEncoding = value;
        }

        public static bool IsErrorRedirected => System.Console.IsErrorRedirected;
        public static bool IsOutputRedirected => System.Console.IsOutputRedirected;
        public static bool KeyAvailable => System.Console.KeyAvailable;
        public static int LargestWindowHeight => System.Console.LargestWindowHeight;
        public static int LargestWindowWidth => System.Console.LargestWindowWidth;

        public static bool NumberLock => System.Console.NumberLock;
        public static TextWriter Out => System.Console.Out;

        public static Encoding OutputEncoding
        {
            get => System.Console.OutputEncoding;
            set => System.Console.OutputEncoding = value;
        }

        public static string Title
        {
            get => System.Console.Title;
            set => System.Console.Title = value;
        }

        public static bool TreatControlCAsInput
        {
            get => System.Console.TreatControlCAsInput;
            set => System.Console.TreatControlCAsInput = value;
        }

        public static int WindowHeight
        {
            get => System.Console.WindowHeight;
            set => System.Console.WindowHeight = value;
        }

        public static int WindowLeft
        {
            get => System.Console.WindowLeft;
            set => System.Console.WindowLeft = value;
        }

        public static int WindowTop
        {
            get => System.Console.WindowTop;
            set => System.Console.WindowTop = value;
        }

        public static int WindowWidth
        {
            get => System.Console.WindowWidth;
            set => System.Console.WindowWidth = value;
        }

        public override bool Equals(object? obj)
        {
            return object.ReferenceEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return typeof(Console).GetHashCode();
        }

        public new static bool Equals(object? a, object? b) => object.Equals(a, b);
        public new static bool ReferenceEquals(object? a, object? b) => object.ReferenceEquals(a, b);

        public static void Beep() => System.Console.Beep();
        public static void Beep(int frequency, int duration) => System.Console.Beep(frequency, duration);

        public static void Clear() => System.Console.Clear();

        public static void GetCursorPosition() => System.Console.GetCursorPosition();

        public static void MoveBufferArea(
            int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
            int targetLeft, int targetTop)
        {
            System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop);
        }

        public static void MoveBufferArea(
            int sourceLeft, int sourceTop, int sourceWidth, int sourceHeight,
            int targetLeft, int targetTop, char sourceChar,
            ConsoleColor sourceForeColor, ConsoleColor sourceBackColor)
        {
            System.Console.MoveBufferArea(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop,
                                          sourceChar, sourceForeColor, sourceBackColor);
        }

        public static Stream OpenStandardError() => System.Console.OpenStandardError();
        public static Stream OpenStandardError(int bufferSize) => System.Console.OpenStandardError(bufferSize);

        public static Stream OpenStandardInput() => System.Console.OpenStandardInput();
        public static Stream OpenStandardInput(int bufferSize) => System.Console.OpenStandardInput(bufferSize);

        public static Stream OpenStandardOutput() => System.Console.OpenStandardOutput();
        public static Stream OpenStandardOutput(int bufferSize) => System.Console.OpenStandardOutput(bufferSize);

        public static int Read() => System.Console.Read();

        public static ConsoleKeyInfo ReadKey() => System.Console.ReadKey();
        public static ConsoleKeyInfo ReadKey(bool intercept) => System.Console.ReadKey(intercept);

        public static string? ReadLine() => System.Console.ReadLine();

        public static void SetBufferSize(int width, int height) => System.Console.SetBufferSize(width, height);
        public static void SetCursorPosition(int left, int top) => System.Console.SetCursorPosition(left, top);
        public static void SetError(TextWriter newError) => System.Console.SetError(newError);
        public static void SetIn(TextReader newIn) => System.Console.SetIn(newIn);
        public static void SetOut(TextWriter newOut) => System.Console.SetOut(newOut);
        public static void SetWindowPosition(int left, int top) => System.Console.SetWindowPosition(left, top);
        public static void SetWindowSize(int width, int height) => System.Console.SetWindowSize(width, height);
        #endregion

        #region Fun - Colors and Enhanced Features
        #region Resets
        public static void ResetForegroundColor() => ForegroundColor = OGForegroundColor;
        public static void ResetBackgroundColor() => BackgroundColor = OGBackgroundColor;
        public static void ResetColors()
        {
            ResetForegroundColor();
            ResetBackgroundColor();
        }
        public static void ResetColor()
        {
            Write("\x1b[0m");
            ResetColors();
        }
        #endregion

        #region Colored Writes        
        public static void Write(ConsoleColor foregroundColor, string text = "  ", ColoringType coloringType = ColoringType.Foreground)
        {
            Write(ColorMap[foregroundColor], text, coloringType);
        }
        public static void Write(Color color, string text = "  ",  ColoringType coloringType = ColoringType.Foreground)
        {
            switch (coloringType)
            {
                case ColoringType.Foreground:
                    ForegroundColor = color;
                    Write($"\x1b[38;2;{color.R};{color.G};{color.B}m{text}");
                    ResetForegroundColor();
                    break;
                case ColoringType.Background:
                    BackgroundColor = color;
                    Write($"\x1b[48;2;{color.R};{color.G};{color.B}m{text}");
                    ResetBackgroundColor();
                    break;
                case ColoringType.Pixel:
                    ForegroundColor = color;
                    BackgroundColor = color;
                    Write($"\x1b[38;2;{color.R};{color.G};{color.B}m\x1b[48;2;{color.R};{color.G};{color.B}m{text}");
                    ResetColor();
                    break;
            }
        }
        #endregion


        #region Custom stuff
        public static void Rainbow(string text, List<Color> colors = default)
        {
            if (colors == default) colors = rainbowColors;

        }
        #endregion




        public static string StyledText(string text)
        {
            if (text.Contains("{/"))
            {
                // Wrap the entire text with a default Bold style.
                //text = /*"{/Bold}" + */text /*+ "{/}"*/;
                List<string> styledCounter = [];

                int i = 0;
                while (i < text.Length)
                {
                    // Check for a closing tag "{/}"
                    if (i <= text.Length - 3 && text.Substring(i, 3) == "{/}")
                    {
                        if (styledCounter.Count > 0)
                        {
                            // Get the most recent style.
                            string lastTag = styledCounter[^1];
                            string counterTag = "";
                            switch (lastTag)
                            {
                                case "Fore":
                                    counterTag = AnsiCodes["ResetFore"];
                                    break;
                                case "Back":
                                    counterTag = AnsiCodes["ResetBack"];
                                    break;
                                case "SwapColors":
                                    counterTag = AnsiCodes["SwapColors"];
                                    break;
                                case "Bold":
                                    counterTag = AnsiCodes["ResetBoldFaint"];
                                    break;
                                case "Faint":
                                    counterTag = AnsiCodes["ResetBoldFaint"];
                                    break;
                                case "Italic":
                                    counterTag = AnsiCodes["ResetItalic"];
                                    break;
                                case "Underline":
                                    counterTag = AnsiCodes["ResetUnderline"];
                                    break;
                                case "Hidden":
                                    counterTag = AnsiCodes["ResetHidden"];
                                    break;
                                case "CrossedOut":
                                    counterTag = AnsiCodes["ResetCrossedOut"];
                                    break;
                                case "Overline":
                                    counterTag = AnsiCodes["ResetOverline"];
                                    break;
                                case "Blink":
                                    counterTag = AnsiCodes["ResetBlink"];
                                    break;
                            }
                            // Optionally reapply the previous style if one exists.
                            if (styledCounter.Count >= 2)
                            {
                                string previousTag = styledCounter[^2];
                                if (AnsiCodes.TryGetValue(previousTag, out string? value))
                                {
                                    counterTag += value;
                                }
                            }
                            // Remove the closing tag and insert the reset code.
                            text = text.Remove(i, 3);
                            text = text.Insert(i, counterTag);
                            i += counterTag.Length;
                            styledCounter.RemoveAt(styledCounter.Count - 1);
                            continue;
                        }
                    }
                    // Check for an opening tag "{/..."
                    else if (i <= text.Length - 2 && text.Substring(i, 2) == "{/")
                    {
                        int startIndex = i + 2; // Skip "{/"
                        int endIndex = text.IndexOf('}', startIndex);
                        if (endIndex == -1)
                        {
                            break; // No closing brace found.
                        }
                        string tag = text[startIndex..endIndex];

                        if (tag.StartsWith("ForegroundColor(") ||
                            tag.StartsWith("Fore(") ||
                            tag.StartsWith("Foreground("))
                        {
                            string[] tagParts = tag.Split(['(', ',', ')'], StringSplitOptions.RemoveEmptyEntries);
                            Color color = Color.FromArgb(int.Parse(tagParts[1]), int.Parse(tagParts[2]), int.Parse(tagParts[3]));
                            // Remove the tag (from the opening "{/" to the closing "}")
                            int lengthToRemove = (endIndex - i) + 1;
                            string ansiCode = $"\x1b[38;2;{color.R};{color.G};{color.B}m";
                            text = text.Remove(i, lengthToRemove);
                            text = text.Insert(i, ansiCode);
                            i += ansiCode.Length;
                            // Also push a marker so that closing tag resets foreground.
                            styledCounter.Add("Fore");
                            continue;
                        }
                        else if (tag.StartsWith("BackgroundColor(") ||
                                 tag.StartsWith("Back(") ||
                                 tag.StartsWith("Background("))
                        {
                            string[] tagParts = tag.Split(['(', ',', ')'], StringSplitOptions.RemoveEmptyEntries);
                            Color color = Color.FromArgb(int.Parse(tagParts[1]), int.Parse(tagParts[2]), int.Parse(tagParts[3]));
                            int lengthToRemove = (endIndex - i) + 1;
                            string ansiCode = $"\x1b[48;2;{color.R};{color.G};{color.B}m";
                            text = text.Remove(i, lengthToRemove);
                            text = text.Insert(i, ansiCode);
                            i += ansiCode.Length;
                            styledCounter.Add("Back");
                            continue;
                        }
                        else if (!AnsiCodes.TryGetValue(tag, out string? ansiCode))
                        {
                            throw new Exception($"Formatting tag '{tag}' does not exist.");
                        }
                        else
                        {
                            // For other tags, replace the tag with its ANSI code.
                            int lengthToRemove = (endIndex - i) + 1;
                            text = text.Remove(i, lengthToRemove);
                            text = text.Insert(i, ansiCode);
                            i += ansiCode.Length;
                            styledCounter.Add(tag);
                            continue;
                        }
                    }
                    i++;
                }
            }
            return text;
        }
        #endregion
    }
}