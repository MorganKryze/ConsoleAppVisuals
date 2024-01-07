using ConsoleAppVisuals;

namespace example
{
    public static class Program
    {
        private static void Main()
        {
            Debugging();

            Window.AddElement(new Title("Debugging"));
            Window.AddElement(new Header());
            Window.AddElement(new Footer());
            Window.AddElement(new FakeLoadingBar("[ Loading ...]"));
            Window.Refresh();

            Window.AddElement(
                new ScrollingMenu(
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
                    "Display a loading bar",
                    "Display elements space",
                    "Display a dashboard",
                    "Quit the app"
                )
            );

            Menu:

            Window.ActivateElement<ScrollingMenu>();
            var response = Window.GetResponse<ScrollingMenu, int>();

            switch (response?.State)
            {
                case Output.Select:
                    switch (response.Info)
                    {
                        case 0:
                            Window.OnResize();

                            Window.AddElement(
                                new ScrollingMenu(
                                    "What color do you want to change?",
                                    0,
                                    Placement.TopCenter,
                                    null,
                                    "White",
                                    "Red",
                                    "Green",
                                    "Blue",
                                    "Yellow",
                                    "Magenta",
                                    "Cyan"
                                )
                            );
                            Window.ActivateElement(5);
                            var responseColor = Window.GetResponse<ScrollingMenu, int>();
                            switch (responseColor?.Info)
                            {
                                case 0:
                                    Core.SetForegroundColor(ConsoleColor.White);
                                    break;
                                case 1:
                                    Core.SetForegroundColor(ConsoleColor.Red);
                                    break;
                                case 2:
                                    Core.SetForegroundColor(ConsoleColor.Green);
                                    break;
                                case 3:
                                    Core.SetForegroundColor(ConsoleColor.Blue);
                                    break;
                                case 4:
                                    Core.SetForegroundColor(ConsoleColor.Yellow);
                                    break;
                                case 5:
                                    Core.SetForegroundColor(ConsoleColor.Magenta);
                                    break;
                                case 6:
                                    Core.SetForegroundColor(ConsoleColor.Cyan);
                                    break;
                                default:
                                    break;
                            }

                            Window.RemoveElement(5);
                            Window.OnResize();
                            goto Menu;

                        case 1:
                            Window.OnResize();

                            Core.WriteContinuousString(
                                "Have a look on the console to see all the text!",
                                Window.GetLineAvailable(Placement.TopCenter),
                                true,
                                1500,
                                100,
                                default,
                                default,
                                true
                            );
                            Core.WritePositionedString(
                                "Bonjour le monde !",
                                TextAlignment.Left,
                                false,
                                Window.GetLineAvailable(Placement.TopLeft) + 1,
                                true
                            );
                            Core.WritePositionedString(
                                "Hola Mundo !",
                                TextAlignment.Right,
                                false,
                                Window.GetLineAvailable(Placement.TopRight) + 2,
                                true
                            );
                            Core.WritePositionedString(
                                "Hallo Welt !",
                                TextAlignment.Center,
                                false,
                                Window.GetLineAvailable(Placement.TopCenter) + 3,
                                true
                            );
                            Core.WritePositionedString(
                                "Ciao mondo !",
                                TextAlignment.Left,
                                false,
                                Window.GetLineAvailable(Placement.TopLeft) + 4,
                                true
                            );
                            Window.StopExecution();

                            Window.Refresh();
                            Window.OnResize();
                            goto Menu;

                        case 2:
                            Window.OnResize();

                            Window.AddElement(
                                new EmbeddedText(
                                    new List<string>()
                                    {
                                        "C# is a general-purpose, multi-paradigm programming language encompassing strong typing,",
                                        "lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based),",
                                        "and component-oriented programming disciplines.",
                                        ""
                                    },
                                    "Press [Enter] to continue..."
                                )
                            );
                            Window.ActivateElement<EmbeddedText>();
                            Window.RemoveElement<EmbeddedText>();
                            goto Menu;

                        case 3:
                            Window.OnResize();

                            Core.WritePositionedStyledText(
                                Core.StyleText("Hello World!"),
                                Window.GetLineAvailable(Placement.TopCenter)
                            );
                            Window.StopExecution();

                            Window.Refresh();

                            Core.WritePositionedStyledText(
                                Core.StyleText("Welcome Aboard!"),
                                Window.GetLineAvailable(Placement.TopCenter)
                            );
                            Window.StopExecution();

                            Window.Refresh();
                            Window.OnResize();
                            goto Menu;

                        case 4:
                            Window.OnResize();

                            List<int?> firstRow = new() { 1, null, 2, 7, 9, 3 };
                            List<int?> secondRow = new() { 4, 5, 6, 8, null, 2 };
                            List<int?> thirdRow = new() { 7, 8, null, 3, 4, 5 };
                            List<int?> fourthRow = new() { null, 2, 3, 4, 5, 6 };
                            List<List<int?>> data =
                                new() { firstRow, secondRow, thirdRow, fourthRow };
                            Matrix<int?> matrix = new(data);
                            matrix.SetRoundedCorners(false);
                            Window.AddElement(matrix);

                            Window.ActivateElement<Matrix<int?>>();
                            Window.StopExecution();
                            Window.DeactivateElement<Matrix<int?>>();

                            matrix.Remove(new Position(0, 0));
                            matrix.Remove(new Position(3, 5));
                            Window.ActivateElement<Matrix<int?>>();
                            Window.StopExecution();
                            Window.DeactivateElement<Matrix<int?>>();

                            Console.ReadKey();
                            Window.Refresh();

                            matrix.UpdateElement(new Position(0, 0), 1);
                            matrix.UpdateElement(new Position(3, 5), 6);
                            Window.ActivateElement<Matrix<int?>>();
                            Window.StopExecution();
                            Window.DeactivateElement<Matrix<int?>>();

                            Window.RemoveElement<Matrix<int?>>();
                            Window.Refresh();
                            Window.OnResize();
                            goto Menu;

                        case 5:
                            Window.OnResize();

                            Window.AddElement(new Prompt("What is your name?", "Theo"));

                            Window.ActivateElement<Prompt>();
                            var responsePrompt = Window.GetResponse<Prompt, string>();
                            Window.AddElement(
                                new EmbeddedText(
                                    new List<string>()
                                    {
                                        "You just wrote " + responsePrompt?.Info + "!"
                                    },
                                    $"Next {Core.GetSelector.Item1}",
                                    TextAlignment.Center
                                )
                            );
                            Window.ActivateElement<EmbeddedText>();

                            Window.RemoveElement<Prompt>();
                            Window.RemoveElement<EmbeddedText>();
                            goto Menu;
                        case 6:
                            Window.OnResize();

                            Window.AddElement(new IntSelector("Select a number", 10, 100, 25, 5));

                            Window.ActivateElement<IntSelector>();
                            var responseNumber = Window.GetResponse<IntSelector, int>();
                            Window.AddElement(
                                new EmbeddedText(
                                    new List<string>()
                                    {
                                        "You chose to " + responseNumber?.State.ToString(),
                                        "the number " + (responseNumber?.Info) + "!"
                                    },
                                    $"Next {Core.GetSelector.Item1}",
                                    TextAlignment.Center
                                )
                            );
                            Window.ActivateElement<EmbeddedText>();

                            Window.OnResize();
                            Window.RemoveElement<IntSelector>();
                            Window.RemoveElement<EmbeddedText>();
                            goto Menu;

                        case 7:
                            Window.OnResize();

                            List<string> headers = new() { "id", "name", "major", "grades" };
                            List<string> student1 = new() { "01", "Theo", "Technology", "97" };
                            List<string> student2 = new() { "02", "Paul", "Mathematics", "86" };
                            List<string> student3 = new() { "03", "Maxime", "Physics", "92" };
                            List<string> student4 =
                                new() { "04", "Charles", "Computer Science", "100" };
                            TableView<string> students =
                                new(
                                    "Students grades",
                                    headers,
                                    new() { student1, student2, student3, student4 }
                                );
                            students.SetRoundedCorners(false);
                            Window.AddElement(students);

                            Window.ActivateElement<TableView<string>>();
                            Window.StopExecution();
                            Window.DeactivateElement<TableView<string>>();

                            students.UpdateLine(0, new() { "01", "Theo", "Biology", "100" });
                            students.RemoveLine(3);
                            Window.ActivateElement<TableView<string>>();
                            Window.StopExecution();
                            Window.DeactivateElement<TableView<string>>();

                            Window.OnResize();
                            Window.RemoveElement<TableView<string>>();
                            goto Menu;

                        case 8:
                            Window.OnResize();

                            float progress = 0f;
                            Window.AddElement(
                                new LoadingBar(
                                    "[ Loading ...]",
                                    ref progress,
                                    Placement.TopCenter,
                                    default,
                                    2000
                                )
                            );
                            Thread thread =
                                new(() =>
                                {
                                    for (progress = 0f; progress <= 100f; progress++)
                                    {
                                        Window
                                            .GetElement<LoadingBar>()
                                            ?.UpdateProgress(progress / 100);
                                        Thread.Sleep(30);
                                    }
                                    Window.GetElement<LoadingBar>()?.UpdateProgress(1f);
                                });

                            thread.Start();
                            Window.ActivateElement<LoadingBar>();
                            thread.Join();

                            Window.RemoveElement<LoadingBar>();
                            goto Menu;

                        case 9:
                            Window.OnResize();

                            Window.GetElement<Title>()?.RenderElementSpace();
                            Window.GetElement<Header>()?.RenderElementSpace();
                            Window.GetElement<Footer>()?.RenderElementSpace();
                            Window.AddElement(
                                new EmbeddedText(
                                    new List<string>()
                                    {
                                        "You have selected to quit the app. Press [Enter] to continue..."
                                    },
                                    $"Next {Core.GetSelector.Item1}",
                                    TextAlignment.Left
                                )
                            );
                            Window.ActivateElement<EmbeddedText>(false);
                            Window.RenderAllElementsSpace();
                            Window.StopExecution();
                            Window.Refresh();

                            Window.OnResize();
                            Window.RemoveElement<EmbeddedText>();
                            goto Menu;

                        case 10:
                            Window.AddDashboard();

                            Window.Refresh();
                            Window.StopExecution();

                            Window.Clear();
                            Window.RemoveDashboard();

                            Window.AddListWindowElements();
                            Window.Refresh();
                            Window.StopExecution();
                            Window.GetElement<TableView<string>>()?.Clear();

                            Window.OnResize();
                            Window.RemoveLibraryElement<TableView<string>>();
                            goto Menu;

                        default:
                            Window.Close();
                            break;
                    }
                    break;

                case Output.Exit:
                    Window.OnResize();

                    Window.AddElement(
                        new EmbeddedText(
                            new List<string>()
                            {
                                "You have selected to quit the app. Press [Enter] to continue..."
                            },
                            $"Next {Core.GetSelector.Item1}",
                            TextAlignment.Left
                        )
                    );
                    Window.ActivateElement<EmbeddedText>();

                    Window.RemoveElement<EmbeddedText>();
                    Window.Close();
                    break;

                case Output.Delete:
                    Window.OnResize();

                    Window.AddElement(
                        new EmbeddedText(
                            new List<string>()
                            {
                                "You have selected the backspace tile. Press [Enter] to continue..."
                            },
                            $"Next {Core.GetSelector.Item1}",
                            TextAlignment.Left
                        )
                    );
                    Window.ActivateElement<EmbeddedText>();

                    Window.RemoveElement<EmbeddedText>();
                    goto Menu;

                default:
                    break;
            }
        }

        public static void Debugging()
        {
            // Debug code placeholder
        }
    }
}
