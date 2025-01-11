namespace ToDo_App;
using ToDo_App.Models;
using Newtonsoft.Json;

public partial class CreateTask : ContentPage
{
    public CreateTask()
    {
        InitializeComponent();
    }

    public void OnSaveTask(object sender, EventArgs e)
    {
        string title = TaskTitleEntry.Text;
        string description = TaskDescriptionEditor.Text;
        DateTime dueDate = TaskDueDatePicker.Date; // Datum vom DatePicker

        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(description))
        {
            // Füge die neue Aufgabe hinzu
            MainPage.tasks.Add(new Task(title, description, dueDate));
            int i = MainPage.tasks.Count;

            // Felder zurücksetzen
            TaskTitleEntry.Text = "";
            TaskDescriptionEditor.Text = "";

            // Aufgaben in JSON speichern
            MainPage.jsonData = JsonConvert.SerializeObject(MainPage.tasks);
            System.IO.File.WriteAllText(MainPage.fullPath, MainPage.jsonData);

            // Nächste ID erhöhen und speichern
            MainPage.nextRecID++;
            Preferences.Default.Set("nextRecordID", MainPage.nextRecID);

            // Erfolgsnachricht anzeigen
            outputLabel.Text = $"Task '{title}' wurde erfolgreich hinzugefügt.";
        }
        else
        {
            // Fehlermeldung anzeigen
            outputLabel.Text = "Überprüfe deine Daten, etwas ist falsch.";
        }
    }

}
