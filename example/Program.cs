using ConsoleAppVisuals;

namespace example
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Test();

            Core.SetTitle("Example");
            Core.WriteTitle();
            Core.WriteBanner(true, true);
            Core.WriteBanner(false, true);
            Core.ClearContent();
            Core.LoadingBar("[ Stunning example loading... ]");
            Core.UpdateScreen();
            Core.ClearContent();

            Menu:

            var index = Core.ScrollingMenuSelector("What do you want to do?", default, default, "Select a number", "Answer some prompt","Display trivia", "Display table", "Change color", "Quit the app");
            switch (index.Item1){
                case Output.Select:
                    switch (index.Item2){
                        case 0:
                            Core.ClearContent();
                            Core.UpdateScreen();
                            Core.ScrollingNumberSelector("Select a number", 10, 50, 25, 5);
                            Core.ClearContent();
                            break;
                        case 1:
                            Core.ClearContent();
                            Core.UpdateScreen();
                            Core.WritePrompt("Hey! What is your name?");
                            Core.ClearContent();
                            break;
                        case 2:
                            Core.ClearContent();
                            Core.UpdateScreen();
                            Core.WriteParagraph(default, default, "C# is a general-purpose, multi-paradigm programming language encompassing strong typing,","lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based),"," and component-oriented programming disciplines.", "", "Press [Enter] to continue...");
                            Console.ReadKey();
                            Core.ClearContent();
                            break;
                        case 3:
                            Core.ClearContent();
                            Core.UpdateScreen();
                            List<string> headers = new () {"id", "name", "major", "grades"};
                            List<string> student1 = new () {"01", "Theo", "Technology", "97"};
                            List<string> student2 = new () {"02", "Paul", "Mathematics", "86"};
                            List<string> student3 = new () {"03", "Maxime", "Physics", "92"};
                            List<string> student4 = new () {"04", "Charles", "Computer Science", "100"};
                            Table<string> students = new (headers, new () {student1, student2, student3, student4});
                            students.ScrollingTableSelector(true, false, "Add student");
                            Core.ClearContent();
                            break;
                        case 4:
                            Core.ClearContent();
                            Core.UpdateScreen();
                            var indexColor = Core.ScrollingMenuSelector("What color do you want to change?", default, default, "White", "Gray", "Red", "Green", "Blue", "Yellow", "Magenta", "Cyan");
                            switch(indexColor.Item2){
                                case 0:
                                    Core.ChangeForeground(ConsoleColor.White);
                                    break;
                                case 1:
                                    Core.ChangeForeground(ConsoleColor.Gray);
                                    break;
                                case 2:
                                    Core.ChangeForeground(ConsoleColor.Red);
                                    break;
                                case 3:
                                    Core.ChangeForeground(ConsoleColor.Green);
                                    break;
                                case 4:
                                    Core.ChangeForeground(ConsoleColor.Blue);
                                    break;
                                case 5:
                                    Core.ChangeForeground(ConsoleColor.Yellow);
                                    break;
                                case 6:
                                    Core.ChangeForeground(ConsoleColor.Magenta);
                                    break;
                                case 7:
                                    Core.ChangeForeground(ConsoleColor.Cyan);
                                    break;
                                default:
                                    break;
                            }
                            Core.UpdateScreen();
                            break;
                        default:
                            break;
                        }
                    break;
                case Output.Exit: 
                    Core.ClearContent();
                    Core.UpdateScreen();
                    Core.WriteParagraph(true, default, "You have selected to quit the app. Press [Enter] to continue...");
                    Console.ReadKey();
                    Core.ExitProgram();
                    break;
                case Output.Delete: 
                    Core.ClearContent();
                    Core.UpdateScreen();
                    Core.WriteParagraph(true, default, "You have selected the backspace tile. Press [Enter] to continue...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            goto Menu;
        }
        public static void Test()
        {   
            // Test code placeholder
        }
    }
}