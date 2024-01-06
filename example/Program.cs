using ConsoleAppVisuals;

namespace example
{
    public static class Program
    {
        private static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Debugging();

            Core.SetTitle("Example");
            Core.WriteTitle();
            Core.WriteHeader(false);
            Core.WriteFooter(false);
            Core.ClearContent();
            Core.LoadingBar("[ Some example loading... ]");
            Core.UpdateScreen();
            Core.ClearContent();

            Menu:

            var index = Core.ScrollingMenuSelector(
                "What will be your next action?",
                0,
                Placement.TopCenter,
                null,
                "Change Console color",
                "Write on the console",
                "Display paragraph",
                "Display a styled text",
                "Display a matrix",
                "Answer some prompt",
                "Select a number",
                "Display table",
                "Quit the app"
            );
            Core.ClearContent();
            switch (index.Item1)
            {
                case Output.Select:
                    switch (index.Item2)
                    {
                        case 0:
                            Core.UpdateScreen();
                            var indexColor = Core.ScrollingMenuSelector(
                                "What color do you want to change?",
                                0,
                                Placement.TopCenter,
                                default,
                                "White",
                                "Red",
                                "Green",
                                "Blue",
                                "Yellow",
                                "Magenta",
                                "Cyan"
                            );
                            switch (indexColor.Item2)
                            {
                                case 0:
                                    Core.ChangeForeground(ConsoleColor.White);
                                    break;
                                case 1:
                                    Core.ChangeForeground(ConsoleColor.Red);
                                    break;
                                case 2:
                                    Core.ChangeForeground(ConsoleColor.Green);
                                    break;
                                case 3:
                                    Core.ChangeForeground(ConsoleColor.Blue);
                                    break;
                                case 4:
                                    Core.ChangeForeground(ConsoleColor.Yellow);
                                    break;
                                case 5:
                                    Core.ChangeForeground(ConsoleColor.Magenta);
                                    break;
                                case 6:
                                    Core.ChangeForeground(ConsoleColor.Cyan);
                                    break;
                                default:
                                    break;
                            }
                            Core.ClearContent();
                            goto Menu;

                        case 1:
                            Core.UpdateScreen();
                            Core.WriteContinuousString(
                                "Have a look on the console to see all the text!",
                                Core.ContentHeight,
                                true,
                                1500,
                                1000,
                                default,
                                default,
                                default,
                                true
                            );
                            Core.WritePositionedString(
                                "Bonjour le monde !",
                                Placement.TopLeft,
                                false,
                                Core.ContentHeight + 1,
                                true
                            );
                            Core.WritePositionedString(
                                "Hola Mundo !",
                                Placement.TopRight,
                                false,
                                Core.ContentHeight + 2,
                                true
                            );
                            Core.WritePositionedString(
                                "Hallo Welt !",
                                Placement.TopCenter,
                                false,
                                Core.ContentHeight + 3,
                                true
                            );
                            Core.WritePositionedString(
                                "Ciao mondo !",
                                Placement.TopLeft,
                                false,
                                Core.ContentHeight + 4,
                                true
                            );

                            Console.ReadKey();
                            Core.ClearContent();
                            goto Menu;

                        case 2:
                            Core.UpdateScreen();

                            Core.WriteMultiplePositionedLines(
                                true,
                                default,
                                default,
                                default,
                                default,
                                "C# is a general-purpose, multi-paradigm programming language encompassing strong typing,",
                                "lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based),",
                                " and component-oriented programming disciplines.",
                                "",
                                "Press [Enter] to continue..."
                            );

                            Console.ReadKey();
                            Core.ClearContent();
                            goto Menu;

                        case 3:
                            Core.UpdateScreen();

                            Core.WritePositionedStyledText(Core.StyleText("Hello World!"));

                            Console.ReadKey();
                            Core.ClearContent();

                            Core.WritePositionedStyledText(Core.StyleText("Welcome Aboard!"));

                            Console.ReadKey();
                            Core.ClearContent();
                            goto Menu;

                        case 4:
                            Core.UpdateScreen();

                            List<int?> firstRow = new() { 1, null, 2, 7, 9, 3 };
                            List<int?> secondRow = new() { 4, 5, 6, 8, null, 2 };
                            List<int?> thirdRow = new() { 7, 8, null, 3, 4, 5 };
                            List<int?> fourthRow = new() { null, 2, 3, 4, 5, 6 };
                            List<List<int?>> data =
                                new() { firstRow, secondRow, thirdRow, fourthRow };
                            Matrix<int?> matrix = new(data);
                            matrix.SetRoundedCorners(false);
                            matrix.WriteMatrix(Placement.TopCenter);

                            Console.ReadKey();
                            Core.ClearContent();

                            matrix.Remove(new Position(0, 0));
                            matrix.Remove(new Position(3, 5));
                            matrix.WriteMatrix(Placement.TopCenter);

                            Console.ReadKey();
                            Core.ClearContent();

                            matrix.UpdateElement(new Position(0, 0), 1);
                            matrix.UpdateElement(new Position(3, 5), 6);
                            matrix.WriteMatrix(Placement.TopCenter);

                            Console.ReadKey();
                            Core.ClearContent();
                            goto Menu;

                        case 5:
                            Core.UpdateScreen();

                            var answerPrompt = Core.WritePrompt("Hey! What is your name?", "Theo");
                            string name = answerPrompt.Item2;
                            Core.WritePositionedString($"You just wrote {name}!");

                            Core.ClearContent();
                            goto Menu;
                        case 6:
                            Core.UpdateScreen();

                            var answerNumber = Core.ScrollingNumberSelector(
                                "Select a number",
                                10,
                                5000,
                                25,
                                5
                            );
                            float number = answerNumber.Item2;
                            Core.WritePositionedString($"You just wrote {number}!");

                            Core.ClearContent();
                            goto Menu;
                        case 7:
                            Core.UpdateScreen();

                            List<string> headers = new() { "id", "name", "major", "grades" };
                            List<string> student1 = new() { "01", "Theo", "Technology", "97" };
                            List<string> student2 = new() { "02", "Paul", "Mathematics", "86" };
                            List<string> student3 = new() { "03", "Maxime", "Physics", "92" };
                            List<string> student4 =
                                new() { "04", "Charles", "Computer Science", "100" };
                            Table<string> students =
                                new(
                                    "Students grades",
                                    headers,
                                    new() { student1, student2, student3, student4 }
                                );
                            students.SetRoundedCorners(false);
                            students.ScrollingTableSelector(true, false, "Add student");

                            students.UpdateLine(0, new() { "01", "Theo", "Biology", "100" });
                            students.RemoveLine(3);
                            students.ScrollingTableSelector(true, true);

                            Core.ClearContent();
                            goto Menu;

                        default:
                            Core.ClearContent();
                            Core.UpdateScreen();

                            Core.ExitProgram();
                            break;
                    }
                    break;

                case Output.Exit:
                    Core.ClearContent();
                    Core.UpdateScreen();

                    Core.WriteMultiplePositionedLines(
                        true,
                        default,
                        default,
                        true,
                        default,
                        "You have selected to quit the app. Press [Enter] to continue..."
                    );

                    Console.ReadKey();
                    Core.ExitProgram();
                    break;

                case Output.Delete:
                    Core.ClearContent();
                    Core.UpdateScreen();

                    Core.WriteMultiplePositionedLines(
                        true,
                        default,
                        default,
                        true,
                        default,
                        "You have selected the backspace tile. Press [Enter] to continue..."
                    );

                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }

