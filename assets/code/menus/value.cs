Window.Open();

string[] options = new string[] { "Play", "Settings", "Quit" };

ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    options
);

Window.AddElement(menu);
Window.ActivateElement(menu);

var response = menu.GetResponse();
switch (response?.Status)
{
    case Status.Selected:
        switch (response.Value)
        {
            case 0:
                EmbedText play = new EmbedText(
                    new List<string>() { "Playing..." }
                );
                Window.AddElement(play);
                Window.ActivateElement(play);

                Window.RemoveElement(play);
                break;
            case 1:
                EmbedText settings = new EmbedText(
                    new List<string>() { "Consulting the settings..." }
                );
                Window.AddElement(settings);
                Window.ActivateElement(settings);

                Window.RemoveElement(settings);
                break;
            case 2:
                // Quit the app
                Window.Close();
                break;
        }
        break;
    case Status.Escaped:
    case Status.Deleted:
        // Quit the app anyway
        Window.Close();
        break;
}
Window.Close();