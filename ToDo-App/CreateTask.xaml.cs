namespace ToDo_App;
using ToDo_App.Models;
using Newtonsoft.Json;

public partial class CreateTask : ContentPage
{
    public CreateTask()
    {
        InitializeComponent();
    }

    public void OnSaveTask()
    {
        string title = TaskTitleEntry.Text;
        string description = TaskDescriptionEditor.Text;

        if (title != null && description != null)
        {
            MainPage.tasks.Add(new Task(title, description));
            int i = MainPage.tasks.Count;

            TaskTitleEntry.Text = "";
            TaskDescriptionEditor.Text = "";
            MainPage.jsonData = JsonConvert.SerializeObject(MainPage.tasks);
            System.IO.File.WriteAllText(MainPage.fullPath, MainPage.jsonData);
            MainPage.nextRecID++;
            Preferences.Default.Set("nextRecordID", MainPage.nextRecID);
        } else {
            outputLabel.Text = "Überprüfe deine Daten etwas ist falsch";

        }

    }
}
