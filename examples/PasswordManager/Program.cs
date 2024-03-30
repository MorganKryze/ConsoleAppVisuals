using ConsoleAppVisuals;
using ConsoleAppVisuals.Enums;
using ConsoleAppVisuals.InteractiveElements;
using ConsoleAppVisuals.PassiveElements;

namespace PasswordManager;

class Program
{
    private const string MASTER_PASSWORD = "password";
    private static readonly List<string> s_headers = ["url", "username", "password", "notes"];
    private static readonly List<List<string>> s_rows = [];

    static void Main()
    {
        /*
        In this example project, we will create a small password manager.
        (Nothing secure, just for demonstration purposes)
        
        The main elements we will use are:
        - Prompt
        - TableView
        - ScrollingMenu
        */

        Setup();

        InitializeRows();

        Authenticate();

        Home();
    }

    static void Setup()
    {
        Window.Open();

        Title title = new Title(text: "Password Manager", font: Font.Stop);
        Window.AddElement(title);

        Header header = new(string.Empty, string.Empty, string.Empty);
        Footer footer = new("[ESC] Back", "[Z|↑] Up   [S|↓] Down", "[ENTER] Select");
        Window.AddElement(header, footer);

        Window.Render();
    }

    static void InitializeRows()
    {
        List<string> firstRow =
        [
            "https://www.amazon.com",
            "john.doe@example.com",
            "password123",
            "entertainment"
        ];
        List<string> secondRow =
        [
            "https://www.slack.com",
            "john.doe@example.com",
            "secure-password",
            "work"
        ];
        List<string> thirdRow =
        [
            "https://www.facebook.com",
            "john.doe@example.com",
            "cyp3rs3cur1ty",
            "social"
        ];

        s_rows.Add(firstRow);
        s_rows.Add(secondRow);
        s_rows.Add(thirdRow);
    }

    static void Authenticate()
    {
        Prompt authentication =
            new(
                question: "Enter your master password to unlock your vault:",
                defaultValue: null,
                placement: Placement.TopCenter,
                maxInputLength: 15,
                style: PromptInputStyle.Secret
            );
        Window.AddElement(authentication);

        bool authorized = false;
        while (!authorized)
        {
            Window.ActivateElement(authentication);
            var response = authentication.GetResponse();

            if (response?.Status == Status.Selected)
            {
                if (response.Value == MASTER_PASSWORD)
                {
                    authorized = true;
                    Window.RemoveElement(authentication);
                }
                else
                {
                    Dialog error = new(["Incorrect password. Please try again."]);
                    Window.AddElement(error);

                    Window.ActivateElement(error);

                    Window.RemoveElement(error);
                }
            }
            else
            {
                Window.Close();
                break;
            }
        }
    }

