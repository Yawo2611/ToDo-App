namespace ToDo_App;

using Newtonsoft.Json;
using ToDo_App.Models;

public partial class CreateTask : ContentPage
{
    public CreateTask()
    {
        InitializeComponent();
    }

    private async void OnSaveTask(object sender, EventArgs e)
    {
        string title = TaskTitleEntry.Text;
        string description = TaskDescriptionEditor.Text;
        DateTime dueDate = DueDatePicker.Date;

        // Konvertiere die Auswahl des Dropdowns in eine numerische Priorität
        int priority = PriorityPicker.SelectedIndex + 1;

        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description) && priority > 0)
        {
            // Neue Aufgabe hinzufügen
            var newTask = new Task(title, description, dueDate, priority);
            MainPage.tasks.Add(newTask);

            // JSON-Daten aktualisieren
            MainPage.jsonData = JsonConvert.SerializeObject(MainPage.tasks);
            System.IO.File.WriteAllText(MainPage.fullPath, MainPage.jsonData);

            await DisplayAlert("Task Added", "Your task has been saved.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please fill out all fields and select a priority.", "OK");
        }
    }
}
