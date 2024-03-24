using ConsoleAppVisuals;
using ConsoleAppVisuals.Enums;
using ConsoleAppVisuals.InteractiveElements;
using ConsoleAppVisuals.PassiveElements;
using CustomElement;

/*
In this example project, we will see how to use user-created elements in the library.

The examples we will see are PassiveDemo and InteractiveDemo.

All the guidelines are all explained in the docs at:
https://morgankryze.github.io/ConsoleAppVisuals/articles/create_element.html
*/


Title title = new(text: "Custom Element");
Window.AddElement(title);

Header header = new(string.Empty, "CustomElement example project", string.Empty);
Footer footer =
    new(
        "Press [ENTER] to select the element to display.",
        string.Empty,
        "Press [ESCAPE] or [DELETE] to exit."
    );
Window.AddElement(header, footer);

ScrollingMenu menu =
    new(
        question: "Please choose your next action:",
        defaultIndex: 0,
        placement: Placement.TopCenter,
        choices: ["Display PassiveDemo", "Display InteractiveDemo", "Exit"]
    );
Window.AddElement(menu);

Window.Open();
Window.Render();

while (true)
{
    Window.ActivateElement(menu);

    var response = menu.GetResponse();
    switch (response?.Status)
    {
        case Status.Selected:
            switch (response.Value)
            {
                case 0:
                    PassiveDemo passiveDemo =
                        new(
                            leftText: "Hello",
                            centerText: "World",
                            rightText: "!",
                            upperMargin: 1,
                            lowerMargin: 1,
                            placement: Placement.TopCenterFullWidth
                        );
                    Window.AddElement(passiveDemo);
                    Window.Render(passiveDemo);
                    Window.Freeze();

                    Window.DeactivateElement(passiveDemo);
                    Window.RemoveElement(passiveDemo);
                    break;
                case 1:
                    InteractiveDemo interactiveDemo =
                        new(
                            question: "What is your name?",
                            defaultValue: "John Doe",
                            placement: Placement.TopCenter,
                            maxLength: 20,
                            printDuration: 50
                        );
                    Window.AddElement(interactiveDemo);

                    Window.ActivateElement(interactiveDemo);

                    var responseToPrompt = interactiveDemo.GetResponse();
                    if (responseToPrompt?.Status == Status.Selected)
                    {
                        PassiveDemo passiveDemo2 =
                            new(
                                leftText: "Hello",
                                centerText: responseToPrompt.Value,
                                rightText: "!",
                                upperMargin: 1,
                                lowerMargin: 1,
                                placement: Placement.TopCenterFullWidth
                            );
                        Window.AddElement(passiveDemo2);
                        Window.Render(passiveDemo2);

                        Window.Freeze();

                        Window.DeactivateElement(passiveDemo2);
                        Window.RemoveElement(passiveDemo2);
                    }
                    Window.RemoveElement(interactiveDemo);
                    break;
                case 2:
                    Window.Close();
                    break;
            }
            break;

        case Status.Escaped:
        case Status.Deleted:
            Window.Close();
            return;
    }
}