    static void Home()
    {
        ScrollingMenu homeMenu =
            new(
                question: "What will you do next? ",
                defaultIndex: 0,
                placement: Placement.TopLeft,
                choices: ["Add new password", "Edit password", "Quit"]
            );
        Window.AddElement(homeMenu);

        TableView passwordTable =
            new(
                title: "John Doe passwords",
                headers: s_headers,
                lines: s_rows,
                placement: Placement.TopCenter
            );
        Window.AddElement(passwordTable);

        while (true)
        {
            Window.ActivateElement(passwordTable);

            Window.ActivateElement(homeMenu);
            var responseHomeMenu = homeMenu.GetResponse();

            switch (responseHomeMenu?.Status)
            {
                case Status.Selected:
                    switch (responseHomeMenu.Value)
                    {
                        case 0:
                            Window.DeactivateElement(passwordTable);
                            AddPassword();
                            break;
                        case 1:
                            Window.DeactivateElement(passwordTable);
                            EditPassword();
                            break;
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
        }
    }

    static bool AddPassword(List<string>? row = null)
    {
        List<string> newRow = row ?? [];
        Prompt urlPrompt =
            new(
                question: "Enter the URL: ",
                defaultValue: newRow.Count > 0 ? newRow[0] : null,
                placement: Placement.TopCenter,
                maxInputLength: 30
            );
        Window.AddElement(urlPrompt);

        Prompt usernamePrompt =
            new(
                question: "Enter the username: ",
                defaultValue: newRow.Count > 1 ? newRow[1] : null,
                placement: Placement.TopCenter,
                maxInputLength: 25
            );
        Window.AddElement(usernamePrompt);

        Prompt passwordPrompt =
            new(
                question: "Enter the password: ",
                defaultValue: newRow.Count > 2 ? newRow[2] : null,
                placement: Placement.TopCenter,
                maxInputLength: 40,
                style: PromptInputStyle.Secret
            );
        Window.AddElement(passwordPrompt);

        Prompt notesPrompt =
            new(
                question: "Enter any notes: ",
                defaultValue: newRow.Count > 3 ? newRow[3] : null,
                placement: Placement.TopCenter,
                maxInputLength: 20
            );
        Window.AddElement(notesPrompt);

        while (true)
        {
            Window.ActivateElement(urlPrompt);
            Window.ActivateElement(usernamePrompt);
            Window.ActivateElement(passwordPrompt);
            Window.ActivateElement(notesPrompt);

            var responseUrl = urlPrompt.GetResponse();
            var responseUsername = usernamePrompt.GetResponse();
            var responsePassword = passwordPrompt.GetResponse();
            var responseNotes = notesPrompt.GetResponse();

            if (
                responseUrl?.Status == Status.Selected
                && responseUsername?.Status == Status.Selected
                && responsePassword?.Status == Status.Selected
                && responseNotes?.Status == Status.Selected
            )
            {
                newRow =
                [
                    responseUrl.Value,
                    responseUsername.Value,
                    responsePassword.Value,
                    responseNotes.Value
                ];
                s_rows.Add(newRow);

                Window.RemoveElement(urlPrompt);
                Window.RemoveElement(usernamePrompt);
                Window.RemoveElement(passwordPrompt);
                Window.RemoveElement(notesPrompt);

                return true;
            }
            else if (
                responseUrl?.Status == Status.Escaped
                || responseUsername?.Status == Status.Escaped
                || responsePassword?.Status == Status.Escaped
                || responseNotes?.Status == Status.Escaped
            )
            {
                Dialog error = new(["Password not saved."]);
                Window.AddElement(error);
                Window.ActivateElement(error);

                Window.RemoveElement(error);
                Window.RemoveElement(urlPrompt);
                Window.RemoveElement(usernamePrompt);
                Window.RemoveElement(passwordPrompt);
                Window.RemoveElement(notesPrompt);

                return false;
            }
        }
    }

    static void EditPassword()
    {
        TableSelector passwordSelector =
            new(
                title: "Select a password to edit: ",
                headers: s_headers,
                lines: s_rows,
                placement: Placement.TopCenter
            );
        Window.AddElement(passwordSelector);
        Window.ActivateElement(passwordSelector);

        var responseSelector = passwordSelector.GetResponse();
        switch (responseSelector!.Status)
        {
            case Status.Selected:
                var toUpdate = s_rows[responseSelector.Value];
                bool status = AddPassword(toUpdate);
                if (status)
                {
                    s_rows.RemoveAt(responseSelector.Value);
                }
                break;
            case Status.Deleted:
                Dialog confirmation = new(["You chose to delete an item."], "Abort", "Confirm");
                Window.AddElement(confirmation);
                Window.ActivateElement(confirmation);

                var responseConfirmation = confirmation.GetResponse();
                if (responseConfirmation!.Status == Status.Selected)
                {
                    s_rows.RemoveAt(responseSelector.Value);
                }

                break;
            case Status.Escaped:
                Window.RemoveElement(passwordSelector);
                break;
        }
        { }
    }
}
