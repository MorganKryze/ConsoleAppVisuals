Window.Open();

// Creating the visuals and adding them to the window

string[] menuOptions = new string[] { "Play", "Settings", "Quit" };
ScrollingMenu menu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    menuOptions
);
Window.AddElement(menu);

string[] settingsOptions = new string[] { "Language", "Sound", "Back" };
ScrollingMenu settingsMenu = new ScrollingMenu(
    "Please choose an option among those below.",
    0,
    Placement.TopCenter,
    settingsOptions
);
Window.AddElement(settingsMenu);

EmbedText play = new EmbedText(
    new List<string>() { "Playing..." }
);
Window.AddElement(play);

EmbedText language = new EmbedText(
    new List<string>() { "Changing language..." }
);
Window.AddElement(language);

EmbedText sound = new EmbedText(
    new List<string>() { "Changing volume..." }
);
Window.AddElement(sound);


// This is a label, it will be used to navigate in the code using the goto statements
MainMenu:

Window.ActivateElement(menu);

var response = menu.GetResponse();
switch (response?.Status)
{
    case Status.Selected:
        switch (response.Value)
        {
            case 0:
                goto Play;
            case 1:
                goto SettingsMenu;
            case 2:
                Window.Close();
                break;
        }
        break;
    case Status.Escaped:
    case Status.Deleted:
        Window.Close();
        break;
}

Play:

Window.ActivateElement(play);
goto MainMenu;

SettingsMenu:

Window.ActivateElement(settingsMenu);

var settingsResponse = settingsMenu.GetResponse();

switch (settingsResponse?.Status)
{
    case Status.Selected:
        switch (settingsResponse.Value)
        {
            case 0:
                Window.ActivateElement(language);
                break;
            case 1:
                Window.ActivateElement(sound);
                break;
            case 2:
                goto MainMenu;
        }
        break;
    case Status.Escaped:
    case Status.Deleted:
        goto MainMenu;
}
goto SettingsMenu;
