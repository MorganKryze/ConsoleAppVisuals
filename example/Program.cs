using ConsoleAppVisuals;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Core.SetTitle("Example");
            Core.ChangeForeground(ConsoleColor.Cyan);
            Core.WriteTitle();
            Core.WriteBanner(true, true);
            Core.WriteBanner(false, true);
            Core.ClearContent();
            Core.LoadingBar("[ Loading a stunning example console app... ]");
            Core.ClearContent();

            var index = Core.ScrollingMenuSelector("What do you want to do?", default, default, "Select a number", "Answer some prompt","Display trivia", "Quit the app");
            switch (index.Item1){
                case 0:
                    switch (index.Item2){
                        case 0:
                            Core.ClearContent();
                            Core.ScrollingNumberSelector("Select a number", 10, 50, 25, 5);
                            Core.ClearContent();
                            break;
                        case 1:
                            Core.ClearContent();
                            Core.WritePrompt("Hey! What is your name?");
                            Core.ClearContent();
                            break;
                        case 2:
                            Core.ClearContent();
                            Core.WriteParagraph(default, default, "C# is a general-purpose, multi-paradigm programming language encompassing strong typing,","lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based),"," and component-oriented programming disciplines.", "", "Press [Enter] to continue...");
                            Console.ReadKey();
                            Core.ClearContent();
                            break;
                        default:
                            break;
                        }
                    break;
                case -1: 
                    Core.ClearContent();
                    Core.WriteParagraph(true, default, "You have selected to quit the app. Press [Enter] to continue...");
                    Console.ReadKey();
                    Core.ClearContent();
                    break;
                case -2: 
                    Core.ClearContent();
                    Core.WriteParagraph(true, default, "You have selected the backspace tile. Press [Enter] to continue...");
                    Console.ReadKey();
                    Core.ClearContent();
                    break;
                default:
                    break;
            }

            Core.ExitProgram();
        }
    }
}