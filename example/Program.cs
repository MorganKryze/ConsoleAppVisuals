using ConsoleAppVisuals;
using ConsoleAppVisuals.PassiveElements;
using ConsoleAppVisuals.InteractiveElements;
using ConsoleAppVisuals.Enums;
using ConsoleAppVisuals.Models;

namespace example
{
    public static class Program
    {
        private static void Main()
        {
            // Empty, do not mind, just for debugging purposes
            Debugging();

            Window.Open();

            // Create the title element
            var title = new Title("Example project");
            // Add the title to the window
            Window.AddElement(title);

            var header = new Header();
            Window.AddElement(header);
            var footer = new Footer();
            Window.AddElement(footer);

            // Render the window to display the elements above
            Window.Render();

            var fakeLoadingBar = new FakeLoadingBar("[ Loading ...]");
            Window.AddElement(fakeLoadingBar);

            // Only this line will make the loading bar appear on the console
            Window.ActivateElement(fakeLoadingBar);

            // Create the main menu element
            var mainMenu = new ScrollingMenu(
                "What will be your next action?",
                0,
                Placement.TopCenter,
                "Change Console color",
                "Write on the console",
                "Display paragraph",
                "Answer some prompt",
                "Select number",
                "Change title style",
                "Display matrix",
                "Display table",
                "Interact with table",
                "Display loading bar",
                "Custom window element",
                "Custom interactive element",
                "Display elements space",
                "Display dashboard",
                "Quit the app"
            );
            // Add the main menu to the window
            Window.AddElement(mainMenu);

            // This is a label, it is used to go back to the main menu after the selection
            Menu:

            // Only this line will make the menu appear on the console
            Window.ActivateElement(mainMenu);
            // Get the response from the user
            var response = mainMenu.GetResponse();

            // Check the response state (escape, enter or backspace)
            // see the Output enum for more details
            switch (response?.Status)
            {
                case Output.Selected:
                    // Check the response info (the index of the selected item).
                    // Here the Info for a ScrollingMenu is an int
                    switch (response.Value)
                    {
                        case 0:
                            var colorMenu = new ScrollingMenu(
                                "What color do you want to change?",
                                0,
                                Placement.TopCenter,
                                "White",
                                "Red",
                                "Green",
                                "Blue",
                                "Yellow",
                                "Magenta",
                                "Cyan"
                            );
                            Window.AddElement(colorMenu);

                            // Activate the element at the index 5 (the ScrollingMenu)
                            Window.ActivateElement(5);
                            var responseColor = colorMenu.GetResponse();

                            switch (responseColor?.Value)
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
                            // This will refresh the window to apply the new color
                            Window.Render();

                            Window.RemoveElement(5);
                            goto Menu;

                        case 1:
                            int startLine = Window.GetLineAvailable(Placement.TopCenter);
                            // These following functions are at the core of the library,
                            // they should not be used directly but can be useful
                            Core.WriteContinuousString(
                                "Have a look on the console to see all the text!",
                                startLine,
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
                                startLine + 1,
                                true
                            );
                            Core.WritePositionedString(
                                "Hola Mundo !",
                                TextAlignment.Right,
                                false,
                                startLine + 2,
                                true
                            );
                            Core.WritePositionedString(
                                "Hallo Welt !",
                                TextAlignment.Center,
                                false,
                                startLine + 3,
                                true
                            );
                            Core.WritePositionedString(
                                "Ciao mondo !",
                                TextAlignment.Left,
                                false,
                                startLine + 4,
                                true
                            );
                            Window.Freeze();

                            Window.Clear(default, startLine, 5);
                            goto Menu;

                        case 2:
                            var text = new EmbedText(
                                new List<string>()
                                {
                                    "C# is a general-purpose, multi-paradigm programming language encompassing strong typing,",
                                    "lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based),",
                                    "and component-oriented programming disciplines.",
                                    ""
                                },
                                "Press [Enter] to continue..."
                            );
                            Window.AddElement(text);

                            // Activate the element to display it on the console
                            Window.ActivateElement(text);

                            // Removing the elements from the window after their use is not mandatory
                            // but it is recommended to keep the list clean
                            Window.RemoveElement(text);
                            goto Menu;

                        case 3:
                            var prompt = new Prompt("What is your name?", "Theo");
                            Window.AddElement(prompt);

                            Window.ActivateElement(prompt);

                            var responsePrompt = prompt.GetResponse();

                            // We create an EmbedText to display the response
                            var embedResponsePrompt = new EmbedText(
                                new List<string>()
                                {
                                    "You just wrote " + responsePrompt?.Value + "!"
                                },
                                $"Next ▶",
                                TextAlignment.Center
                            );
                            Window.AddElement(embedResponsePrompt);
                            Window.ActivateElement(embedResponsePrompt);

                            Window.RemoveElement(prompt);
                            Window.RemoveElement(embedResponsePrompt);
                            goto Menu;

                        case 4:
                            // A FloatSelector is also available depending on your needs
                            var intSelector = new IntSelector("Select a number", 10, 100, 25, 5);
                            Window.AddElement(intSelector);

                            Window.ActivateElement(intSelector);
                            var responseNumber = intSelector.GetResponse();

                            var embedResponseNumber = new EmbedText(
                                new List<string>()
                                {
                                    "Status: " + responseNumber?.Status.ToString(),
                                    "Selected the number " + (responseNumber?.Value) + "!"
                                }
                            );
                            Window.AddElement(embedResponseNumber);
                            Window.ActivateElement(embedResponseNumber);

                            Window.RemoveElement(intSelector);
                            Window.RemoveElement(embedResponseNumber);
                            goto Menu;

                        case 5:
                            ScrollingMenu fontMenu =
                                new(
                                    "What font do you want to use?",
                                    0,
                                    Placement.TopCenter,
                                    "Lil_Devil",
                                    "ANSI_Shadow",
                                    "Big",
                                    "Merlin",
                                    "Bloody",
                                    "Custom: Stop"
                                );
                            Window.AddElement(fontMenu);

                            Window.ActivateElement(fontMenu);
                            var responseFont = fontMenu.GetResponse();

                            switch (responseFont?.Value)
                            {
                                case 0:
                                    title.UpdateFont(Font.Lil_Devil);
                                    break;
                                case 1:
                                    title.UpdateFont(Font.ANSI_Shadow);
                                    break;
                                case 2:
                                    title.UpdateFont(Font.Big);
                                    break;
                                case 3:
                                    title.UpdateFont(Font.Merlin);
                                    break;
                                case 4:
                                    title.UpdateFont(Font.Bloody);
                                    break;
                                case 5:
                                    title.UpdateFont(Font.Custom, "Stop/");
                                    break;
                            }
                            Window.Render();

                            Window.RemoveElement(fontMenu);
                            goto Menu;

                        case 6:
                            // We first create the data to display
                            List<int?> firstRow = new() { 1, null, 2, 7, 9, 3 };
                            List<int?> secondRow = new() { 4, 5, 6, 8, null, 2 };
                            List<int?> thirdRow = new() { 7, 8, null, 3, 4, 5 };
                            List<int?> fourthRow = new() { null, 2, 3, 4, 5, 6 };
                            List<List<int?>> data =
                                new() { firstRow, secondRow, thirdRow, fourthRow };

                            var matrix = new Matrix<int?>(data);

                            // Then we add the element to the window,
                            // You may update the matrix after adding it,
                            // the modification will be taken in account
                            Window.AddElement(matrix);
                            Window.Render(matrix);

                            // As this is only a display element and not interactive,
                            // we have to stop the execution to see it
                            Window.Freeze();

                            // You can update the matrix after adding it
                            matrix.RemoveItem(new Position(0, 0));
                            matrix.RemoveItem(new Position(3, 5));
                            Window.Render(matrix);

                            Window.Freeze();

                            // Restore the data
                            matrix.UpdateItem(new Position(0, 0), 1);
                            matrix.UpdateItem(new Position(3, 5), 6);
                            Window.Render(matrix);

                            Window.Freeze();

                            Window.DeactivateElement(matrix);
                            Window.RemoveElement(matrix);
                            goto Menu;

                        case 7:
                            // We first create the data to display,
                            // pay attention to the order of the data and their length
                            // (the length of the headers and the data must be the same)
                            List<string> studentsHeaders =
                                new() { "id", "name", "major", "grades" };
                            List<string> student1 = new() { "01", "Theo", "Technology", "97" };
                            List<string> student2 = new() { "02", "Paul", "Mathematics", "86" };
                            List<string> student3 = new() { "03", "Maxime", "Physics", "92" };
                            List<string> student4 =
                                new() { "04", "Charles", "Computer Science", "89" };
                            TableView<string> students =
                                new(
                                    "Students grades",
                                    studentsHeaders,
                                    new() { student1, student2, student3, student4 }
                                );
                            Window.AddElement(students);

                            Window.ActivateElement(students);
                            // As this is only a display element and not interactive,
                            // we have to stop the execution to see it
                            Window.Freeze();
                            Window.DeactivateElement(students);

                            // Similarly to the matrix, you can update the table after adding it
                            students.UpdateLine(0, new() { "01", "Theo", "Biology", "100" });
                            students.RemoveLine(3);

                            Window.ActivateElement(students);
                            Window.Freeze();
                            Window.DeactivateElement(students);

                            Window.RemoveElement(students);
                            goto Menu;

                        case 8:
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
                            Window.AddElement(players);

                            Window.ActivateElement(players);
                            var responseTable = players.GetResponse();
                            var embedResponseTable = new EmbedText(
                                new List<string>()
                                {
                                    "Status: " + responseTable?.Status.ToString(),
                                    "Selected the player "
                                        + playersData[responseTable?.Value ?? 0][2]
                                        + "!"
                                }
                            );
                            Window.AddElement(embedResponseTable);
                            Window.ActivateElement(embedResponseTable);

                            Window.RemoveElement(players);
                            Window.RemoveElement(embedResponseTable);
                            goto Menu;

                        case 9:
                            // Contrary to the FakeLoadingBar, the LoadingBar
                            // corresponds to a real loading defined by a variable (here progress)
                            float progress = 0f;
                            var loadingBar = new LoadingBar(
                                "[ Loading ...]",
                                // The variable must be passed by reference
                                // so the updates on the variable are taken in account
                                ref progress,
                                Placement.TopCenter,
                                2000
                            );
                            Window.AddElement(loadingBar);

                            // We create a thread to simulate a process
                            // that will update the progress variable while
                            // we display the loading bar in the main thread
                            Thread thread =
                                new(() =>
                                {
                                    for (progress = 0f; progress <= 100f; progress++)
                                    {
                                        loadingBar.UpdateProgress(progress / 100);
                                        Thread.Sleep(30);
                                    }
                                    loadingBar.UpdateProgress(1f);
                                });

                            // Start the process
                            thread.Start();
                            // Start the loading bar
                            Window.ActivateElement(loadingBar);
                            // Wait for the thread to finish
                            thread.Join();

                            Window.RemoveElement(loadingBar);
                            goto Menu;

                        case 10:
                            // Custom element, see the StaticDemo class
                            // in this project for more information
                            var customStaticElement = new StaticDemo(
                                "This element has been created in this project",
                                "Its interest is for demonstration only",
                                "The model in on the StaticDemo.cs file",
                                3,
                                2,
                                Placement.TopCenterFullWidth
                            );
                            Window.AddElement(customStaticElement);
                            Window.Render(customStaticElement);
                            Window.Freeze();

                            Window.RemoveElement(customStaticElement);
                            goto Menu;

                        case 11:
                            var customInteractiveElement = new InteractDemo(
                                "This element is also custom for demo purposes, you may type something:"
                            );
                            Window.AddElement(customInteractiveElement);

                            Window.ActivateElement(customInteractiveElement);

                            Window.RemoveElement(customInteractiveElement);
                            goto Menu;

                        case 12:
                            // These following elements are for debugging purposes,
                            // they should not be used in a production state of a project
                            var embedInfo = new EmbedText(
                                new List<string>()
                                {
                                    "The colors represented the space taken by the elements. Press [Enter] to continue..."
                                }
                            );
                            Window.AddElement(embedInfo);
                            Window.ActivateElement(embedInfo);

                            // This method will display all the spaces taken by the element in the window
                            Window.RenderElementsSpace();
                            Window.Freeze();

                            // Render the window to display the elements above
                            Window.Render();

                            Window.RemoveElement(embedInfo);
                            goto Menu;

                        case 13:
                            // These following functions are for debugging purposes,
                            // they should not be used in a production state of a software

                            // See all the elements in the window
                            var dashboard = new ElementsDashboard();
                            Window.AddElement(dashboard);

                            Window.Render(dashboard);
                            Window.Freeze();

                            Window.DeactivateElement(dashboard);
                            Window.RemoveElement<ElementsDashboard>();

                            // See all the element types available
                            var elementList = new ElementList();
                            Window.AddElement(elementList);

                            Window.Render(elementList);
                            Window.Freeze();

                            Window.DeactivateElement(elementList);
                            Window.RemoveElement<ElementList>();

                            // See all the interactive element types available
                            var interactiveList = new InteractiveList();
                            Window.AddElement(interactiveList);

                            Window.Render(interactiveList);
                            Window.Freeze();

                            Window.DeactivateElement(interactiveList);
                            Window.RemoveElement<InteractiveList>();
                            goto Menu;

                        default:
                            Window.Close();
                            break;
                    }
                    break;

                case Output.Escaped:
                    var exitText = new EmbedText(
                        new List<string>()
                        {
                            "You have selected to quit the app. Press [Enter] to continue..."
                        },
                        $"Next ▶",
                        TextAlignment.Left
                    );
                    Window.AddElement(exitText);
                    Window.ActivateElement(exitText);

                    Window.RemoveElement(exitText);

                    // Close the window and exits the app
                    Window.Close();
                    break;

                case Output.Deleted:
                    var backspaceText = new EmbedText(
                        new List<string>()
                        {
                            "You have selected the backspace tile.",
                            "You will be redirected to the main menu.",
                            "Press [Enter] to continue..."
                        }
                    );
                    Window.AddElement(backspaceText);
                    Window.ActivateElement(backspaceText);

                    Window.RemoveElement(backspaceText);
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
