using ConsoleAppVisuals;
using ConsoleAppVisuals.Enums;
using ConsoleAppVisuals.InteractiveElements;
using ConsoleAppVisuals.PassiveElements;

/*
In this example project, we will use built-in and a custom font:
- Built-in fonts: ANSI Shadow, Bloody
- Custom font: Stop (also built-in)

To use a custom font, you need to add the font folder to the project (here :"./Stop/").
Pay attention, the files should follow very specific rules to be read by the library.
These are all explained in the docs at:
https://morgankryze.github.io/ConsoleAppVisuals/articles/create_font.html
*/

Title title =
    new(text: "Custom Font", margin: 1, align: TextAlignment.Center, font: Font.ANSI_Shadow);
Window.AddElement(title);

Header header = new(string.Empty, "CustomFont example project", string.Empty);
Footer footer =
    new(
        string.Empty,
        "Press [ENTER] to select the font and [ESCAPE] or [DELETE] to exit.",
        string.Empty
    );
Window.AddElement(header, footer);

ScrollingMenu menu =
    new(
        question: "Please select the next font of the title:",
        defaultIndex: 0,
        placement: Placement.TopCenter,
        choices: ["Default: ANSI Shadow", "Built-in: Bloody", "Custom: Stop", "Quit"]
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
                    title.UpdateFont(font: Font.ANSI_Shadow);
                    break;
                case 1:
                    title.UpdateFont(font: Font.Bloody);
                    break;
                case 2:
                    title.UpdateFont(font: Font.Custom, fontPath: "./Stop/");
                    break;
                case 3:
                    Window.Close();
                    return;
            }
            Window.Render();

            Dialog embedText = new(["Font changed to: " + title.Font.ToString()], null, "OK");
            Window.AddElement(embedText);

            Window.ActivateElement(embedText);

            Window.RemoveElement(embedText);
            break;

        case Status.Escaped:
        case Status.Deleted:
            Window.Close();
            return;
    }
}
