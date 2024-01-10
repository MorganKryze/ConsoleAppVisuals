using ConsoleAppVisuals;

namespace example
{
    public static class Program
    {
        private static void Main()
        {
            Debugging(); // Empty, do not mind, just for debugging purposes

            Window.AddElement(new Title("Example project")); // Define the default elements to display
            Window.AddElement(new Header());
            Window.AddElement(new Footer());
            Window.AddElement(new FakeLoadingBar("[ Loading ...]"));
            Window.Refresh(); // Refresh the window to display the elements above, they have only been added to the window

            Window.AddElement( // Add the scrolling menu to the window
                new ScrollingMenu(
                    "What will be your next action?",
                    0,
                    Placement.TopCenter,
                    null,
                    "Change Console color",
                    "Write on the console",
                    "Display paragraph",
                    "Display styled text",
                    "Display matrix",
                    "Answer some prompt",
                    "Select number",
                    "Display table",
                    "Interact with table",
                    "Display loading bar",
                    "Display elements space",
                    "Custom window element",
                    "Custom interactive element",
                    "Display dashboard",
                    "Quit the app"
                )
            );

            Menu:

            Window.ActivateElement<ScrollingMenu>(); // Only this line will make the menu appear on the console
            var response = Window.GetResponse<ScrollingMenu, int>(); // Get the response from the user. It is very important to Get the response for an Interactive element, or to Deactivate it (done by default by the GetResponse method)

            switch (response?.State) // Check the response state (escape, enter or backspace) see the Output enum for more details
            {
                case Output.Select:
                    switch (response.Info) // Check the response info (the index of the selected item). Here the Info for a ScrollingMenu is an int
                    {
                        case 0:
                            Window.OnResize(); // Refresh the window if the console has been resized

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
                            Window.ActivateElement(5); // Activate the element at the index 5 (the ScrollingMenu)
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

                        case 1: // These following functions are at the core of the library, they should not be used directly
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

                            Window.AddElement( // When you add an element, the info of the constructor are not displayed by default consider looking to the documentation to know what they are or use your IDE to see them
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
                            Window.ActivateElement<EmbeddedText>(); // Activate the element to display it on the console

                            Window.RemoveElement<EmbeddedText>(); // Removing the elements from the window after their use is not mandatory but it is recommended to keep the list clean
                            Window.OnResize();
                            goto Menu;

                        case 3: // These following functions are at the core of the library, they should not be used directly
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

                            List<int?> firstRow = new() { 1, null, 2, 7, 9, 3 }; // We first create the data to display
                            List<int?> secondRow = new() { 4, 5, 6, 8, null, 2 };
                            List<int?> thirdRow = new() { 7, 8, null, 3, 4, 5 };
                            List<int?> fourthRow = new() { null, 2, 3, 4, 5, 6 };
                            List<List<int?>> data =
                                new() { firstRow, secondRow, thirdRow, fourthRow };
                            Matrix<int?> matrix = new(data);
                            matrix.SetRoundedCorners(false);
                            Window.AddElement(matrix); // Then we add the element to the window, you may update the matrix after adding it, the modification will be taken in account

                            Window.ActivateElement<Matrix<int?>>(); // As this is only a display element and not interactive, we have to stop the execution to see it
                            Window.StopExecution();
                            Window.DeactivateElement<Matrix<int?>>();

                            matrix.RemoveItem(new Position(0, 0)); // You can indeed update the matrix after adding it
                            matrix.RemoveItem(new Position(3, 5));
                            Window.ActivateElement<Matrix<int?>>();
                            Window.StopExecution();
                            Window.DeactivateElement<Matrix<int?>>();

                            matrix.UpdateItem(new Position(0, 0), 1);
                            matrix.UpdateItem(new Position(3, 5), 6);
                            Window.ActivateElement<Matrix<int?>>();
                            Window.StopExecution();
                            Window.DeactivateElement<Matrix<int?>>();

                            Window.RemoveElement<Matrix<int?>>();
                            Window.Refresh();
                            Window.OnResize();
                            goto Menu;

                        case 5:
                            Window.OnResize();

                            Window.AddElement(new Prompt("What is your name?", "Theo")); // For more information about the Prompt element, see the documentation

                            Window.ActivateElement<Prompt>();
                            var responsePrompt = Window.GetResponse<Prompt, string>(); // We saw Interactive elements before, here we get the response from the user as a string, an error will if you do not associate Prompt with a string
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

                            Window.AddElement(new IntSelector("Select a number", 10, 100, 25, 5)); // A FloatSelector is also available depending on your needs

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

                            List<string> studentsHeaders =
                                new() { "id", "name", "major", "grades" }; // We first create the data to display, pay attention to the order of the data and their length (the length of the headers and the data must be the same)
                            List<string> student1 = new() { "01", "Theo", "Technology", "97" };
                            List<string> student2 = new() { "02", "Paul", "Mathematics", "86" };
                            List<string> student3 = new() { "03", "Maxime", "Physics", "92" };
                            List<string> student4 =
                                new() { "04", "Charles", "Computer Science", "100" };
                            TableView<string> students =
                                new(
                                    "Students grades",
                                    studentsHeaders,
                                    new() { student1, student2, student3, student4 }
                                );
                            students.SetRoundedCorners(false);
                            Window.AddElement(students);

                            Window.ActivateElement<TableView<string>>(); // As this is only a display element and not interactive, we have to stop the execution to see it
                            Window.StopExecution();
                            Window.DeactivateElement<TableView<string>>();

                            students.UpdateLine(0, new() { "01", "Theo", "Biology", "100" }); // Similarly to the matrix, you can update the table after adding it
                            students.RemoveLine(3);
                            Window.ActivateElement<TableView<string>>();
                            Window.StopExecution();
                            Window.DeactivateElement<TableView<string>>();

                            Window.OnResize();
                            Window.RemoveElement<TableView<string>>();
                            goto Menu;

                        case 8:
                            Window.OnResize();

                            List<string> playersHeaders =
                                new() { "id", "first name", "last name", "nationality", "slams" };
                            List<string> player1 =
                                new() { "01", "Novak", "Djokovic", "Serbia", "24" };
                            List<string> player2 =
                                new() { "02", "Carlos", "Alkaraz", "Spain", "2" };
                            List<string> player3 =
                                new() { "03", "Roger", "Federer", "Switzerland", "21" };
                            List<string> player4 = new() { "04", "Rafael", "Nadal", "Spain", "23" };
                            List<string> player5 = new() { "05", "Andy", "Murray", "England", "3" };
                            List<string> player6 =
                                new() { "06", "Daniil", "Medvedev", "Russia", "1" };
                            List<string> player7 =
                                new() { "07", "Stan", "Wawrinka", "Switzerland", "2" };
                            List<List<string>> playersData =
                                new()
                                {
                                    player1,
                                    player2,
                                    player3,
                                    player4,
                                    player5,
                                    player6,
                                    player7
                                };
                            TableSelector<string> players =
                                new("Great tennis players", playersHeaders, playersData);
                            players.SetRoundedCorners(false);
                            Window.AddElement(players);

                            Window.ActivateElement<TableSelector<string>>(); // Contrary to the matrix and the table, the TableSelector is interactive, so we do not have to stop the execution to see it
                            var responseTable = Window.GetResponse<TableSelector<string>, int>(); // Here a little subtlety, the type is TableSelector<string> and is associated with an int response, string refers to the type of the data displayed in the table
                            Window.AddElement(
                                new EmbeddedText(
                                    new List<string>()
                                    {
                                        "You chose to " + responseTable?.State.ToString(),
                                        "the player "
                                            + playersData[responseTable?.Info ?? 0][2]
                                            + "!"
                                    },
                                    $"Next {Core.GetSelector.Item1}",
                                    TextAlignment.Center
                                )
                            );
                            Window.ActivateElement<EmbeddedText>();

                            Window.OnResize();
                            Window.RemoveElement<TableSelector<string>>();
                            Window.RemoveElement<EmbeddedText>();
                            goto Menu;

                        case 9:
                            Window.OnResize();

                            float progress = 0f; // Contrary to the FakeLoadingBar, the LoadingBar is corresponds to a real loading defined by a variable, here progress
                            Window.AddElement(
                                new LoadingBar(
                                    "[ Loading ...]",
                                    ref progress, // The variable must be passed by reference so the updates on the variable are taken in account
                                    Placement.TopCenter,
                                    default,
                                    2000
                                )
                            );
                            Thread thread = // We create a thread to simulate a process that will update the progress variable while we display the loading bar in the main thread
                                new(() =>
                                {
                                    for (progress = 0f; progress <= 100f; progress++)
                                    {
                                        Window
                                            .GetElement<LoadingBar>()
                                            ?.UpdateProgress(progress / 100);
                                        Thread.Sleep(30);
                                    }
                                    Window.GetElement<LoadingBar>()?.UpdateProgress(1f); // Here is an example of how to access method from an object in the window
                                });

                            thread.Start();
                            Window.ActivateElement<LoadingBar>(); // Start the loading bar
                            thread.Join(); // Wait for the thread to finish

                            Window.RemoveElement<LoadingBar>();
                            goto Menu;

                        case 10: // These following functions are for debugging purposes, they should not be used in a production state of a software
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
                            Window.ActivateElement<EmbeddedText>(false);

                            Window.RenderAllElementsSpace(); // This method will display all the spaces taken by the element in teh window
                            Window.StopExecution();

                            Window.Refresh(); // Refresh the window to display the elements above

                            Window.OnResize();
                            Window.RemoveElement<EmbeddedText>();
                            goto Menu;

                        case 11:
                            Window.OnResize();

                            Window.AddElement(
                                new DisplayDemo( // Custom element, see the DisplayDemo class for more information
                                    new List<string>()
                                    {
                                        "This element has been created in this project",
                                        "Its interest is for demonstration only",
                                        "The model in on the DisplayDemo.cs file"
                                    },
                                    TextAlignment.Center
                                )
                            );
                            Window.ActivateElement<DisplayDemo>();

                            Window.RemoveElement<DisplayDemo>();
                            Window.OnResize();
                            goto Menu;

                        case 12:
                            Window.OnResize();

                            Window.AddElement(
                                new InteractDemo(
                                    "This element is also custom for demo purposes, you may type something:"
                                )
                            );
                            Window.ActivateElement<InteractDemo>();

                            Window.DeactivateElement<InteractDemo>();

                            Window.RemoveElement<InteractDemo>();
                            Window.OnResize();
                            goto Menu;

                        case 13: // These following functions are for debugging purposes, they should not be used in a production state of a software
                            Window.AddDashboard(); // Add the three TableView elements to the window

                            Window.Refresh(); // This will display the elements
                            Window.StopExecution();

                            Window.Clear();
                            Window.RemoveDashboard(); // This will remove the three items

                            Window.AddListWindowElements(); // Add one of the three items
                            Window.Refresh();
                            Window.StopExecution();
                            Window.DeactivateElement<TableView<string>>(); // This will deactivate the table

                            Window.Refresh();
                            Window.OnResize();
                            Window.RemoveLibraryElement<TableView<string>>(); // This will manually remove the item from the window
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
                    Window.Close(); // Close the window and exits the app
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