        public static void Debugging()
        {
            // Debug code placeholder
            Window.AddElement(new Title("Debugging"), true);
            Window.AddElement(new Header(), true);
            Window.AddElement(new Footer(), true);

            // float progress = 0f;
            // Window.AddElement(
            //     new LoadingBar("[ Loading ...]", ref progress, Placement.TopCenter, default, 2000),
            //     true
            // );
            // Thread thread = new (() =>
            // {
            //     for (progress = 0f; progress <= 100f; progress++)
            //     {
            //         Window.GetElement<LoadingBar>()?.UpdateProgress(progress / 100);
            //         Thread.Sleep(30);
            //     }
            //     Window.GetElement<LoadingBar>()?.UpdateProgress(1f);
            // });
            // thread.Start();
            // Window.Refresh();
            // thread.Join();
            // Window.DeactivateElement<LoadingBar>();

            Window.AddElement(new FakeLoadingBar("[ Loading ...]"), true);
            Window.Refresh();
            Console.WriteLine(Window.GetLineAvailable(Placement.TopCenter));
            //Window.ListWindowElements();
            Window.AddElement(
                new ScrollingMenu(
                    "Choose the best number:",
                    0,
                    Placement.TopCenter,
                    null,
                    "1",
                    "2",
                    "3"
                )
            );
            Window.Refresh();
            Window.ActivateElement<ScrollingMenu>();
            var response = Window.GetResponse<ScrollingMenu, int>();
            Window.AddElement(new EmbeddedText(new List<string>() { "You            chose to " + response?.State.ToString(),  "the number " + (response?.Info + 1)  + "!" }, $"Next {Core.GetSelector.Item1}", TextAlignment.Center));
            Window.ActivateElement<EmbeddedText>();
            Window.GetFullInfo();
            Window.Close();
        }
    }
}
